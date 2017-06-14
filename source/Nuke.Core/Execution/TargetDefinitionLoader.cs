// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            foreach (var targetDefinition in targetDefinitions)
                targetDefinition.Dependencies.AddRange(GetDependencies(targetDefinition, nameDictionary, factoryDictionary));

            ControlFlow.Assert(!nameDictionary.ContainsKey("default"), "Don't use 'default' as a target identifier.");
            nameDictionary.Add("default", nameDictionary.Values.Single(x => x.Factory == defaultTarget));
            var specifiedTargets = specifiedTargetStrings.Select(x => GetTargetByName(x, defaultTarget, nameDictionary)).ToList();

            return GetTargetList(specifiedTargets, targetDefinitions, executeDependencies, strictExecution);
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
            ICollection<TargetDefinition> targetDefinitionGraph,
            bool executeDependencies,
            // ReSharper disable once UnusedParameter.Local
            bool strictExecution)
        {
            var scc = new StronglyConnectedComponentFinder();
            var cycles = scc.DetectCycle(targetDefinitionGraph).Cycles().ToList();
            if (cycles.Count > 0)
                throw new LoaderException(
                    "Circular dependencies between target definitions.",
                    string.Join(EnvironmentInfo.NewLine, $"  - {cycles.Select(x => string.Join(" -> ", x.Select(y => y.Name)))}"));

            var targetList = new TargetList();

            List<TargetDefinition> GetIndependents (IEnumerable<TargetDefinition> additionalGraphTargets = null)
            {
                additionalGraphTargets = additionalGraphTargets ?? Enumerable.Empty<TargetDefinition>();
                var tempGraph = targetDefinitionGraph.Concat(additionalGraphTargets).ToList();
                var independents = tempGraph.Where(x => !tempGraph.Any(y => y.Dependencies.Contains(x))).ToList();

                if (strictExecution && independents.Count > 1)
                    throw new LoaderException(
                        "Incomplete target definition order.",
                        string.Join(EnvironmentInfo.NewLine, independents.Select(x => $"  - {x.Name}")));

                return independents;
            }

            bool ShouldExecute (TargetDefinition target)
            {
                if (specifiedTargets.Contains(target))
                    return true;

                if (!executeDependencies)
                    return false;

                return targetList.SelectMany(x => x).SelectMany(x => x).SelectMany(x => x.Dependencies).Contains(target);
            }

            while (targetDefinitionGraph.Any())
            {
                var targetSequence = new TargetSequence();

                while (true)
                {
                    var independents = GetIndependents(targetSequence.SelectMany(x => x)).Except(targetSequence.SelectMany(x => x)).ToList();
                    if (independents.Count == 0)
                        break;

                    independents.ForEach(x => targetDefinitionGraph.Remove(x));
                    targetSequence.AddRange(independents.Where(ShouldExecute).Select(x => new TargetChunk { x }));
                }

                if (targetSequence.Count == 0)
                    continue;

                targetList.Add(targetSequence);

                if (targetSequence.Count <= 1)
                    continue;

                foreach (var targetChunk in targetSequence)
                {
                    while (true)
                    {
                        var parallelTargets = targetSequence.Except(new[] { targetChunk }).SelectMany(x => x).ToList();
                        var additionalChunkTargets = GetIndependents(parallelTargets).Except(parallelTargets).Where(ShouldExecute).ToList();
                        if (additionalChunkTargets.Count == 0)
                            break;

                        foreach (var additionalChunkTarget in additionalChunkTargets)
                        {
                            targetDefinitionGraph.Remove(additionalChunkTarget);
                            targetChunk.Add(additionalChunkTarget);
                        }
                    }
                }
            }

            targetList.Reverse();
            return targetList;
        }
    }

    public class TargetList : List<TargetSequence>
    {
    }

    public class TargetSequence : List<TargetChunk>
    {
    }

    public class TargetChunk : List<TargetDefinition>
    {
    }
}
