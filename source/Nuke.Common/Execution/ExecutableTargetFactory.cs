// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using NuGet.Packaging;

namespace Nuke.Common.Execution
{
    public interface IExecutableTargetFactory
    {
        IReadOnlyCollection<ExecutableTarget> CreateAll<T>(T build, Expression<Func<T, Target>> defaultTargetExpression)
            where T : NukeBuild;
    }

    public class ExecutableTargetFactory : IExecutableTargetFactory
    {
        public IReadOnlyCollection<ExecutableTarget> CreateAll<T>(
            T build,
            Expression<Func<T, Target>> defaultTargetExpression)
            where T : NukeBuild
        {
            var defaultTarget = defaultTargetExpression.Compile().Invoke(build);
            var properties = build.GetType()
                .GetProperties(ReflectionService.Instance)
                .Where(x => x.PropertyType == typeof(Target)).ToList();

            var executables = new List<ExecutableTarget>();

            foreach (var property in properties)
            {
                var factory = (Target) property.GetValue(build);
                var definition = new TargetDefinition();
                factory.Invoke(definition);
                var executable = new ExecutableTarget(
                    property,
                    referenceObject: factory,
                    definitionObject: definition,
                    isDefault: factory == defaultTarget,
                    definition.Description,
                    definition.Conditions,
                    definition.Requirements,
                    definition.Actions);
                executables.Add(executable);
            }

            foreach (var executable in executables)
            {
                IEnumerable<ExecutableTarget> GetDependencies(
                    Func<TargetDefinition, IReadOnlyList<object>> directDependenciesSelector,
                    Func<TargetDefinition, IReadOnlyList<object>> indirectDependenciesSelector)
                {
                    foreach (var factoryDependency in directDependenciesSelector((TargetDefinition) executable.DefinitionObject))
                        yield return executables.Single(x => x.ReferenceObject.Equals(factoryDependency));

                    foreach (var otherExecutables in executables.Where(x => x != executable))
                    {
                        var otherDependencies = indirectDependenciesSelector((TargetDefinition) otherExecutables.DefinitionObject);
                        if (otherDependencies.Any(x => x.Equals(executable.ReferenceObject)))
                            yield return otherExecutables;
                    }
                }
                
                executable.ExecutionDependencies.AddRange(GetDependencies(x => x.DependsOnTargets, x => x.DependentForTargets));
                executable.OrderDependencies.AddRange(GetDependencies(x => x.AfterTargets, x => x.BeforeTargets));
                executable.TriggerDependencies.AddRange(GetDependencies(x => x.TriggeredByTargets, x => x.TriggersTargets));
                executable.Triggers.AddRange(GetDependencies(x => x.TriggersTargets, x => x.TriggeredByTargets));
            }

            return executables;
        }
    }
}
