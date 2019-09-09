// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.Common.IO;

namespace Nuke.Common.Execution
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class HandleShellCompletionAttribute : Attribute, IPreLogoBuildExtension
    {
        public void PreLogo(
            NukeBuild build,
            IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            var completionItems = new SortedDictionary<string, string[]>();

            var targets = build.ExecutableTargets.Select(x => $"{x.Name}#{x.Description}").OrderBy(x => x).ToList();
            completionItems[Constants.InvokedTargetsParameterName] = targets.ToArray();
            completionItems[Constants.SkippedTargetsParameterName] = targets.ToArray();

            var parameters = InjectionUtility.GetParameterMembers(build.GetType(), includeUnlisted: false);
            foreach (var parameter in parameters)
            {
                var parameterName = ParameterService.GetParameterMemberName(parameter);
                if (parameterName == Constants.InvokedTargetsParameterName ||
                    parameterName == Constants.SkippedTargetsParameterName)
                    continue;

                var parameterDescription = ParameterService.GetParameterDescription(parameter);
                var subItems = ParameterService.GetParameterValueSet(parameter, build)?.Select(x => x.Text);
                completionItems[$"{parameterName}#{parameterDescription}"] = subItems?.ToArray();
            }

            SerializationTasks.YamlSerializeToFile(completionItems, Constants.GetCompletionFile(NukeBuild.RootDirectory, 2));

            if (EnvironmentInfo.GetParameter<bool>(Constants.CompletionParameterName))
                Environment.Exit(exitCode: 0);
        }
    }
}
