// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.CI.TeamCity;

namespace Nuke.Common.Tools.MSBuild
{
    public static partial class MSBuildSettingsExtensions
    {
        /// <summary><em>Sets <see cref="MSBuildSettings.TargetPath" />.</em></summary>
        public static MSBuildSettings SetSolutionFile(this MSBuildSettings toolSettings, string solutionFile)
        {
            return toolSettings.SetTargetPath(solutionFile);
        }

        /// <summary><em>Sets <see cref="MSBuildSettings.TargetPath" />.</em></summary>
        public static MSBuildSettings SetProjectFile(this MSBuildSettings toolSettings, string projectFile)
        {
            return toolSettings.SetTargetPath(projectFile);
        }

        public static MSBuildSettings AddTeamCityLogger(this MSBuildSettings toolSettings)
        {
            var teamCity = TeamCity.Instance.NotNull("TeamCity.Instance != null");
            var teamCityLogger = teamCity.ConfigurationProperties["TEAMCITY_DOTNET_MSBUILD_EXTENSIONS4_0"];
            return toolSettings
                .AddLoggers($"JetBrains.BuildServer.MSBuildLoggers.MSBuildLogger,{teamCityLogger}")
                .EnableNoConsoleLogger();
        }

        public static MSBuildSettings AddFileLogger(this MSBuildSettings toolSettings, params Func<MSBuildFileLoggerParameters, MSBuildFileLoggerParameters>[] configurators)
        {
            var instance = new MSBuildFileLoggerParameters();
            return toolSettings.AddFileLogger(configurators.Select(configurator => configurator(instance)));
        }

        public static MSBuildSettings SetFileLogger(this MSBuildSettings toolSettings, params Func<MSBuildFileLoggerParameters, MSBuildFileLoggerParameters>[] configurators)
        {
            var instance = new MSBuildFileLoggerParameters();
            return toolSettings.SetFileLogger(configurators.Select(configurator => configurator(instance)));
        }

        public static MSBuildSettings SetConsoleLogger(this MSBuildSettings toolSettings, Func<MSBuildConsoleLoggerParameters, MSBuildConsoleLoggerParameters> configurator)
        {
            var instance = new MSBuildConsoleLoggerParameters();
            return toolSettings.SetConsoleLogger(configurator(instance));
        }
    }
}
