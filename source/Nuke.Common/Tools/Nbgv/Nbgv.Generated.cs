// Generated from https://github.com/juchom/common/blob/master/build/specifications/Nbgv.json

using JetBrains.Annotations;
using Newtonsoft.Json;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.Tooling;
using Nuke.Common.Tools;
using Nuke.Common.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;

namespace Nuke.Common.Tools.Nbgv
{
    /// <summary>
    ///   <p>This package adds precise, semver-compatible git commit information to every assembly, VSIX, NuGet and NPM package, and more. It implicitly supports all cloud build services and CI server software because it simply uses git itself and integrates naturally in MSBuild, gulp and other build scripts.</p>
    ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NbgvTasks
    {
        /// <summary>
        ///   Path to the Nbgv executable.
        /// </summary>
        public static string NbgvPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("NBGV_EXE") ??
            ToolPathResolver.GetPackageExecutable("nbgv", "nbgv.dll");
        public static Action<OutputType, string> NbgvLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>This package adds precise, semver-compatible git commit information to every assembly, VSIX, NuGet and NPM package, and more. It implicitly supports all cloud build services and CI server software because it simply uses git itself and integrates naturally in MSBuild, gulp and other build scripts.</p>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> Nbgv(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Func<string, string> outputFilter = null)
        {
            var process = ProcessTasks.StartProcess(NbgvPath, arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, NbgvLogger, outputFilter);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p> Prepares a project to have version stamps applied using Nerdbank.GitVersioning.</p>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--help</c> via <see cref="NbgvInstallSettings.Help"/></li>
        ///     <li><c>--project</c> via <see cref="NbgvInstallSettings.Project"/></li>
        ///     <li><c>--version</c> via <see cref="NbgvInstallSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NbgvInstall(NbgvInstallSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new NbgvInstallSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p> Prepares a project to have version stamps applied using Nerdbank.GitVersioning.</p>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--help</c> via <see cref="NbgvInstallSettings.Help"/></li>
        ///     <li><c>--project</c> via <see cref="NbgvInstallSettings.Project"/></li>
        ///     <li><c>--version</c> via <see cref="NbgvInstallSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NbgvInstall(Configure<NbgvInstallSettings> configurator)
        {
            return NbgvInstall(configurator(new NbgvInstallSettings()));
        }
        /// <summary>
        ///   <p> Prepares a project to have version stamps applied using Nerdbank.GitVersioning.</p>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--help</c> via <see cref="NbgvInstallSettings.Help"/></li>
        ///     <li><c>--project</c> via <see cref="NbgvInstallSettings.Project"/></li>
        ///     <li><c>--version</c> via <see cref="NbgvInstallSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(NbgvInstallSettings Settings, IReadOnlyCollection<Output> Output)> NbgvInstall(CombinatorialConfigure<NbgvInstallSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(NbgvInstall, NbgvLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Gets the version information for a project.</p>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;commit&gt;</c> via <see cref="NbgvGetVersionSettings.Commit"/></li>
        ///     <li><c>--format</c> via <see cref="NbgvGetVersionSettings.Format"/></li>
        ///     <li><c>--help</c> via <see cref="NbgvGetVersionSettings.Help"/></li>
        ///     <li><c>--project</c> via <see cref="NbgvGetVersionSettings.Project"/></li>
        ///     <li><c>--variable</c> via <see cref="NbgvGetVersionSettings.Variable"/></li>
        ///   </ul>
        /// </remarks>
        public static (Nbgv Result, IReadOnlyCollection<Output> Output) NbgvGetVersion(NbgvGetVersionSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new NbgvGetVersionSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return (GetResult(process, toolSettings), process.Output);
        }
        /// <summary>
        ///   <p>Gets the version information for a project.</p>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;commit&gt;</c> via <see cref="NbgvGetVersionSettings.Commit"/></li>
        ///     <li><c>--format</c> via <see cref="NbgvGetVersionSettings.Format"/></li>
        ///     <li><c>--help</c> via <see cref="NbgvGetVersionSettings.Help"/></li>
        ///     <li><c>--project</c> via <see cref="NbgvGetVersionSettings.Project"/></li>
        ///     <li><c>--variable</c> via <see cref="NbgvGetVersionSettings.Variable"/></li>
        ///   </ul>
        /// </remarks>
        public static (Nbgv Result, IReadOnlyCollection<Output> Output) NbgvGetVersion(Configure<NbgvGetVersionSettings> configurator)
        {
            return NbgvGetVersion(configurator(new NbgvGetVersionSettings()));
        }
        /// <summary>
        ///   <p>Gets the version information for a project.</p>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;commit&gt;</c> via <see cref="NbgvGetVersionSettings.Commit"/></li>
        ///     <li><c>--format</c> via <see cref="NbgvGetVersionSettings.Format"/></li>
        ///     <li><c>--help</c> via <see cref="NbgvGetVersionSettings.Help"/></li>
        ///     <li><c>--project</c> via <see cref="NbgvGetVersionSettings.Project"/></li>
        ///     <li><c>--variable</c> via <see cref="NbgvGetVersionSettings.Variable"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(NbgvGetVersionSettings Settings, Nbgv Result, IReadOnlyCollection<Output> Output)> NbgvGetVersion(CombinatorialConfigure<NbgvGetVersionSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(NbgvGetVersion, NbgvLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Updates the version stamp that is applied to a project.</p>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;version&gt;</c> via <see cref="NbgvSetVersionSettings.Version"/></li>
        ///     <li><c>--help</c> via <see cref="NbgvSetVersionSettings.Help"/></li>
        ///     <li><c>--project</c> via <see cref="NbgvSetVersionSettings.Project"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NbgvSetVersion(NbgvSetVersionSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new NbgvSetVersionSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Updates the version stamp that is applied to a project.</p>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;version&gt;</c> via <see cref="NbgvSetVersionSettings.Version"/></li>
        ///     <li><c>--help</c> via <see cref="NbgvSetVersionSettings.Help"/></li>
        ///     <li><c>--project</c> via <see cref="NbgvSetVersionSettings.Project"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NbgvSetVersion(Configure<NbgvSetVersionSettings> configurator)
        {
            return NbgvSetVersion(configurator(new NbgvSetVersionSettings()));
        }
        /// <summary>
        ///   <p>Updates the version stamp that is applied to a project.</p>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;version&gt;</c> via <see cref="NbgvSetVersionSettings.Version"/></li>
        ///     <li><c>--help</c> via <see cref="NbgvSetVersionSettings.Help"/></li>
        ///     <li><c>--project</c> via <see cref="NbgvSetVersionSettings.Project"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(NbgvSetVersionSettings Settings, IReadOnlyCollection<Output> Output)> NbgvSetVersion(CombinatorialConfigure<NbgvSetVersionSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(NbgvSetVersion, NbgvLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Creates a git tag to mark a version.</p>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;versionOrRef&gt;</c> via <see cref="NbgvTagSettings.VersionOrRef"/></li>
        ///     <li><c>--help</c> via <see cref="NbgvTagSettings.Help"/></li>
        ///     <li><c>--project</c> via <see cref="NbgvTagSettings.Project"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NbgvTag(NbgvTagSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new NbgvTagSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Creates a git tag to mark a version.</p>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;versionOrRef&gt;</c> via <see cref="NbgvTagSettings.VersionOrRef"/></li>
        ///     <li><c>--help</c> via <see cref="NbgvTagSettings.Help"/></li>
        ///     <li><c>--project</c> via <see cref="NbgvTagSettings.Project"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NbgvTag(Configure<NbgvTagSettings> configurator)
        {
            return NbgvTag(configurator(new NbgvTagSettings()));
        }
        /// <summary>
        ///   <p>Creates a git tag to mark a version.</p>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;versionOrRef&gt;</c> via <see cref="NbgvTagSettings.VersionOrRef"/></li>
        ///     <li><c>--help</c> via <see cref="NbgvTagSettings.Help"/></li>
        ///     <li><c>--project</c> via <see cref="NbgvTagSettings.Project"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(NbgvTagSettings Settings, IReadOnlyCollection<Output> Output)> NbgvTag(CombinatorialConfigure<NbgvTagSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(NbgvTag, NbgvLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Gets the commit(s) that match a given version.</p>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;version&gt;</c> via <see cref="NbgvGetCommitsSettings.Version"/></li>
        ///     <li><c>--help</c> via <see cref="NbgvGetCommitsSettings.Help"/></li>
        ///     <li><c>--project</c> via <see cref="NbgvGetCommitsSettings.Project"/></li>
        ///     <li><c>--quiet</c> via <see cref="NbgvGetCommitsSettings.Quiet"/></li>
        ///   </ul>
        /// </remarks>
        public static (List<string> Result, IReadOnlyCollection<Output> Output) NbgvGetCommits(NbgvGetCommitsSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new NbgvGetCommitsSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return (GetResult(process, toolSettings), process.Output);
        }
        /// <summary>
        ///   <p>Gets the commit(s) that match a given version.</p>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;version&gt;</c> via <see cref="NbgvGetCommitsSettings.Version"/></li>
        ///     <li><c>--help</c> via <see cref="NbgvGetCommitsSettings.Help"/></li>
        ///     <li><c>--project</c> via <see cref="NbgvGetCommitsSettings.Project"/></li>
        ///     <li><c>--quiet</c> via <see cref="NbgvGetCommitsSettings.Quiet"/></li>
        ///   </ul>
        /// </remarks>
        public static (List<string> Result, IReadOnlyCollection<Output> Output) NbgvGetCommits(Configure<NbgvGetCommitsSettings> configurator)
        {
            return NbgvGetCommits(configurator(new NbgvGetCommitsSettings()));
        }
        /// <summary>
        ///   <p>Gets the commit(s) that match a given version.</p>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;version&gt;</c> via <see cref="NbgvGetCommitsSettings.Version"/></li>
        ///     <li><c>--help</c> via <see cref="NbgvGetCommitsSettings.Help"/></li>
        ///     <li><c>--project</c> via <see cref="NbgvGetCommitsSettings.Project"/></li>
        ///     <li><c>--quiet</c> via <see cref="NbgvGetCommitsSettings.Quiet"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(NbgvGetCommitsSettings Settings, List<string> Result, IReadOnlyCollection<Output> Output)> NbgvGetCommits(CombinatorialConfigure<NbgvGetCommitsSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(NbgvGetCommits, NbgvLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Communicates with the ambient cloud build to set the build number and/or other cloud build variables.</p>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--all-vars</c> via <see cref="NbgvCloudSettings.AllVars"/></li>
        ///     <li><c>--ci-system</c> via <see cref="NbgvCloudSettings.CiSystem"/></li>
        ///     <li><c>--common-vars</c> via <see cref="NbgvCloudSettings.CommonVars"/></li>
        ///     <li><c>--define</c> via <see cref="NbgvCloudSettings.Define"/></li>
        ///     <li><c>--help</c> via <see cref="NbgvCloudSettings.Help"/></li>
        ///     <li><c>--project</c> via <see cref="NbgvCloudSettings.Project"/></li>
        ///     <li><c>--version</c> via <see cref="NbgvCloudSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NbgvCloud(NbgvCloudSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new NbgvCloudSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Communicates with the ambient cloud build to set the build number and/or other cloud build variables.</p>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--all-vars</c> via <see cref="NbgvCloudSettings.AllVars"/></li>
        ///     <li><c>--ci-system</c> via <see cref="NbgvCloudSettings.CiSystem"/></li>
        ///     <li><c>--common-vars</c> via <see cref="NbgvCloudSettings.CommonVars"/></li>
        ///     <li><c>--define</c> via <see cref="NbgvCloudSettings.Define"/></li>
        ///     <li><c>--help</c> via <see cref="NbgvCloudSettings.Help"/></li>
        ///     <li><c>--project</c> via <see cref="NbgvCloudSettings.Project"/></li>
        ///     <li><c>--version</c> via <see cref="NbgvCloudSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NbgvCloud(Configure<NbgvCloudSettings> configurator)
        {
            return NbgvCloud(configurator(new NbgvCloudSettings()));
        }
        /// <summary>
        ///   <p>Communicates with the ambient cloud build to set the build number and/or other cloud build variables.</p>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--all-vars</c> via <see cref="NbgvCloudSettings.AllVars"/></li>
        ///     <li><c>--ci-system</c> via <see cref="NbgvCloudSettings.CiSystem"/></li>
        ///     <li><c>--common-vars</c> via <see cref="NbgvCloudSettings.CommonVars"/></li>
        ///     <li><c>--define</c> via <see cref="NbgvCloudSettings.Define"/></li>
        ///     <li><c>--help</c> via <see cref="NbgvCloudSettings.Help"/></li>
        ///     <li><c>--project</c> via <see cref="NbgvCloudSettings.Project"/></li>
        ///     <li><c>--version</c> via <see cref="NbgvCloudSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(NbgvCloudSettings Settings, IReadOnlyCollection<Output> Output)> NbgvCloud(CombinatorialConfigure<NbgvCloudSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(NbgvCloud, NbgvLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Prepares a release by creating a release branch for the current version and adjusting the version on the current branch.</p>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;tag&gt;</c> via <see cref="NbgvPrepareReleaseSettings.Tag"/></li>
        ///     <li><c>--help</c> via <see cref="NbgvPrepareReleaseSettings.Help"/></li>
        ///     <li><c>--nextVersion</c> via <see cref="NbgvPrepareReleaseSettings.NextVersion"/></li>
        ///     <li><c>--project</c> via <see cref="NbgvPrepareReleaseSettings.Project"/></li>
        ///     <li><c>--versionIncrement</c> via <see cref="NbgvPrepareReleaseSettings.VersionIncrement"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NbgvPrepareRelease(NbgvPrepareReleaseSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new NbgvPrepareReleaseSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Prepares a release by creating a release branch for the current version and adjusting the version on the current branch.</p>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;tag&gt;</c> via <see cref="NbgvPrepareReleaseSettings.Tag"/></li>
        ///     <li><c>--help</c> via <see cref="NbgvPrepareReleaseSettings.Help"/></li>
        ///     <li><c>--nextVersion</c> via <see cref="NbgvPrepareReleaseSettings.NextVersion"/></li>
        ///     <li><c>--project</c> via <see cref="NbgvPrepareReleaseSettings.Project"/></li>
        ///     <li><c>--versionIncrement</c> via <see cref="NbgvPrepareReleaseSettings.VersionIncrement"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NbgvPrepareRelease(Configure<NbgvPrepareReleaseSettings> configurator)
        {
            return NbgvPrepareRelease(configurator(new NbgvPrepareReleaseSettings()));
        }
        /// <summary>
        ///   <p>Prepares a release by creating a release branch for the current version and adjusting the version on the current branch.</p>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;tag&gt;</c> via <see cref="NbgvPrepareReleaseSettings.Tag"/></li>
        ///     <li><c>--help</c> via <see cref="NbgvPrepareReleaseSettings.Help"/></li>
        ///     <li><c>--nextVersion</c> via <see cref="NbgvPrepareReleaseSettings.NextVersion"/></li>
        ///     <li><c>--project</c> via <see cref="NbgvPrepareReleaseSettings.Project"/></li>
        ///     <li><c>--versionIncrement</c> via <see cref="NbgvPrepareReleaseSettings.VersionIncrement"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(NbgvPrepareReleaseSettings Settings, IReadOnlyCollection<Output> Output)> NbgvPrepareRelease(CombinatorialConfigure<NbgvPrepareReleaseSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(NbgvPrepareRelease, NbgvLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region NbgvInstallSettings
    /// <summary>
    ///   Used within <see cref="NbgvTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NbgvInstallSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Nbgv executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? NbgvTasks.NbgvPath;
        public override Action<OutputType, string> CustomLogger => NbgvTasks.NbgvLogger;
        /// <summary>
        ///   The initial version to set. The default is 1.0-beta.
        /// </summary>
        public virtual string Version { get; internal set; }
        /// <summary>
        ///   The path to the project or project directory. The default is the current directory.
        /// </summary>
        public virtual string Project { get; internal set; }
        /// <summary>
        ///   Use after a command to get more help about a particular command.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("install")
              .Add("--version {value}", Version)
              .Add("--project {value}", Project)
              .Add("--help", Help);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region NbgvGetVersionSettings
    /// <summary>
    ///   Used within <see cref="NbgvTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NbgvGetVersionSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Nbgv executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? NbgvTasks.NbgvPath;
        public override Action<OutputType, string> CustomLogger => NbgvTasks.NbgvLogger;
        /// <summary>
        ///   The format to write the version information. Allowed values are: text, json. The default is text.
        /// </summary>
        public virtual NbgvFormat Format { get; internal set; }
        /// <summary>
        ///   The name of just one version property to print to stdout. When specified, the output is always in raw text. Useful in scripts.
        /// </summary>
        public virtual string Variable { get; internal set; }
        /// <summary>
        ///   The commit/ref to get the version information for. The default is HEAD.
        /// </summary>
        public virtual string Commit { get; internal set; }
        /// <summary>
        ///   The path to the project or project directory. The default is the current directory.
        /// </summary>
        public virtual string Project { get; internal set; }
        /// <summary>
        ///   Use after a command to get more help about a particular command.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("get-version")
              .Add("--format {value}", Format)
              .Add("--variable {value}", Variable)
              .Add("{value}", Commit)
              .Add("--project {value}", Project)
              .Add("--help", Help);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region NbgvSetVersionSettings
    /// <summary>
    ///   Used within <see cref="NbgvTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NbgvSetVersionSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Nbgv executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? NbgvTasks.NbgvPath;
        public override Action<OutputType, string> CustomLogger => NbgvTasks.NbgvLogger;
        /// <summary>
        ///   The version to set.
        /// </summary>
        public virtual string Version { get; internal set; }
        /// <summary>
        ///   The path to the project or project directory. The default is the current directory.
        /// </summary>
        public virtual string Project { get; internal set; }
        /// <summary>
        ///   Use after a command to get more help about a particular command.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("set-version")
              .Add("{value}", Version)
              .Add("--project {value}", Project)
              .Add("--help", Help);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region NbgvTagSettings
    /// <summary>
    ///   Used within <see cref="NbgvTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NbgvTagSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Nbgv executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? NbgvTasks.NbgvPath;
        public override Action<OutputType, string> CustomLogger => NbgvTasks.NbgvLogger;
        /// <summary>
        ///   The a.b.c[.d] version or git ref to be tagged. If not specified, HEAD is used.
        /// </summary>
        public virtual string VersionOrRef { get; internal set; }
        /// <summary>
        ///   The path to the project or project directory. The default is the current directory.
        /// </summary>
        public virtual string Project { get; internal set; }
        /// <summary>
        ///   Use after a command to get more help about a particular command.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("tag")
              .Add("{value}", VersionOrRef)
              .Add("--project {value}", Project)
              .Add("--help", Help);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region NbgvGetCommitsSettings
    /// <summary>
    ///   Used within <see cref="NbgvTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NbgvGetCommitsSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Nbgv executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? NbgvTasks.NbgvPath;
        public override Action<OutputType, string> CustomLogger => NbgvTasks.NbgvLogger;
        /// <summary>
        ///   Use minimal output.
        /// </summary>
        public virtual bool? Quiet { get; internal set; }
        /// <summary>
        ///   The a.b.c[.d] version to find.
        /// </summary>
        public virtual string Version { get; internal set; }
        /// <summary>
        ///   The path to the project or project directory. The default is the current directory.
        /// </summary>
        public virtual string Project { get; internal set; }
        /// <summary>
        ///   Use after a command to get more help about a particular command.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("get-commits")
              .Add("--quiet", Quiet)
              .Add("{value}", Version)
              .Add("--project {value}", Project)
              .Add("--help", Help);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region NbgvCloudSettings
    /// <summary>
    ///   Used within <see cref="NbgvTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NbgvCloudSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Nbgv executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? NbgvTasks.NbgvPath;
        public override Action<OutputType, string> CustomLogger => NbgvTasks.NbgvLogger;
        /// <summary>
        ///   The string to use for the cloud build number. If not specified, the computed version will be used.
        /// </summary>
        public virtual string Version { get; internal set; }
        /// <summary>
        ///   Force activation for a particular CI system. If not specified, auto-detection will be used. Supported values are: AppVeyor, VisualStudioTeamServices, TeamCity, AtlassianBamboo, Jenkins, GitLab, Travis
        /// </summary>
        public virtual NbgvCiSystem CiSystem { get; internal set; }
        /// <summary>
        ///   Defines ALL version variables as cloud build variables, with a "NBGV_" prefix.
        /// </summary>
        public virtual bool? AllVars { get; internal set; }
        /// <summary>
        ///   Defines a few common version variables as cloud build variables, with a "Git" prefix (e.g. GitBuildVersion, GitBuildVersionSimple, GitAssemblyInformationalVersion).
        /// </summary>
        public virtual bool? CommonVars { get; internal set; }
        /// <summary>
        ///   Additional cloud build variables to define. Each should be in the NAME=VALUE syntax.
        /// </summary>
        public virtual IReadOnlyDictionary<string, string> Define => DefineInternal.AsReadOnly();
        internal Dictionary<string, string> DefineInternal { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///   The path to the project or project directory. The default is the current directory.
        /// </summary>
        public virtual string Project { get; internal set; }
        /// <summary>
        ///   Use after a command to get more help about a particular command.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("cloud")
              .Add("--version {value}", Version)
              .Add("--ci-system {value}", CiSystem)
              .Add("--all-vars", AllVars)
              .Add("--common-vars", CommonVars)
              .Add("--define {value}", Define, "{key}={value}", separator: ' ')
              .Add("--project {value}", Project)
              .Add("--help", Help);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region NbgvPrepareReleaseSettings
    /// <summary>
    ///   Used within <see cref="NbgvTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NbgvPrepareReleaseSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Nbgv executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? NbgvTasks.NbgvPath;
        public override Action<OutputType, string> CustomLogger => NbgvTasks.NbgvLogger;
        /// <summary>
        ///   The version to set for the current branch. If omitted, the next version is determined automatically by incrementing the current version.
        /// </summary>
        public virtual string NextVersion { get; internal set; }
        /// <summary>
        ///   Overrides the 'versionIncrement' setting set in version.json for determining the next version of the current branch.
        /// </summary>
        public virtual string VersionIncrement { get; internal set; }
        /// <summary>
        ///   The prerelease tag to apply on the release branch (if any). If not specified, any existing prerelease tag will be removed. The preceding hyphen may be omitted.
        /// </summary>
        public virtual string Tag { get; internal set; }
        /// <summary>
        ///   The path to the project or project directory. The default is the current directory.
        /// </summary>
        public virtual string Project { get; internal set; }
        /// <summary>
        ///   Use after a command to get more help about a particular command.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("prepare-release")
              .Add("--nextVersion {value}", NextVersion)
              .Add("--versionIncrement {value}", VersionIncrement)
              .Add("{value}", Tag)
              .Add("--project {value}", Project)
              .Add("--help", Help);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region Nbgv
    /// <summary>
    ///   Used within <see cref="NbgvTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class Nbgv : ISettingsEntity
    {
        public virtual string CloudBuildNumber { get; internal set; }
        public virtual bool? CloudBuildNumberEnabled { get; internal set; }
        public virtual IReadOnlyList<string> BuildMetadataWithCommitId => BuildMetadataWithCommitIdInternal.AsReadOnly();
        internal List<string> BuildMetadataWithCommitIdInternal { get; set; } = new List<string>();
        public virtual bool? VersionFileFound { get; internal set; }
        public virtual string AssemblyVersion { get; internal set; }
        public virtual string AssemblyFileVersion { get; internal set; }
        public virtual string AssemblyInformationalVersion { get; internal set; }
        public virtual bool? PublicRelease { get; internal set; }
        public virtual string PrereleaseVersion { get; internal set; }
        public virtual string PrereleaseVersionNoLeadingHyphen { get; internal set; }
        public virtual string SimpleVersion { get; internal set; }
        public virtual int? BuildNumber { get; internal set; }
        public virtual int? VersionRevision { get; internal set; }
        public virtual string MajorMinorVersion { get; internal set; }
        public virtual int? VersionMajor { get; internal set; }
        public virtual int? VersionMinor { get; internal set; }
        public virtual string GitCommitId { get; internal set; }
        public virtual string GitCommitIdShort { get; internal set; }
        public virtual DateTimeOffset? GitCommitDate { get; internal set; }
        public virtual int? VersionHeight { get; internal set; }
        public virtual int? VersionHeightOffset { get; internal set; }
        public virtual string BuildingRef { get; internal set; }
        public virtual string Version { get; internal set; }
        public virtual bool? CloudBuildAllVarsEnabled { get; internal set; }
        public virtual IReadOnlyDictionary<string, string> CloudBuildAllVars => CloudBuildAllVarsInternal.AsReadOnly();
        internal Dictionary<string, string> CloudBuildAllVarsInternal { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        public virtual bool? CloudBuildVersionVarsEnabled { get; internal set; }
        public virtual IReadOnlyDictionary<string, string> CloudBuildVersionVars => CloudBuildVersionVarsInternal.AsReadOnly();
        internal Dictionary<string, string> CloudBuildVersionVarsInternal { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        public virtual IReadOnlyList<string> BuildMetadata => BuildMetadataInternal.AsReadOnly();
        internal List<string> BuildMetadataInternal { get; set; } = new List<string>();
        public virtual string BuildMetadataFragment { get; internal set; }
        public virtual string NuGetPackageVersion { get; internal set; }
        public virtual string ChocolateyPackageVersion { get; internal set; }
        public virtual string NpmPackageVersion { get; internal set; }
        public virtual string SemVer1 { get; internal set; }
        public virtual string SemVer2 { get; internal set; }
        public virtual int? SemVer1NumericIdentifierPadding { get; internal set; }
    }
    #endregion
    #region NbgvInstallSettingsExtensions
    /// <summary>
    ///   Used within <see cref="NbgvTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NbgvInstallSettingsExtensions
    {
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="NbgvInstallSettings.Version"/></em></p>
        ///   <p>The initial version to set. The default is 1.0-beta.</p>
        /// </summary>
        [Pure]
        public static NbgvInstallSettings SetVersion(this NbgvInstallSettings toolSettings, string version)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NbgvInstallSettings.Version"/></em></p>
        ///   <p>The initial version to set. The default is 1.0-beta.</p>
        /// </summary>
        [Pure]
        public static NbgvInstallSettings ResetVersion(this NbgvInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        #endregion
        #region Project
        /// <summary>
        ///   <p><em>Sets <see cref="NbgvInstallSettings.Project"/></em></p>
        ///   <p>The path to the project or project directory. The default is the current directory.</p>
        /// </summary>
        [Pure]
        public static NbgvInstallSettings SetProject(this NbgvInstallSettings toolSettings, string project)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NbgvInstallSettings.Project"/></em></p>
        ///   <p>The path to the project or project directory. The default is the current directory.</p>
        /// </summary>
        [Pure]
        public static NbgvInstallSettings ResetProject(this NbgvInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="NbgvInstallSettings.Help"/></em></p>
        ///   <p>Use after a command to get more help about a particular command.</p>
        /// </summary>
        [Pure]
        public static NbgvInstallSettings SetHelp(this NbgvInstallSettings toolSettings, bool? help)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NbgvInstallSettings.Help"/></em></p>
        ///   <p>Use after a command to get more help about a particular command.</p>
        /// </summary>
        [Pure]
        public static NbgvInstallSettings ResetHelp(this NbgvInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NbgvInstallSettings.Help"/></em></p>
        ///   <p>Use after a command to get more help about a particular command.</p>
        /// </summary>
        [Pure]
        public static NbgvInstallSettings EnableHelp(this NbgvInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NbgvInstallSettings.Help"/></em></p>
        ///   <p>Use after a command to get more help about a particular command.</p>
        /// </summary>
        [Pure]
        public static NbgvInstallSettings DisableHelp(this NbgvInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NbgvInstallSettings.Help"/></em></p>
        ///   <p>Use after a command to get more help about a particular command.</p>
        /// </summary>
        [Pure]
        public static NbgvInstallSettings ToggleHelp(this NbgvInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NbgvGetVersionSettingsExtensions
    /// <summary>
    ///   Used within <see cref="NbgvTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NbgvGetVersionSettingsExtensions
    {
        #region Format
        /// <summary>
        ///   <p><em>Sets <see cref="NbgvGetVersionSettings.Format"/></em></p>
        ///   <p>The format to write the version information. Allowed values are: text, json. The default is text.</p>
        /// </summary>
        [Pure]
        public static NbgvGetVersionSettings SetFormat(this NbgvGetVersionSettings toolSettings, NbgvFormat format)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Format = format;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NbgvGetVersionSettings.Format"/></em></p>
        ///   <p>The format to write the version information. Allowed values are: text, json. The default is text.</p>
        /// </summary>
        [Pure]
        public static NbgvGetVersionSettings ResetFormat(this NbgvGetVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Format = null;
            return toolSettings;
        }
        #endregion
        #region Variable
        /// <summary>
        ///   <p><em>Sets <see cref="NbgvGetVersionSettings.Variable"/></em></p>
        ///   <p>The name of just one version property to print to stdout. When specified, the output is always in raw text. Useful in scripts.</p>
        /// </summary>
        [Pure]
        public static NbgvGetVersionSettings SetVariable(this NbgvGetVersionSettings toolSettings, string variable)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Variable = variable;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NbgvGetVersionSettings.Variable"/></em></p>
        ///   <p>The name of just one version property to print to stdout. When specified, the output is always in raw text. Useful in scripts.</p>
        /// </summary>
        [Pure]
        public static NbgvGetVersionSettings ResetVariable(this NbgvGetVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Variable = null;
            return toolSettings;
        }
        #endregion
        #region Commit
        /// <summary>
        ///   <p><em>Sets <see cref="NbgvGetVersionSettings.Commit"/></em></p>
        ///   <p>The commit/ref to get the version information for. The default is HEAD.</p>
        /// </summary>
        [Pure]
        public static NbgvGetVersionSettings SetCommit(this NbgvGetVersionSettings toolSettings, string commit)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Commit = commit;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NbgvGetVersionSettings.Commit"/></em></p>
        ///   <p>The commit/ref to get the version information for. The default is HEAD.</p>
        /// </summary>
        [Pure]
        public static NbgvGetVersionSettings ResetCommit(this NbgvGetVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Commit = null;
            return toolSettings;
        }
        #endregion
        #region Project
        /// <summary>
        ///   <p><em>Sets <see cref="NbgvGetVersionSettings.Project"/></em></p>
        ///   <p>The path to the project or project directory. The default is the current directory.</p>
        /// </summary>
        [Pure]
        public static NbgvGetVersionSettings SetProject(this NbgvGetVersionSettings toolSettings, string project)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NbgvGetVersionSettings.Project"/></em></p>
        ///   <p>The path to the project or project directory. The default is the current directory.</p>
        /// </summary>
        [Pure]
        public static NbgvGetVersionSettings ResetProject(this NbgvGetVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="NbgvGetVersionSettings.Help"/></em></p>
        ///   <p>Use after a command to get more help about a particular command.</p>
        /// </summary>
        [Pure]
        public static NbgvGetVersionSettings SetHelp(this NbgvGetVersionSettings toolSettings, bool? help)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NbgvGetVersionSettings.Help"/></em></p>
        ///   <p>Use after a command to get more help about a particular command.</p>
        /// </summary>
        [Pure]
        public static NbgvGetVersionSettings ResetHelp(this NbgvGetVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NbgvGetVersionSettings.Help"/></em></p>
        ///   <p>Use after a command to get more help about a particular command.</p>
        /// </summary>
        [Pure]
        public static NbgvGetVersionSettings EnableHelp(this NbgvGetVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NbgvGetVersionSettings.Help"/></em></p>
        ///   <p>Use after a command to get more help about a particular command.</p>
        /// </summary>
        [Pure]
        public static NbgvGetVersionSettings DisableHelp(this NbgvGetVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NbgvGetVersionSettings.Help"/></em></p>
        ///   <p>Use after a command to get more help about a particular command.</p>
        /// </summary>
        [Pure]
        public static NbgvGetVersionSettings ToggleHelp(this NbgvGetVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NbgvSetVersionSettingsExtensions
    /// <summary>
    ///   Used within <see cref="NbgvTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NbgvSetVersionSettingsExtensions
    {
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="NbgvSetVersionSettings.Version"/></em></p>
        ///   <p>The version to set.</p>
        /// </summary>
        [Pure]
        public static NbgvSetVersionSettings SetVersion(this NbgvSetVersionSettings toolSettings, string version)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NbgvSetVersionSettings.Version"/></em></p>
        ///   <p>The version to set.</p>
        /// </summary>
        [Pure]
        public static NbgvSetVersionSettings ResetVersion(this NbgvSetVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        #endregion
        #region Project
        /// <summary>
        ///   <p><em>Sets <see cref="NbgvSetVersionSettings.Project"/></em></p>
        ///   <p>The path to the project or project directory. The default is the current directory.</p>
        /// </summary>
        [Pure]
        public static NbgvSetVersionSettings SetProject(this NbgvSetVersionSettings toolSettings, string project)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NbgvSetVersionSettings.Project"/></em></p>
        ///   <p>The path to the project or project directory. The default is the current directory.</p>
        /// </summary>
        [Pure]
        public static NbgvSetVersionSettings ResetProject(this NbgvSetVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="NbgvSetVersionSettings.Help"/></em></p>
        ///   <p>Use after a command to get more help about a particular command.</p>
        /// </summary>
        [Pure]
        public static NbgvSetVersionSettings SetHelp(this NbgvSetVersionSettings toolSettings, bool? help)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NbgvSetVersionSettings.Help"/></em></p>
        ///   <p>Use after a command to get more help about a particular command.</p>
        /// </summary>
        [Pure]
        public static NbgvSetVersionSettings ResetHelp(this NbgvSetVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NbgvSetVersionSettings.Help"/></em></p>
        ///   <p>Use after a command to get more help about a particular command.</p>
        /// </summary>
        [Pure]
        public static NbgvSetVersionSettings EnableHelp(this NbgvSetVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NbgvSetVersionSettings.Help"/></em></p>
        ///   <p>Use after a command to get more help about a particular command.</p>
        /// </summary>
        [Pure]
        public static NbgvSetVersionSettings DisableHelp(this NbgvSetVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NbgvSetVersionSettings.Help"/></em></p>
        ///   <p>Use after a command to get more help about a particular command.</p>
        /// </summary>
        [Pure]
        public static NbgvSetVersionSettings ToggleHelp(this NbgvSetVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NbgvTagSettingsExtensions
    /// <summary>
    ///   Used within <see cref="NbgvTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NbgvTagSettingsExtensions
    {
        #region VersionOrRef
        /// <summary>
        ///   <p><em>Sets <see cref="NbgvTagSettings.VersionOrRef"/></em></p>
        ///   <p>The a.b.c[.d] version or git ref to be tagged. If not specified, HEAD is used.</p>
        /// </summary>
        [Pure]
        public static NbgvTagSettings SetVersionOrRef(this NbgvTagSettings toolSettings, string versionOrRef)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VersionOrRef = versionOrRef;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NbgvTagSettings.VersionOrRef"/></em></p>
        ///   <p>The a.b.c[.d] version or git ref to be tagged. If not specified, HEAD is used.</p>
        /// </summary>
        [Pure]
        public static NbgvTagSettings ResetVersionOrRef(this NbgvTagSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VersionOrRef = null;
            return toolSettings;
        }
        #endregion
        #region Project
        /// <summary>
        ///   <p><em>Sets <see cref="NbgvTagSettings.Project"/></em></p>
        ///   <p>The path to the project or project directory. The default is the current directory.</p>
        /// </summary>
        [Pure]
        public static NbgvTagSettings SetProject(this NbgvTagSettings toolSettings, string project)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NbgvTagSettings.Project"/></em></p>
        ///   <p>The path to the project or project directory. The default is the current directory.</p>
        /// </summary>
        [Pure]
        public static NbgvTagSettings ResetProject(this NbgvTagSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="NbgvTagSettings.Help"/></em></p>
        ///   <p>Use after a command to get more help about a particular command.</p>
        /// </summary>
        [Pure]
        public static NbgvTagSettings SetHelp(this NbgvTagSettings toolSettings, bool? help)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NbgvTagSettings.Help"/></em></p>
        ///   <p>Use after a command to get more help about a particular command.</p>
        /// </summary>
        [Pure]
        public static NbgvTagSettings ResetHelp(this NbgvTagSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NbgvTagSettings.Help"/></em></p>
        ///   <p>Use after a command to get more help about a particular command.</p>
        /// </summary>
        [Pure]
        public static NbgvTagSettings EnableHelp(this NbgvTagSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NbgvTagSettings.Help"/></em></p>
        ///   <p>Use after a command to get more help about a particular command.</p>
        /// </summary>
        [Pure]
        public static NbgvTagSettings DisableHelp(this NbgvTagSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NbgvTagSettings.Help"/></em></p>
        ///   <p>Use after a command to get more help about a particular command.</p>
        /// </summary>
        [Pure]
        public static NbgvTagSettings ToggleHelp(this NbgvTagSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NbgvGetCommitsSettingsExtensions
    /// <summary>
    ///   Used within <see cref="NbgvTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NbgvGetCommitsSettingsExtensions
    {
        #region Quiet
        /// <summary>
        ///   <p><em>Sets <see cref="NbgvGetCommitsSettings.Quiet"/></em></p>
        ///   <p>Use minimal output.</p>
        /// </summary>
        [Pure]
        public static NbgvGetCommitsSettings SetQuiet(this NbgvGetCommitsSettings toolSettings, bool? quiet)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quiet = quiet;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NbgvGetCommitsSettings.Quiet"/></em></p>
        ///   <p>Use minimal output.</p>
        /// </summary>
        [Pure]
        public static NbgvGetCommitsSettings ResetQuiet(this NbgvGetCommitsSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quiet = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NbgvGetCommitsSettings.Quiet"/></em></p>
        ///   <p>Use minimal output.</p>
        /// </summary>
        [Pure]
        public static NbgvGetCommitsSettings EnableQuiet(this NbgvGetCommitsSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quiet = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NbgvGetCommitsSettings.Quiet"/></em></p>
        ///   <p>Use minimal output.</p>
        /// </summary>
        [Pure]
        public static NbgvGetCommitsSettings DisableQuiet(this NbgvGetCommitsSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quiet = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NbgvGetCommitsSettings.Quiet"/></em></p>
        ///   <p>Use minimal output.</p>
        /// </summary>
        [Pure]
        public static NbgvGetCommitsSettings ToggleQuiet(this NbgvGetCommitsSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quiet = !toolSettings.Quiet;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="NbgvGetCommitsSettings.Version"/></em></p>
        ///   <p>The a.b.c[.d] version to find.</p>
        /// </summary>
        [Pure]
        public static NbgvGetCommitsSettings SetVersion(this NbgvGetCommitsSettings toolSettings, string version)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NbgvGetCommitsSettings.Version"/></em></p>
        ///   <p>The a.b.c[.d] version to find.</p>
        /// </summary>
        [Pure]
        public static NbgvGetCommitsSettings ResetVersion(this NbgvGetCommitsSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        #endregion
        #region Project
        /// <summary>
        ///   <p><em>Sets <see cref="NbgvGetCommitsSettings.Project"/></em></p>
        ///   <p>The path to the project or project directory. The default is the current directory.</p>
        /// </summary>
        [Pure]
        public static NbgvGetCommitsSettings SetProject(this NbgvGetCommitsSettings toolSettings, string project)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NbgvGetCommitsSettings.Project"/></em></p>
        ///   <p>The path to the project or project directory. The default is the current directory.</p>
        /// </summary>
        [Pure]
        public static NbgvGetCommitsSettings ResetProject(this NbgvGetCommitsSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="NbgvGetCommitsSettings.Help"/></em></p>
        ///   <p>Use after a command to get more help about a particular command.</p>
        /// </summary>
        [Pure]
        public static NbgvGetCommitsSettings SetHelp(this NbgvGetCommitsSettings toolSettings, bool? help)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NbgvGetCommitsSettings.Help"/></em></p>
        ///   <p>Use after a command to get more help about a particular command.</p>
        /// </summary>
        [Pure]
        public static NbgvGetCommitsSettings ResetHelp(this NbgvGetCommitsSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NbgvGetCommitsSettings.Help"/></em></p>
        ///   <p>Use after a command to get more help about a particular command.</p>
        /// </summary>
        [Pure]
        public static NbgvGetCommitsSettings EnableHelp(this NbgvGetCommitsSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NbgvGetCommitsSettings.Help"/></em></p>
        ///   <p>Use after a command to get more help about a particular command.</p>
        /// </summary>
        [Pure]
        public static NbgvGetCommitsSettings DisableHelp(this NbgvGetCommitsSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NbgvGetCommitsSettings.Help"/></em></p>
        ///   <p>Use after a command to get more help about a particular command.</p>
        /// </summary>
        [Pure]
        public static NbgvGetCommitsSettings ToggleHelp(this NbgvGetCommitsSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NbgvCloudSettingsExtensions
    /// <summary>
    ///   Used within <see cref="NbgvTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NbgvCloudSettingsExtensions
    {
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="NbgvCloudSettings.Version"/></em></p>
        ///   <p>The string to use for the cloud build number. If not specified, the computed version will be used.</p>
        /// </summary>
        [Pure]
        public static NbgvCloudSettings SetVersion(this NbgvCloudSettings toolSettings, string version)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NbgvCloudSettings.Version"/></em></p>
        ///   <p>The string to use for the cloud build number. If not specified, the computed version will be used.</p>
        /// </summary>
        [Pure]
        public static NbgvCloudSettings ResetVersion(this NbgvCloudSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        #endregion
        #region CiSystem
        /// <summary>
        ///   <p><em>Sets <see cref="NbgvCloudSettings.CiSystem"/></em></p>
        ///   <p>Force activation for a particular CI system. If not specified, auto-detection will be used. Supported values are: AppVeyor, VisualStudioTeamServices, TeamCity, AtlassianBamboo, Jenkins, GitLab, Travis</p>
        /// </summary>
        [Pure]
        public static NbgvCloudSettings SetCiSystem(this NbgvCloudSettings toolSettings, NbgvCiSystem ciSystem)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CiSystem = ciSystem;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NbgvCloudSettings.CiSystem"/></em></p>
        ///   <p>Force activation for a particular CI system. If not specified, auto-detection will be used. Supported values are: AppVeyor, VisualStudioTeamServices, TeamCity, AtlassianBamboo, Jenkins, GitLab, Travis</p>
        /// </summary>
        [Pure]
        public static NbgvCloudSettings ResetCiSystem(this NbgvCloudSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CiSystem = null;
            return toolSettings;
        }
        #endregion
        #region AllVars
        /// <summary>
        ///   <p><em>Sets <see cref="NbgvCloudSettings.AllVars"/></em></p>
        ///   <p>Defines ALL version variables as cloud build variables, with a "NBGV_" prefix.</p>
        /// </summary>
        [Pure]
        public static NbgvCloudSettings SetAllVars(this NbgvCloudSettings toolSettings, bool? allVars)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllVars = allVars;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NbgvCloudSettings.AllVars"/></em></p>
        ///   <p>Defines ALL version variables as cloud build variables, with a "NBGV_" prefix.</p>
        /// </summary>
        [Pure]
        public static NbgvCloudSettings ResetAllVars(this NbgvCloudSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllVars = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NbgvCloudSettings.AllVars"/></em></p>
        ///   <p>Defines ALL version variables as cloud build variables, with a "NBGV_" prefix.</p>
        /// </summary>
        [Pure]
        public static NbgvCloudSettings EnableAllVars(this NbgvCloudSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllVars = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NbgvCloudSettings.AllVars"/></em></p>
        ///   <p>Defines ALL version variables as cloud build variables, with a "NBGV_" prefix.</p>
        /// </summary>
        [Pure]
        public static NbgvCloudSettings DisableAllVars(this NbgvCloudSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllVars = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NbgvCloudSettings.AllVars"/></em></p>
        ///   <p>Defines ALL version variables as cloud build variables, with a "NBGV_" prefix.</p>
        /// </summary>
        [Pure]
        public static NbgvCloudSettings ToggleAllVars(this NbgvCloudSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllVars = !toolSettings.AllVars;
            return toolSettings;
        }
        #endregion
        #region CommonVars
        /// <summary>
        ///   <p><em>Sets <see cref="NbgvCloudSettings.CommonVars"/></em></p>
        ///   <p>Defines a few common version variables as cloud build variables, with a "Git" prefix (e.g. GitBuildVersion, GitBuildVersionSimple, GitAssemblyInformationalVersion).</p>
        /// </summary>
        [Pure]
        public static NbgvCloudSettings SetCommonVars(this NbgvCloudSettings toolSettings, bool? commonVars)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommonVars = commonVars;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NbgvCloudSettings.CommonVars"/></em></p>
        ///   <p>Defines a few common version variables as cloud build variables, with a "Git" prefix (e.g. GitBuildVersion, GitBuildVersionSimple, GitAssemblyInformationalVersion).</p>
        /// </summary>
        [Pure]
        public static NbgvCloudSettings ResetCommonVars(this NbgvCloudSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommonVars = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NbgvCloudSettings.CommonVars"/></em></p>
        ///   <p>Defines a few common version variables as cloud build variables, with a "Git" prefix (e.g. GitBuildVersion, GitBuildVersionSimple, GitAssemblyInformationalVersion).</p>
        /// </summary>
        [Pure]
        public static NbgvCloudSettings EnableCommonVars(this NbgvCloudSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommonVars = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NbgvCloudSettings.CommonVars"/></em></p>
        ///   <p>Defines a few common version variables as cloud build variables, with a "Git" prefix (e.g. GitBuildVersion, GitBuildVersionSimple, GitAssemblyInformationalVersion).</p>
        /// </summary>
        [Pure]
        public static NbgvCloudSettings DisableCommonVars(this NbgvCloudSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommonVars = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NbgvCloudSettings.CommonVars"/></em></p>
        ///   <p>Defines a few common version variables as cloud build variables, with a "Git" prefix (e.g. GitBuildVersion, GitBuildVersionSimple, GitAssemblyInformationalVersion).</p>
        /// </summary>
        [Pure]
        public static NbgvCloudSettings ToggleCommonVars(this NbgvCloudSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommonVars = !toolSettings.CommonVars;
            return toolSettings;
        }
        #endregion
        #region Define
        /// <summary>
        ///   <p><em>Sets <see cref="NbgvCloudSettings.Define"/> to a new dictionary</em></p>
        ///   <p>Additional cloud build variables to define. Each should be in the NAME=VALUE syntax.</p>
        /// </summary>
        [Pure]
        public static NbgvCloudSettings SetDefine(this NbgvCloudSettings toolSettings, IDictionary<string, string> define)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefineInternal = define.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="NbgvCloudSettings.Define"/></em></p>
        ///   <p>Additional cloud build variables to define. Each should be in the NAME=VALUE syntax.</p>
        /// </summary>
        [Pure]
        public static NbgvCloudSettings ClearDefine(this NbgvCloudSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefineInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="NbgvCloudSettings.Define"/></em></p>
        ///   <p>Additional cloud build variables to define. Each should be in the NAME=VALUE syntax.</p>
        /// </summary>
        [Pure]
        public static NbgvCloudSettings AddDefine(this NbgvCloudSettings toolSettings, string defineKey, string defineValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefineInternal.Add(defineKey, defineValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="NbgvCloudSettings.Define"/></em></p>
        ///   <p>Additional cloud build variables to define. Each should be in the NAME=VALUE syntax.</p>
        /// </summary>
        [Pure]
        public static NbgvCloudSettings RemoveDefine(this NbgvCloudSettings toolSettings, string defineKey)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefineInternal.Remove(defineKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="NbgvCloudSettings.Define"/></em></p>
        ///   <p>Additional cloud build variables to define. Each should be in the NAME=VALUE syntax.</p>
        /// </summary>
        [Pure]
        public static NbgvCloudSettings SetDefine(this NbgvCloudSettings toolSettings, string defineKey, string defineValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefineInternal[defineKey] = defineValue;
            return toolSettings;
        }
        #endregion
        #region Project
        /// <summary>
        ///   <p><em>Sets <see cref="NbgvCloudSettings.Project"/></em></p>
        ///   <p>The path to the project or project directory. The default is the current directory.</p>
        /// </summary>
        [Pure]
        public static NbgvCloudSettings SetProject(this NbgvCloudSettings toolSettings, string project)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NbgvCloudSettings.Project"/></em></p>
        ///   <p>The path to the project or project directory. The default is the current directory.</p>
        /// </summary>
        [Pure]
        public static NbgvCloudSettings ResetProject(this NbgvCloudSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="NbgvCloudSettings.Help"/></em></p>
        ///   <p>Use after a command to get more help about a particular command.</p>
        /// </summary>
        [Pure]
        public static NbgvCloudSettings SetHelp(this NbgvCloudSettings toolSettings, bool? help)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NbgvCloudSettings.Help"/></em></p>
        ///   <p>Use after a command to get more help about a particular command.</p>
        /// </summary>
        [Pure]
        public static NbgvCloudSettings ResetHelp(this NbgvCloudSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NbgvCloudSettings.Help"/></em></p>
        ///   <p>Use after a command to get more help about a particular command.</p>
        /// </summary>
        [Pure]
        public static NbgvCloudSettings EnableHelp(this NbgvCloudSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NbgvCloudSettings.Help"/></em></p>
        ///   <p>Use after a command to get more help about a particular command.</p>
        /// </summary>
        [Pure]
        public static NbgvCloudSettings DisableHelp(this NbgvCloudSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NbgvCloudSettings.Help"/></em></p>
        ///   <p>Use after a command to get more help about a particular command.</p>
        /// </summary>
        [Pure]
        public static NbgvCloudSettings ToggleHelp(this NbgvCloudSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NbgvPrepareReleaseSettingsExtensions
    /// <summary>
    ///   Used within <see cref="NbgvTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NbgvPrepareReleaseSettingsExtensions
    {
        #region NextVersion
        /// <summary>
        ///   <p><em>Sets <see cref="NbgvPrepareReleaseSettings.NextVersion"/></em></p>
        ///   <p>The version to set for the current branch. If omitted, the next version is determined automatically by incrementing the current version.</p>
        /// </summary>
        [Pure]
        public static NbgvPrepareReleaseSettings SetNextVersion(this NbgvPrepareReleaseSettings toolSettings, string nextVersion)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NextVersion = nextVersion;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NbgvPrepareReleaseSettings.NextVersion"/></em></p>
        ///   <p>The version to set for the current branch. If omitted, the next version is determined automatically by incrementing the current version.</p>
        /// </summary>
        [Pure]
        public static NbgvPrepareReleaseSettings ResetNextVersion(this NbgvPrepareReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NextVersion = null;
            return toolSettings;
        }
        #endregion
        #region VersionIncrement
        /// <summary>
        ///   <p><em>Sets <see cref="NbgvPrepareReleaseSettings.VersionIncrement"/></em></p>
        ///   <p>Overrides the 'versionIncrement' setting set in version.json for determining the next version of the current branch.</p>
        /// </summary>
        [Pure]
        public static NbgvPrepareReleaseSettings SetVersionIncrement(this NbgvPrepareReleaseSettings toolSettings, string versionIncrement)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VersionIncrement = versionIncrement;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NbgvPrepareReleaseSettings.VersionIncrement"/></em></p>
        ///   <p>Overrides the 'versionIncrement' setting set in version.json for determining the next version of the current branch.</p>
        /// </summary>
        [Pure]
        public static NbgvPrepareReleaseSettings ResetVersionIncrement(this NbgvPrepareReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VersionIncrement = null;
            return toolSettings;
        }
        #endregion
        #region Tag
        /// <summary>
        ///   <p><em>Sets <see cref="NbgvPrepareReleaseSettings.Tag"/></em></p>
        ///   <p>The prerelease tag to apply on the release branch (if any). If not specified, any existing prerelease tag will be removed. The preceding hyphen may be omitted.</p>
        /// </summary>
        [Pure]
        public static NbgvPrepareReleaseSettings SetTag(this NbgvPrepareReleaseSettings toolSettings, string tag)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Tag = tag;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NbgvPrepareReleaseSettings.Tag"/></em></p>
        ///   <p>The prerelease tag to apply on the release branch (if any). If not specified, any existing prerelease tag will be removed. The preceding hyphen may be omitted.</p>
        /// </summary>
        [Pure]
        public static NbgvPrepareReleaseSettings ResetTag(this NbgvPrepareReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Tag = null;
            return toolSettings;
        }
        #endregion
        #region Project
        /// <summary>
        ///   <p><em>Sets <see cref="NbgvPrepareReleaseSettings.Project"/></em></p>
        ///   <p>The path to the project or project directory. The default is the current directory.</p>
        /// </summary>
        [Pure]
        public static NbgvPrepareReleaseSettings SetProject(this NbgvPrepareReleaseSettings toolSettings, string project)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NbgvPrepareReleaseSettings.Project"/></em></p>
        ///   <p>The path to the project or project directory. The default is the current directory.</p>
        /// </summary>
        [Pure]
        public static NbgvPrepareReleaseSettings ResetProject(this NbgvPrepareReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="NbgvPrepareReleaseSettings.Help"/></em></p>
        ///   <p>Use after a command to get more help about a particular command.</p>
        /// </summary>
        [Pure]
        public static NbgvPrepareReleaseSettings SetHelp(this NbgvPrepareReleaseSettings toolSettings, bool? help)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NbgvPrepareReleaseSettings.Help"/></em></p>
        ///   <p>Use after a command to get more help about a particular command.</p>
        /// </summary>
        [Pure]
        public static NbgvPrepareReleaseSettings ResetHelp(this NbgvPrepareReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NbgvPrepareReleaseSettings.Help"/></em></p>
        ///   <p>Use after a command to get more help about a particular command.</p>
        /// </summary>
        [Pure]
        public static NbgvPrepareReleaseSettings EnableHelp(this NbgvPrepareReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NbgvPrepareReleaseSettings.Help"/></em></p>
        ///   <p>Use after a command to get more help about a particular command.</p>
        /// </summary>
        [Pure]
        public static NbgvPrepareReleaseSettings DisableHelp(this NbgvPrepareReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NbgvPrepareReleaseSettings.Help"/></em></p>
        ///   <p>Use after a command to get more help about a particular command.</p>
        /// </summary>
        [Pure]
        public static NbgvPrepareReleaseSettings ToggleHelp(this NbgvPrepareReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NbgvFormat
    /// <summary>
    ///   Used within <see cref="NbgvTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<NbgvFormat>))]
    public partial class NbgvFormat : Enumeration
    {
        public static NbgvFormat text = (NbgvFormat) "text";
        public static NbgvFormat json = (NbgvFormat) "json";
        public static explicit operator NbgvFormat(string value)
        {
            return new NbgvFormat { Value = value };
        }
    }
    #endregion
    #region NbgvCiSystem
    /// <summary>
    ///   Used within <see cref="NbgvTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<NbgvCiSystem>))]
    public partial class NbgvCiSystem : Enumeration
    {
        public static NbgvCiSystem AppVeyor = (NbgvCiSystem) "AppVeyor";
        public static NbgvCiSystem VisualStudioTeamServices = (NbgvCiSystem) "VisualStudioTeamServices";
        public static NbgvCiSystem TeamCity = (NbgvCiSystem) "TeamCity";
        public static NbgvCiSystem AtlassianBamboo = (NbgvCiSystem) "AtlassianBamboo";
        public static NbgvCiSystem Jenkins = (NbgvCiSystem) "Jenkins";
        public static NbgvCiSystem GitLab = (NbgvCiSystem) "GitLab";
        public static NbgvCiSystem Travis = (NbgvCiSystem) "Travis";
        public static explicit operator NbgvCiSystem(string value)
        {
            return new NbgvCiSystem { Value = value };
        }
    }
    #endregion
}
