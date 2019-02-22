// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using NuGet.Packaging;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Execution
{
    /// <summary>
    /// Given the invoked target names, creates an execution plan under consideration of execution, ordering and trigger dependencies.
    /// </summary>
    internal static class ExecutionPlanner
    {
        public static ExecutionPlan GetComposedExecutionPlan(
            IReadOnlyCollection<ExecutableTarget> executableTargets,
            [CanBeNull] IReadOnlyCollection<string> invokedTargetNames)
        {
            var sequentialPlan = GetSequentialExecutionPlan(executableTargets, invokedTargetNames);

            ExecutionPlan Compose(IReadOnlyCollection<ExecutableTarget> plannedTargets)
            {
                
            }


            return Compose(sequentialPlan);
        }

        public static IReadOnlyCollection<ExecutableTarget> GetSequentialExecutionPlan(
            IReadOnlyCollection<ExecutableTarget> executableTargets,
            [CanBeNull] IReadOnlyCollection<string> invokedTargetNames)
        {
            CheckCycles(executableTargets);

            var invokedTargets = invokedTargetNames?.Select(x => GetExecutableTarget(x, executableTargets)).ToArray() ??
                                 GetDefaultTarget(executableTargets);
            invokedTargets.ForEach(x => x.Invoked = true);

            // Repeat to create the plan with triggers taken into account until plan doesn't change
            IReadOnlyCollection<ExecutableTarget> executionPlan;
            IReadOnlyCollection<ExecutableTarget> additionallyTriggered;
            do
            {
                executionPlan = GetExecutionPlanInternal(executableTargets.ToList(), invokedTargets);
                additionallyTriggered = executionPlan.SelectMany(x => x.Triggers).Except(executionPlan).ToList();
                invokedTargets = executionPlan.Concat(additionallyTriggered).ToArray();
            } while (additionallyTriggered.Count > 0);

            return executionPlan;
        }

        private static void CheckCycles(IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            var vertexDictionary = executableTargets.ToDictionary(x => x, x => new Vertex<ExecutableTarget>(x));
            foreach (var (executable, vertex) in vertexDictionary)
                vertex.Dependencies.AddRange(executable.AllDependencies.Select(x => vertexDictionary[x]));
            
            var scc = new StronglyConnectedComponentFinder<ExecutableTarget>();
            var cycles = scc.DetectCycle(vertexDictionary.Values).Cycles().ToList();
            if (cycles.Count > 0)
            {
                ControlFlow.Fail(
                    new[] { "Circular dependencies between targets:" }
                        .Concat(cycles.Select(x => $" - {x.Select(y => y.Value.Name).JoinComma()}"))
                        .JoinNewLine());
            }
        }

        private static IReadOnlyCollection<ExecutableTarget> GetExecutionPlanInternal(
            ICollection<ExecutableTarget> availableTargets,
            IReadOnlyCollection<ExecutableTarget> invokedTargets)
        {
            var executingTargets = new List<ExecutableTarget>();
            
            while (availableTargets.Any())
            {
                var independentTarget = availableTargets.GetIndependents().First();
                availableTargets.Remove(independentTarget);

                if (!invokedTargets.Contains(independentTarget) &&
                    !executingTargets.SelectMany(x => x.ExecutionDependencies).Contains(independentTarget))
                    continue;

                executingTargets.Add(independentTarget);
            }

            executingTargets.Reverse();

            return executingTargets;
        }

        private static IReadOnlyCollection<ExecutableTarget> GetIndependents(this ICollection<ExecutableTarget> availableTargets)
        {
            var independents = availableTargets.Where(x => !availableTargets.Any(y => y.AllDependencies.Contains(x))).ToList();
            
            if (EnvironmentInfo.ArgumentSwitch("strict") && independents.Count > 1)
            {
                ControlFlow.Fail(
                    new[] { "Incomplete target definition order." }
                        .Concat(independents.Select(x => $"  - {x.Name}"))
                        .JoinNewLine());
            }

            return independents;
        }

        private static ExecutableTarget GetExecutableTarget(
            string targetName,
            IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            var executableTarget = executableTargets.SingleOrDefault(x => x.Name.EqualsOrdinalIgnoreCase(targetName));
            if (executableTarget == null)
                ControlFlow.Fail($"Target with name '{targetName}' is not available.");

            return executableTarget;
        }

        private static ExecutableTarget[] GetDefaultTarget(IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            var target = executableTargets.SingleOrDefault(x => x.IsDefault);
            if (target == null)
                Fail("No target has been marked to be the default.", executableTargets);
            
            return new[] { target };
        }

        private static void Fail(string message, IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            ControlFlow.Fail(new StringBuilder()
                .AppendLine(message)
                .AppendLine()
                .AppendLine(HelpTextService.GetTargetsText(executableTargets)).ToString());
        }
    }
    
    // public class TargetDefinitionLoader
    // {
    //     private TargetList GetTargetList (
    //         IReadOnlyCollection<TargetDefinition> specifiedTargets,
    //         ICollection<TargetDefinition> targetDefinitionGraph,
    //         bool executeDependencies,
    //         // ReSharper disable once UnusedParameter.Local
    //         bool strictExecution)
    //     {

    //
    //         List<TargetDefinition> GetIndependents (IEnumerable<TargetDefinition> additionalGraphTargets = null)
    //         {
    //             additionalGraphTargets = additionalGraphTargets ?? Enumerable.Empty<TargetDefinition>();
    //             var tempGraph = targetDefinitionGraph.Concat(additionalGraphTargets).ToList();
    //             var independents = tempGraph.Where(x => !tempGraph.Any(y => y.Dependencies.Contains(x))).ToList();
    //
    //             if (strictExecution && independents.Count > 1)
    //                 throw new LoaderException(
    //                     "Incomplete target definition order.",
    //                     string.Join(EnvironmentInfo.NewLine, independents.Select(x => $"  - {x.Name}")));
    //
    //             return independents;
    //         }
    //
    //         bool ShouldExecute (TargetDefinition target)
    //         {
    //             if (specifiedTargets.Contains(target))
    //                 return true;
    //
    //             if (!executeDependencies)
    //                 return false;
    //
    //             return targetList.SelectMany(x => x).SelectMany(x => x).SelectMany(x => x.Dependencies).Contains(target);
    //         }
    //
    //         while (targetDefinitionGraph.Any())
    //         {
    //             var targetSequence = new TargetSequence();
    //
    //             while (true)
    //             {
    //                 var independents = GetIndependents(targetSequence.SelectMany(x => x)).Except(targetSequence.SelectMany(x => x)).ToList();
    //                 if (independents.Count == 0)
    //                     break;
    //
    //                 independents.ForEach(x => targetDefinitionGraph.Remove(x));
    //                 targetSequence.AddRange(independents.Where(ShouldExecute).Select(x => new TargetChunk { x }));
    //             }
    //
    //             if (targetSequence.Count == 0)
    //                 continue;
    //
    //             targetList.Add(targetSequence);
    //
    //             if (targetSequence.Count <= 1)
    //                 continue;
    //
    //             foreach (var targetChunk in targetSequence)
    //             {
    //                 while (true)
    //                 {
    //                     var parallelTargets = targetSequence.Except(new[] { targetChunk }).SelectMany(x => x).ToList();
    //                     var additionalChunkTargets = GetIndependents(parallelTargets).Except(parallelTargets).Where(ShouldExecute).ToList();
    //                     if (additionalChunkTargets.Count == 0)
    //                         break;
    //
    //                     foreach (var additionalChunkTarget in additionalChunkTargets)
    //                     {
    //                         targetDefinitionGraph.Remove(additionalChunkTarget);
    //                         targetChunk.Add(additionalChunkTarget);
    //                     }
    //                 }
    //             }
    //         }
    //
    //         targetList.Reverse();
    //         return targetList;
    //     }
    // }

    public interface IExecutionItem
    {
    }

    public class ExecutionPlan  : IExecutionItem
    {
        public ExecutionMode Mode { get; set; }

        public Stack<IExecutionItem> Items { get; } = new Stack<IExecutionItem>();
    }

    public enum ExecutionMode
    {
        Sequential,
        Parallel
    }

    public static class ExecutionPlanExtensions
    {
        public static IEnumerable<ExecutableTarget> GetAllTargets(this ExecutionPlan executionPlan)
        {
            foreach (var item in executionPlan.Items)
            {
                switch (item)
                {
                    case ExecutionPlan plan:
                        foreach (var subItems in plan.GetAllTargets())
                            yield return subItems;
                        break;
                    case ExecutableTarget target:
                        yield return target;
                        break;
                }
            }
        }
    }
}
