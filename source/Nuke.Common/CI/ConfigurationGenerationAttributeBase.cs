// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Utilities;
using static Nuke.Common.IO.PathConstruction;

namespace Nuke.Common.CI
{
    [PublicAPI]
    [AttributeUsage(AttributeTargets.Class)]
    public abstract class ConfigurationGenerationAttributeBase : Attribute, IOnBeforeLogo, IOnAfterLogo, IOnBuildFinished
    {
        public const string ConfigurationParameterName = "configure-build-server";

        public bool AutoGenerate { get; set; } = true;

        public bool ShutdownDotNetBuildServer { get; set; } = true;

        protected abstract IEnumerable<string> GeneratedFiles { get; }

        protected virtual string PowerShellScript =>
            NukeBuild.RootDirectory.GlobFiles("build.ps1", "*/build.ps1")
                .Select(x => (WinRelativePath) GetRelativePath(NukeBuild.RootDirectory, x))
                .FirstOrDefault().NotNull("PowerShellScript != null");

        protected virtual string BashScript =>
            NukeBuild.RootDirectory.GlobFiles("build.sh", "*/build.sh")
                .Select(x => (UnixRelativePath) GetRelativePath(NukeBuild.RootDirectory, x))
                .FirstOrDefault().NotNull("BashScript != null");

        public void OnBeforeLogo(NukeBuild build, IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            if (NukeBuild.Host != HostType)
                return;

            Generate(build, executableTargets);
            Environment.Exit(0);
        }

        public void OnAfterLogo(
            NukeBuild build,
            IReadOnlyCollection<ExecutableTarget> executableTargets,
            IReadOnlyCollection<ExecutableTarget> executionPlan)
        {
            if (NukeBuild.Host != HostType ||
                EnvironmentInfo.GetParameter<bool>(ConfigurationParameterName) ||
                !AutoGenerate)
                return;

            Logger.LogLevel = LogLevel.Trace;
            var previousHash = GetCurrentHash();

            var assembly = Assembly.GetEntryAssembly().NotNull("assembly != null");
            ProcessTasks.StartProcess(
                    assembly.Location,
                    $"--{ConfigurationParameterName} --host {HostType}",
                    logInvocation: false,
                    logOutput: true)
                .AssertZeroExitCode();

            if (GetCurrentHash() != previousHash)
                Logger.Warn($"Configuration files for {HostType} have changed.");
        }

        public void OnBuildFinished(NukeBuild build)
        {
            if (NukeBuild.Host != HostType)
                return;

            // Note https://github.com/dotnet/cli/issues/11424
            if (ShutdownDotNetBuildServer)
                DotNetTasks.DotNet("build-server shutdown");

            OnBuildFinishedInternal(build);
        }

        private string GetCurrentHash()
        {
            return GeneratedFiles.Select(FileSystemTasks.GetFileHash).JoinComma();
        }

        protected abstract HostType HostType { get; }

        protected abstract void Generate(NukeBuild build, IReadOnlyCollection<ExecutableTarget> executableTargets);

        protected virtual void OnBuildFinishedInternal(NukeBuild build)
        {
        }
    }
}
