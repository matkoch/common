// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Nuke.Core.Utilities.Collections;

namespace Nuke.Core.Execution
{
    public class TargetDefinitionLoader
    {
        public TargetList GetTargetList (
            Build build,
            Target defaultTarget,
            IEnumerable<string> specifiedTargetStrings,
            bool executeDependencies,
            bool strictExecution = false)
        {
            var targetDefinitions = build.GetType()
                    .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                    .Where(x => x.PropertyType == typeof(Target))
                    .Select(x => LoadTargetDefinition(build, x))
                    .ToList();
            var nameDictionary = targetDefinitions.ToDictionary(x => x.Name, x => x, StringComparer.OrdinalIgnoreCase);
            var factoryDictionary = targetDefinitions.ToDictionary(x => x.Factory, x => x);

            ControlFlow.Assert(!nameDictionary.ContainsKey("default"), "Don't use 'default' as a target identifier.");
            nameDictionary.Add("default", nameDictionary.Values.Single(x => x.Factory == defaultTarget));
            var specifiedTargets = specifiedTargetStrings.Select(x => GetTargetByName(x, defaultTarget, nameDictionary)).ToList();

            var targetDependencies = targetDefinitions.ToDictionary(
                x => x,
                x => GetDependencies(x, nameDictionary, factoryDictionary).ToList());
            return GetTargetList(specifiedTargets, targetDependencies, executeDependencies, strictExecution);
        }

        private TargetDefinition LoadTargetDefinition (Build build, PropertyInfo property)
        {
            var targetFactory = (Target) property.GetValue(build);
            return TargetDefinition.Create(property.Name, targetFactory);
        }

        private static TargetDefinition GetTargetByName (string targetName, Target defaultTarget, Dictionary<string, TargetDefinition> nameDictionary)
        {
            if (nameDictionary.TryGetValue(targetName, out var targetDefinition))
                return targetDefinition;

            var stringBuilder = new StringBuilder()
                    .AppendLine($"Target with name '{targetName}' does not exist.")
                    .AppendLine("Available targets are:");
            nameDictionary
                    .Where(x => !x.Key.Equals("default", StringComparison.OrdinalIgnoreCase))
                    .OrderBy(x => x.Key, StringComparer.OrdinalIgnoreCase)
                    .ForEach(x => stringBuilder.AppendLine($"  - {x.Key}{(x.Value.Factory == defaultTarget ? " (default)" : string.Empty)}"));

            throw new LoaderException(stringBuilder.ToString());
        }

        private IEnumerable<TargetDefinition> GetDependencies (
            TargetDefinition targetDefinition,
            Dictionary<string, TargetDefinition> nameDictionary,
            Dictionary<Target, TargetDefinition> factoryDictionary)
        {
            return targetDefinition.DependentShadowTargets
                    .Select(shadowTargetName => nameDictionary.TryGetValue(shadowTargetName, out var shadowTarget)
                        ? shadowTarget
                        : TargetDefinition.Create(shadowTargetName))
                    .Concat(targetDefinition.DependentTargets.Select(x => factoryDictionary[x]));
        }

        private TargetList GetTargetList (
            IReadOnlyCollection<TargetDefinition> specifiedTargets,
            IReadOnlyDictionary<TargetDefinition, List<TargetDefinition>> targetDependencies,
            bool executeDependencies,
            bool strictExecution)
        {
            var vertexDictionary = targetDependencies.ToDictionary(x => x.Key, x => new Vertex<TargetDefinition>(x.Key));
            foreach (var pair in vertexDictionary)
                pair.Value.Dependencies = targetDependencies[pair.Key].Select(x => vertexDictionary[x]).ToList();
            var targetDefinitionGraph = vertexDictionary.Values.ToList();

            var scc = new StronglyConnectedComponentFinder<TargetDefinition> ();
            var cycles = scc.DetectCycle (targetDefinitionGraph).Cycles ().ToList ();
            if (cycles.Count > 0)
                throw new LoaderException (
                    "Circular dependencies between target definitions.",
                    string.Join (EnvironmentInfo.NewLine, $"  - {cycles.Select (x => string.Join (" -> ", x.Select (y => y.Value.Name)))}"));

            var targetList = new TargetList ();

            IEnumerable<Vertex<TargetDefinition>> GetIndependents (IEnumerable<Vertex<TargetDefinition>> additionalGraphTargets = null)
            {
                additionalGraphTargets = additionalGraphTargets ?? Enumerable.Empty<Vertex<TargetDefinition>>();
                var tempGraph = targetDefinitionGraph.Concat(additionalGraphTargets).ToList();
                var independents = tempGraph.Where (x => !tempGraph.Any (y => y.Dependencies.Contains (x))).ToList ();

                if (strictExecution && independents.Count > 1)
                    throw new LoaderException (
                        "Incomplete target definition order.",
                        string.Join (EnvironmentInfo.NewLine, independents.Select (x => $"  - {x.Value.Name}")));

                return independents;
            }

            bool ShouldExecute(Vertex<TargetDefinition> target)
            {
                if (specifiedTargets.Contains(target.Value))
                    return true;

                if (!executeDependencies)
                    return false;

                return targetList.SelectMany(x => x).SelectMany(x => x).Select(x => x.Value)
                        .SelectMany(x => targetDependencies[x])
                        .Contains(target.Value);
            }

            while (targetDefinitionGraph.Any ())
            {
                var targetChunks = GetIndependents()
                        .ForEachLazy (x => targetDefinitionGraph.Remove (x))
                        .Where (ShouldExecute).ToList()
                        .Select(x => new TargetChunk { x }).ToList();

                if (targetChunks.Count == 0)
                    continue;

                var targetSequence = new TargetSequence();
                targetSequence.AddRange(targetChunks);
                targetList.Add(targetSequence);

                if (targetChunks.Count > 1)
                {
                    foreach (var targetChunk in targetChunks)
                    {
                        while (true)
                        {
                            var parallelTargets = targetChunks.Except(new[] { targetChunk }).SelectMany(x => x).ToList();
                            var additionalChunkTargets = GetIndependents(parallelTargets).Except(parallelTargets).Where(ShouldExecute).ToList();
                            if (additionalChunkTargets.Count == 0)
                                break;

                            foreach (var additionalChunkTarget in additionalChunkTargets)
                            {
                                targetDefinitionGraph.Remove (additionalChunkTarget);
                                targetChunk.Add (additionalChunkTarget);
                            }
                        }
                    }
                }
            }

            targetList.Reverse ();
            return targetList;
        }
    }

    public class TargetList : List<TargetSequence>
    {
    }

    public class TargetSequence : List<TargetChunk>
    {
    }

    public class TargetChunk : List<Vertex<TargetDefinition>>
    {
    }
}
