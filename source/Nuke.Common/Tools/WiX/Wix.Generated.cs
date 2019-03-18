// Generated from https://github.com/jonsth131/common/blob/master/build/specifications/Wix.json
// Generated with Nuke.CodeGeneration version LOCAL (Windows,.NETStandard,Version=v2.0)

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

namespace Nuke.Common.Tools.Wix
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class WixTasks
    {
        /// <summary>
        ///   Path to the Wix executable.
        /// </summary>
        public static string WixPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("WIX_EXE") ??
            GetToolPath();
        public static Action<OutputType, string> WixLogger { get; set; } = ProcessTasks.DefaultLogger;
        public static IReadOnlyCollection<Output> Wix(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Func<string, string> outputFilter = null)
        {
            var process = ProcessTasks.StartProcess(WixPath, arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, WixLogger, outputFilter);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Preprocesses and compiles WiX source files into object files (.wixobj).</p>
        ///   <p>For more details, visit the <a href="http://wixtoolset.org/">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> WixCandle(WixCandleSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new WixCandleSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Preprocesses and compiles WiX source files into object files (.wixobj).</p>
        ///   <p>For more details, visit the <a href="http://wixtoolset.org/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;inputFiles&gt;</c> via <see cref="WixCandleSettings.InputFiles"/></li>
        ///     <li><c>@</c> via <see cref="WixCandleSettings.ResponseFile"/></li>
        ///     <li><c>-arch</c> via <see cref="WixCandleSettings.Architecture"/></li>
        ///     <li><c>-d</c> via <see cref="WixCandleSettings.Parameter"/></li>
        ///     <li><c>-ext</c> via <see cref="WixCandleSettings.Extension"/></li>
        ///     <li><c>-fips</c> via <see cref="WixCandleSettings.Fips"/></li>
        ///     <li><c>-I</c> via <see cref="WixCandleSettings.Include"/></li>
        ///     <li><c>-nologo</c> via <see cref="WixCandleSettings.NoLogo"/></li>
        ///     <li><c>-out</c> via <see cref="WixCandleSettings.Output"/></li>
        ///     <li><c>-p</c> via <see cref="WixCandleSettings.PreprocessToFile"/></li>
        ///     <li><c>-pedantic</c> via <see cref="WixCandleSettings.Pedantic"/></li>
        ///     <li><c>-sw</c> via <see cref="WixCandleSettings.SuppressAllWarnings"/></li>
        ///     <li><c>-sw</c> via <see cref="WixCandleSettings.SuppressWarnings"/></li>
        ///     <li><c>-v</c> via <see cref="WixCandleSettings.Verbose"/></li>
        ///     <li><c>-wx</c> via <see cref="WixCandleSettings.WarningsAsErrors"/></li>
        ///     <li><c>-wx</c> via <see cref="WixCandleSettings.MessageIdAsError"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> WixCandle(Configure<WixCandleSettings> configurator)
        {
            return WixCandle(configurator(new WixCandleSettings()));
        }
        /// <summary>
        ///   <p>Preprocesses and compiles WiX source files into object files (.wixobj).</p>
        ///   <p>For more details, visit the <a href="http://wixtoolset.org/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;inputFiles&gt;</c> via <see cref="WixCandleSettings.InputFiles"/></li>
        ///     <li><c>@</c> via <see cref="WixCandleSettings.ResponseFile"/></li>
        ///     <li><c>-arch</c> via <see cref="WixCandleSettings.Architecture"/></li>
        ///     <li><c>-d</c> via <see cref="WixCandleSettings.Parameter"/></li>
        ///     <li><c>-ext</c> via <see cref="WixCandleSettings.Extension"/></li>
        ///     <li><c>-fips</c> via <see cref="WixCandleSettings.Fips"/></li>
        ///     <li><c>-I</c> via <see cref="WixCandleSettings.Include"/></li>
        ///     <li><c>-nologo</c> via <see cref="WixCandleSettings.NoLogo"/></li>
        ///     <li><c>-out</c> via <see cref="WixCandleSettings.Output"/></li>
        ///     <li><c>-p</c> via <see cref="WixCandleSettings.PreprocessToFile"/></li>
        ///     <li><c>-pedantic</c> via <see cref="WixCandleSettings.Pedantic"/></li>
        ///     <li><c>-sw</c> via <see cref="WixCandleSettings.SuppressAllWarnings"/></li>
        ///     <li><c>-sw</c> via <see cref="WixCandleSettings.SuppressWarnings"/></li>
        ///     <li><c>-v</c> via <see cref="WixCandleSettings.Verbose"/></li>
        ///     <li><c>-wx</c> via <see cref="WixCandleSettings.WarningsAsErrors"/></li>
        ///     <li><c>-wx</c> via <see cref="WixCandleSettings.MessageIdAsError"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(WixCandleSettings Settings, IReadOnlyCollection<Output> Output)> WixCandle(CombinatorialConfigure<WixCandleSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(WixCandle, WixLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Generates WiX authoring from various input formats. It is used for harvesting files, Visual Studio projects and Internet Information Server web sites, harvesting these files into components and generating Windows Installer XML Source files (.wxs). Heat is good to use when you begin authoring your first Windows Installer package for a product.</p>
        ///   <p>For more details, visit the <a href="http://wixtoolset.org/">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> WixHeat(WixHeatSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new WixHeatSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Generates WiX authoring from various input formats. It is used for harvesting files, Visual Studio projects and Internet Information Server web sites, harvesting these files into components and generating Windows Installer XML Source files (.wxs). Heat is good to use when you begin authoring your first Windows Installer package for a product.</p>
        ///   <p>For more details, visit the <a href="http://wixtoolset.org/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;source&gt;</c> via <see cref="WixHeatSettings.Source"/></li>
        ///     <li><c>&lt;sourceFile&gt;</c> via <see cref="WixHeatSettings.SourceFile"/></li>
        ///     <li><c>&lt;type&gt;</c> via <see cref="WixHeatSettings.Type"/></li>
        ///     <li><c>-ag</c> via <see cref="WixHeatSettings.AutogenerateComponentGuids"/></li>
        ///     <li><c>-cg</c> via <see cref="WixHeatSettings.ComponentGroup"/></li>
        ///     <li><c>-configuration</c> via <see cref="WixHeatSettings.Configuration"/></li>
        ///     <li><c>-directoryid</c> via <see cref="WixHeatSettings.DirectoryId"/></li>
        ///     <li><c>-dr</c> via <see cref="WixHeatSettings.RootDirectoryReference"/></li>
        ///     <li><c>-ext</c> via <see cref="WixHeatSettings.Extension"/></li>
        ///     <li><c>-generate</c> via <see cref="WixHeatSettings.GenerateElement"/></li>
        ///     <li><c>-gg</c> via <see cref="WixHeatSettings.GenerateGuidsNow"/></li>
        ///     <li><c>-gl</c> via <see cref="WixHeatSettings.NoBracketGuids"/></li>
        ///     <li><c>-indent</c> via <see cref="WixHeatSettings.Indentation"/></li>
        ///     <li><c>-ke</c> via <see cref="WixHeatSettings.KeepEmptyDirectories"/></li>
        ///     <li><c>-nologo</c> via <see cref="WixHeatSettings.NoLogo"/></li>
        ///     <li><c>-out</c> via <see cref="WixHeatSettings.Output"/></li>
        ///     <li><c>-platform</c> via <see cref="WixHeatSettings.Platform"/></li>
        ///     <li><c>-pog</c> via <see cref="WixHeatSettings.ProjectOutputGroup"/></li>
        ///     <li><c>-projectname</c> via <see cref="WixHeatSettings.ProjectName"/></li>
        ///     <li><c>-scom</c> via <see cref="WixHeatSettings.SuppressComElements"/></li>
        ///     <li><c>-sfrag</c> via <see cref="WixHeatSettings.SuppressFragments"/></li>
        ///     <li><c>-srd</c> via <see cref="WixHeatSettings.SuppressRootDirectoryAsElement"/></li>
        ///     <li><c>-sreg</c> via <see cref="WixHeatSettings.SuppressRegistry"/></li>
        ///     <li><c>-suid</c> via <see cref="WixHeatSettings.SuppressUids"/></li>
        ///     <li><c>-sw</c> via <see cref="WixHeatSettings.SuppressAllWarnings"/></li>
        ///     <li><c>-sw</c> via <see cref="WixHeatSettings.SuppressWarnings"/></li>
        ///     <li><c>-svb6</c> via <see cref="WixHeatSettings.SuppressVb6ComElements"/></li>
        ///     <li><c>-t</c> via <see cref="WixHeatSettings.Transform"/></li>
        ///     <li><c>-template</c> via <see cref="WixHeatSettings.Template"/></li>
        ///     <li><c>-v</c> via <see cref="WixHeatSettings.Verbose"/></li>
        ///     <li><c>-var</c> via <see cref="WixHeatSettings.Var"/></li>
        ///     <li><c>-wixvar</c> via <see cref="WixHeatSettings.WixVar"/></li>
        ///     <li><c>-wx</c> via <see cref="WixHeatSettings.WarningsAsErrors"/></li>
        ///     <li><c>-wx</c> via <see cref="WixHeatSettings.MessageIdAsError"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> WixHeat(Configure<WixHeatSettings> configurator)
        {
            return WixHeat(configurator(new WixHeatSettings()));
        }
        /// <summary>
        ///   <p>Generates WiX authoring from various input formats. It is used for harvesting files, Visual Studio projects and Internet Information Server web sites, harvesting these files into components and generating Windows Installer XML Source files (.wxs). Heat is good to use when you begin authoring your first Windows Installer package for a product.</p>
        ///   <p>For more details, visit the <a href="http://wixtoolset.org/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;source&gt;</c> via <see cref="WixHeatSettings.Source"/></li>
        ///     <li><c>&lt;sourceFile&gt;</c> via <see cref="WixHeatSettings.SourceFile"/></li>
        ///     <li><c>&lt;type&gt;</c> via <see cref="WixHeatSettings.Type"/></li>
        ///     <li><c>-ag</c> via <see cref="WixHeatSettings.AutogenerateComponentGuids"/></li>
        ///     <li><c>-cg</c> via <see cref="WixHeatSettings.ComponentGroup"/></li>
        ///     <li><c>-configuration</c> via <see cref="WixHeatSettings.Configuration"/></li>
        ///     <li><c>-directoryid</c> via <see cref="WixHeatSettings.DirectoryId"/></li>
        ///     <li><c>-dr</c> via <see cref="WixHeatSettings.RootDirectoryReference"/></li>
        ///     <li><c>-ext</c> via <see cref="WixHeatSettings.Extension"/></li>
        ///     <li><c>-generate</c> via <see cref="WixHeatSettings.GenerateElement"/></li>
        ///     <li><c>-gg</c> via <see cref="WixHeatSettings.GenerateGuidsNow"/></li>
        ///     <li><c>-gl</c> via <see cref="WixHeatSettings.NoBracketGuids"/></li>
        ///     <li><c>-indent</c> via <see cref="WixHeatSettings.Indentation"/></li>
        ///     <li><c>-ke</c> via <see cref="WixHeatSettings.KeepEmptyDirectories"/></li>
        ///     <li><c>-nologo</c> via <see cref="WixHeatSettings.NoLogo"/></li>
        ///     <li><c>-out</c> via <see cref="WixHeatSettings.Output"/></li>
        ///     <li><c>-platform</c> via <see cref="WixHeatSettings.Platform"/></li>
        ///     <li><c>-pog</c> via <see cref="WixHeatSettings.ProjectOutputGroup"/></li>
        ///     <li><c>-projectname</c> via <see cref="WixHeatSettings.ProjectName"/></li>
        ///     <li><c>-scom</c> via <see cref="WixHeatSettings.SuppressComElements"/></li>
        ///     <li><c>-sfrag</c> via <see cref="WixHeatSettings.SuppressFragments"/></li>
        ///     <li><c>-srd</c> via <see cref="WixHeatSettings.SuppressRootDirectoryAsElement"/></li>
        ///     <li><c>-sreg</c> via <see cref="WixHeatSettings.SuppressRegistry"/></li>
        ///     <li><c>-suid</c> via <see cref="WixHeatSettings.SuppressUids"/></li>
        ///     <li><c>-sw</c> via <see cref="WixHeatSettings.SuppressAllWarnings"/></li>
        ///     <li><c>-sw</c> via <see cref="WixHeatSettings.SuppressWarnings"/></li>
        ///     <li><c>-svb6</c> via <see cref="WixHeatSettings.SuppressVb6ComElements"/></li>
        ///     <li><c>-t</c> via <see cref="WixHeatSettings.Transform"/></li>
        ///     <li><c>-template</c> via <see cref="WixHeatSettings.Template"/></li>
        ///     <li><c>-v</c> via <see cref="WixHeatSettings.Verbose"/></li>
        ///     <li><c>-var</c> via <see cref="WixHeatSettings.Var"/></li>
        ///     <li><c>-wixvar</c> via <see cref="WixHeatSettings.WixVar"/></li>
        ///     <li><c>-wx</c> via <see cref="WixHeatSettings.WarningsAsErrors"/></li>
        ///     <li><c>-wx</c> via <see cref="WixHeatSettings.MessageIdAsError"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(WixHeatSettings Settings, IReadOnlyCollection<Output> Output)> WixHeat(CombinatorialConfigure<WixHeatSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(WixHeat, WixLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Inscribes an installer database with information about the digital certificates its external cabs are signed with.</p>
        ///   <p>For more details, visit the <a href="http://wixtoolset.org/">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> WixInsignia(WixInsigniaSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new WixInsigniaSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Inscribes an installer database with information about the digital certificates its external cabs are signed with.</p>
        ///   <p>For more details, visit the <a href="http://wixtoolset.org/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>@</c> via <see cref="WixInsigniaSettings.ResponseFile"/></li>
        ///     <li><c>-ab</c> via <see cref="WixInsigniaSettings.Reattach"/></li>
        ///     <li><c>-ib</c> via <see cref="WixInsigniaSettings.Bundle"/></li>
        ///     <li><c>-im</c> via <see cref="WixInsigniaSettings.DatabaseFile"/></li>
        ///     <li><c>-nologo</c> via <see cref="WixInsigniaSettings.NoLogo"/></li>
        ///     <li><c>-out</c> via <see cref="WixInsigniaSettings.Output"/></li>
        ///     <li><c>-sw</c> via <see cref="WixInsigniaSettings.SuppressAllWarnings"/></li>
        ///     <li><c>-sw</c> via <see cref="WixInsigniaSettings.SuppressWarnings"/></li>
        ///     <li><c>-v</c> via <see cref="WixInsigniaSettings.Verbose"/></li>
        ///     <li><c>-wx</c> via <see cref="WixInsigniaSettings.WarningsAsErrors"/></li>
        ///     <li><c>-wx</c> via <see cref="WixInsigniaSettings.MessageIdAsError"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> WixInsignia(Configure<WixInsigniaSettings> configurator)
        {
            return WixInsignia(configurator(new WixInsigniaSettings()));
        }
        /// <summary>
        ///   <p>Inscribes an installer database with information about the digital certificates its external cabs are signed with.</p>
        ///   <p>For more details, visit the <a href="http://wixtoolset.org/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>@</c> via <see cref="WixInsigniaSettings.ResponseFile"/></li>
        ///     <li><c>-ab</c> via <see cref="WixInsigniaSettings.Reattach"/></li>
        ///     <li><c>-ib</c> via <see cref="WixInsigniaSettings.Bundle"/></li>
        ///     <li><c>-im</c> via <see cref="WixInsigniaSettings.DatabaseFile"/></li>
        ///     <li><c>-nologo</c> via <see cref="WixInsigniaSettings.NoLogo"/></li>
        ///     <li><c>-out</c> via <see cref="WixInsigniaSettings.Output"/></li>
        ///     <li><c>-sw</c> via <see cref="WixInsigniaSettings.SuppressAllWarnings"/></li>
        ///     <li><c>-sw</c> via <see cref="WixInsigniaSettings.SuppressWarnings"/></li>
        ///     <li><c>-v</c> via <see cref="WixInsigniaSettings.Verbose"/></li>
        ///     <li><c>-wx</c> via <see cref="WixInsigniaSettings.WarningsAsErrors"/></li>
        ///     <li><c>-wx</c> via <see cref="WixInsigniaSettings.MessageIdAsError"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(WixInsigniaSettings Settings, IReadOnlyCollection<Output> Output)> WixInsignia(CombinatorialConfigure<WixInsigniaSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(WixInsignia, WixLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Runs validation checks on .msi or .msm files.</p>
        ///   <p>For more details, visit the <a href="http://wixtoolset.org/">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> WixSmoke(WixSmokeSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new WixSmokeSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Runs validation checks on .msi or .msm files.</p>
        ///   <p>For more details, visit the <a href="http://wixtoolset.org/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;inputFiles&gt;</c> via <see cref="WixSmokeSettings.InputFiles"/></li>
        ///     <li><c>-cub</c> via <see cref="WixSmokeSettings.CubFile"/></li>
        ///     <li><c>-ext</c> via <see cref="WixSmokeSettings.Extension"/></li>
        ///     <li><c>-ice</c> via <see cref="WixSmokeSettings.Ice"/></li>
        ///     <li><c>-nodefault</c> via <see cref="WixSmokeSettings.NoDefault"/></li>
        ///     <li><c>-nologo</c> via <see cref="WixSmokeSettings.NoLogo"/></li>
        ///     <li><c>-notidy</c> via <see cref="WixSmokeSettings.NoTidy"/></li>
        ///     <li><c>-pdb</c> via <see cref="WixSmokeSettings.Pdb"/></li>
        ///     <li><c>-sice</c> via <see cref="WixSmokeSettings.SuppressIce"/></li>
        ///     <li><c>-sw</c> via <see cref="WixSmokeSettings.SuppressAllWarnings"/></li>
        ///     <li><c>-sw</c> via <see cref="WixSmokeSettings.SuppressWarnings"/></li>
        ///     <li><c>-v</c> via <see cref="WixSmokeSettings.Verbose"/></li>
        ///     <li><c>-wx</c> via <see cref="WixSmokeSettings.WarningsAsErrors"/></li>
        ///     <li><c>-wx</c> via <see cref="WixSmokeSettings.MessageIdAsError"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> WixSmoke(Configure<WixSmokeSettings> configurator)
        {
            return WixSmoke(configurator(new WixSmokeSettings()));
        }
        /// <summary>
        ///   <p>Runs validation checks on .msi or .msm files.</p>
        ///   <p>For more details, visit the <a href="http://wixtoolset.org/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;inputFiles&gt;</c> via <see cref="WixSmokeSettings.InputFiles"/></li>
        ///     <li><c>-cub</c> via <see cref="WixSmokeSettings.CubFile"/></li>
        ///     <li><c>-ext</c> via <see cref="WixSmokeSettings.Extension"/></li>
        ///     <li><c>-ice</c> via <see cref="WixSmokeSettings.Ice"/></li>
        ///     <li><c>-nodefault</c> via <see cref="WixSmokeSettings.NoDefault"/></li>
        ///     <li><c>-nologo</c> via <see cref="WixSmokeSettings.NoLogo"/></li>
        ///     <li><c>-notidy</c> via <see cref="WixSmokeSettings.NoTidy"/></li>
        ///     <li><c>-pdb</c> via <see cref="WixSmokeSettings.Pdb"/></li>
        ///     <li><c>-sice</c> via <see cref="WixSmokeSettings.SuppressIce"/></li>
        ///     <li><c>-sw</c> via <see cref="WixSmokeSettings.SuppressAllWarnings"/></li>
        ///     <li><c>-sw</c> via <see cref="WixSmokeSettings.SuppressWarnings"/></li>
        ///     <li><c>-v</c> via <see cref="WixSmokeSettings.Verbose"/></li>
        ///     <li><c>-wx</c> via <see cref="WixSmokeSettings.WarningsAsErrors"/></li>
        ///     <li><c>-wx</c> via <see cref="WixSmokeSettings.MessageIdAsError"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(WixSmokeSettings Settings, IReadOnlyCollection<Output> Output)> WixSmoke(CombinatorialConfigure<WixSmokeSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(WixSmoke, WixLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Author and run declarative unit tests for custom actions.</p>
        ///   <p>For more details, visit the <a href="http://wixtoolset.org/">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> WixNit(WixNitSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new WixNitSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Author and run declarative unit tests for custom actions.</p>
        ///   <p>For more details, visit the <a href="http://wixtoolset.org/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;inputFiles&gt;</c> via <see cref="WixNitSettings.InputFiles"/></li>
        ///     <li><c>-nologo</c> via <see cref="WixNitSettings.NoLogo"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> WixNit(Configure<WixNitSettings> configurator)
        {
            return WixNit(configurator(new WixNitSettings()));
        }
        /// <summary>
        ///   <p>Author and run declarative unit tests for custom actions.</p>
        ///   <p>For more details, visit the <a href="http://wixtoolset.org/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;inputFiles&gt;</c> via <see cref="WixNitSettings.InputFiles"/></li>
        ///     <li><c>-nologo</c> via <see cref="WixNitSettings.NoLogo"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(WixNitSettings Settings, IReadOnlyCollection<Output> Output)> WixNit(CombinatorialConfigure<WixNitSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(WixNit, WixLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Creates a WiX source file that consumes unit tests declared in one or more WiX source files.</p>
        ///   <p>For more details, visit the <a href="http://wixtoolset.org/">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> WixLux(WixLuxSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new WixLuxSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Creates a WiX source file that consumes unit tests declared in one or more WiX source files.</p>
        ///   <p>For more details, visit the <a href="http://wixtoolset.org/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;inputFiles&gt;</c> via <see cref="WixLuxSettings.InputFiles"/></li>
        ///     <li><c>-ext</c> via <see cref="WixLuxSettings.Extension"/></li>
        ///     <li><c>-nologo</c> via <see cref="WixLuxSettings.NoLogo"/></li>
        ///     <li><c>-out</c> via <see cref="WixLuxSettings.Output"/></li>
        ///     <li><c>-v</c> via <see cref="WixLuxSettings.Verbose"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> WixLux(Configure<WixLuxSettings> configurator)
        {
            return WixLux(configurator(new WixLuxSettings()));
        }
        /// <summary>
        ///   <p>Creates a WiX source file that consumes unit tests declared in one or more WiX source files.</p>
        ///   <p>For more details, visit the <a href="http://wixtoolset.org/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;inputFiles&gt;</c> via <see cref="WixLuxSettings.InputFiles"/></li>
        ///     <li><c>-ext</c> via <see cref="WixLuxSettings.Extension"/></li>
        ///     <li><c>-nologo</c> via <see cref="WixLuxSettings.NoLogo"/></li>
        ///     <li><c>-out</c> via <see cref="WixLuxSettings.Output"/></li>
        ///     <li><c>-v</c> via <see cref="WixLuxSettings.Verbose"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(WixLuxSettings Settings, IReadOnlyCollection<Output> Output)> WixLux(CombinatorialConfigure<WixLuxSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(WixLux, WixLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Combines multiple .wixobj files into libraries that can be consumed by Light.</p>
        ///   <p>For more details, visit the <a href="http://wixtoolset.org/">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> WixLit(WixLitSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new WixLitSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Combines multiple .wixobj files into libraries that can be consumed by Light.</p>
        ///   <p>For more details, visit the <a href="http://wixtoolset.org/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;inputFiles&gt;</c> via <see cref="WixLitSettings.InputFiles"/></li>
        ///     <li><c>@</c> via <see cref="WixLitSettings.ResponseFile"/></li>
        ///     <li><c>-b</c> via <see cref="WixLitSettings.Bind"/></li>
        ///     <li><c>-bf</c> via <see cref="WixLitSettings.BindFiles"/></li>
        ///     <li><c>-ext</c> via <see cref="WixLitSettings.Extension"/></li>
        ///     <li><c>-loc</c> via <see cref="WixLitSettings.Localization"/></li>
        ///     <li><c>-nologo</c> via <see cref="WixLitSettings.NoLogo"/></li>
        ///     <li><c>-out</c> via <see cref="WixLitSettings.Output"/></li>
        ///     <li><c>-ss</c> via <see cref="WixLitSettings.SuppressSchemaValidation"/></li>
        ///     <li><c>-sv</c> via <see cref="WixLitSettings.SuppressVersionMismatchCheck"/></li>
        ///     <li><c>-sw</c> via <see cref="WixLitSettings.SuppressAllWarnings"/></li>
        ///     <li><c>-sw</c> via <see cref="WixLitSettings.SuppressWarnings"/></li>
        ///     <li><c>-v</c> via <see cref="WixLitSettings.Verbose"/></li>
        ///     <li><c>-wx</c> via <see cref="WixLitSettings.WarningsAsErrors"/></li>
        ///     <li><c>-wx</c> via <see cref="WixLitSettings.MessageIdAsError"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> WixLit(Configure<WixLitSettings> configurator)
        {
            return WixLit(configurator(new WixLitSettings()));
        }
        /// <summary>
        ///   <p>Combines multiple .wixobj files into libraries that can be consumed by Light.</p>
        ///   <p>For more details, visit the <a href="http://wixtoolset.org/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;inputFiles&gt;</c> via <see cref="WixLitSettings.InputFiles"/></li>
        ///     <li><c>@</c> via <see cref="WixLitSettings.ResponseFile"/></li>
        ///     <li><c>-b</c> via <see cref="WixLitSettings.Bind"/></li>
        ///     <li><c>-bf</c> via <see cref="WixLitSettings.BindFiles"/></li>
        ///     <li><c>-ext</c> via <see cref="WixLitSettings.Extension"/></li>
        ///     <li><c>-loc</c> via <see cref="WixLitSettings.Localization"/></li>
        ///     <li><c>-nologo</c> via <see cref="WixLitSettings.NoLogo"/></li>
        ///     <li><c>-out</c> via <see cref="WixLitSettings.Output"/></li>
        ///     <li><c>-ss</c> via <see cref="WixLitSettings.SuppressSchemaValidation"/></li>
        ///     <li><c>-sv</c> via <see cref="WixLitSettings.SuppressVersionMismatchCheck"/></li>
        ///     <li><c>-sw</c> via <see cref="WixLitSettings.SuppressAllWarnings"/></li>
        ///     <li><c>-sw</c> via <see cref="WixLitSettings.SuppressWarnings"/></li>
        ///     <li><c>-v</c> via <see cref="WixLitSettings.Verbose"/></li>
        ///     <li><c>-wx</c> via <see cref="WixLitSettings.WarningsAsErrors"/></li>
        ///     <li><c>-wx</c> via <see cref="WixLitSettings.MessageIdAsError"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(WixLitSettings Settings, IReadOnlyCollection<Output> Output)> WixLit(CombinatorialConfigure<WixLitSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(WixLit, WixLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Enforces standards on WiX source files. WixCop can also be used to assist in converting a set of WiX source files created using an older version of WiX to the latest version of WiX.</p>
        ///   <p>For more details, visit the <a href="http://wixtoolset.org/">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> WixCop(WixCopSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new WixCopSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Enforces standards on WiX source files. WixCop can also be used to assist in converting a set of WiX source files created using an older version of WiX to the latest version of WiX.</p>
        ///   <p>For more details, visit the <a href="http://wixtoolset.org/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;inputFiles&gt;</c> via <see cref="WixCopSettings.InputFiles"/></li>
        ///     <li><c>-f</c> via <see cref="WixCopSettings.AutoFix"/></li>
        ///     <li><c>-indent</c> via <see cref="WixCopSettings.Indentation"/></li>
        ///     <li><c>-nologo</c> via <see cref="WixCopSettings.NoLogo"/></li>
        ///     <li><c>-s</c> via <see cref="WixCopSettings.Search"/></li>
        ///     <li><c>-set1</c> via <see cref="WixCopSettings.PrimarySettingsFile"/></li>
        ///     <li><c>-set2</c> via <see cref="WixCopSettings.SecondarySettingsFile"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> WixCop(Configure<WixCopSettings> configurator)
        {
            return WixCop(configurator(new WixCopSettings()));
        }
        /// <summary>
        ///   <p>Enforces standards on WiX source files. WixCop can also be used to assist in converting a set of WiX source files created using an older version of WiX to the latest version of WiX.</p>
        ///   <p>For more details, visit the <a href="http://wixtoolset.org/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;inputFiles&gt;</c> via <see cref="WixCopSettings.InputFiles"/></li>
        ///     <li><c>-f</c> via <see cref="WixCopSettings.AutoFix"/></li>
        ///     <li><c>-indent</c> via <see cref="WixCopSettings.Indentation"/></li>
        ///     <li><c>-nologo</c> via <see cref="WixCopSettings.NoLogo"/></li>
        ///     <li><c>-s</c> via <see cref="WixCopSettings.Search"/></li>
        ///     <li><c>-set1</c> via <see cref="WixCopSettings.PrimarySettingsFile"/></li>
        ///     <li><c>-set2</c> via <see cref="WixCopSettings.SecondarySettingsFile"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(WixCopSettings Settings, IReadOnlyCollection<Output> Output)> WixCop(CombinatorialConfigure<WixCopSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(WixCop, WixLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Links and binds one or more .wixobj files and creates a Windows Installer database (.msi or .msm). When necessary, Light will also create cabinets and embed streams into the Windows Installer database it creates.</p>
        ///   <p>For more details, visit the <a href="http://wixtoolset.org/">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> WixLight(WixLightSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new WixLightSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Links and binds one or more .wixobj files and creates a Windows Installer database (.msi or .msm). When necessary, Light will also create cabinets and embed streams into the Windows Installer database it creates.</p>
        ///   <p>For more details, visit the <a href="http://wixtoolset.org/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;inputFiles&gt;</c> via <see cref="WixLightSettings.InputFiles"/></li>
        ///     <li><c>@</c> via <see cref="WixLightSettings.ResponseFile"/></li>
        ///     <li><c>-b</c> via <see cref="WixLightSettings.BinderPath"/></li>
        ///     <li><c>-bcgg</c> via <see cref="WixLightSettings.BackwardsCompatableGuids"/></li>
        ///     <li><c>-cc</c> via <see cref="WixLightSettings.CachePath"/></li>
        ///     <li><c>-ct</c> via <see cref="WixLightSettings.Threads"/></li>
        ///     <li><c>-cub</c> via <see cref="WixLightSettings.CubFile"/></li>
        ///     <li><c>-cultures</c> via <see cref="WixLightSettings.Cultures"/></li>
        ///     <li><c>-d</c> via <see cref="WixLightSettings.Parameter"/></li>
        ///     <li><c>-dcl</c> via <see cref="WixLightSettings.CompressionLevel"/></li>
        ///     <li><c>-eav</c> via <see cref="WixLightSettings.ExactAssemblyVersions"/></li>
        ///     <li><c>-ext</c> via <see cref="WixLightSettings.Extension"/></li>
        ///     <li><c>-fv</c> via <see cref="WixLightSettings.AddFileVersionEntry"/></li>
        ///     <li><c>-ice</c> via <see cref="WixLightSettings.Ice"/></li>
        ///     <li><c>-loc</c> via <see cref="WixLightSettings.Localization"/></li>
        ///     <li><c>-nologo</c> via <see cref="WixLightSettings.NoLogo"/></li>
        ///     <li><c>-notidy</c> via <see cref="WixLightSettings.NoTidy"/></li>
        ///     <li><c>-out</c> via <see cref="WixLightSettings.Output"/></li>
        ///     <li><c>-pdbout</c> via <see cref="WixLightSettings.PdbOut"/></li>
        ///     <li><c>-pedantic</c> via <see cref="WixLightSettings.Pedantic"/></li>
        ///     <li><c>-reusecab</c> via <see cref="WixLightSettings.ReuseCab"/></li>
        ///     <li><c>-sa</c> via <see cref="WixLightSettings.SuppressAssemblies"/></li>
        ///     <li><c>-sacl</c> via <see cref="WixLightSettings.SuppressResettingAcls"/></li>
        ///     <li><c>-sf</c> via <see cref="WixLightSettings.SuppressFiles"/></li>
        ///     <li><c>-sh</c> via <see cref="WixLightSettings.SuppressFileInfo"/></li>
        ///     <li><c>-sice</c> via <see cref="WixLightSettings.SuppressIce"/></li>
        ///     <li><c>-sl</c> via <see cref="WixLightSettings.SuppressLayout"/></li>
        ///     <li><c>-sloc</c> via <see cref="WixLightSettings.SuppressLocalization"/></li>
        ///     <li><c>-spdb</c> via <see cref="WixLightSettings.SuppressWixPdb"/></li>
        ///     <li><c>-spsd</c> via <see cref="WixLightSettings.SuppressPatchSequenceData"/></li>
        ///     <li><c>-sw</c> via <see cref="WixLightSettings.SuppressAllWarnings"/></li>
        ///     <li><c>-sw</c> via <see cref="WixLightSettings.SuppressWarnings"/></li>
        ///     <li><c>-sval</c> via <see cref="WixLightSettings.SuppressValidation"/></li>
        ///     <li><c>-v</c> via <see cref="WixLightSettings.Verbose"/></li>
        ///     <li><c>-wx</c> via <see cref="WixLightSettings.WarningsAsErrors"/></li>
        ///     <li><c>-wx</c> via <see cref="WixLightSettings.MessageIdAsError"/></li>
        ///     <li><c>-xo</c> via <see cref="WixLightSettings.WixOutFormat"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> WixLight(Configure<WixLightSettings> configurator)
        {
            return WixLight(configurator(new WixLightSettings()));
        }
        /// <summary>
        ///   <p>Links and binds one or more .wixobj files and creates a Windows Installer database (.msi or .msm). When necessary, Light will also create cabinets and embed streams into the Windows Installer database it creates.</p>
        ///   <p>For more details, visit the <a href="http://wixtoolset.org/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;inputFiles&gt;</c> via <see cref="WixLightSettings.InputFiles"/></li>
        ///     <li><c>@</c> via <see cref="WixLightSettings.ResponseFile"/></li>
        ///     <li><c>-b</c> via <see cref="WixLightSettings.BinderPath"/></li>
        ///     <li><c>-bcgg</c> via <see cref="WixLightSettings.BackwardsCompatableGuids"/></li>
        ///     <li><c>-cc</c> via <see cref="WixLightSettings.CachePath"/></li>
        ///     <li><c>-ct</c> via <see cref="WixLightSettings.Threads"/></li>
        ///     <li><c>-cub</c> via <see cref="WixLightSettings.CubFile"/></li>
        ///     <li><c>-cultures</c> via <see cref="WixLightSettings.Cultures"/></li>
        ///     <li><c>-d</c> via <see cref="WixLightSettings.Parameter"/></li>
        ///     <li><c>-dcl</c> via <see cref="WixLightSettings.CompressionLevel"/></li>
        ///     <li><c>-eav</c> via <see cref="WixLightSettings.ExactAssemblyVersions"/></li>
        ///     <li><c>-ext</c> via <see cref="WixLightSettings.Extension"/></li>
        ///     <li><c>-fv</c> via <see cref="WixLightSettings.AddFileVersionEntry"/></li>
        ///     <li><c>-ice</c> via <see cref="WixLightSettings.Ice"/></li>
        ///     <li><c>-loc</c> via <see cref="WixLightSettings.Localization"/></li>
        ///     <li><c>-nologo</c> via <see cref="WixLightSettings.NoLogo"/></li>
        ///     <li><c>-notidy</c> via <see cref="WixLightSettings.NoTidy"/></li>
        ///     <li><c>-out</c> via <see cref="WixLightSettings.Output"/></li>
        ///     <li><c>-pdbout</c> via <see cref="WixLightSettings.PdbOut"/></li>
        ///     <li><c>-pedantic</c> via <see cref="WixLightSettings.Pedantic"/></li>
        ///     <li><c>-reusecab</c> via <see cref="WixLightSettings.ReuseCab"/></li>
        ///     <li><c>-sa</c> via <see cref="WixLightSettings.SuppressAssemblies"/></li>
        ///     <li><c>-sacl</c> via <see cref="WixLightSettings.SuppressResettingAcls"/></li>
        ///     <li><c>-sf</c> via <see cref="WixLightSettings.SuppressFiles"/></li>
        ///     <li><c>-sh</c> via <see cref="WixLightSettings.SuppressFileInfo"/></li>
        ///     <li><c>-sice</c> via <see cref="WixLightSettings.SuppressIce"/></li>
        ///     <li><c>-sl</c> via <see cref="WixLightSettings.SuppressLayout"/></li>
        ///     <li><c>-sloc</c> via <see cref="WixLightSettings.SuppressLocalization"/></li>
        ///     <li><c>-spdb</c> via <see cref="WixLightSettings.SuppressWixPdb"/></li>
        ///     <li><c>-spsd</c> via <see cref="WixLightSettings.SuppressPatchSequenceData"/></li>
        ///     <li><c>-sw</c> via <see cref="WixLightSettings.SuppressAllWarnings"/></li>
        ///     <li><c>-sw</c> via <see cref="WixLightSettings.SuppressWarnings"/></li>
        ///     <li><c>-sval</c> via <see cref="WixLightSettings.SuppressValidation"/></li>
        ///     <li><c>-v</c> via <see cref="WixLightSettings.Verbose"/></li>
        ///     <li><c>-wx</c> via <see cref="WixLightSettings.WarningsAsErrors"/></li>
        ///     <li><c>-wx</c> via <see cref="WixLightSettings.MessageIdAsError"/></li>
        ///     <li><c>-xo</c> via <see cref="WixLightSettings.WixOutFormat"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(WixLightSettings Settings, IReadOnlyCollection<Output> Output)> WixLight(CombinatorialConfigure<WixLightSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(WixLight, WixLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Performs a diff to generate a transform (.wixmst or .mst) for XML outputs (.wixout or .wixpdb) or .msi files.</p>
        ///   <p>For more details, visit the <a href="http://wixtoolset.org/">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> WixTorch(WixTorchSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new WixTorchSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Performs a diff to generate a transform (.wixmst or .mst) for XML outputs (.wixout or .wixpdb) or .msi files.</p>
        ///   <p>For more details, visit the <a href="http://wixtoolset.org/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;targetInput&gt;</c> via <see cref="WixTorchSettings.TargetInput"/></li>
        ///     <li><c>&lt;updatedInput&gt;</c> via <see cref="WixTorchSettings.UpdatedInput"/></li>
        ///     <li><c>@</c> via <see cref="WixTorchSettings.ResponseFile"/></li>
        ///     <li><c>-a</c> via <see cref="WixTorchSettings.AdminImage"/></li>
        ///     <li><c>-ax</c> via <see cref="WixTorchSettings.AdminImageWithExtraction"/></li>
        ///     <li><c>-ext</c> via <see cref="WixTorchSettings.Extension"/></li>
        ///     <li><c>-nologo</c> via <see cref="WixTorchSettings.NoLogo"/></li>
        ///     <li><c>-notidy</c> via <see cref="WixTorchSettings.NoTidy"/></li>
        ///     <li><c>-out</c> via <see cref="WixTorchSettings.Output"/></li>
        ///     <li><c>-p</c> via <see cref="WixTorchSettings.Preserve"/></li>
        ///     <li><c>-pedantic</c> via <see cref="WixTorchSettings.Pedantic"/></li>
        ///     <li><c>-serr</c> via <see cref="WixTorchSettings.SuppressErrors"/></li>
        ///     <li><c>-sw</c> via <see cref="WixTorchSettings.SuppressAllWarnings"/></li>
        ///     <li><c>-sw</c> via <see cref="WixTorchSettings.SuppressWarnings"/></li>
        ///     <li><c>-t</c> via <see cref="WixTorchSettings.TransformType"/></li>
        ///     <li><c>-v</c> via <see cref="WixTorchSettings.Verbose"/></li>
        ///     <li><c>-val</c> via <see cref="WixTorchSettings.ValidationFlags"/></li>
        ///     <li><c>-wx</c> via <see cref="WixTorchSettings.WarningsAsErrors"/></li>
        ///     <li><c>-wx</c> via <see cref="WixTorchSettings.MessageIdAsError"/></li>
        ///     <li><c>-x</c> via <see cref="WixTorchSettings.ExtractBinariesToPath"/></li>
        ///     <li><c>-xi</c> via <see cref="WixTorchSettings.WixInputFormat"/></li>
        ///     <li><c>-xo</c> via <see cref="WixTorchSettings.Wixout"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> WixTorch(Configure<WixTorchSettings> configurator)
        {
            return WixTorch(configurator(new WixTorchSettings()));
        }
        /// <summary>
        ///   <p>Performs a diff to generate a transform (.wixmst or .mst) for XML outputs (.wixout or .wixpdb) or .msi files.</p>
        ///   <p>For more details, visit the <a href="http://wixtoolset.org/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;targetInput&gt;</c> via <see cref="WixTorchSettings.TargetInput"/></li>
        ///     <li><c>&lt;updatedInput&gt;</c> via <see cref="WixTorchSettings.UpdatedInput"/></li>
        ///     <li><c>@</c> via <see cref="WixTorchSettings.ResponseFile"/></li>
        ///     <li><c>-a</c> via <see cref="WixTorchSettings.AdminImage"/></li>
        ///     <li><c>-ax</c> via <see cref="WixTorchSettings.AdminImageWithExtraction"/></li>
        ///     <li><c>-ext</c> via <see cref="WixTorchSettings.Extension"/></li>
        ///     <li><c>-nologo</c> via <see cref="WixTorchSettings.NoLogo"/></li>
        ///     <li><c>-notidy</c> via <see cref="WixTorchSettings.NoTidy"/></li>
        ///     <li><c>-out</c> via <see cref="WixTorchSettings.Output"/></li>
        ///     <li><c>-p</c> via <see cref="WixTorchSettings.Preserve"/></li>
        ///     <li><c>-pedantic</c> via <see cref="WixTorchSettings.Pedantic"/></li>
        ///     <li><c>-serr</c> via <see cref="WixTorchSettings.SuppressErrors"/></li>
        ///     <li><c>-sw</c> via <see cref="WixTorchSettings.SuppressAllWarnings"/></li>
        ///     <li><c>-sw</c> via <see cref="WixTorchSettings.SuppressWarnings"/></li>
        ///     <li><c>-t</c> via <see cref="WixTorchSettings.TransformType"/></li>
        ///     <li><c>-v</c> via <see cref="WixTorchSettings.Verbose"/></li>
        ///     <li><c>-val</c> via <see cref="WixTorchSettings.ValidationFlags"/></li>
        ///     <li><c>-wx</c> via <see cref="WixTorchSettings.WarningsAsErrors"/></li>
        ///     <li><c>-wx</c> via <see cref="WixTorchSettings.MessageIdAsError"/></li>
        ///     <li><c>-x</c> via <see cref="WixTorchSettings.ExtractBinariesToPath"/></li>
        ///     <li><c>-xi</c> via <see cref="WixTorchSettings.WixInputFormat"/></li>
        ///     <li><c>-xo</c> via <see cref="WixTorchSettings.Wixout"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(WixTorchSettings Settings, IReadOnlyCollection<Output> Output)> WixTorch(CombinatorialConfigure<WixTorchSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(WixTorch, WixLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Takes an XML output patch file (.wixmsp) and one or more XML transform files (.wixmst) and produces an .msp file.</p>
        ///   <p>For more details, visit the <a href="http://wixtoolset.org/">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> WixPyro(WixPyroSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new WixPyroSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Takes an XML output patch file (.wixmsp) and one or more XML transform files (.wixmst) and produces an .msp file.</p>
        ///   <p>For more details, visit the <a href="http://wixtoolset.org/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>@</c> via <see cref="WixPyroSettings.ResponseFile"/></li>
        ///     <li><c>-aet</c> via <see cref="WixPyroSettings.AllowEmptyProductTransforms"/></li>
        ///     <li><c>-bt</c> via <see cref="WixPyroSettings.BindTargetPath"/></li>
        ///     <li><c>-bu</c> via <see cref="WixPyroSettings.BindUpdatePath"/></li>
        ///     <li><c>-cc</c> via <see cref="WixPyroSettings.CachePath"/></li>
        ///     <li><c>-delta</c> via <see cref="WixPyroSettings.CreateDeltaPatch"/></li>
        ///     <li><c>-ext</c> via <see cref="WixPyroSettings.Extension"/></li>
        ///     <li><c>-fv</c> via <see cref="WixPyroSettings.UpdateFileVersionEntries"/></li>
        ///     <li><c>-nologo</c> via <see cref="WixPyroSettings.NoLogo"/></li>
        ///     <li><c>-notidy</c> via <see cref="WixPyroSettings.NoTidy"/></li>
        ///     <li><c>-out</c> via <see cref="WixPyroSettings.Output"/></li>
        ///     <li><c>-pdbout</c> via <see cref="WixPyroSettings.PdbOut"/></li>
        ///     <li><c>-reusecab</c> via <see cref="WixPyroSettings.ReuseCab"/></li>
        ///     <li><c>-sa</c> via <see cref="WixPyroSettings.SuppressAssemblies"/></li>
        ///     <li><c>-sf</c> via <see cref="WixPyroSettings.SuppressFiles"/></li>
        ///     <li><c>-sh</c> via <see cref="WixPyroSettings.SuppressFileInfo"/></li>
        ///     <li><c>-spdb</c> via <see cref="WixPyroSettings.SuppressWixPdb"/></li>
        ///     <li><c>-sw</c> via <see cref="WixPyroSettings.SuppressAllWarnings"/></li>
        ///     <li><c>-sw</c> via <see cref="WixPyroSettings.SuppressWarnings"/></li>
        ///     <li><c>-t</c> via <see cref="WixPyroSettings.BaselineAndTransform"/></li>
        ///     <li><c>-v</c> via <see cref="WixPyroSettings.Verbose"/></li>
        ///     <li><c>-wx</c> via <see cref="WixPyroSettings.WarningsAsErrors"/></li>
        ///     <li><c>-wx</c> via <see cref="WixPyroSettings.MessageIdAsError"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> WixPyro(Configure<WixPyroSettings> configurator)
        {
            return WixPyro(configurator(new WixPyroSettings()));
        }
        /// <summary>
        ///   <p>Takes an XML output patch file (.wixmsp) and one or more XML transform files (.wixmst) and produces an .msp file.</p>
        ///   <p>For more details, visit the <a href="http://wixtoolset.org/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>@</c> via <see cref="WixPyroSettings.ResponseFile"/></li>
        ///     <li><c>-aet</c> via <see cref="WixPyroSettings.AllowEmptyProductTransforms"/></li>
        ///     <li><c>-bt</c> via <see cref="WixPyroSettings.BindTargetPath"/></li>
        ///     <li><c>-bu</c> via <see cref="WixPyroSettings.BindUpdatePath"/></li>
        ///     <li><c>-cc</c> via <see cref="WixPyroSettings.CachePath"/></li>
        ///     <li><c>-delta</c> via <see cref="WixPyroSettings.CreateDeltaPatch"/></li>
        ///     <li><c>-ext</c> via <see cref="WixPyroSettings.Extension"/></li>
        ///     <li><c>-fv</c> via <see cref="WixPyroSettings.UpdateFileVersionEntries"/></li>
        ///     <li><c>-nologo</c> via <see cref="WixPyroSettings.NoLogo"/></li>
        ///     <li><c>-notidy</c> via <see cref="WixPyroSettings.NoTidy"/></li>
        ///     <li><c>-out</c> via <see cref="WixPyroSettings.Output"/></li>
        ///     <li><c>-pdbout</c> via <see cref="WixPyroSettings.PdbOut"/></li>
        ///     <li><c>-reusecab</c> via <see cref="WixPyroSettings.ReuseCab"/></li>
        ///     <li><c>-sa</c> via <see cref="WixPyroSettings.SuppressAssemblies"/></li>
        ///     <li><c>-sf</c> via <see cref="WixPyroSettings.SuppressFiles"/></li>
        ///     <li><c>-sh</c> via <see cref="WixPyroSettings.SuppressFileInfo"/></li>
        ///     <li><c>-spdb</c> via <see cref="WixPyroSettings.SuppressWixPdb"/></li>
        ///     <li><c>-sw</c> via <see cref="WixPyroSettings.SuppressAllWarnings"/></li>
        ///     <li><c>-sw</c> via <see cref="WixPyroSettings.SuppressWarnings"/></li>
        ///     <li><c>-t</c> via <see cref="WixPyroSettings.BaselineAndTransform"/></li>
        ///     <li><c>-v</c> via <see cref="WixPyroSettings.Verbose"/></li>
        ///     <li><c>-wx</c> via <see cref="WixPyroSettings.WarningsAsErrors"/></li>
        ///     <li><c>-wx</c> via <see cref="WixPyroSettings.MessageIdAsError"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(WixPyroSettings Settings, IReadOnlyCollection<Output> Output)> WixPyro(CombinatorialConfigure<WixPyroSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(WixPyro, WixLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region WixCandleSettings
    /// <summary>
    ///   Used within <see cref="WixTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class WixCandleSettings : CandleBaseSettings
    {
        /// <summary>
        ///   Path to the Wix executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? GetToolPath();
        public override Action<OutputType, string> CustomLogger => WixTasks.WixLogger;
        /// <summary>
        ///   set architecture defaults for package, components, etc. values: x86, x64, or ia64 (default: x86)
        /// </summary>
        public virtual Architecture Architecture { get; internal set; }
        /// <summary>
        ///   enables FIPS compliant algorithms
        /// </summary>
        public virtual bool? Fips { get; internal set; }
        /// <summary>
        ///   add to include search path
        /// </summary>
        public virtual IReadOnlyList<string> Include => IncludeInternal.AsReadOnly();
        internal List<string> IncludeInternal { get; set; } = new List<string>();
        /// <summary>
        ///   preprocess to a file
        /// </summary>
        public virtual string PreprocessToFile { get; internal set; }
        /// <summary>
        ///   suppress all warnings
        /// </summary>
        public virtual bool? SuppressAllWarnings { get; internal set; }
        /// <summary>
        ///   suppress a specific message ID
        /// </summary>
        public virtual IReadOnlyList<int> SuppressWarnings => SuppressWarningsInternal.AsReadOnly();
        internal List<int> SuppressWarningsInternal { get; set; } = new List<int>();
        /// <summary>
        ///   treat all warnings as an error
        /// </summary>
        public virtual bool? WarningsAsErrors { get; internal set; }
        /// <summary>
        ///   treat a specific message ID as an error
        /// </summary>
        public virtual IReadOnlyList<int> MessageIdAsError => MessageIdAsErrorInternal.AsReadOnly();
        internal List<int> MessageIdAsErrorInternal { get; set; } = new List<int>();
        /// <summary>
        ///    extension assembly or 'class, assembly'
        /// </summary>
        public virtual IReadOnlyList<string> Extension => ExtensionInternal.AsReadOnly();
        internal List<string> ExtensionInternal { get; set; } = new List<string>();
        /// <summary>
        ///   response file
        /// </summary>
        public virtual string ResponseFile { get; internal set; }
        /// <summary>
        ///   input files to process
        /// </summary>
        public virtual IReadOnlyList<string> InputFiles => InputFilesInternal.AsReadOnly();
        internal List<string> InputFilesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   specify output file (default: write to current directory)
        /// </summary>
        public virtual string Output { get; internal set; }
        /// <summary>
        ///   skip printing logo information
        /// </summary>
        public virtual bool? NoLogo { get; internal set; }
        /// <summary>
        ///   verbose output
        /// </summary>
        public virtual bool? Verbose { get; internal set; }
        /// <summary>
        ///   show pedantic messages
        /// </summary>
        public virtual bool? Pedantic { get; internal set; }
        /// <summary>
        ///   define a parameter for the preprocessor
        /// </summary>
        public virtual IReadOnlyDictionary<string, string> Parameter => ParameterInternal.AsReadOnly();
        internal Dictionary<string, string> ParameterInternal { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("-arch {value}", Architecture)
              .Add("-fips", Fips)
              .Add("-I{value}", Include)
              .Add("-p{value}", PreprocessToFile)
              .Add("-sw", SuppressAllWarnings)
              .Add("-sw{value}", SuppressWarnings)
              .Add("-wx", WarningsAsErrors)
              .Add("-wx{value}", MessageIdAsError)
              .Add("-ext {value}", Extension)
              .Add("@{value}", ResponseFile)
              .Add("{value}", InputFiles)
              .Add("-out {value}", Output)
              .Add("-nologo", NoLogo)
              .Add("-v", Verbose)
              .Add("-pedantic", Pedantic)
              .Add("-d{value}", Parameter, "{key}={value}");
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region WixHeatSettings
    /// <summary>
    ///   Used within <see cref="WixTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class WixHeatSettings : HeatBaseSettings
    {
        /// <summary>
        ///   Path to the Wix executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? GetToolPath();
        public override Action<OutputType, string> CustomLogger => WixTasks.WixLogger;
        /// <summary>
        ///   harvest type
        /// </summary>
        public virtual HarvestType Type { get; internal set; }
        /// <summary>
        ///   harvest source
        /// </summary>
        public virtual string Source { get; internal set; }
        /// <summary>
        ///   WXS source file
        /// </summary>
        public virtual string SourceFile { get; internal set; }
        /// <summary>
        ///   autogenerate component guids at compile time
        /// </summary>
        public virtual bool? AutogenerateComponentGuids { get; internal set; }
        /// <summary>
        ///   component group name (cannot contain spaces e.g -cg MyComponentGroup)
        /// </summary>
        public virtual string ComponentGroup { get; internal set; }
        /// <summary>
        ///   configuration to set when harvesting the project
        /// </summary>
        public virtual string Configuration { get; internal set; }
        /// <summary>
        ///   overridden directory id for generated directory elements
        /// </summary>
        public virtual string DirectoryId { get; internal set; }
        /// <summary>
        ///   directory reference to root directories (cannot contain spaces e.g. -dr MyAppDirRef)
        /// </summary>
        public virtual string RootDirectoryReference { get; internal set; }
        /// <summary>
        ///   generated guids are not in brackets
        /// </summary>
        public virtual bool? NoBracketGuids { get; internal set; }
        /// <summary>
        ///   specify what elements to generate
        /// </summary>
        public virtual Element GenerateElement { get; internal set; }
        /// <summary>
        ///   generate guids now
        /// </summary>
        public virtual bool? GenerateGuidsNow { get; internal set; }
        /// <summary>
        ///   indentation multiple
        /// </summary>
        public virtual int? Indentation { get; internal set; }
        /// <summary>
        ///   keep empty directories
        /// </summary>
        public virtual bool? KeepEmptyDirectories { get; internal set; }
        /// <summary>
        ///   platform to set when harvesting the project
        /// </summary>
        public virtual string Platform { get; internal set; }
        /// <summary>
        ///   specify output group of VS project
        /// </summary>
        public virtual IReadOnlyList<ProjectOutputGroup> ProjectOutputGroup => ProjectOutputGroupInternal.AsReadOnly();
        internal List<ProjectOutputGroup> ProjectOutputGroupInternal { get; set; } = new List<ProjectOutputGroup>();
        /// <summary>
        ///   overridden project name to use in variables
        /// </summary>
        public virtual string ProjectName { get; internal set; }
        /// <summary>
        ///   suppress COM elements
        /// </summary>
        public virtual bool? SuppressComElements { get; internal set; }
        /// <summary>
        ///   suppress fragments
        /// </summary>
        public virtual bool? SuppressFragments { get; internal set; }
        /// <summary>
        ///   suppress harvesting the root directory as an element
        /// </summary>
        public virtual bool? SuppressRootDirectoryAsElement { get; internal set; }
        /// <summary>
        ///   suppress registry harvesting
        /// </summary>
        public virtual bool? SuppressRegistry { get; internal set; }
        /// <summary>
        ///   suppress unique identifiers for files, components, and directories
        /// </summary>
        public virtual bool? SuppressUids { get; internal set; }
        /// <summary>
        ///   suppress VB6 COM elements
        /// </summary>
        public virtual bool? SuppressVb6ComElements { get; internal set; }
        /// <summary>
        ///   transform harvested output with XSL file
        /// </summary>
        public virtual string Transform { get; internal set; }
        /// <summary>
        ///   use template, one of: fragment,module,product
        /// </summary>
        public virtual Template Template { get; internal set; }
        /// <summary>
        ///   substitute File/@Source="SourceDir" with a preprocessor or a wix variable (e.g. -var var.MySource will become File/@Source="$(var.MySource)\myfile.txt" and -var wix.MySource will become File/@Source="!(wix.MySource)\myfile.txt"
        /// </summary>
        public virtual string Var { get; internal set; }
        /// <summary>
        ///   generate binder variables instead of preprocessor variables
        /// </summary>
        public virtual bool? WixVar { get; internal set; }
        /// <summary>
        ///   suppress all warnings
        /// </summary>
        public virtual bool? SuppressAllWarnings { get; internal set; }
        /// <summary>
        ///   suppress a specific message ID
        /// </summary>
        public virtual IReadOnlyList<int> SuppressWarnings => SuppressWarningsInternal.AsReadOnly();
        internal List<int> SuppressWarningsInternal { get; set; } = new List<int>();
        /// <summary>
        ///   treat all warnings as an error
        /// </summary>
        public virtual bool? WarningsAsErrors { get; internal set; }
        /// <summary>
        ///   treat a specific message ID as an error
        /// </summary>
        public virtual IReadOnlyList<int> MessageIdAsError => MessageIdAsErrorInternal.AsReadOnly();
        internal List<int> MessageIdAsErrorInternal { get; set; } = new List<int>();
        /// <summary>
        ///    extension assembly or 'class, assembly'
        /// </summary>
        public virtual IReadOnlyList<string> Extension => ExtensionInternal.AsReadOnly();
        internal List<string> ExtensionInternal { get; set; } = new List<string>();
        /// <summary>
        ///   specify output file (default: write to current directory)
        /// </summary>
        public virtual string Output { get; internal set; }
        /// <summary>
        ///   skip printing logo information
        /// </summary>
        public virtual bool? NoLogo { get; internal set; }
        /// <summary>
        ///   verbose output
        /// </summary>
        public virtual bool? Verbose { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("{value}", Type)
              .Add("{value}", Source)
              .Add("{value}", SourceFile)
              .Add("-ag", AutogenerateComponentGuids)
              .Add("-cg {value}", ComponentGroup)
              .Add("-configuration {value}", Configuration)
              .Add("-directoryid {value}", DirectoryId)
              .Add("-dr {value}", RootDirectoryReference)
              .Add("-gl", NoBracketGuids)
              .Add("-generate {value}", GenerateElement)
              .Add("-gg", GenerateGuidsNow)
              .Add("-indent {value}", Indentation)
              .Add("-ke", KeepEmptyDirectories)
              .Add("-platform {value}", Platform)
              .Add("-pog {value}", ProjectOutputGroup)
              .Add("-projectname {value}", ProjectName)
              .Add("-scom", SuppressComElements)
              .Add("-sfrag", SuppressFragments)
              .Add("-srd", SuppressRootDirectoryAsElement)
              .Add("-sreg", SuppressRegistry)
              .Add("-suid", SuppressUids)
              .Add("-svb6", SuppressVb6ComElements)
              .Add("-t {value}", Transform)
              .Add("-template {value}", Template)
              .Add("-var {value}", Var)
              .Add("-wixvar", WixVar)
              .Add("-sw", SuppressAllWarnings)
              .Add("-sw{value}", SuppressWarnings)
              .Add("-wx", WarningsAsErrors)
              .Add("-wx{value}", MessageIdAsError)
              .Add("-ext {value}", Extension)
              .Add("-out {value}", Output)
              .Add("-nologo", NoLogo)
              .Add("-v", Verbose);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region WixInsigniaSettings
    /// <summary>
    ///   Used within <see cref="WixTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class WixInsigniaSettings : InsigniaBaseSettings
    {
        /// <summary>
        ///   Path to the Wix executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? GetToolPath();
        public override Action<OutputType, string> CustomLogger => WixTasks.WixLogger;
        /// <summary>
        ///   specify the database file to inscribe
        /// </summary>
        public virtual string DatabaseFile { get; internal set; }
        /// <summary>
        ///   specify the bundle file from which to extract the engine. The engine is stored in the file specified by -o
        /// </summary>
        public virtual string Bundle { get; internal set; }
        /// <summary>
        ///   Reattach the engine to a bundle (bundle path + bundle with attached container path)
        /// </summary>
        public virtual string Reattach { get; internal set; }
        /// <summary>
        ///   suppress all warnings
        /// </summary>
        public virtual bool? SuppressAllWarnings { get; internal set; }
        /// <summary>
        ///   suppress a specific message ID
        /// </summary>
        public virtual IReadOnlyList<int> SuppressWarnings => SuppressWarningsInternal.AsReadOnly();
        internal List<int> SuppressWarningsInternal { get; set; } = new List<int>();
        /// <summary>
        ///   treat all warnings as an error
        /// </summary>
        public virtual bool? WarningsAsErrors { get; internal set; }
        /// <summary>
        ///   treat a specific message ID as an error
        /// </summary>
        public virtual IReadOnlyList<int> MessageIdAsError => MessageIdAsErrorInternal.AsReadOnly();
        internal List<int> MessageIdAsErrorInternal { get; set; } = new List<int>();
        /// <summary>
        ///   response file
        /// </summary>
        public virtual string ResponseFile { get; internal set; }
        /// <summary>
        ///   specify output file (default: write to current directory)
        /// </summary>
        public virtual string Output { get; internal set; }
        /// <summary>
        ///   skip printing logo information
        /// </summary>
        public virtual bool? NoLogo { get; internal set; }
        /// <summary>
        ///   verbose output
        /// </summary>
        public virtual bool? Verbose { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("-im {value}", DatabaseFile)
              .Add("-ib {value}", Bundle)
              .Add("-ab {value}", Reattach)
              .Add("-sw", SuppressAllWarnings)
              .Add("-sw{value}", SuppressWarnings)
              .Add("-wx", WarningsAsErrors)
              .Add("-wx{value}", MessageIdAsError)
              .Add("@{value}", ResponseFile)
              .Add("-out {value}", Output)
              .Add("-nologo", NoLogo)
              .Add("-v", Verbose);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region WixSmokeSettings
    /// <summary>
    ///   Used within <see cref="WixTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class WixSmokeSettings : SmokeBaseSettings
    {
        /// <summary>
        ///   Path to the Wix executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? GetToolPath();
        public override Action<OutputType, string> CustomLogger => WixTasks.WixLogger;
        /// <summary>
        ///   do not add the default .cub files for .msi and .msm files
        /// </summary>
        public virtual bool? NoDefault { get; internal set; }
        /// <summary>
        ///   path to the pdb file corresponding to the databaseFile
        /// </summary>
        public virtual string Pdb { get; internal set; }
        /// <summary>
        ///   input files to process
        /// </summary>
        public virtual IReadOnlyList<string> InputFiles => InputFilesInternal.AsReadOnly();
        internal List<string> InputFilesInternal { get; set; } = new List<string>();
        /// <summary>
        ///    extension assembly or 'class, assembly'
        /// </summary>
        public virtual IReadOnlyList<string> Extension => ExtensionInternal.AsReadOnly();
        internal List<string> ExtensionInternal { get; set; } = new List<string>();
        /// <summary>
        ///   suppress all warnings
        /// </summary>
        public virtual bool? SuppressAllWarnings { get; internal set; }
        /// <summary>
        ///   suppress a specific message ID
        /// </summary>
        public virtual IReadOnlyList<int> SuppressWarnings => SuppressWarningsInternal.AsReadOnly();
        internal List<int> SuppressWarningsInternal { get; set; } = new List<int>();
        /// <summary>
        ///   treat all warnings as an error
        /// </summary>
        public virtual bool? WarningsAsErrors { get; internal set; }
        /// <summary>
        ///   treat a specific message ID as an error
        /// </summary>
        public virtual IReadOnlyList<int> MessageIdAsError => MessageIdAsErrorInternal.AsReadOnly();
        internal List<int> MessageIdAsErrorInternal { get; set; } = new List<int>();
        /// <summary>
        ///   additional .cub file containing ICEs to run
        /// </summary>
        public virtual string CubFile { get; internal set; }
        /// <summary>
        ///   run a specific internal consistency evaluator (ICE)
        /// </summary>
        public virtual IReadOnlyList<string> Ice => IceInternal.AsReadOnly();
        internal List<string> IceInternal { get; set; } = new List<string>();
        /// <summary>
        ///   suppress an internal consistency evaluator (ICE)
        /// </summary>
        public virtual IReadOnlyList<string> SuppressIce => SuppressIceInternal.AsReadOnly();
        internal List<string> SuppressIceInternal { get; set; } = new List<string>();
        /// <summary>
        ///   skip printing logo information
        /// </summary>
        public virtual bool? NoLogo { get; internal set; }
        /// <summary>
        ///   verbose output
        /// </summary>
        public virtual bool? Verbose { get; internal set; }
        /// <summary>
        ///   do not delete temporary files (useful for debugging)
        /// </summary>
        public virtual bool? NoTidy { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("-nodefault", NoDefault)
              .Add("-pdb {value}", Pdb)
              .Add("{value}", InputFiles)
              .Add("-ext {value}", Extension)
              .Add("-sw", SuppressAllWarnings)
              .Add("-sw{value}", SuppressWarnings)
              .Add("-wx", WarningsAsErrors)
              .Add("-wx{value}", MessageIdAsError)
              .Add("-cub {value}", CubFile)
              .Add("-ice:{value}", Ice)
              .Add("-sice:{value}", SuppressIce)
              .Add("-nologo", NoLogo)
              .Add("-v", Verbose)
              .Add("-notidy", NoTidy);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region WixNitSettings
    /// <summary>
    ///   Used within <see cref="WixTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class WixNitSettings : NitBaseSettings
    {
        /// <summary>
        ///   Path to the Wix executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? GetToolPath();
        public override Action<OutputType, string> CustomLogger => WixTasks.WixLogger;
        /// <summary>
        ///   input files to process
        /// </summary>
        public virtual IReadOnlyList<string> InputFiles => InputFilesInternal.AsReadOnly();
        internal List<string> InputFilesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   skip printing logo information
        /// </summary>
        public virtual bool? NoLogo { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("{value}", InputFiles)
              .Add("-nologo", NoLogo);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region WixLuxSettings
    /// <summary>
    ///   Used within <see cref="WixTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class WixLuxSettings : LuxBaseSettings
    {
        /// <summary>
        ///   Path to the Wix executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? GetToolPath();
        public override Action<OutputType, string> CustomLogger => WixTasks.WixLogger;
        /// <summary>
        ///   input files to process
        /// </summary>
        public virtual IReadOnlyList<string> InputFiles => InputFilesInternal.AsReadOnly();
        internal List<string> InputFilesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   skip printing logo information
        /// </summary>
        public virtual bool? NoLogo { get; internal set; }
        /// <summary>
        ///   specify output file (default: write to current directory)
        /// </summary>
        public virtual string Output { get; internal set; }
        /// <summary>
        ///    extension assembly or 'class, assembly'
        /// </summary>
        public virtual IReadOnlyList<string> Extension => ExtensionInternal.AsReadOnly();
        internal List<string> ExtensionInternal { get; set; } = new List<string>();
        /// <summary>
        ///   verbose output
        /// </summary>
        public virtual bool? Verbose { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("{value}", InputFiles)
              .Add("-nologo", NoLogo)
              .Add("-out {value}", Output)
              .Add("-ext {value}", Extension)
              .Add("-v", Verbose);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region WixLitSettings
    /// <summary>
    ///   Used within <see cref="WixTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class WixLitSettings : LitBaseSettings
    {
        /// <summary>
        ///   Path to the Wix executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? GetToolPath();
        public override Action<OutputType, string> CustomLogger => WixTasks.WixLogger;
        /// <summary>
        ///   binder path to locate all files (default: current directory) prefix the path with 'name=' where 'name' is the name of your named bindpath.
        /// </summary>
        public virtual string Bind { get; internal set; }
        /// <summary>
        ///   bind files into the library file
        /// </summary>
        public virtual bool? BindFiles { get; internal set; }
        /// <summary>
        ///   suppress schema validation of documents (performance boost)
        /// </summary>
        public virtual bool? SuppressSchemaValidation { get; internal set; }
        /// <summary>
        ///   suppress intermediate file version mismatch checking
        /// </summary>
        public virtual bool? SuppressVersionMismatchCheck { get; internal set; }
        /// <summary>
        ///   input files to process
        /// </summary>
        public virtual IReadOnlyList<string> InputFiles => InputFilesInternal.AsReadOnly();
        internal List<string> InputFilesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   response file
        /// </summary>
        public virtual string ResponseFile { get; internal set; }
        /// <summary>
        ///   skip printing logo information
        /// </summary>
        public virtual bool? NoLogo { get; internal set; }
        /// <summary>
        ///   specify output file (default: write to current directory)
        /// </summary>
        public virtual string Output { get; internal set; }
        /// <summary>
        ///    extension assembly or 'class, assembly'
        /// </summary>
        public virtual IReadOnlyList<string> Extension => ExtensionInternal.AsReadOnly();
        internal List<string> ExtensionInternal { get; set; } = new List<string>();
        /// <summary>
        ///   verbose output
        /// </summary>
        public virtual bool? Verbose { get; internal set; }
        /// <summary>
        ///   suppress all warnings
        /// </summary>
        public virtual bool? SuppressAllWarnings { get; internal set; }
        /// <summary>
        ///   suppress a specific message ID
        /// </summary>
        public virtual IReadOnlyList<int> SuppressWarnings => SuppressWarningsInternal.AsReadOnly();
        internal List<int> SuppressWarningsInternal { get; set; } = new List<int>();
        /// <summary>
        ///   treat all warnings as an error
        /// </summary>
        public virtual bool? WarningsAsErrors { get; internal set; }
        /// <summary>
        ///   treat a specific message ID as an error
        /// </summary>
        public virtual IReadOnlyList<int> MessageIdAsError => MessageIdAsErrorInternal.AsReadOnly();
        internal List<int> MessageIdAsErrorInternal { get; set; } = new List<int>();
        /// <summary>
        ///   read localization strings from .wxl file
        /// </summary>
        public virtual string Localization { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("-b {value}", Bind)
              .Add("-bf", BindFiles)
              .Add("-ss", SuppressSchemaValidation)
              .Add("-sv", SuppressVersionMismatchCheck)
              .Add("{value}", InputFiles)
              .Add("@{value}", ResponseFile)
              .Add("-nologo", NoLogo)
              .Add("-out {value}", Output)
              .Add("-ext {value}", Extension)
              .Add("-v", Verbose)
              .Add("-sw", SuppressAllWarnings)
              .Add("-sw{value}", SuppressWarnings)
              .Add("-wx", WarningsAsErrors)
              .Add("-wx{value}", MessageIdAsError)
              .Add("-loc {value}", Localization);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region WixCopSettings
    /// <summary>
    ///   Used within <see cref="WixTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class WixCopSettings : CopBaseSettings
    {
        /// <summary>
        ///   Path to the Wix executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? GetToolPath();
        public override Action<OutputType, string> CustomLogger => WixTasks.WixLogger;
        /// <summary>
        ///   fix errors automatically for writable files
        /// </summary>
        public virtual bool? AutoFix { get; internal set; }
        /// <summary>
        ///   search for matching files in current dir and subdirs
        /// </summary>
        public virtual bool? Search { get; internal set; }
        /// <summary>
        ///   primary settings file
        /// </summary>
        public virtual string PrimarySettingsFile { get; internal set; }
        /// <summary>
        ///   secondary settings file (overrides primary)
        /// </summary>
        public virtual string SecondarySettingsFile { get; internal set; }
        /// <summary>
        ///   indentation multiple (overrides default of 4)
        /// </summary>
        public virtual int? Indentation { get; internal set; }
        /// <summary>
        ///   input files to process
        /// </summary>
        public virtual IReadOnlyList<string> InputFiles => InputFilesInternal.AsReadOnly();
        internal List<string> InputFilesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   skip printing logo information
        /// </summary>
        public virtual bool? NoLogo { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("-f", AutoFix)
              .Add("-s", Search)
              .Add("-set1{value}", PrimarySettingsFile)
              .Add("-set2{value}", SecondarySettingsFile)
              .Add("-indent:{value}", Indentation)
              .Add("{value}", InputFiles)
              .Add("-nologo", NoLogo);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region WixLightSettings
    /// <summary>
    ///   Used within <see cref="WixTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class WixLightSettings : LightBaseSettings
    {
        /// <summary>
        ///   Path to the Wix executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? GetToolPath();
        public override Action<OutputType, string> CustomLogger => WixTasks.WixLogger;
        /// <summary>
        ///   specify a binder path to locate all files (default: current directory) prefix the path with 'name=' where 'name' is the name of your named bindpath.
        /// </summary>
        public virtual string BinderPath { get; internal set; }
        /// <summary>
        ///   semicolon or comma delimited list of localized string cultures to load from .wxl files and libraries. Precedence of cultures is from left to right.
        /// </summary>
        public virtual IReadOnlyList<string> Cultures => CulturesInternal.AsReadOnly();
        internal List<string> CulturesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   suppress localization
        /// </summary>
        public virtual bool? SuppressLocalization { get; internal set; }
        /// <summary>
        ///   output wixout format instead of MSI format
        /// </summary>
        public virtual bool? WixOutFormat { get; internal set; }
        /// <summary>
        ///   use backwards compatible guid generation algorithm (almost never needed)
        /// </summary>
        public virtual bool? BackwardsCompatableGuids { get; internal set; }
        /// <summary>
        ///   path to cache built cabinets (will not be deleted after linking)
        /// </summary>
        public virtual string CachePath { get; internal set; }
        /// <summary>
        ///   number of threads to use when creating cabinets (default: %NUMBER_OF_PROCESSORS%)
        /// </summary>
        public virtual int? Threads { get; internal set; }
        /// <summary>
        ///   set default cabinet compression level (low, medium, high, none, mszip; mszip default)
        /// </summary>
        public virtual CompressionLevel CompressionLevel { get; internal set; }
        /// <summary>
        ///   exact assembly versions (breaks .NET 1.1 RTM compatibility)
        /// </summary>
        public virtual bool? ExactAssemblyVersions { get; internal set; }
        /// <summary>
        ///   add a 'fileVersion' entry to the MsiAssemblyName table (rarely needed)
        /// </summary>
        public virtual bool? AddFileVersionEntry { get; internal set; }
        /// <summary>
        ///   save the WixPdb to a specific file (default: same name as output with wixpdb extension)
        /// </summary>
        public virtual string PdbOut { get; internal set; }
        /// <summary>
        ///   reuse cabinets from cabinet cache
        /// </summary>
        public virtual bool? ReuseCab { get; internal set; }
        /// <summary>
        ///   suppress assemblies: do not get assembly name information for assemblies
        /// </summary>
        public virtual bool? SuppressAssemblies { get; internal set; }
        /// <summary>
        ///   suppress resetting ACLs (useful when laying out image to a network share)
        /// </summary>
        public virtual bool? SuppressResettingAcls { get; internal set; }
        /// <summary>
        ///   suppress files: do not get any file information (equivalent to -sa and -sh)
        /// </summary>
        public virtual bool? SuppressFiles { get; internal set; }
        /// <summary>
        ///   suppress file info: do not get hash, version, language, etc
        /// </summary>
        public virtual bool? SuppressFileInfo { get; internal set; }
        /// <summary>
        ///   suppress layout
        /// </summary>
        public virtual bool? SuppressLayout { get; internal set; }
        /// <summary>
        ///   suppress outputting the WixPdb
        /// </summary>
        public virtual bool? SuppressWixPdb { get; internal set; }
        /// <summary>
        ///   suppress patch sequence data in patch XML to decrease bundle size and increase patch applicability performance (patch packages themselves are not modified)
        /// </summary>
        public virtual bool? SuppressPatchSequenceData { get; internal set; }
        /// <summary>
        ///   suppress MSI/MSM validation
        /// </summary>
        public virtual bool? SuppressValidation { get; internal set; }
        /// <summary>
        ///   define a parameter for the preprocessor
        /// </summary>
        public virtual IReadOnlyDictionary<string, string> Parameter => ParameterInternal.AsReadOnly();
        internal Dictionary<string, string> ParameterInternal { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///    extension assembly or 'class, assembly'
        /// </summary>
        public virtual IReadOnlyList<string> Extension => ExtensionInternal.AsReadOnly();
        internal List<string> ExtensionInternal { get; set; } = new List<string>();
        /// <summary>
        ///   read localization strings from .wxl file
        /// </summary>
        public virtual string Localization { get; internal set; }
        /// <summary>
        ///   skip printing logo information
        /// </summary>
        public virtual bool? NoLogo { get; internal set; }
        /// <summary>
        ///   do not delete temporary files (useful for debugging)
        /// </summary>
        public virtual bool? NoTidy { get; internal set; }
        /// <summary>
        ///   specify output file (default: write to current directory)
        /// </summary>
        public virtual string Output { get; internal set; }
        /// <summary>
        ///   input files to process
        /// </summary>
        public virtual IReadOnlyList<string> InputFiles => InputFilesInternal.AsReadOnly();
        internal List<string> InputFilesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   response file
        /// </summary>
        public virtual string ResponseFile { get; internal set; }
        /// <summary>
        ///   show pedantic messages
        /// </summary>
        public virtual bool? Pedantic { get; internal set; }
        /// <summary>
        ///   suppress all warnings
        /// </summary>
        public virtual bool? SuppressAllWarnings { get; internal set; }
        /// <summary>
        ///   suppress a specific message ID
        /// </summary>
        public virtual IReadOnlyList<int> SuppressWarnings => SuppressWarningsInternal.AsReadOnly();
        internal List<int> SuppressWarningsInternal { get; set; } = new List<int>();
        /// <summary>
        ///   treat all warnings as an error
        /// </summary>
        public virtual bool? WarningsAsErrors { get; internal set; }
        /// <summary>
        ///   treat a specific message ID as an error
        /// </summary>
        public virtual IReadOnlyList<int> MessageIdAsError => MessageIdAsErrorInternal.AsReadOnly();
        internal List<int> MessageIdAsErrorInternal { get; set; } = new List<int>();
        /// <summary>
        ///   verbose output
        /// </summary>
        public virtual bool? Verbose { get; internal set; }
        /// <summary>
        ///   additional .cub file containing ICEs to run
        /// </summary>
        public virtual string CubFile { get; internal set; }
        /// <summary>
        ///   run a specific internal consistency evaluator (ICE)
        /// </summary>
        public virtual IReadOnlyList<string> Ice => IceInternal.AsReadOnly();
        internal List<string> IceInternal { get; set; } = new List<string>();
        /// <summary>
        ///   suppress an internal consistency evaluator (ICE)
        /// </summary>
        public virtual IReadOnlyList<string> SuppressIce => SuppressIceInternal.AsReadOnly();
        internal List<string> SuppressIceInternal { get; set; } = new List<string>();
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("-b {value}", BinderPath)
              .Add("-cultures:{value}", Cultures, separator: ';')
              .Add("-sloc", SuppressLocalization)
              .Add("-xo", WixOutFormat)
              .Add("-bcgg", BackwardsCompatableGuids)
              .Add("-cc {value}", CachePath)
              .Add("-ct {value}", Threads)
              .Add("-dcl:{value}", CompressionLevel)
              .Add("-eav", ExactAssemblyVersions)
              .Add("-fv", AddFileVersionEntry)
              .Add("-pdbout {value}", PdbOut)
              .Add("-reusecab", ReuseCab)
              .Add("-sa", SuppressAssemblies)
              .Add("-sacl", SuppressResettingAcls)
              .Add("-sf", SuppressFiles)
              .Add("-sh", SuppressFileInfo)
              .Add("-sl", SuppressLayout)
              .Add("-spdb", SuppressWixPdb)
              .Add("-spsd", SuppressPatchSequenceData)
              .Add("-sval", SuppressValidation)
              .Add("-d{value}", Parameter, "{key}={value}")
              .Add("-ext {value}", Extension)
              .Add("-loc {value}", Localization)
              .Add("-nologo", NoLogo)
              .Add("-notidy", NoTidy)
              .Add("-out {value}", Output)
              .Add("{value}", InputFiles)
              .Add("@{value}", ResponseFile)
              .Add("-pedantic", Pedantic)
              .Add("-sw", SuppressAllWarnings)
              .Add("-sw{value}", SuppressWarnings)
              .Add("-wx", WarningsAsErrors)
              .Add("-wx{value}", MessageIdAsError)
              .Add("-v", Verbose)
              .Add("-cub {value}", CubFile)
              .Add("-ice:{value}", Ice)
              .Add("-sice:{value}", SuppressIce);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region WixTorchSettings
    /// <summary>
    ///   Used within <see cref="WixTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class WixTorchSettings : TorchBaseSettings
    {
        /// <summary>
        ///   Path to the Wix executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? GetToolPath();
        public override Action<OutputType, string> CustomLogger => WixTasks.WixLogger;
        /// <summary>
        ///   Target input
        /// </summary>
        public virtual string TargetInput { get; internal set; }
        /// <summary>
        ///   Updated input
        /// </summary>
        public virtual string UpdatedInput { get; internal set; }
        /// <summary>
        ///   admin image (generates source file information in the transform) (default with -ax)
        /// </summary>
        public virtual bool? AdminImage { get; internal set; }
        /// <summary>
        ///   admin image with extraction of binaries (combination of -a and -x)
        /// </summary>
        public virtual string AdminImageWithExtraction { get; internal set; }
        /// <summary>
        ///   preserve unmodified content in the output
        /// </summary>
        public virtual bool? Preserve { get; internal set; }
        /// <summary>
        ///   suppress error when applying transform, a - Ignore errors when adding an existing row, b - Ignore errors when deleting a missing row, c - Ignore errors when adding an existing table, d - Ignore errors when deleting a missing table, e - Ignore errors when modifying a missing row, f - Ignore errors when changing the code page
        /// </summary>
        public virtual IReadOnlyList<TorchErrorFlag> SuppressErrors => SuppressErrorsInternal.AsReadOnly();
        internal List<TorchErrorFlag> SuppressErrorsInternal { get; set; } = new List<TorchErrorFlag>();
        /// <summary>
        ///   use default validation flags for the transform type, g - UpgradeCode must match, l - Language must match, r - Product ID must match, s - Check major version only, t - Check major and minor versions, u - Check major, minor, and upgrade versions, v - Upgrade version less than target version, w - Upgrade version less or equal than target version, x - Upgrade version equals target version, y - Upgrade version greater than target version, z - Upgrade version greater or equal than target version
        /// </summary>
        public virtual IReadOnlyList<TorchValidationFlag> ValidationFlags => ValidationFlagsInternal.AsReadOnly();
        internal List<TorchValidationFlag> ValidationFlagsInternal { get; set; } = new List<TorchValidationFlag>();
        /// <summary>
        ///   use default validation flags for the transform type
        /// </summary>
        public virtual TorchTransformType TransformType { get; internal set; }
        /// <summary>
        ///   extract binaries to the specified path
        /// </summary>
        public virtual string ExtractBinariesToPath { get; internal set; }
        /// <summary>
        ///   input WiX format instead of MSI format (.wixout or .wixpdb)
        /// </summary>
        public virtual bool? WixInputFormat { get; internal set; }
        /// <summary>
        ///   output wixout instead of MST format (set by default if -xi is present)
        /// </summary>
        public virtual bool? Wixout { get; internal set; }
        /// <summary>
        ///   skip printing logo information
        /// </summary>
        public virtual bool? NoLogo { get; internal set; }
        /// <summary>
        ///   response file
        /// </summary>
        public virtual string ResponseFile { get; internal set; }
        /// <summary>
        ///   specify output file (default: write to current directory)
        /// </summary>
        public virtual string Output { get; internal set; }
        /// <summary>
        ///    extension assembly or 'class, assembly'
        /// </summary>
        public virtual IReadOnlyList<string> Extension => ExtensionInternal.AsReadOnly();
        internal List<string> ExtensionInternal { get; set; } = new List<string>();
        /// <summary>
        ///   do not delete temporary files (useful for debugging)
        /// </summary>
        public virtual bool? NoTidy { get; internal set; }
        /// <summary>
        ///   show pedantic messages
        /// </summary>
        public virtual bool? Pedantic { get; internal set; }
        /// <summary>
        ///   suppress all warnings
        /// </summary>
        public virtual bool? SuppressAllWarnings { get; internal set; }
        /// <summary>
        ///   suppress a specific message ID
        /// </summary>
        public virtual IReadOnlyList<int> SuppressWarnings => SuppressWarningsInternal.AsReadOnly();
        internal List<int> SuppressWarningsInternal { get; set; } = new List<int>();
        /// <summary>
        ///   treat all warnings as an error
        /// </summary>
        public virtual bool? WarningsAsErrors { get; internal set; }
        /// <summary>
        ///   treat a specific message ID as an error
        /// </summary>
        public virtual IReadOnlyList<int> MessageIdAsError => MessageIdAsErrorInternal.AsReadOnly();
        internal List<int> MessageIdAsErrorInternal { get; set; } = new List<int>();
        /// <summary>
        ///   verbose output
        /// </summary>
        public virtual bool? Verbose { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("{value}", TargetInput)
              .Add("{value}", UpdatedInput)
              .Add("-a", AdminImage)
              .Add("-ax {value}", AdminImageWithExtraction)
              .Add("-p", Preserve)
              .Add("-serr {value}", SuppressErrors)
              .Add("-val {value}", ValidationFlags)
              .Add("-t {value}", TransformType)
              .Add("-x {value}", ExtractBinariesToPath)
              .Add("-xi", WixInputFormat)
              .Add("-xo", Wixout)
              .Add("-nologo", NoLogo)
              .Add("@{value}", ResponseFile)
              .Add("-out {value}", Output)
              .Add("-ext {value}", Extension)
              .Add("-notidy", NoTidy)
              .Add("-pedantic", Pedantic)
              .Add("-sw", SuppressAllWarnings)
              .Add("-sw{value}", SuppressWarnings)
              .Add("-wx", WarningsAsErrors)
              .Add("-wx{value}", MessageIdAsError)
              .Add("-v", Verbose);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region WixPyroSettings
    /// <summary>
    ///   Used within <see cref="WixTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class WixPyroSettings : PyroBaseSettings
    {
        /// <summary>
        ///   Path to the Wix executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? GetToolPath();
        public override Action<OutputType, string> CustomLogger => WixTasks.WixLogger;
        /// <summary>
        ///   allow patches to be created with one or more empty product transforms
        /// </summary>
        public virtual bool? AllowEmptyProductTransforms { get; internal set; }
        /// <summary>
        ///   new bind path to replace the original target path. It accepts two formats matching the exact light behavior. (example: -bt name1=c:\feature1\component1 -bt c:\feature2)
        /// </summary>
        public virtual string BindTargetPath { get; internal set; }
        /// <summary>
        ///   new bind paths to replace the bind paths for the updated input. It accepts two formats matching the exact light behavior. example: -bu name1=\\serverA\feature1\component1 -bu \\serverA\feature2
        /// </summary>
        public virtual string BindUpdatePath { get; internal set; }
        /// <summary>
        ///   path to cache built cabinets
        /// </summary>
        public virtual string CachePath { get; internal set; }
        /// <summary>
        ///   create binary delta patch (instead of whole file patch)
        /// </summary>
        public virtual bool? CreateDeltaPatch { get; internal set; }
        /// <summary>
        ///   update 'fileVersion' entries in the MsiAssemblyName table
        /// </summary>
        public virtual bool? UpdateFileVersionEntries { get; internal set; }
        /// <summary>
        ///   save the WixPdb to a specific file (default: same name as output with wixpdb extension)
        /// </summary>
        public virtual string PdbOut { get; internal set; }
        /// <summary>
        ///   reuse cabinets from cabinet cache
        /// </summary>
        public virtual bool? ReuseCab { get; internal set; }
        /// <summary>
        ///   suppress assemblies: do not get assembly name information for assemblies
        /// </summary>
        public virtual bool? SuppressAssemblies { get; internal set; }
        /// <summary>
        ///   suppress files: do not get any file information (equivalent to -sa and -sh)
        /// </summary>
        public virtual bool? SuppressFiles { get; internal set; }
        /// <summary>
        ///   suppress file info: do not get hash, version, language, etc
        /// </summary>
        public virtual bool? SuppressFileInfo { get; internal set; }
        /// <summary>
        ///   suppress outputting the WixPdb
        /// </summary>
        public virtual bool? SuppressWixPdb { get; internal set; }
        /// <summary>
        ///   one or more wix transforms and its baseline
        /// </summary>
        public virtual IReadOnlyList<string> BaselineAndTransform => BaselineAndTransformInternal.AsReadOnly();
        internal List<string> BaselineAndTransformInternal { get; set; } = new List<string>();
        /// <summary>
        ///   skip printing logo information
        /// </summary>
        public virtual bool? NoLogo { get; internal set; }
        /// <summary>
        ///   do not delete temporary files (useful for debugging)
        /// </summary>
        public virtual bool? NoTidy { get; internal set; }
        /// <summary>
        ///   specify output file (default: write to current directory)
        /// </summary>
        public virtual string Output { get; internal set; }
        /// <summary>
        ///   suppress all warnings
        /// </summary>
        public virtual bool? SuppressAllWarnings { get; internal set; }
        /// <summary>
        ///   suppress a specific message ID
        /// </summary>
        public virtual IReadOnlyList<int> SuppressWarnings => SuppressWarningsInternal.AsReadOnly();
        internal List<int> SuppressWarningsInternal { get; set; } = new List<int>();
        /// <summary>
        ///   treat all warnings as an error
        /// </summary>
        public virtual bool? WarningsAsErrors { get; internal set; }
        /// <summary>
        ///   treat a specific message ID as an error
        /// </summary>
        public virtual IReadOnlyList<int> MessageIdAsError => MessageIdAsErrorInternal.AsReadOnly();
        internal List<int> MessageIdAsErrorInternal { get; set; } = new List<int>();
        /// <summary>
        ///   verbose output
        /// </summary>
        public virtual bool? Verbose { get; internal set; }
        /// <summary>
        ///   response file
        /// </summary>
        public virtual string ResponseFile { get; internal set; }
        /// <summary>
        ///    extension assembly or 'class, assembly'
        /// </summary>
        public virtual IReadOnlyList<string> Extension => ExtensionInternal.AsReadOnly();
        internal List<string> ExtensionInternal { get; set; } = new List<string>();
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("-aet", AllowEmptyProductTransforms)
              .Add("-bt {value}", BindTargetPath)
              .Add("-bu {value}", BindUpdatePath)
              .Add("-cc {value}", CachePath)
              .Add("-delta", CreateDeltaPatch)
              .Add("-fv", UpdateFileVersionEntries)
              .Add("-pdbout {value}", PdbOut)
              .Add("-reusecab", ReuseCab)
              .Add("-sa", SuppressAssemblies)
              .Add("-sf", SuppressFiles)
              .Add("-sh", SuppressFileInfo)
              .Add("-spdb", SuppressWixPdb)
              .Add("-t {value}", BaselineAndTransform, separator: ' ')
              .Add("-nologo", NoLogo)
              .Add("-notidy", NoTidy)
              .Add("-out {value}", Output)
              .Add("-sw", SuppressAllWarnings)
              .Add("-sw{value}", SuppressWarnings)
              .Add("-wx", WarningsAsErrors)
              .Add("-wx{value}", MessageIdAsError)
              .Add("-v", Verbose)
              .Add("@{value}", ResponseFile)
              .Add("-ext {value}", Extension);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region CandleBaseSettings
    /// <summary>
    ///   Used within <see cref="WixTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class CandleBaseSettings : ToolSettings
    {
    }
    #endregion
    #region HeatBaseSettings
    /// <summary>
    ///   Used within <see cref="WixTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class HeatBaseSettings : ToolSettings
    {
    }
    #endregion
    #region InsigniaBaseSettings
    /// <summary>
    ///   Used within <see cref="WixTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class InsigniaBaseSettings : ToolSettings
    {
    }
    #endregion
    #region SmokeBaseSettings
    /// <summary>
    ///   Used within <see cref="WixTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class SmokeBaseSettings : ToolSettings
    {
    }
    #endregion
    #region NitBaseSettings
    /// <summary>
    ///   Used within <see cref="WixTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NitBaseSettings : ToolSettings
    {
    }
    #endregion
    #region LuxBaseSettings
    /// <summary>
    ///   Used within <see cref="WixTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class LuxBaseSettings : ToolSettings
    {
    }
    #endregion
    #region LitBaseSettings
    /// <summary>
    ///   Used within <see cref="WixTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class LitBaseSettings : ToolSettings
    {
    }
    #endregion
    #region CopBaseSettings
    /// <summary>
    ///   Used within <see cref="WixTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class CopBaseSettings : ToolSettings
    {
    }
    #endregion
    #region LightBaseSettings
    /// <summary>
    ///   Used within <see cref="WixTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class LightBaseSettings : ToolSettings
    {
    }
    #endregion
    #region TorchBaseSettings
    /// <summary>
    ///   Used within <see cref="WixTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class TorchBaseSettings : ToolSettings
    {
    }
    #endregion
    #region PyroBaseSettings
    /// <summary>
    ///   Used within <see cref="WixTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class PyroBaseSettings : ToolSettings
    {
    }
    #endregion
    #region WixCandleSettingsExtensions
    /// <summary>
    ///   Used within <see cref="WixTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class WixCandleSettingsExtensions
    {
        #region Architecture
        /// <summary>
        ///   <p><em>Sets <see cref="WixCandleSettings.Architecture"/></em></p>
        ///   <p>set architecture defaults for package, components, etc. values: x86, x64, or ia64 (default: x86)</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings SetArchitecture(this WixCandleSettings toolSettings, Architecture architecture)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Architecture = architecture;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixCandleSettings.Architecture"/></em></p>
        ///   <p>set architecture defaults for package, components, etc. values: x86, x64, or ia64 (default: x86)</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings ResetArchitecture(this WixCandleSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Architecture = null;
            return toolSettings;
        }
        #endregion
        #region Fips
        /// <summary>
        ///   <p><em>Sets <see cref="WixCandleSettings.Fips"/></em></p>
        ///   <p>enables FIPS compliant algorithms</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings SetFips(this WixCandleSettings toolSettings, bool? fips)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Fips = fips;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixCandleSettings.Fips"/></em></p>
        ///   <p>enables FIPS compliant algorithms</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings ResetFips(this WixCandleSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Fips = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixCandleSettings.Fips"/></em></p>
        ///   <p>enables FIPS compliant algorithms</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings EnableFips(this WixCandleSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Fips = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixCandleSettings.Fips"/></em></p>
        ///   <p>enables FIPS compliant algorithms</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings DisableFips(this WixCandleSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Fips = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixCandleSettings.Fips"/></em></p>
        ///   <p>enables FIPS compliant algorithms</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings ToggleFips(this WixCandleSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Fips = !toolSettings.Fips;
            return toolSettings;
        }
        #endregion
        #region Include
        /// <summary>
        ///   <p><em>Sets <see cref="WixCandleSettings.Include"/> to a new list</em></p>
        ///   <p>add to include search path</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings SetInclude(this WixCandleSettings toolSettings, params string[] include)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeInternal = include.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="WixCandleSettings.Include"/> to a new list</em></p>
        ///   <p>add to include search path</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings SetInclude(this WixCandleSettings toolSettings, IEnumerable<string> include)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeInternal = include.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixCandleSettings.Include"/></em></p>
        ///   <p>add to include search path</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings AddInclude(this WixCandleSettings toolSettings, params string[] include)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeInternal.AddRange(include);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixCandleSettings.Include"/></em></p>
        ///   <p>add to include search path</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings AddInclude(this WixCandleSettings toolSettings, IEnumerable<string> include)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeInternal.AddRange(include);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="WixCandleSettings.Include"/></em></p>
        ///   <p>add to include search path</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings ClearInclude(this WixCandleSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixCandleSettings.Include"/></em></p>
        ///   <p>add to include search path</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings RemoveInclude(this WixCandleSettings toolSettings, params string[] include)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(include);
            toolSettings.IncludeInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixCandleSettings.Include"/></em></p>
        ///   <p>add to include search path</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings RemoveInclude(this WixCandleSettings toolSettings, IEnumerable<string> include)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(include);
            toolSettings.IncludeInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region PreprocessToFile
        /// <summary>
        ///   <p><em>Sets <see cref="WixCandleSettings.PreprocessToFile"/></em></p>
        ///   <p>preprocess to a file</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings SetPreprocessToFile(this WixCandleSettings toolSettings, string preprocessToFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PreprocessToFile = preprocessToFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixCandleSettings.PreprocessToFile"/></em></p>
        ///   <p>preprocess to a file</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings ResetPreprocessToFile(this WixCandleSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PreprocessToFile = null;
            return toolSettings;
        }
        #endregion
        #region SuppressAllWarnings
        /// <summary>
        ///   <p><em>Sets <see cref="WixCandleSettings.SuppressAllWarnings"/></em></p>
        ///   <p>suppress all warnings</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings SetSuppressAllWarnings(this WixCandleSettings toolSettings, bool? suppressAllWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAllWarnings = suppressAllWarnings;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixCandleSettings.SuppressAllWarnings"/></em></p>
        ///   <p>suppress all warnings</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings ResetSuppressAllWarnings(this WixCandleSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAllWarnings = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixCandleSettings.SuppressAllWarnings"/></em></p>
        ///   <p>suppress all warnings</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings EnableSuppressAllWarnings(this WixCandleSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAllWarnings = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixCandleSettings.SuppressAllWarnings"/></em></p>
        ///   <p>suppress all warnings</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings DisableSuppressAllWarnings(this WixCandleSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAllWarnings = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixCandleSettings.SuppressAllWarnings"/></em></p>
        ///   <p>suppress all warnings</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings ToggleSuppressAllWarnings(this WixCandleSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAllWarnings = !toolSettings.SuppressAllWarnings;
            return toolSettings;
        }
        #endregion
        #region SuppressWarnings
        /// <summary>
        ///   <p><em>Sets <see cref="WixCandleSettings.SuppressWarnings"/> to a new list</em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings SetSuppressWarnings(this WixCandleSettings toolSettings, params int[] suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWarningsInternal = suppressWarnings.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="WixCandleSettings.SuppressWarnings"/> to a new list</em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings SetSuppressWarnings(this WixCandleSettings toolSettings, IEnumerable<int> suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWarningsInternal = suppressWarnings.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixCandleSettings.SuppressWarnings"/></em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings AddSuppressWarnings(this WixCandleSettings toolSettings, params int[] suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWarningsInternal.AddRange(suppressWarnings);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixCandleSettings.SuppressWarnings"/></em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings AddSuppressWarnings(this WixCandleSettings toolSettings, IEnumerable<int> suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWarningsInternal.AddRange(suppressWarnings);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="WixCandleSettings.SuppressWarnings"/></em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings ClearSuppressWarnings(this WixCandleSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWarningsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixCandleSettings.SuppressWarnings"/></em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings RemoveSuppressWarnings(this WixCandleSettings toolSettings, params int[] suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<int>(suppressWarnings);
            toolSettings.SuppressWarningsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixCandleSettings.SuppressWarnings"/></em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings RemoveSuppressWarnings(this WixCandleSettings toolSettings, IEnumerable<int> suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<int>(suppressWarnings);
            toolSettings.SuppressWarningsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region WarningsAsErrors
        /// <summary>
        ///   <p><em>Sets <see cref="WixCandleSettings.WarningsAsErrors"/></em></p>
        ///   <p>treat all warnings as an error</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings SetWarningsAsErrors(this WixCandleSettings toolSettings, bool? warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = warningsAsErrors;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixCandleSettings.WarningsAsErrors"/></em></p>
        ///   <p>treat all warnings as an error</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings ResetWarningsAsErrors(this WixCandleSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixCandleSettings.WarningsAsErrors"/></em></p>
        ///   <p>treat all warnings as an error</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings EnableWarningsAsErrors(this WixCandleSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixCandleSettings.WarningsAsErrors"/></em></p>
        ///   <p>treat all warnings as an error</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings DisableWarningsAsErrors(this WixCandleSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixCandleSettings.WarningsAsErrors"/></em></p>
        ///   <p>treat all warnings as an error</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings ToggleWarningsAsErrors(this WixCandleSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = !toolSettings.WarningsAsErrors;
            return toolSettings;
        }
        #endregion
        #region MessageIdAsError
        /// <summary>
        ///   <p><em>Sets <see cref="WixCandleSettings.MessageIdAsError"/> to a new list</em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings SetMessageIdAsError(this WixCandleSettings toolSettings, params int[] messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MessageIdAsErrorInternal = messageIdAsError.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="WixCandleSettings.MessageIdAsError"/> to a new list</em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings SetMessageIdAsError(this WixCandleSettings toolSettings, IEnumerable<int> messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MessageIdAsErrorInternal = messageIdAsError.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixCandleSettings.MessageIdAsError"/></em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings AddMessageIdAsError(this WixCandleSettings toolSettings, params int[] messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MessageIdAsErrorInternal.AddRange(messageIdAsError);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixCandleSettings.MessageIdAsError"/></em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings AddMessageIdAsError(this WixCandleSettings toolSettings, IEnumerable<int> messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MessageIdAsErrorInternal.AddRange(messageIdAsError);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="WixCandleSettings.MessageIdAsError"/></em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings ClearMessageIdAsError(this WixCandleSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MessageIdAsErrorInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixCandleSettings.MessageIdAsError"/></em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings RemoveMessageIdAsError(this WixCandleSettings toolSettings, params int[] messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<int>(messageIdAsError);
            toolSettings.MessageIdAsErrorInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixCandleSettings.MessageIdAsError"/></em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings RemoveMessageIdAsError(this WixCandleSettings toolSettings, IEnumerable<int> messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<int>(messageIdAsError);
            toolSettings.MessageIdAsErrorInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Extension
        /// <summary>
        ///   <p><em>Sets <see cref="WixCandleSettings.Extension"/> to a new list</em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings SetExtension(this WixCandleSettings toolSettings, params string[] extension)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionInternal = extension.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="WixCandleSettings.Extension"/> to a new list</em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings SetExtension(this WixCandleSettings toolSettings, IEnumerable<string> extension)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionInternal = extension.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixCandleSettings.Extension"/></em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings AddExtension(this WixCandleSettings toolSettings, params string[] extension)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionInternal.AddRange(extension);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixCandleSettings.Extension"/></em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings AddExtension(this WixCandleSettings toolSettings, IEnumerable<string> extension)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionInternal.AddRange(extension);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="WixCandleSettings.Extension"/></em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings ClearExtension(this WixCandleSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixCandleSettings.Extension"/></em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings RemoveExtension(this WixCandleSettings toolSettings, params string[] extension)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(extension);
            toolSettings.ExtensionInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixCandleSettings.Extension"/></em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings RemoveExtension(this WixCandleSettings toolSettings, IEnumerable<string> extension)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(extension);
            toolSettings.ExtensionInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ResponseFile
        /// <summary>
        ///   <p><em>Sets <see cref="WixCandleSettings.ResponseFile"/></em></p>
        ///   <p>response file</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings SetResponseFile(this WixCandleSettings toolSettings, string responseFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResponseFile = responseFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixCandleSettings.ResponseFile"/></em></p>
        ///   <p>response file</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings ResetResponseFile(this WixCandleSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResponseFile = null;
            return toolSettings;
        }
        #endregion
        #region InputFiles
        /// <summary>
        ///   <p><em>Sets <see cref="WixCandleSettings.InputFiles"/> to a new list</em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings SetInputFiles(this WixCandleSettings toolSettings, params string[] inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal = inputFiles.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="WixCandleSettings.InputFiles"/> to a new list</em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings SetInputFiles(this WixCandleSettings toolSettings, IEnumerable<string> inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal = inputFiles.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixCandleSettings.InputFiles"/></em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings AddInputFiles(this WixCandleSettings toolSettings, params string[] inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal.AddRange(inputFiles);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixCandleSettings.InputFiles"/></em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings AddInputFiles(this WixCandleSettings toolSettings, IEnumerable<string> inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal.AddRange(inputFiles);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="WixCandleSettings.InputFiles"/></em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings ClearInputFiles(this WixCandleSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixCandleSettings.InputFiles"/></em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings RemoveInputFiles(this WixCandleSettings toolSettings, params string[] inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(inputFiles);
            toolSettings.InputFilesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixCandleSettings.InputFiles"/></em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings RemoveInputFiles(this WixCandleSettings toolSettings, IEnumerable<string> inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(inputFiles);
            toolSettings.InputFilesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary>
        ///   <p><em>Sets <see cref="WixCandleSettings.Output"/></em></p>
        ///   <p>specify output file (default: write to current directory)</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings SetOutput(this WixCandleSettings toolSettings, string output)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixCandleSettings.Output"/></em></p>
        ///   <p>specify output file (default: write to current directory)</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings ResetOutput(this WixCandleSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
        #region NoLogo
        /// <summary>
        ///   <p><em>Sets <see cref="WixCandleSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings SetNoLogo(this WixCandleSettings toolSettings, bool? noLogo)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = noLogo;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixCandleSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings ResetNoLogo(this WixCandleSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixCandleSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings EnableNoLogo(this WixCandleSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixCandleSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings DisableNoLogo(this WixCandleSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixCandleSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings ToggleNoLogo(this WixCandleSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = !toolSettings.NoLogo;
            return toolSettings;
        }
        #endregion
        #region Verbose
        /// <summary>
        ///   <p><em>Sets <see cref="WixCandleSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings SetVerbose(this WixCandleSettings toolSettings, bool? verbose)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = verbose;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixCandleSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings ResetVerbose(this WixCandleSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixCandleSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings EnableVerbose(this WixCandleSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixCandleSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings DisableVerbose(this WixCandleSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixCandleSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings ToggleVerbose(this WixCandleSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = !toolSettings.Verbose;
            return toolSettings;
        }
        #endregion
        #region Pedantic
        /// <summary>
        ///   <p><em>Sets <see cref="WixCandleSettings.Pedantic"/></em></p>
        ///   <p>show pedantic messages</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings SetPedantic(this WixCandleSettings toolSettings, bool? pedantic)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pedantic = pedantic;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixCandleSettings.Pedantic"/></em></p>
        ///   <p>show pedantic messages</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings ResetPedantic(this WixCandleSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pedantic = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixCandleSettings.Pedantic"/></em></p>
        ///   <p>show pedantic messages</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings EnablePedantic(this WixCandleSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pedantic = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixCandleSettings.Pedantic"/></em></p>
        ///   <p>show pedantic messages</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings DisablePedantic(this WixCandleSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pedantic = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixCandleSettings.Pedantic"/></em></p>
        ///   <p>show pedantic messages</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings TogglePedantic(this WixCandleSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pedantic = !toolSettings.Pedantic;
            return toolSettings;
        }
        #endregion
        #region Parameter
        /// <summary>
        ///   <p><em>Sets <see cref="WixCandleSettings.Parameter"/> to a new dictionary</em></p>
        ///   <p>define a parameter for the preprocessor</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings SetParameter(this WixCandleSettings toolSettings, IDictionary<string, string> parameter)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParameterInternal = parameter.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="WixCandleSettings.Parameter"/></em></p>
        ///   <p>define a parameter for the preprocessor</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings ClearParameter(this WixCandleSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParameterInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="WixCandleSettings.Parameter"/></em></p>
        ///   <p>define a parameter for the preprocessor</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings AddParameter(this WixCandleSettings toolSettings, string parameterKey, string parameterValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParameterInternal.Add(parameterKey, parameterValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="WixCandleSettings.Parameter"/></em></p>
        ///   <p>define a parameter for the preprocessor</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings RemoveParameter(this WixCandleSettings toolSettings, string parameterKey)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParameterInternal.Remove(parameterKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="WixCandleSettings.Parameter"/></em></p>
        ///   <p>define a parameter for the preprocessor</p>
        /// </summary>
        [Pure]
        public static WixCandleSettings SetParameter(this WixCandleSettings toolSettings, string parameterKey, string parameterValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParameterInternal[parameterKey] = parameterValue;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region WixHeatSettingsExtensions
    /// <summary>
    ///   Used within <see cref="WixTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class WixHeatSettingsExtensions
    {
        #region Type
        /// <summary>
        ///   <p><em>Sets <see cref="WixHeatSettings.Type"/></em></p>
        ///   <p>harvest type</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings SetType(this WixHeatSettings toolSettings, HarvestType type)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Type = type;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixHeatSettings.Type"/></em></p>
        ///   <p>harvest type</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ResetType(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Type = null;
            return toolSettings;
        }
        #endregion
        #region Source
        /// <summary>
        ///   <p><em>Sets <see cref="WixHeatSettings.Source"/></em></p>
        ///   <p>harvest source</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings SetSource(this WixHeatSettings toolSettings, string source)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Source = source;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixHeatSettings.Source"/></em></p>
        ///   <p>harvest source</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ResetSource(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Source = null;
            return toolSettings;
        }
        #endregion
        #region SourceFile
        /// <summary>
        ///   <p><em>Sets <see cref="WixHeatSettings.SourceFile"/></em></p>
        ///   <p>WXS source file</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings SetSourceFile(this WixHeatSettings toolSettings, string sourceFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceFile = sourceFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixHeatSettings.SourceFile"/></em></p>
        ///   <p>WXS source file</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ResetSourceFile(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceFile = null;
            return toolSettings;
        }
        #endregion
        #region AutogenerateComponentGuids
        /// <summary>
        ///   <p><em>Sets <see cref="WixHeatSettings.AutogenerateComponentGuids"/></em></p>
        ///   <p>autogenerate component guids at compile time</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings SetAutogenerateComponentGuids(this WixHeatSettings toolSettings, bool? autogenerateComponentGuids)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AutogenerateComponentGuids = autogenerateComponentGuids;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixHeatSettings.AutogenerateComponentGuids"/></em></p>
        ///   <p>autogenerate component guids at compile time</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ResetAutogenerateComponentGuids(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AutogenerateComponentGuids = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixHeatSettings.AutogenerateComponentGuids"/></em></p>
        ///   <p>autogenerate component guids at compile time</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings EnableAutogenerateComponentGuids(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AutogenerateComponentGuids = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixHeatSettings.AutogenerateComponentGuids"/></em></p>
        ///   <p>autogenerate component guids at compile time</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings DisableAutogenerateComponentGuids(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AutogenerateComponentGuids = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixHeatSettings.AutogenerateComponentGuids"/></em></p>
        ///   <p>autogenerate component guids at compile time</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ToggleAutogenerateComponentGuids(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AutogenerateComponentGuids = !toolSettings.AutogenerateComponentGuids;
            return toolSettings;
        }
        #endregion
        #region ComponentGroup
        /// <summary>
        ///   <p><em>Sets <see cref="WixHeatSettings.ComponentGroup"/></em></p>
        ///   <p>component group name (cannot contain spaces e.g -cg MyComponentGroup)</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings SetComponentGroup(this WixHeatSettings toolSettings, string componentGroup)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ComponentGroup = componentGroup;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixHeatSettings.ComponentGroup"/></em></p>
        ///   <p>component group name (cannot contain spaces e.g -cg MyComponentGroup)</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ResetComponentGroup(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ComponentGroup = null;
            return toolSettings;
        }
        #endregion
        #region Configuration
        /// <summary>
        ///   <p><em>Sets <see cref="WixHeatSettings.Configuration"/></em></p>
        ///   <p>configuration to set when harvesting the project</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings SetConfiguration(this WixHeatSettings toolSettings, string configuration)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = configuration;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixHeatSettings.Configuration"/></em></p>
        ///   <p>configuration to set when harvesting the project</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ResetConfiguration(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = null;
            return toolSettings;
        }
        #endregion
        #region DirectoryId
        /// <summary>
        ///   <p><em>Sets <see cref="WixHeatSettings.DirectoryId"/></em></p>
        ///   <p>overridden directory id for generated directory elements</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings SetDirectoryId(this WixHeatSettings toolSettings, string directoryId)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DirectoryId = directoryId;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixHeatSettings.DirectoryId"/></em></p>
        ///   <p>overridden directory id for generated directory elements</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ResetDirectoryId(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DirectoryId = null;
            return toolSettings;
        }
        #endregion
        #region RootDirectoryReference
        /// <summary>
        ///   <p><em>Sets <see cref="WixHeatSettings.RootDirectoryReference"/></em></p>
        ///   <p>directory reference to root directories (cannot contain spaces e.g. -dr MyAppDirRef)</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings SetRootDirectoryReference(this WixHeatSettings toolSettings, string rootDirectoryReference)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RootDirectoryReference = rootDirectoryReference;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixHeatSettings.RootDirectoryReference"/></em></p>
        ///   <p>directory reference to root directories (cannot contain spaces e.g. -dr MyAppDirRef)</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ResetRootDirectoryReference(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RootDirectoryReference = null;
            return toolSettings;
        }
        #endregion
        #region NoBracketGuids
        /// <summary>
        ///   <p><em>Sets <see cref="WixHeatSettings.NoBracketGuids"/></em></p>
        ///   <p>generated guids are not in brackets</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings SetNoBracketGuids(this WixHeatSettings toolSettings, bool? noBracketGuids)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBracketGuids = noBracketGuids;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixHeatSettings.NoBracketGuids"/></em></p>
        ///   <p>generated guids are not in brackets</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ResetNoBracketGuids(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBracketGuids = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixHeatSettings.NoBracketGuids"/></em></p>
        ///   <p>generated guids are not in brackets</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings EnableNoBracketGuids(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBracketGuids = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixHeatSettings.NoBracketGuids"/></em></p>
        ///   <p>generated guids are not in brackets</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings DisableNoBracketGuids(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBracketGuids = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixHeatSettings.NoBracketGuids"/></em></p>
        ///   <p>generated guids are not in brackets</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ToggleNoBracketGuids(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBracketGuids = !toolSettings.NoBracketGuids;
            return toolSettings;
        }
        #endregion
        #region GenerateElement
        /// <summary>
        ///   <p><em>Sets <see cref="WixHeatSettings.GenerateElement"/></em></p>
        ///   <p>specify what elements to generate</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings SetGenerateElement(this WixHeatSettings toolSettings, Element generateElement)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateElement = generateElement;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixHeatSettings.GenerateElement"/></em></p>
        ///   <p>specify what elements to generate</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ResetGenerateElement(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateElement = null;
            return toolSettings;
        }
        #endregion
        #region GenerateGuidsNow
        /// <summary>
        ///   <p><em>Sets <see cref="WixHeatSettings.GenerateGuidsNow"/></em></p>
        ///   <p>generate guids now</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings SetGenerateGuidsNow(this WixHeatSettings toolSettings, bool? generateGuidsNow)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateGuidsNow = generateGuidsNow;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixHeatSettings.GenerateGuidsNow"/></em></p>
        ///   <p>generate guids now</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ResetGenerateGuidsNow(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateGuidsNow = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixHeatSettings.GenerateGuidsNow"/></em></p>
        ///   <p>generate guids now</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings EnableGenerateGuidsNow(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateGuidsNow = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixHeatSettings.GenerateGuidsNow"/></em></p>
        ///   <p>generate guids now</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings DisableGenerateGuidsNow(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateGuidsNow = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixHeatSettings.GenerateGuidsNow"/></em></p>
        ///   <p>generate guids now</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ToggleGenerateGuidsNow(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateGuidsNow = !toolSettings.GenerateGuidsNow;
            return toolSettings;
        }
        #endregion
        #region Indentation
        /// <summary>
        ///   <p><em>Sets <see cref="WixHeatSettings.Indentation"/></em></p>
        ///   <p>indentation multiple</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings SetIndentation(this WixHeatSettings toolSettings, int? indentation)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Indentation = indentation;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixHeatSettings.Indentation"/></em></p>
        ///   <p>indentation multiple</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ResetIndentation(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Indentation = null;
            return toolSettings;
        }
        #endregion
        #region KeepEmptyDirectories
        /// <summary>
        ///   <p><em>Sets <see cref="WixHeatSettings.KeepEmptyDirectories"/></em></p>
        ///   <p>keep empty directories</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings SetKeepEmptyDirectories(this WixHeatSettings toolSettings, bool? keepEmptyDirectories)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepEmptyDirectories = keepEmptyDirectories;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixHeatSettings.KeepEmptyDirectories"/></em></p>
        ///   <p>keep empty directories</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ResetKeepEmptyDirectories(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepEmptyDirectories = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixHeatSettings.KeepEmptyDirectories"/></em></p>
        ///   <p>keep empty directories</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings EnableKeepEmptyDirectories(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepEmptyDirectories = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixHeatSettings.KeepEmptyDirectories"/></em></p>
        ///   <p>keep empty directories</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings DisableKeepEmptyDirectories(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepEmptyDirectories = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixHeatSettings.KeepEmptyDirectories"/></em></p>
        ///   <p>keep empty directories</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ToggleKeepEmptyDirectories(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepEmptyDirectories = !toolSettings.KeepEmptyDirectories;
            return toolSettings;
        }
        #endregion
        #region Platform
        /// <summary>
        ///   <p><em>Sets <see cref="WixHeatSettings.Platform"/></em></p>
        ///   <p>platform to set when harvesting the project</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings SetPlatform(this WixHeatSettings toolSettings, string platform)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Platform = platform;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixHeatSettings.Platform"/></em></p>
        ///   <p>platform to set when harvesting the project</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ResetPlatform(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Platform = null;
            return toolSettings;
        }
        #endregion
        #region ProjectOutputGroup
        /// <summary>
        ///   <p><em>Sets <see cref="WixHeatSettings.ProjectOutputGroup"/> to a new list</em></p>
        ///   <p>specify output group of VS project</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings SetProjectOutputGroup(this WixHeatSettings toolSettings, params ProjectOutputGroup[] projectOutputGroup)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectOutputGroupInternal = projectOutputGroup.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="WixHeatSettings.ProjectOutputGroup"/> to a new list</em></p>
        ///   <p>specify output group of VS project</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings SetProjectOutputGroup(this WixHeatSettings toolSettings, IEnumerable<ProjectOutputGroup> projectOutputGroup)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectOutputGroupInternal = projectOutputGroup.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixHeatSettings.ProjectOutputGroup"/></em></p>
        ///   <p>specify output group of VS project</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings AddProjectOutputGroup(this WixHeatSettings toolSettings, params ProjectOutputGroup[] projectOutputGroup)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectOutputGroupInternal.AddRange(projectOutputGroup);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixHeatSettings.ProjectOutputGroup"/></em></p>
        ///   <p>specify output group of VS project</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings AddProjectOutputGroup(this WixHeatSettings toolSettings, IEnumerable<ProjectOutputGroup> projectOutputGroup)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectOutputGroupInternal.AddRange(projectOutputGroup);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="WixHeatSettings.ProjectOutputGroup"/></em></p>
        ///   <p>specify output group of VS project</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ClearProjectOutputGroup(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectOutputGroupInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixHeatSettings.ProjectOutputGroup"/></em></p>
        ///   <p>specify output group of VS project</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings RemoveProjectOutputGroup(this WixHeatSettings toolSettings, params ProjectOutputGroup[] projectOutputGroup)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<ProjectOutputGroup>(projectOutputGroup);
            toolSettings.ProjectOutputGroupInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixHeatSettings.ProjectOutputGroup"/></em></p>
        ///   <p>specify output group of VS project</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings RemoveProjectOutputGroup(this WixHeatSettings toolSettings, IEnumerable<ProjectOutputGroup> projectOutputGroup)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<ProjectOutputGroup>(projectOutputGroup);
            toolSettings.ProjectOutputGroupInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ProjectName
        /// <summary>
        ///   <p><em>Sets <see cref="WixHeatSettings.ProjectName"/></em></p>
        ///   <p>overridden project name to use in variables</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings SetProjectName(this WixHeatSettings toolSettings, string projectName)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectName = projectName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixHeatSettings.ProjectName"/></em></p>
        ///   <p>overridden project name to use in variables</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ResetProjectName(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectName = null;
            return toolSettings;
        }
        #endregion
        #region SuppressComElements
        /// <summary>
        ///   <p><em>Sets <see cref="WixHeatSettings.SuppressComElements"/></em></p>
        ///   <p>suppress COM elements</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings SetSuppressComElements(this WixHeatSettings toolSettings, bool? suppressComElements)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressComElements = suppressComElements;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixHeatSettings.SuppressComElements"/></em></p>
        ///   <p>suppress COM elements</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ResetSuppressComElements(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressComElements = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixHeatSettings.SuppressComElements"/></em></p>
        ///   <p>suppress COM elements</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings EnableSuppressComElements(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressComElements = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixHeatSettings.SuppressComElements"/></em></p>
        ///   <p>suppress COM elements</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings DisableSuppressComElements(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressComElements = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixHeatSettings.SuppressComElements"/></em></p>
        ///   <p>suppress COM elements</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ToggleSuppressComElements(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressComElements = !toolSettings.SuppressComElements;
            return toolSettings;
        }
        #endregion
        #region SuppressFragments
        /// <summary>
        ///   <p><em>Sets <see cref="WixHeatSettings.SuppressFragments"/></em></p>
        ///   <p>suppress fragments</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings SetSuppressFragments(this WixHeatSettings toolSettings, bool? suppressFragments)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressFragments = suppressFragments;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixHeatSettings.SuppressFragments"/></em></p>
        ///   <p>suppress fragments</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ResetSuppressFragments(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressFragments = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixHeatSettings.SuppressFragments"/></em></p>
        ///   <p>suppress fragments</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings EnableSuppressFragments(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressFragments = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixHeatSettings.SuppressFragments"/></em></p>
        ///   <p>suppress fragments</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings DisableSuppressFragments(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressFragments = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixHeatSettings.SuppressFragments"/></em></p>
        ///   <p>suppress fragments</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ToggleSuppressFragments(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressFragments = !toolSettings.SuppressFragments;
            return toolSettings;
        }
        #endregion
        #region SuppressRootDirectoryAsElement
        /// <summary>
        ///   <p><em>Sets <see cref="WixHeatSettings.SuppressRootDirectoryAsElement"/></em></p>
        ///   <p>suppress harvesting the root directory as an element</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings SetSuppressRootDirectoryAsElement(this WixHeatSettings toolSettings, bool? suppressRootDirectoryAsElement)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressRootDirectoryAsElement = suppressRootDirectoryAsElement;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixHeatSettings.SuppressRootDirectoryAsElement"/></em></p>
        ///   <p>suppress harvesting the root directory as an element</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ResetSuppressRootDirectoryAsElement(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressRootDirectoryAsElement = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixHeatSettings.SuppressRootDirectoryAsElement"/></em></p>
        ///   <p>suppress harvesting the root directory as an element</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings EnableSuppressRootDirectoryAsElement(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressRootDirectoryAsElement = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixHeatSettings.SuppressRootDirectoryAsElement"/></em></p>
        ///   <p>suppress harvesting the root directory as an element</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings DisableSuppressRootDirectoryAsElement(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressRootDirectoryAsElement = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixHeatSettings.SuppressRootDirectoryAsElement"/></em></p>
        ///   <p>suppress harvesting the root directory as an element</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ToggleSuppressRootDirectoryAsElement(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressRootDirectoryAsElement = !toolSettings.SuppressRootDirectoryAsElement;
            return toolSettings;
        }
        #endregion
        #region SuppressRegistry
        /// <summary>
        ///   <p><em>Sets <see cref="WixHeatSettings.SuppressRegistry"/></em></p>
        ///   <p>suppress registry harvesting</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings SetSuppressRegistry(this WixHeatSettings toolSettings, bool? suppressRegistry)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressRegistry = suppressRegistry;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixHeatSettings.SuppressRegistry"/></em></p>
        ///   <p>suppress registry harvesting</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ResetSuppressRegistry(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressRegistry = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixHeatSettings.SuppressRegistry"/></em></p>
        ///   <p>suppress registry harvesting</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings EnableSuppressRegistry(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressRegistry = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixHeatSettings.SuppressRegistry"/></em></p>
        ///   <p>suppress registry harvesting</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings DisableSuppressRegistry(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressRegistry = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixHeatSettings.SuppressRegistry"/></em></p>
        ///   <p>suppress registry harvesting</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ToggleSuppressRegistry(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressRegistry = !toolSettings.SuppressRegistry;
            return toolSettings;
        }
        #endregion
        #region SuppressUids
        /// <summary>
        ///   <p><em>Sets <see cref="WixHeatSettings.SuppressUids"/></em></p>
        ///   <p>suppress unique identifiers for files, components, and directories</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings SetSuppressUids(this WixHeatSettings toolSettings, bool? suppressUids)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressUids = suppressUids;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixHeatSettings.SuppressUids"/></em></p>
        ///   <p>suppress unique identifiers for files, components, and directories</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ResetSuppressUids(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressUids = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixHeatSettings.SuppressUids"/></em></p>
        ///   <p>suppress unique identifiers for files, components, and directories</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings EnableSuppressUids(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressUids = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixHeatSettings.SuppressUids"/></em></p>
        ///   <p>suppress unique identifiers for files, components, and directories</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings DisableSuppressUids(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressUids = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixHeatSettings.SuppressUids"/></em></p>
        ///   <p>suppress unique identifiers for files, components, and directories</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ToggleSuppressUids(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressUids = !toolSettings.SuppressUids;
            return toolSettings;
        }
        #endregion
        #region SuppressVb6ComElements
        /// <summary>
        ///   <p><em>Sets <see cref="WixHeatSettings.SuppressVb6ComElements"/></em></p>
        ///   <p>suppress VB6 COM elements</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings SetSuppressVb6ComElements(this WixHeatSettings toolSettings, bool? suppressVb6ComElements)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressVb6ComElements = suppressVb6ComElements;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixHeatSettings.SuppressVb6ComElements"/></em></p>
        ///   <p>suppress VB6 COM elements</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ResetSuppressVb6ComElements(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressVb6ComElements = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixHeatSettings.SuppressVb6ComElements"/></em></p>
        ///   <p>suppress VB6 COM elements</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings EnableSuppressVb6ComElements(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressVb6ComElements = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixHeatSettings.SuppressVb6ComElements"/></em></p>
        ///   <p>suppress VB6 COM elements</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings DisableSuppressVb6ComElements(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressVb6ComElements = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixHeatSettings.SuppressVb6ComElements"/></em></p>
        ///   <p>suppress VB6 COM elements</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ToggleSuppressVb6ComElements(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressVb6ComElements = !toolSettings.SuppressVb6ComElements;
            return toolSettings;
        }
        #endregion
        #region Transform
        /// <summary>
        ///   <p><em>Sets <see cref="WixHeatSettings.Transform"/></em></p>
        ///   <p>transform harvested output with XSL file</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings SetTransform(this WixHeatSettings toolSettings, string transform)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Transform = transform;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixHeatSettings.Transform"/></em></p>
        ///   <p>transform harvested output with XSL file</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ResetTransform(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Transform = null;
            return toolSettings;
        }
        #endregion
        #region Template
        /// <summary>
        ///   <p><em>Sets <see cref="WixHeatSettings.Template"/></em></p>
        ///   <p>use template, one of: fragment,module,product</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings SetTemplate(this WixHeatSettings toolSettings, Template template)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Template = template;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixHeatSettings.Template"/></em></p>
        ///   <p>use template, one of: fragment,module,product</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ResetTemplate(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Template = null;
            return toolSettings;
        }
        #endregion
        #region Var
        /// <summary>
        ///   <p><em>Sets <see cref="WixHeatSettings.Var"/></em></p>
        ///   <p>substitute File/@Source="SourceDir" with a preprocessor or a wix variable (e.g. -var var.MySource will become File/@Source="$(var.MySource)\myfile.txt" and -var wix.MySource will become File/@Source="!(wix.MySource)\myfile.txt"</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings SetVar(this WixHeatSettings toolSettings, string var)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Var = var;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixHeatSettings.Var"/></em></p>
        ///   <p>substitute File/@Source="SourceDir" with a preprocessor or a wix variable (e.g. -var var.MySource will become File/@Source="$(var.MySource)\myfile.txt" and -var wix.MySource will become File/@Source="!(wix.MySource)\myfile.txt"</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ResetVar(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Var = null;
            return toolSettings;
        }
        #endregion
        #region WixVar
        /// <summary>
        ///   <p><em>Sets <see cref="WixHeatSettings.WixVar"/></em></p>
        ///   <p>generate binder variables instead of preprocessor variables</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings SetWixVar(this WixHeatSettings toolSettings, bool? wixVar)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WixVar = wixVar;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixHeatSettings.WixVar"/></em></p>
        ///   <p>generate binder variables instead of preprocessor variables</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ResetWixVar(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WixVar = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixHeatSettings.WixVar"/></em></p>
        ///   <p>generate binder variables instead of preprocessor variables</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings EnableWixVar(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WixVar = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixHeatSettings.WixVar"/></em></p>
        ///   <p>generate binder variables instead of preprocessor variables</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings DisableWixVar(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WixVar = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixHeatSettings.WixVar"/></em></p>
        ///   <p>generate binder variables instead of preprocessor variables</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ToggleWixVar(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WixVar = !toolSettings.WixVar;
            return toolSettings;
        }
        #endregion
        #region SuppressAllWarnings
        /// <summary>
        ///   <p><em>Sets <see cref="WixHeatSettings.SuppressAllWarnings"/></em></p>
        ///   <p>suppress all warnings</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings SetSuppressAllWarnings(this WixHeatSettings toolSettings, bool? suppressAllWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAllWarnings = suppressAllWarnings;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixHeatSettings.SuppressAllWarnings"/></em></p>
        ///   <p>suppress all warnings</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ResetSuppressAllWarnings(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAllWarnings = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixHeatSettings.SuppressAllWarnings"/></em></p>
        ///   <p>suppress all warnings</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings EnableSuppressAllWarnings(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAllWarnings = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixHeatSettings.SuppressAllWarnings"/></em></p>
        ///   <p>suppress all warnings</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings DisableSuppressAllWarnings(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAllWarnings = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixHeatSettings.SuppressAllWarnings"/></em></p>
        ///   <p>suppress all warnings</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ToggleSuppressAllWarnings(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAllWarnings = !toolSettings.SuppressAllWarnings;
            return toolSettings;
        }
        #endregion
        #region SuppressWarnings
        /// <summary>
        ///   <p><em>Sets <see cref="WixHeatSettings.SuppressWarnings"/> to a new list</em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings SetSuppressWarnings(this WixHeatSettings toolSettings, params int[] suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWarningsInternal = suppressWarnings.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="WixHeatSettings.SuppressWarnings"/> to a new list</em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings SetSuppressWarnings(this WixHeatSettings toolSettings, IEnumerable<int> suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWarningsInternal = suppressWarnings.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixHeatSettings.SuppressWarnings"/></em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings AddSuppressWarnings(this WixHeatSettings toolSettings, params int[] suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWarningsInternal.AddRange(suppressWarnings);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixHeatSettings.SuppressWarnings"/></em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings AddSuppressWarnings(this WixHeatSettings toolSettings, IEnumerable<int> suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWarningsInternal.AddRange(suppressWarnings);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="WixHeatSettings.SuppressWarnings"/></em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ClearSuppressWarnings(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWarningsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixHeatSettings.SuppressWarnings"/></em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings RemoveSuppressWarnings(this WixHeatSettings toolSettings, params int[] suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<int>(suppressWarnings);
            toolSettings.SuppressWarningsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixHeatSettings.SuppressWarnings"/></em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings RemoveSuppressWarnings(this WixHeatSettings toolSettings, IEnumerable<int> suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<int>(suppressWarnings);
            toolSettings.SuppressWarningsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region WarningsAsErrors
        /// <summary>
        ///   <p><em>Sets <see cref="WixHeatSettings.WarningsAsErrors"/></em></p>
        ///   <p>treat all warnings as an error</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings SetWarningsAsErrors(this WixHeatSettings toolSettings, bool? warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = warningsAsErrors;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixHeatSettings.WarningsAsErrors"/></em></p>
        ///   <p>treat all warnings as an error</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ResetWarningsAsErrors(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixHeatSettings.WarningsAsErrors"/></em></p>
        ///   <p>treat all warnings as an error</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings EnableWarningsAsErrors(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixHeatSettings.WarningsAsErrors"/></em></p>
        ///   <p>treat all warnings as an error</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings DisableWarningsAsErrors(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixHeatSettings.WarningsAsErrors"/></em></p>
        ///   <p>treat all warnings as an error</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ToggleWarningsAsErrors(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = !toolSettings.WarningsAsErrors;
            return toolSettings;
        }
        #endregion
        #region MessageIdAsError
        /// <summary>
        ///   <p><em>Sets <see cref="WixHeatSettings.MessageIdAsError"/> to a new list</em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings SetMessageIdAsError(this WixHeatSettings toolSettings, params int[] messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MessageIdAsErrorInternal = messageIdAsError.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="WixHeatSettings.MessageIdAsError"/> to a new list</em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings SetMessageIdAsError(this WixHeatSettings toolSettings, IEnumerable<int> messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MessageIdAsErrorInternal = messageIdAsError.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixHeatSettings.MessageIdAsError"/></em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings AddMessageIdAsError(this WixHeatSettings toolSettings, params int[] messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MessageIdAsErrorInternal.AddRange(messageIdAsError);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixHeatSettings.MessageIdAsError"/></em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings AddMessageIdAsError(this WixHeatSettings toolSettings, IEnumerable<int> messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MessageIdAsErrorInternal.AddRange(messageIdAsError);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="WixHeatSettings.MessageIdAsError"/></em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ClearMessageIdAsError(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MessageIdAsErrorInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixHeatSettings.MessageIdAsError"/></em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings RemoveMessageIdAsError(this WixHeatSettings toolSettings, params int[] messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<int>(messageIdAsError);
            toolSettings.MessageIdAsErrorInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixHeatSettings.MessageIdAsError"/></em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings RemoveMessageIdAsError(this WixHeatSettings toolSettings, IEnumerable<int> messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<int>(messageIdAsError);
            toolSettings.MessageIdAsErrorInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Extension
        /// <summary>
        ///   <p><em>Sets <see cref="WixHeatSettings.Extension"/> to a new list</em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings SetExtension(this WixHeatSettings toolSettings, params string[] extension)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionInternal = extension.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="WixHeatSettings.Extension"/> to a new list</em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings SetExtension(this WixHeatSettings toolSettings, IEnumerable<string> extension)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionInternal = extension.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixHeatSettings.Extension"/></em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings AddExtension(this WixHeatSettings toolSettings, params string[] extension)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionInternal.AddRange(extension);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixHeatSettings.Extension"/></em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings AddExtension(this WixHeatSettings toolSettings, IEnumerable<string> extension)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionInternal.AddRange(extension);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="WixHeatSettings.Extension"/></em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ClearExtension(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixHeatSettings.Extension"/></em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings RemoveExtension(this WixHeatSettings toolSettings, params string[] extension)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(extension);
            toolSettings.ExtensionInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixHeatSettings.Extension"/></em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings RemoveExtension(this WixHeatSettings toolSettings, IEnumerable<string> extension)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(extension);
            toolSettings.ExtensionInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary>
        ///   <p><em>Sets <see cref="WixHeatSettings.Output"/></em></p>
        ///   <p>specify output file (default: write to current directory)</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings SetOutput(this WixHeatSettings toolSettings, string output)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixHeatSettings.Output"/></em></p>
        ///   <p>specify output file (default: write to current directory)</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ResetOutput(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
        #region NoLogo
        /// <summary>
        ///   <p><em>Sets <see cref="WixHeatSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings SetNoLogo(this WixHeatSettings toolSettings, bool? noLogo)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = noLogo;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixHeatSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ResetNoLogo(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixHeatSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings EnableNoLogo(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixHeatSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings DisableNoLogo(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixHeatSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ToggleNoLogo(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = !toolSettings.NoLogo;
            return toolSettings;
        }
        #endregion
        #region Verbose
        /// <summary>
        ///   <p><em>Sets <see cref="WixHeatSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings SetVerbose(this WixHeatSettings toolSettings, bool? verbose)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = verbose;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixHeatSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ResetVerbose(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixHeatSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings EnableVerbose(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixHeatSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings DisableVerbose(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixHeatSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixHeatSettings ToggleVerbose(this WixHeatSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = !toolSettings.Verbose;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region WixInsigniaSettingsExtensions
    /// <summary>
    ///   Used within <see cref="WixTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class WixInsigniaSettingsExtensions
    {
        #region DatabaseFile
        /// <summary>
        ///   <p><em>Sets <see cref="WixInsigniaSettings.DatabaseFile"/></em></p>
        ///   <p>specify the database file to inscribe</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings SetDatabaseFile(this WixInsigniaSettings toolSettings, string databaseFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DatabaseFile = databaseFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixInsigniaSettings.DatabaseFile"/></em></p>
        ///   <p>specify the database file to inscribe</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings ResetDatabaseFile(this WixInsigniaSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DatabaseFile = null;
            return toolSettings;
        }
        #endregion
        #region Bundle
        /// <summary>
        ///   <p><em>Sets <see cref="WixInsigniaSettings.Bundle"/></em></p>
        ///   <p>specify the bundle file from which to extract the engine. The engine is stored in the file specified by -o</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings SetBundle(this WixInsigniaSettings toolSettings, string bundle)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Bundle = bundle;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixInsigniaSettings.Bundle"/></em></p>
        ///   <p>specify the bundle file from which to extract the engine. The engine is stored in the file specified by -o</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings ResetBundle(this WixInsigniaSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Bundle = null;
            return toolSettings;
        }
        #endregion
        #region Reattach
        /// <summary>
        ///   <p><em>Sets <see cref="WixInsigniaSettings.Reattach"/></em></p>
        ///   <p>Reattach the engine to a bundle (bundle path + bundle with attached container path)</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings SetReattach(this WixInsigniaSettings toolSettings, string reattach)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Reattach = reattach;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixInsigniaSettings.Reattach"/></em></p>
        ///   <p>Reattach the engine to a bundle (bundle path + bundle with attached container path)</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings ResetReattach(this WixInsigniaSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Reattach = null;
            return toolSettings;
        }
        #endregion
        #region SuppressAllWarnings
        /// <summary>
        ///   <p><em>Sets <see cref="WixInsigniaSettings.SuppressAllWarnings"/></em></p>
        ///   <p>suppress all warnings</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings SetSuppressAllWarnings(this WixInsigniaSettings toolSettings, bool? suppressAllWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAllWarnings = suppressAllWarnings;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixInsigniaSettings.SuppressAllWarnings"/></em></p>
        ///   <p>suppress all warnings</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings ResetSuppressAllWarnings(this WixInsigniaSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAllWarnings = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixInsigniaSettings.SuppressAllWarnings"/></em></p>
        ///   <p>suppress all warnings</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings EnableSuppressAllWarnings(this WixInsigniaSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAllWarnings = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixInsigniaSettings.SuppressAllWarnings"/></em></p>
        ///   <p>suppress all warnings</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings DisableSuppressAllWarnings(this WixInsigniaSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAllWarnings = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixInsigniaSettings.SuppressAllWarnings"/></em></p>
        ///   <p>suppress all warnings</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings ToggleSuppressAllWarnings(this WixInsigniaSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAllWarnings = !toolSettings.SuppressAllWarnings;
            return toolSettings;
        }
        #endregion
        #region SuppressWarnings
        /// <summary>
        ///   <p><em>Sets <see cref="WixInsigniaSettings.SuppressWarnings"/> to a new list</em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings SetSuppressWarnings(this WixInsigniaSettings toolSettings, params int[] suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWarningsInternal = suppressWarnings.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="WixInsigniaSettings.SuppressWarnings"/> to a new list</em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings SetSuppressWarnings(this WixInsigniaSettings toolSettings, IEnumerable<int> suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWarningsInternal = suppressWarnings.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixInsigniaSettings.SuppressWarnings"/></em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings AddSuppressWarnings(this WixInsigniaSettings toolSettings, params int[] suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWarningsInternal.AddRange(suppressWarnings);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixInsigniaSettings.SuppressWarnings"/></em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings AddSuppressWarnings(this WixInsigniaSettings toolSettings, IEnumerable<int> suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWarningsInternal.AddRange(suppressWarnings);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="WixInsigniaSettings.SuppressWarnings"/></em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings ClearSuppressWarnings(this WixInsigniaSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWarningsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixInsigniaSettings.SuppressWarnings"/></em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings RemoveSuppressWarnings(this WixInsigniaSettings toolSettings, params int[] suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<int>(suppressWarnings);
            toolSettings.SuppressWarningsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixInsigniaSettings.SuppressWarnings"/></em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings RemoveSuppressWarnings(this WixInsigniaSettings toolSettings, IEnumerable<int> suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<int>(suppressWarnings);
            toolSettings.SuppressWarningsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region WarningsAsErrors
        /// <summary>
        ///   <p><em>Sets <see cref="WixInsigniaSettings.WarningsAsErrors"/></em></p>
        ///   <p>treat all warnings as an error</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings SetWarningsAsErrors(this WixInsigniaSettings toolSettings, bool? warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = warningsAsErrors;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixInsigniaSettings.WarningsAsErrors"/></em></p>
        ///   <p>treat all warnings as an error</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings ResetWarningsAsErrors(this WixInsigniaSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixInsigniaSettings.WarningsAsErrors"/></em></p>
        ///   <p>treat all warnings as an error</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings EnableWarningsAsErrors(this WixInsigniaSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixInsigniaSettings.WarningsAsErrors"/></em></p>
        ///   <p>treat all warnings as an error</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings DisableWarningsAsErrors(this WixInsigniaSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixInsigniaSettings.WarningsAsErrors"/></em></p>
        ///   <p>treat all warnings as an error</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings ToggleWarningsAsErrors(this WixInsigniaSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = !toolSettings.WarningsAsErrors;
            return toolSettings;
        }
        #endregion
        #region MessageIdAsError
        /// <summary>
        ///   <p><em>Sets <see cref="WixInsigniaSettings.MessageIdAsError"/> to a new list</em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings SetMessageIdAsError(this WixInsigniaSettings toolSettings, params int[] messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MessageIdAsErrorInternal = messageIdAsError.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="WixInsigniaSettings.MessageIdAsError"/> to a new list</em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings SetMessageIdAsError(this WixInsigniaSettings toolSettings, IEnumerable<int> messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MessageIdAsErrorInternal = messageIdAsError.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixInsigniaSettings.MessageIdAsError"/></em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings AddMessageIdAsError(this WixInsigniaSettings toolSettings, params int[] messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MessageIdAsErrorInternal.AddRange(messageIdAsError);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixInsigniaSettings.MessageIdAsError"/></em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings AddMessageIdAsError(this WixInsigniaSettings toolSettings, IEnumerable<int> messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MessageIdAsErrorInternal.AddRange(messageIdAsError);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="WixInsigniaSettings.MessageIdAsError"/></em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings ClearMessageIdAsError(this WixInsigniaSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MessageIdAsErrorInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixInsigniaSettings.MessageIdAsError"/></em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings RemoveMessageIdAsError(this WixInsigniaSettings toolSettings, params int[] messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<int>(messageIdAsError);
            toolSettings.MessageIdAsErrorInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixInsigniaSettings.MessageIdAsError"/></em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings RemoveMessageIdAsError(this WixInsigniaSettings toolSettings, IEnumerable<int> messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<int>(messageIdAsError);
            toolSettings.MessageIdAsErrorInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ResponseFile
        /// <summary>
        ///   <p><em>Sets <see cref="WixInsigniaSettings.ResponseFile"/></em></p>
        ///   <p>response file</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings SetResponseFile(this WixInsigniaSettings toolSettings, string responseFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResponseFile = responseFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixInsigniaSettings.ResponseFile"/></em></p>
        ///   <p>response file</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings ResetResponseFile(this WixInsigniaSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResponseFile = null;
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary>
        ///   <p><em>Sets <see cref="WixInsigniaSettings.Output"/></em></p>
        ///   <p>specify output file (default: write to current directory)</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings SetOutput(this WixInsigniaSettings toolSettings, string output)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixInsigniaSettings.Output"/></em></p>
        ///   <p>specify output file (default: write to current directory)</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings ResetOutput(this WixInsigniaSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
        #region NoLogo
        /// <summary>
        ///   <p><em>Sets <see cref="WixInsigniaSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings SetNoLogo(this WixInsigniaSettings toolSettings, bool? noLogo)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = noLogo;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixInsigniaSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings ResetNoLogo(this WixInsigniaSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixInsigniaSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings EnableNoLogo(this WixInsigniaSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixInsigniaSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings DisableNoLogo(this WixInsigniaSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixInsigniaSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings ToggleNoLogo(this WixInsigniaSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = !toolSettings.NoLogo;
            return toolSettings;
        }
        #endregion
        #region Verbose
        /// <summary>
        ///   <p><em>Sets <see cref="WixInsigniaSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings SetVerbose(this WixInsigniaSettings toolSettings, bool? verbose)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = verbose;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixInsigniaSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings ResetVerbose(this WixInsigniaSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixInsigniaSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings EnableVerbose(this WixInsigniaSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixInsigniaSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings DisableVerbose(this WixInsigniaSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixInsigniaSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixInsigniaSettings ToggleVerbose(this WixInsigniaSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = !toolSettings.Verbose;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region WixSmokeSettingsExtensions
    /// <summary>
    ///   Used within <see cref="WixTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class WixSmokeSettingsExtensions
    {
        #region NoDefault
        /// <summary>
        ///   <p><em>Sets <see cref="WixSmokeSettings.NoDefault"/></em></p>
        ///   <p>do not add the default .cub files for .msi and .msm files</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings SetNoDefault(this WixSmokeSettings toolSettings, bool? noDefault)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDefault = noDefault;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixSmokeSettings.NoDefault"/></em></p>
        ///   <p>do not add the default .cub files for .msi and .msm files</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings ResetNoDefault(this WixSmokeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDefault = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixSmokeSettings.NoDefault"/></em></p>
        ///   <p>do not add the default .cub files for .msi and .msm files</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings EnableNoDefault(this WixSmokeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDefault = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixSmokeSettings.NoDefault"/></em></p>
        ///   <p>do not add the default .cub files for .msi and .msm files</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings DisableNoDefault(this WixSmokeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDefault = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixSmokeSettings.NoDefault"/></em></p>
        ///   <p>do not add the default .cub files for .msi and .msm files</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings ToggleNoDefault(this WixSmokeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDefault = !toolSettings.NoDefault;
            return toolSettings;
        }
        #endregion
        #region Pdb
        /// <summary>
        ///   <p><em>Sets <see cref="WixSmokeSettings.Pdb"/></em></p>
        ///   <p>path to the pdb file corresponding to the databaseFile</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings SetPdb(this WixSmokeSettings toolSettings, string pdb)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pdb = pdb;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixSmokeSettings.Pdb"/></em></p>
        ///   <p>path to the pdb file corresponding to the databaseFile</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings ResetPdb(this WixSmokeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pdb = null;
            return toolSettings;
        }
        #endregion
        #region InputFiles
        /// <summary>
        ///   <p><em>Sets <see cref="WixSmokeSettings.InputFiles"/> to a new list</em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings SetInputFiles(this WixSmokeSettings toolSettings, params string[] inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal = inputFiles.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="WixSmokeSettings.InputFiles"/> to a new list</em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings SetInputFiles(this WixSmokeSettings toolSettings, IEnumerable<string> inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal = inputFiles.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixSmokeSettings.InputFiles"/></em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings AddInputFiles(this WixSmokeSettings toolSettings, params string[] inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal.AddRange(inputFiles);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixSmokeSettings.InputFiles"/></em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings AddInputFiles(this WixSmokeSettings toolSettings, IEnumerable<string> inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal.AddRange(inputFiles);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="WixSmokeSettings.InputFiles"/></em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings ClearInputFiles(this WixSmokeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixSmokeSettings.InputFiles"/></em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings RemoveInputFiles(this WixSmokeSettings toolSettings, params string[] inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(inputFiles);
            toolSettings.InputFilesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixSmokeSettings.InputFiles"/></em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings RemoveInputFiles(this WixSmokeSettings toolSettings, IEnumerable<string> inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(inputFiles);
            toolSettings.InputFilesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Extension
        /// <summary>
        ///   <p><em>Sets <see cref="WixSmokeSettings.Extension"/> to a new list</em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings SetExtension(this WixSmokeSettings toolSettings, params string[] extension)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionInternal = extension.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="WixSmokeSettings.Extension"/> to a new list</em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings SetExtension(this WixSmokeSettings toolSettings, IEnumerable<string> extension)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionInternal = extension.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixSmokeSettings.Extension"/></em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings AddExtension(this WixSmokeSettings toolSettings, params string[] extension)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionInternal.AddRange(extension);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixSmokeSettings.Extension"/></em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings AddExtension(this WixSmokeSettings toolSettings, IEnumerable<string> extension)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionInternal.AddRange(extension);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="WixSmokeSettings.Extension"/></em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings ClearExtension(this WixSmokeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixSmokeSettings.Extension"/></em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings RemoveExtension(this WixSmokeSettings toolSettings, params string[] extension)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(extension);
            toolSettings.ExtensionInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixSmokeSettings.Extension"/></em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings RemoveExtension(this WixSmokeSettings toolSettings, IEnumerable<string> extension)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(extension);
            toolSettings.ExtensionInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region SuppressAllWarnings
        /// <summary>
        ///   <p><em>Sets <see cref="WixSmokeSettings.SuppressAllWarnings"/></em></p>
        ///   <p>suppress all warnings</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings SetSuppressAllWarnings(this WixSmokeSettings toolSettings, bool? suppressAllWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAllWarnings = suppressAllWarnings;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixSmokeSettings.SuppressAllWarnings"/></em></p>
        ///   <p>suppress all warnings</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings ResetSuppressAllWarnings(this WixSmokeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAllWarnings = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixSmokeSettings.SuppressAllWarnings"/></em></p>
        ///   <p>suppress all warnings</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings EnableSuppressAllWarnings(this WixSmokeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAllWarnings = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixSmokeSettings.SuppressAllWarnings"/></em></p>
        ///   <p>suppress all warnings</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings DisableSuppressAllWarnings(this WixSmokeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAllWarnings = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixSmokeSettings.SuppressAllWarnings"/></em></p>
        ///   <p>suppress all warnings</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings ToggleSuppressAllWarnings(this WixSmokeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAllWarnings = !toolSettings.SuppressAllWarnings;
            return toolSettings;
        }
        #endregion
        #region SuppressWarnings
        /// <summary>
        ///   <p><em>Sets <see cref="WixSmokeSettings.SuppressWarnings"/> to a new list</em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings SetSuppressWarnings(this WixSmokeSettings toolSettings, params int[] suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWarningsInternal = suppressWarnings.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="WixSmokeSettings.SuppressWarnings"/> to a new list</em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings SetSuppressWarnings(this WixSmokeSettings toolSettings, IEnumerable<int> suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWarningsInternal = suppressWarnings.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixSmokeSettings.SuppressWarnings"/></em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings AddSuppressWarnings(this WixSmokeSettings toolSettings, params int[] suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWarningsInternal.AddRange(suppressWarnings);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixSmokeSettings.SuppressWarnings"/></em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings AddSuppressWarnings(this WixSmokeSettings toolSettings, IEnumerable<int> suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWarningsInternal.AddRange(suppressWarnings);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="WixSmokeSettings.SuppressWarnings"/></em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings ClearSuppressWarnings(this WixSmokeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWarningsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixSmokeSettings.SuppressWarnings"/></em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings RemoveSuppressWarnings(this WixSmokeSettings toolSettings, params int[] suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<int>(suppressWarnings);
            toolSettings.SuppressWarningsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixSmokeSettings.SuppressWarnings"/></em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings RemoveSuppressWarnings(this WixSmokeSettings toolSettings, IEnumerable<int> suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<int>(suppressWarnings);
            toolSettings.SuppressWarningsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region WarningsAsErrors
        /// <summary>
        ///   <p><em>Sets <see cref="WixSmokeSettings.WarningsAsErrors"/></em></p>
        ///   <p>treat all warnings as an error</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings SetWarningsAsErrors(this WixSmokeSettings toolSettings, bool? warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = warningsAsErrors;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixSmokeSettings.WarningsAsErrors"/></em></p>
        ///   <p>treat all warnings as an error</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings ResetWarningsAsErrors(this WixSmokeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixSmokeSettings.WarningsAsErrors"/></em></p>
        ///   <p>treat all warnings as an error</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings EnableWarningsAsErrors(this WixSmokeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixSmokeSettings.WarningsAsErrors"/></em></p>
        ///   <p>treat all warnings as an error</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings DisableWarningsAsErrors(this WixSmokeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixSmokeSettings.WarningsAsErrors"/></em></p>
        ///   <p>treat all warnings as an error</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings ToggleWarningsAsErrors(this WixSmokeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = !toolSettings.WarningsAsErrors;
            return toolSettings;
        }
        #endregion
        #region MessageIdAsError
        /// <summary>
        ///   <p><em>Sets <see cref="WixSmokeSettings.MessageIdAsError"/> to a new list</em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings SetMessageIdAsError(this WixSmokeSettings toolSettings, params int[] messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MessageIdAsErrorInternal = messageIdAsError.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="WixSmokeSettings.MessageIdAsError"/> to a new list</em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings SetMessageIdAsError(this WixSmokeSettings toolSettings, IEnumerable<int> messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MessageIdAsErrorInternal = messageIdAsError.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixSmokeSettings.MessageIdAsError"/></em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings AddMessageIdAsError(this WixSmokeSettings toolSettings, params int[] messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MessageIdAsErrorInternal.AddRange(messageIdAsError);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixSmokeSettings.MessageIdAsError"/></em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings AddMessageIdAsError(this WixSmokeSettings toolSettings, IEnumerable<int> messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MessageIdAsErrorInternal.AddRange(messageIdAsError);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="WixSmokeSettings.MessageIdAsError"/></em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings ClearMessageIdAsError(this WixSmokeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MessageIdAsErrorInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixSmokeSettings.MessageIdAsError"/></em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings RemoveMessageIdAsError(this WixSmokeSettings toolSettings, params int[] messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<int>(messageIdAsError);
            toolSettings.MessageIdAsErrorInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixSmokeSettings.MessageIdAsError"/></em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings RemoveMessageIdAsError(this WixSmokeSettings toolSettings, IEnumerable<int> messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<int>(messageIdAsError);
            toolSettings.MessageIdAsErrorInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region CubFile
        /// <summary>
        ///   <p><em>Sets <see cref="WixSmokeSettings.CubFile"/></em></p>
        ///   <p>additional .cub file containing ICEs to run</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings SetCubFile(this WixSmokeSettings toolSettings, string cubFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CubFile = cubFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixSmokeSettings.CubFile"/></em></p>
        ///   <p>additional .cub file containing ICEs to run</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings ResetCubFile(this WixSmokeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CubFile = null;
            return toolSettings;
        }
        #endregion
        #region Ice
        /// <summary>
        ///   <p><em>Sets <see cref="WixSmokeSettings.Ice"/> to a new list</em></p>
        ///   <p>run a specific internal consistency evaluator (ICE)</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings SetIce(this WixSmokeSettings toolSettings, params string[] ice)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IceInternal = ice.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="WixSmokeSettings.Ice"/> to a new list</em></p>
        ///   <p>run a specific internal consistency evaluator (ICE)</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings SetIce(this WixSmokeSettings toolSettings, IEnumerable<string> ice)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IceInternal = ice.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixSmokeSettings.Ice"/></em></p>
        ///   <p>run a specific internal consistency evaluator (ICE)</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings AddIce(this WixSmokeSettings toolSettings, params string[] ice)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IceInternal.AddRange(ice);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixSmokeSettings.Ice"/></em></p>
        ///   <p>run a specific internal consistency evaluator (ICE)</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings AddIce(this WixSmokeSettings toolSettings, IEnumerable<string> ice)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IceInternal.AddRange(ice);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="WixSmokeSettings.Ice"/></em></p>
        ///   <p>run a specific internal consistency evaluator (ICE)</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings ClearIce(this WixSmokeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IceInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixSmokeSettings.Ice"/></em></p>
        ///   <p>run a specific internal consistency evaluator (ICE)</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings RemoveIce(this WixSmokeSettings toolSettings, params string[] ice)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(ice);
            toolSettings.IceInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixSmokeSettings.Ice"/></em></p>
        ///   <p>run a specific internal consistency evaluator (ICE)</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings RemoveIce(this WixSmokeSettings toolSettings, IEnumerable<string> ice)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(ice);
            toolSettings.IceInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region SuppressIce
        /// <summary>
        ///   <p><em>Sets <see cref="WixSmokeSettings.SuppressIce"/> to a new list</em></p>
        ///   <p>suppress an internal consistency evaluator (ICE)</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings SetSuppressIce(this WixSmokeSettings toolSettings, params string[] suppressIce)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressIceInternal = suppressIce.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="WixSmokeSettings.SuppressIce"/> to a new list</em></p>
        ///   <p>suppress an internal consistency evaluator (ICE)</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings SetSuppressIce(this WixSmokeSettings toolSettings, IEnumerable<string> suppressIce)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressIceInternal = suppressIce.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixSmokeSettings.SuppressIce"/></em></p>
        ///   <p>suppress an internal consistency evaluator (ICE)</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings AddSuppressIce(this WixSmokeSettings toolSettings, params string[] suppressIce)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressIceInternal.AddRange(suppressIce);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixSmokeSettings.SuppressIce"/></em></p>
        ///   <p>suppress an internal consistency evaluator (ICE)</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings AddSuppressIce(this WixSmokeSettings toolSettings, IEnumerable<string> suppressIce)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressIceInternal.AddRange(suppressIce);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="WixSmokeSettings.SuppressIce"/></em></p>
        ///   <p>suppress an internal consistency evaluator (ICE)</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings ClearSuppressIce(this WixSmokeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressIceInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixSmokeSettings.SuppressIce"/></em></p>
        ///   <p>suppress an internal consistency evaluator (ICE)</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings RemoveSuppressIce(this WixSmokeSettings toolSettings, params string[] suppressIce)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(suppressIce);
            toolSettings.SuppressIceInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixSmokeSettings.SuppressIce"/></em></p>
        ///   <p>suppress an internal consistency evaluator (ICE)</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings RemoveSuppressIce(this WixSmokeSettings toolSettings, IEnumerable<string> suppressIce)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(suppressIce);
            toolSettings.SuppressIceInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region NoLogo
        /// <summary>
        ///   <p><em>Sets <see cref="WixSmokeSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings SetNoLogo(this WixSmokeSettings toolSettings, bool? noLogo)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = noLogo;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixSmokeSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings ResetNoLogo(this WixSmokeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixSmokeSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings EnableNoLogo(this WixSmokeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixSmokeSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings DisableNoLogo(this WixSmokeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixSmokeSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings ToggleNoLogo(this WixSmokeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = !toolSettings.NoLogo;
            return toolSettings;
        }
        #endregion
        #region Verbose
        /// <summary>
        ///   <p><em>Sets <see cref="WixSmokeSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings SetVerbose(this WixSmokeSettings toolSettings, bool? verbose)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = verbose;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixSmokeSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings ResetVerbose(this WixSmokeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixSmokeSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings EnableVerbose(this WixSmokeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixSmokeSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings DisableVerbose(this WixSmokeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixSmokeSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings ToggleVerbose(this WixSmokeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = !toolSettings.Verbose;
            return toolSettings;
        }
        #endregion
        #region NoTidy
        /// <summary>
        ///   <p><em>Sets <see cref="WixSmokeSettings.NoTidy"/></em></p>
        ///   <p>do not delete temporary files (useful for debugging)</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings SetNoTidy(this WixSmokeSettings toolSettings, bool? noTidy)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoTidy = noTidy;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixSmokeSettings.NoTidy"/></em></p>
        ///   <p>do not delete temporary files (useful for debugging)</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings ResetNoTidy(this WixSmokeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoTidy = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixSmokeSettings.NoTidy"/></em></p>
        ///   <p>do not delete temporary files (useful for debugging)</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings EnableNoTidy(this WixSmokeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoTidy = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixSmokeSettings.NoTidy"/></em></p>
        ///   <p>do not delete temporary files (useful for debugging)</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings DisableNoTidy(this WixSmokeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoTidy = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixSmokeSettings.NoTidy"/></em></p>
        ///   <p>do not delete temporary files (useful for debugging)</p>
        /// </summary>
        [Pure]
        public static WixSmokeSettings ToggleNoTidy(this WixSmokeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoTidy = !toolSettings.NoTidy;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region WixNitSettingsExtensions
    /// <summary>
    ///   Used within <see cref="WixTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class WixNitSettingsExtensions
    {
        #region InputFiles
        /// <summary>
        ///   <p><em>Sets <see cref="WixNitSettings.InputFiles"/> to a new list</em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixNitSettings SetInputFiles(this WixNitSettings toolSettings, params string[] inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal = inputFiles.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="WixNitSettings.InputFiles"/> to a new list</em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixNitSettings SetInputFiles(this WixNitSettings toolSettings, IEnumerable<string> inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal = inputFiles.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixNitSettings.InputFiles"/></em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixNitSettings AddInputFiles(this WixNitSettings toolSettings, params string[] inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal.AddRange(inputFiles);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixNitSettings.InputFiles"/></em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixNitSettings AddInputFiles(this WixNitSettings toolSettings, IEnumerable<string> inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal.AddRange(inputFiles);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="WixNitSettings.InputFiles"/></em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixNitSettings ClearInputFiles(this WixNitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixNitSettings.InputFiles"/></em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixNitSettings RemoveInputFiles(this WixNitSettings toolSettings, params string[] inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(inputFiles);
            toolSettings.InputFilesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixNitSettings.InputFiles"/></em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixNitSettings RemoveInputFiles(this WixNitSettings toolSettings, IEnumerable<string> inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(inputFiles);
            toolSettings.InputFilesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region NoLogo
        /// <summary>
        ///   <p><em>Sets <see cref="WixNitSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixNitSettings SetNoLogo(this WixNitSettings toolSettings, bool? noLogo)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = noLogo;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixNitSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixNitSettings ResetNoLogo(this WixNitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixNitSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixNitSettings EnableNoLogo(this WixNitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixNitSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixNitSettings DisableNoLogo(this WixNitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixNitSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixNitSettings ToggleNoLogo(this WixNitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = !toolSettings.NoLogo;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region WixLuxSettingsExtensions
    /// <summary>
    ///   Used within <see cref="WixTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class WixLuxSettingsExtensions
    {
        #region InputFiles
        /// <summary>
        ///   <p><em>Sets <see cref="WixLuxSettings.InputFiles"/> to a new list</em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixLuxSettings SetInputFiles(this WixLuxSettings toolSettings, params string[] inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal = inputFiles.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="WixLuxSettings.InputFiles"/> to a new list</em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixLuxSettings SetInputFiles(this WixLuxSettings toolSettings, IEnumerable<string> inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal = inputFiles.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixLuxSettings.InputFiles"/></em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixLuxSettings AddInputFiles(this WixLuxSettings toolSettings, params string[] inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal.AddRange(inputFiles);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixLuxSettings.InputFiles"/></em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixLuxSettings AddInputFiles(this WixLuxSettings toolSettings, IEnumerable<string> inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal.AddRange(inputFiles);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="WixLuxSettings.InputFiles"/></em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixLuxSettings ClearInputFiles(this WixLuxSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixLuxSettings.InputFiles"/></em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixLuxSettings RemoveInputFiles(this WixLuxSettings toolSettings, params string[] inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(inputFiles);
            toolSettings.InputFilesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixLuxSettings.InputFiles"/></em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixLuxSettings RemoveInputFiles(this WixLuxSettings toolSettings, IEnumerable<string> inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(inputFiles);
            toolSettings.InputFilesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region NoLogo
        /// <summary>
        ///   <p><em>Sets <see cref="WixLuxSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixLuxSettings SetNoLogo(this WixLuxSettings toolSettings, bool? noLogo)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = noLogo;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixLuxSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixLuxSettings ResetNoLogo(this WixLuxSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixLuxSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixLuxSettings EnableNoLogo(this WixLuxSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixLuxSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixLuxSettings DisableNoLogo(this WixLuxSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixLuxSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixLuxSettings ToggleNoLogo(this WixLuxSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = !toolSettings.NoLogo;
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary>
        ///   <p><em>Sets <see cref="WixLuxSettings.Output"/></em></p>
        ///   <p>specify output file (default: write to current directory)</p>
        /// </summary>
        [Pure]
        public static WixLuxSettings SetOutput(this WixLuxSettings toolSettings, string output)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixLuxSettings.Output"/></em></p>
        ///   <p>specify output file (default: write to current directory)</p>
        /// </summary>
        [Pure]
        public static WixLuxSettings ResetOutput(this WixLuxSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
        #region Extension
        /// <summary>
        ///   <p><em>Sets <see cref="WixLuxSettings.Extension"/> to a new list</em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixLuxSettings SetExtension(this WixLuxSettings toolSettings, params string[] extension)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionInternal = extension.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="WixLuxSettings.Extension"/> to a new list</em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixLuxSettings SetExtension(this WixLuxSettings toolSettings, IEnumerable<string> extension)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionInternal = extension.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixLuxSettings.Extension"/></em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixLuxSettings AddExtension(this WixLuxSettings toolSettings, params string[] extension)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionInternal.AddRange(extension);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixLuxSettings.Extension"/></em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixLuxSettings AddExtension(this WixLuxSettings toolSettings, IEnumerable<string> extension)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionInternal.AddRange(extension);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="WixLuxSettings.Extension"/></em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixLuxSettings ClearExtension(this WixLuxSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixLuxSettings.Extension"/></em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixLuxSettings RemoveExtension(this WixLuxSettings toolSettings, params string[] extension)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(extension);
            toolSettings.ExtensionInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixLuxSettings.Extension"/></em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixLuxSettings RemoveExtension(this WixLuxSettings toolSettings, IEnumerable<string> extension)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(extension);
            toolSettings.ExtensionInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Verbose
        /// <summary>
        ///   <p><em>Sets <see cref="WixLuxSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixLuxSettings SetVerbose(this WixLuxSettings toolSettings, bool? verbose)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = verbose;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixLuxSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixLuxSettings ResetVerbose(this WixLuxSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixLuxSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixLuxSettings EnableVerbose(this WixLuxSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixLuxSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixLuxSettings DisableVerbose(this WixLuxSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixLuxSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixLuxSettings ToggleVerbose(this WixLuxSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = !toolSettings.Verbose;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region WixLitSettingsExtensions
    /// <summary>
    ///   Used within <see cref="WixTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class WixLitSettingsExtensions
    {
        #region Bind
        /// <summary>
        ///   <p><em>Sets <see cref="WixLitSettings.Bind"/></em></p>
        ///   <p>binder path to locate all files (default: current directory) prefix the path with 'name=' where 'name' is the name of your named bindpath.</p>
        /// </summary>
        [Pure]
        public static WixLitSettings SetBind(this WixLitSettings toolSettings, string bind)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Bind = bind;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixLitSettings.Bind"/></em></p>
        ///   <p>binder path to locate all files (default: current directory) prefix the path with 'name=' where 'name' is the name of your named bindpath.</p>
        /// </summary>
        [Pure]
        public static WixLitSettings ResetBind(this WixLitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Bind = null;
            return toolSettings;
        }
        #endregion
        #region BindFiles
        /// <summary>
        ///   <p><em>Sets <see cref="WixLitSettings.BindFiles"/></em></p>
        ///   <p>bind files into the library file</p>
        /// </summary>
        [Pure]
        public static WixLitSettings SetBindFiles(this WixLitSettings toolSettings, bool? bindFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BindFiles = bindFiles;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixLitSettings.BindFiles"/></em></p>
        ///   <p>bind files into the library file</p>
        /// </summary>
        [Pure]
        public static WixLitSettings ResetBindFiles(this WixLitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BindFiles = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixLitSettings.BindFiles"/></em></p>
        ///   <p>bind files into the library file</p>
        /// </summary>
        [Pure]
        public static WixLitSettings EnableBindFiles(this WixLitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BindFiles = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixLitSettings.BindFiles"/></em></p>
        ///   <p>bind files into the library file</p>
        /// </summary>
        [Pure]
        public static WixLitSettings DisableBindFiles(this WixLitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BindFiles = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixLitSettings.BindFiles"/></em></p>
        ///   <p>bind files into the library file</p>
        /// </summary>
        [Pure]
        public static WixLitSettings ToggleBindFiles(this WixLitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BindFiles = !toolSettings.BindFiles;
            return toolSettings;
        }
        #endregion
        #region SuppressSchemaValidation
        /// <summary>
        ///   <p><em>Sets <see cref="WixLitSettings.SuppressSchemaValidation"/></em></p>
        ///   <p>suppress schema validation of documents (performance boost)</p>
        /// </summary>
        [Pure]
        public static WixLitSettings SetSuppressSchemaValidation(this WixLitSettings toolSettings, bool? suppressSchemaValidation)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressSchemaValidation = suppressSchemaValidation;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixLitSettings.SuppressSchemaValidation"/></em></p>
        ///   <p>suppress schema validation of documents (performance boost)</p>
        /// </summary>
        [Pure]
        public static WixLitSettings ResetSuppressSchemaValidation(this WixLitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressSchemaValidation = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixLitSettings.SuppressSchemaValidation"/></em></p>
        ///   <p>suppress schema validation of documents (performance boost)</p>
        /// </summary>
        [Pure]
        public static WixLitSettings EnableSuppressSchemaValidation(this WixLitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressSchemaValidation = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixLitSettings.SuppressSchemaValidation"/></em></p>
        ///   <p>suppress schema validation of documents (performance boost)</p>
        /// </summary>
        [Pure]
        public static WixLitSettings DisableSuppressSchemaValidation(this WixLitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressSchemaValidation = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixLitSettings.SuppressSchemaValidation"/></em></p>
        ///   <p>suppress schema validation of documents (performance boost)</p>
        /// </summary>
        [Pure]
        public static WixLitSettings ToggleSuppressSchemaValidation(this WixLitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressSchemaValidation = !toolSettings.SuppressSchemaValidation;
            return toolSettings;
        }
        #endregion
        #region SuppressVersionMismatchCheck
        /// <summary>
        ///   <p><em>Sets <see cref="WixLitSettings.SuppressVersionMismatchCheck"/></em></p>
        ///   <p>suppress intermediate file version mismatch checking</p>
        /// </summary>
        [Pure]
        public static WixLitSettings SetSuppressVersionMismatchCheck(this WixLitSettings toolSettings, bool? suppressVersionMismatchCheck)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressVersionMismatchCheck = suppressVersionMismatchCheck;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixLitSettings.SuppressVersionMismatchCheck"/></em></p>
        ///   <p>suppress intermediate file version mismatch checking</p>
        /// </summary>
        [Pure]
        public static WixLitSettings ResetSuppressVersionMismatchCheck(this WixLitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressVersionMismatchCheck = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixLitSettings.SuppressVersionMismatchCheck"/></em></p>
        ///   <p>suppress intermediate file version mismatch checking</p>
        /// </summary>
        [Pure]
        public static WixLitSettings EnableSuppressVersionMismatchCheck(this WixLitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressVersionMismatchCheck = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixLitSettings.SuppressVersionMismatchCheck"/></em></p>
        ///   <p>suppress intermediate file version mismatch checking</p>
        /// </summary>
        [Pure]
        public static WixLitSettings DisableSuppressVersionMismatchCheck(this WixLitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressVersionMismatchCheck = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixLitSettings.SuppressVersionMismatchCheck"/></em></p>
        ///   <p>suppress intermediate file version mismatch checking</p>
        /// </summary>
        [Pure]
        public static WixLitSettings ToggleSuppressVersionMismatchCheck(this WixLitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressVersionMismatchCheck = !toolSettings.SuppressVersionMismatchCheck;
            return toolSettings;
        }
        #endregion
        #region InputFiles
        /// <summary>
        ///   <p><em>Sets <see cref="WixLitSettings.InputFiles"/> to a new list</em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixLitSettings SetInputFiles(this WixLitSettings toolSettings, params string[] inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal = inputFiles.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="WixLitSettings.InputFiles"/> to a new list</em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixLitSettings SetInputFiles(this WixLitSettings toolSettings, IEnumerable<string> inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal = inputFiles.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixLitSettings.InputFiles"/></em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixLitSettings AddInputFiles(this WixLitSettings toolSettings, params string[] inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal.AddRange(inputFiles);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixLitSettings.InputFiles"/></em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixLitSettings AddInputFiles(this WixLitSettings toolSettings, IEnumerable<string> inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal.AddRange(inputFiles);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="WixLitSettings.InputFiles"/></em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixLitSettings ClearInputFiles(this WixLitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixLitSettings.InputFiles"/></em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixLitSettings RemoveInputFiles(this WixLitSettings toolSettings, params string[] inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(inputFiles);
            toolSettings.InputFilesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixLitSettings.InputFiles"/></em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixLitSettings RemoveInputFiles(this WixLitSettings toolSettings, IEnumerable<string> inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(inputFiles);
            toolSettings.InputFilesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ResponseFile
        /// <summary>
        ///   <p><em>Sets <see cref="WixLitSettings.ResponseFile"/></em></p>
        ///   <p>response file</p>
        /// </summary>
        [Pure]
        public static WixLitSettings SetResponseFile(this WixLitSettings toolSettings, string responseFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResponseFile = responseFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixLitSettings.ResponseFile"/></em></p>
        ///   <p>response file</p>
        /// </summary>
        [Pure]
        public static WixLitSettings ResetResponseFile(this WixLitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResponseFile = null;
            return toolSettings;
        }
        #endregion
        #region NoLogo
        /// <summary>
        ///   <p><em>Sets <see cref="WixLitSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixLitSettings SetNoLogo(this WixLitSettings toolSettings, bool? noLogo)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = noLogo;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixLitSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixLitSettings ResetNoLogo(this WixLitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixLitSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixLitSettings EnableNoLogo(this WixLitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixLitSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixLitSettings DisableNoLogo(this WixLitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixLitSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixLitSettings ToggleNoLogo(this WixLitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = !toolSettings.NoLogo;
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary>
        ///   <p><em>Sets <see cref="WixLitSettings.Output"/></em></p>
        ///   <p>specify output file (default: write to current directory)</p>
        /// </summary>
        [Pure]
        public static WixLitSettings SetOutput(this WixLitSettings toolSettings, string output)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixLitSettings.Output"/></em></p>
        ///   <p>specify output file (default: write to current directory)</p>
        /// </summary>
        [Pure]
        public static WixLitSettings ResetOutput(this WixLitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
        #region Extension
        /// <summary>
        ///   <p><em>Sets <see cref="WixLitSettings.Extension"/> to a new list</em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixLitSettings SetExtension(this WixLitSettings toolSettings, params string[] extension)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionInternal = extension.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="WixLitSettings.Extension"/> to a new list</em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixLitSettings SetExtension(this WixLitSettings toolSettings, IEnumerable<string> extension)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionInternal = extension.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixLitSettings.Extension"/></em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixLitSettings AddExtension(this WixLitSettings toolSettings, params string[] extension)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionInternal.AddRange(extension);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixLitSettings.Extension"/></em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixLitSettings AddExtension(this WixLitSettings toolSettings, IEnumerable<string> extension)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionInternal.AddRange(extension);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="WixLitSettings.Extension"/></em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixLitSettings ClearExtension(this WixLitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixLitSettings.Extension"/></em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixLitSettings RemoveExtension(this WixLitSettings toolSettings, params string[] extension)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(extension);
            toolSettings.ExtensionInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixLitSettings.Extension"/></em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixLitSettings RemoveExtension(this WixLitSettings toolSettings, IEnumerable<string> extension)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(extension);
            toolSettings.ExtensionInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Verbose
        /// <summary>
        ///   <p><em>Sets <see cref="WixLitSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixLitSettings SetVerbose(this WixLitSettings toolSettings, bool? verbose)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = verbose;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixLitSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixLitSettings ResetVerbose(this WixLitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixLitSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixLitSettings EnableVerbose(this WixLitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixLitSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixLitSettings DisableVerbose(this WixLitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixLitSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixLitSettings ToggleVerbose(this WixLitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = !toolSettings.Verbose;
            return toolSettings;
        }
        #endregion
        #region SuppressAllWarnings
        /// <summary>
        ///   <p><em>Sets <see cref="WixLitSettings.SuppressAllWarnings"/></em></p>
        ///   <p>suppress all warnings</p>
        /// </summary>
        [Pure]
        public static WixLitSettings SetSuppressAllWarnings(this WixLitSettings toolSettings, bool? suppressAllWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAllWarnings = suppressAllWarnings;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixLitSettings.SuppressAllWarnings"/></em></p>
        ///   <p>suppress all warnings</p>
        /// </summary>
        [Pure]
        public static WixLitSettings ResetSuppressAllWarnings(this WixLitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAllWarnings = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixLitSettings.SuppressAllWarnings"/></em></p>
        ///   <p>suppress all warnings</p>
        /// </summary>
        [Pure]
        public static WixLitSettings EnableSuppressAllWarnings(this WixLitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAllWarnings = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixLitSettings.SuppressAllWarnings"/></em></p>
        ///   <p>suppress all warnings</p>
        /// </summary>
        [Pure]
        public static WixLitSettings DisableSuppressAllWarnings(this WixLitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAllWarnings = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixLitSettings.SuppressAllWarnings"/></em></p>
        ///   <p>suppress all warnings</p>
        /// </summary>
        [Pure]
        public static WixLitSettings ToggleSuppressAllWarnings(this WixLitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAllWarnings = !toolSettings.SuppressAllWarnings;
            return toolSettings;
        }
        #endregion
        #region SuppressWarnings
        /// <summary>
        ///   <p><em>Sets <see cref="WixLitSettings.SuppressWarnings"/> to a new list</em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixLitSettings SetSuppressWarnings(this WixLitSettings toolSettings, params int[] suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWarningsInternal = suppressWarnings.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="WixLitSettings.SuppressWarnings"/> to a new list</em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixLitSettings SetSuppressWarnings(this WixLitSettings toolSettings, IEnumerable<int> suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWarningsInternal = suppressWarnings.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixLitSettings.SuppressWarnings"/></em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixLitSettings AddSuppressWarnings(this WixLitSettings toolSettings, params int[] suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWarningsInternal.AddRange(suppressWarnings);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixLitSettings.SuppressWarnings"/></em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixLitSettings AddSuppressWarnings(this WixLitSettings toolSettings, IEnumerable<int> suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWarningsInternal.AddRange(suppressWarnings);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="WixLitSettings.SuppressWarnings"/></em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixLitSettings ClearSuppressWarnings(this WixLitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWarningsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixLitSettings.SuppressWarnings"/></em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixLitSettings RemoveSuppressWarnings(this WixLitSettings toolSettings, params int[] suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<int>(suppressWarnings);
            toolSettings.SuppressWarningsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixLitSettings.SuppressWarnings"/></em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixLitSettings RemoveSuppressWarnings(this WixLitSettings toolSettings, IEnumerable<int> suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<int>(suppressWarnings);
            toolSettings.SuppressWarningsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region WarningsAsErrors
        /// <summary>
        ///   <p><em>Sets <see cref="WixLitSettings.WarningsAsErrors"/></em></p>
        ///   <p>treat all warnings as an error</p>
        /// </summary>
        [Pure]
        public static WixLitSettings SetWarningsAsErrors(this WixLitSettings toolSettings, bool? warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = warningsAsErrors;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixLitSettings.WarningsAsErrors"/></em></p>
        ///   <p>treat all warnings as an error</p>
        /// </summary>
        [Pure]
        public static WixLitSettings ResetWarningsAsErrors(this WixLitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixLitSettings.WarningsAsErrors"/></em></p>
        ///   <p>treat all warnings as an error</p>
        /// </summary>
        [Pure]
        public static WixLitSettings EnableWarningsAsErrors(this WixLitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixLitSettings.WarningsAsErrors"/></em></p>
        ///   <p>treat all warnings as an error</p>
        /// </summary>
        [Pure]
        public static WixLitSettings DisableWarningsAsErrors(this WixLitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixLitSettings.WarningsAsErrors"/></em></p>
        ///   <p>treat all warnings as an error</p>
        /// </summary>
        [Pure]
        public static WixLitSettings ToggleWarningsAsErrors(this WixLitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = !toolSettings.WarningsAsErrors;
            return toolSettings;
        }
        #endregion
        #region MessageIdAsError
        /// <summary>
        ///   <p><em>Sets <see cref="WixLitSettings.MessageIdAsError"/> to a new list</em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixLitSettings SetMessageIdAsError(this WixLitSettings toolSettings, params int[] messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MessageIdAsErrorInternal = messageIdAsError.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="WixLitSettings.MessageIdAsError"/> to a new list</em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixLitSettings SetMessageIdAsError(this WixLitSettings toolSettings, IEnumerable<int> messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MessageIdAsErrorInternal = messageIdAsError.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixLitSettings.MessageIdAsError"/></em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixLitSettings AddMessageIdAsError(this WixLitSettings toolSettings, params int[] messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MessageIdAsErrorInternal.AddRange(messageIdAsError);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixLitSettings.MessageIdAsError"/></em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixLitSettings AddMessageIdAsError(this WixLitSettings toolSettings, IEnumerable<int> messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MessageIdAsErrorInternal.AddRange(messageIdAsError);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="WixLitSettings.MessageIdAsError"/></em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixLitSettings ClearMessageIdAsError(this WixLitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MessageIdAsErrorInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixLitSettings.MessageIdAsError"/></em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixLitSettings RemoveMessageIdAsError(this WixLitSettings toolSettings, params int[] messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<int>(messageIdAsError);
            toolSettings.MessageIdAsErrorInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixLitSettings.MessageIdAsError"/></em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixLitSettings RemoveMessageIdAsError(this WixLitSettings toolSettings, IEnumerable<int> messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<int>(messageIdAsError);
            toolSettings.MessageIdAsErrorInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Localization
        /// <summary>
        ///   <p><em>Sets <see cref="WixLitSettings.Localization"/></em></p>
        ///   <p>read localization strings from .wxl file</p>
        /// </summary>
        [Pure]
        public static WixLitSettings SetLocalization(this WixLitSettings toolSettings, string localization)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Localization = localization;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixLitSettings.Localization"/></em></p>
        ///   <p>read localization strings from .wxl file</p>
        /// </summary>
        [Pure]
        public static WixLitSettings ResetLocalization(this WixLitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Localization = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region WixCopSettingsExtensions
    /// <summary>
    ///   Used within <see cref="WixTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class WixCopSettingsExtensions
    {
        #region AutoFix
        /// <summary>
        ///   <p><em>Sets <see cref="WixCopSettings.AutoFix"/></em></p>
        ///   <p>fix errors automatically for writable files</p>
        /// </summary>
        [Pure]
        public static WixCopSettings SetAutoFix(this WixCopSettings toolSettings, bool? autoFix)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AutoFix = autoFix;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixCopSettings.AutoFix"/></em></p>
        ///   <p>fix errors automatically for writable files</p>
        /// </summary>
        [Pure]
        public static WixCopSettings ResetAutoFix(this WixCopSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AutoFix = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixCopSettings.AutoFix"/></em></p>
        ///   <p>fix errors automatically for writable files</p>
        /// </summary>
        [Pure]
        public static WixCopSettings EnableAutoFix(this WixCopSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AutoFix = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixCopSettings.AutoFix"/></em></p>
        ///   <p>fix errors automatically for writable files</p>
        /// </summary>
        [Pure]
        public static WixCopSettings DisableAutoFix(this WixCopSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AutoFix = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixCopSettings.AutoFix"/></em></p>
        ///   <p>fix errors automatically for writable files</p>
        /// </summary>
        [Pure]
        public static WixCopSettings ToggleAutoFix(this WixCopSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AutoFix = !toolSettings.AutoFix;
            return toolSettings;
        }
        #endregion
        #region Search
        /// <summary>
        ///   <p><em>Sets <see cref="WixCopSettings.Search"/></em></p>
        ///   <p>search for matching files in current dir and subdirs</p>
        /// </summary>
        [Pure]
        public static WixCopSettings SetSearch(this WixCopSettings toolSettings, bool? search)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Search = search;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixCopSettings.Search"/></em></p>
        ///   <p>search for matching files in current dir and subdirs</p>
        /// </summary>
        [Pure]
        public static WixCopSettings ResetSearch(this WixCopSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Search = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixCopSettings.Search"/></em></p>
        ///   <p>search for matching files in current dir and subdirs</p>
        /// </summary>
        [Pure]
        public static WixCopSettings EnableSearch(this WixCopSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Search = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixCopSettings.Search"/></em></p>
        ///   <p>search for matching files in current dir and subdirs</p>
        /// </summary>
        [Pure]
        public static WixCopSettings DisableSearch(this WixCopSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Search = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixCopSettings.Search"/></em></p>
        ///   <p>search for matching files in current dir and subdirs</p>
        /// </summary>
        [Pure]
        public static WixCopSettings ToggleSearch(this WixCopSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Search = !toolSettings.Search;
            return toolSettings;
        }
        #endregion
        #region PrimarySettingsFile
        /// <summary>
        ///   <p><em>Sets <see cref="WixCopSettings.PrimarySettingsFile"/></em></p>
        ///   <p>primary settings file</p>
        /// </summary>
        [Pure]
        public static WixCopSettings SetPrimarySettingsFile(this WixCopSettings toolSettings, string primarySettingsFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrimarySettingsFile = primarySettingsFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixCopSettings.PrimarySettingsFile"/></em></p>
        ///   <p>primary settings file</p>
        /// </summary>
        [Pure]
        public static WixCopSettings ResetPrimarySettingsFile(this WixCopSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrimarySettingsFile = null;
            return toolSettings;
        }
        #endregion
        #region SecondarySettingsFile
        /// <summary>
        ///   <p><em>Sets <see cref="WixCopSettings.SecondarySettingsFile"/></em></p>
        ///   <p>secondary settings file (overrides primary)</p>
        /// </summary>
        [Pure]
        public static WixCopSettings SetSecondarySettingsFile(this WixCopSettings toolSettings, string secondarySettingsFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SecondarySettingsFile = secondarySettingsFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixCopSettings.SecondarySettingsFile"/></em></p>
        ///   <p>secondary settings file (overrides primary)</p>
        /// </summary>
        [Pure]
        public static WixCopSettings ResetSecondarySettingsFile(this WixCopSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SecondarySettingsFile = null;
            return toolSettings;
        }
        #endregion
        #region Indentation
        /// <summary>
        ///   <p><em>Sets <see cref="WixCopSettings.Indentation"/></em></p>
        ///   <p>indentation multiple (overrides default of 4)</p>
        /// </summary>
        [Pure]
        public static WixCopSettings SetIndentation(this WixCopSettings toolSettings, int? indentation)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Indentation = indentation;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixCopSettings.Indentation"/></em></p>
        ///   <p>indentation multiple (overrides default of 4)</p>
        /// </summary>
        [Pure]
        public static WixCopSettings ResetIndentation(this WixCopSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Indentation = null;
            return toolSettings;
        }
        #endregion
        #region InputFiles
        /// <summary>
        ///   <p><em>Sets <see cref="WixCopSettings.InputFiles"/> to a new list</em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixCopSettings SetInputFiles(this WixCopSettings toolSettings, params string[] inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal = inputFiles.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="WixCopSettings.InputFiles"/> to a new list</em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixCopSettings SetInputFiles(this WixCopSettings toolSettings, IEnumerable<string> inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal = inputFiles.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixCopSettings.InputFiles"/></em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixCopSettings AddInputFiles(this WixCopSettings toolSettings, params string[] inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal.AddRange(inputFiles);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixCopSettings.InputFiles"/></em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixCopSettings AddInputFiles(this WixCopSettings toolSettings, IEnumerable<string> inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal.AddRange(inputFiles);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="WixCopSettings.InputFiles"/></em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixCopSettings ClearInputFiles(this WixCopSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixCopSettings.InputFiles"/></em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixCopSettings RemoveInputFiles(this WixCopSettings toolSettings, params string[] inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(inputFiles);
            toolSettings.InputFilesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixCopSettings.InputFiles"/></em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixCopSettings RemoveInputFiles(this WixCopSettings toolSettings, IEnumerable<string> inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(inputFiles);
            toolSettings.InputFilesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region NoLogo
        /// <summary>
        ///   <p><em>Sets <see cref="WixCopSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixCopSettings SetNoLogo(this WixCopSettings toolSettings, bool? noLogo)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = noLogo;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixCopSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixCopSettings ResetNoLogo(this WixCopSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixCopSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixCopSettings EnableNoLogo(this WixCopSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixCopSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixCopSettings DisableNoLogo(this WixCopSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixCopSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixCopSettings ToggleNoLogo(this WixCopSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = !toolSettings.NoLogo;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region WixLightSettingsExtensions
    /// <summary>
    ///   Used within <see cref="WixTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class WixLightSettingsExtensions
    {
        #region BinderPath
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.BinderPath"/></em></p>
        ///   <p>specify a binder path to locate all files (default: current directory) prefix the path with 'name=' where 'name' is the name of your named bindpath.</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetBinderPath(this WixLightSettings toolSettings, string binderPath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BinderPath = binderPath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixLightSettings.BinderPath"/></em></p>
        ///   <p>specify a binder path to locate all files (default: current directory) prefix the path with 'name=' where 'name' is the name of your named bindpath.</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ResetBinderPath(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BinderPath = null;
            return toolSettings;
        }
        #endregion
        #region Cultures
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.Cultures"/> to a new list</em></p>
        ///   <p>semicolon or comma delimited list of localized string cultures to load from .wxl files and libraries. Precedence of cultures is from left to right.</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetCultures(this WixLightSettings toolSettings, params string[] cultures)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CulturesInternal = cultures.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.Cultures"/> to a new list</em></p>
        ///   <p>semicolon or comma delimited list of localized string cultures to load from .wxl files and libraries. Precedence of cultures is from left to right.</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetCultures(this WixLightSettings toolSettings, IEnumerable<string> cultures)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CulturesInternal = cultures.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixLightSettings.Cultures"/></em></p>
        ///   <p>semicolon or comma delimited list of localized string cultures to load from .wxl files and libraries. Precedence of cultures is from left to right.</p>
        /// </summary>
        [Pure]
        public static WixLightSettings AddCultures(this WixLightSettings toolSettings, params string[] cultures)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CulturesInternal.AddRange(cultures);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixLightSettings.Cultures"/></em></p>
        ///   <p>semicolon or comma delimited list of localized string cultures to load from .wxl files and libraries. Precedence of cultures is from left to right.</p>
        /// </summary>
        [Pure]
        public static WixLightSettings AddCultures(this WixLightSettings toolSettings, IEnumerable<string> cultures)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CulturesInternal.AddRange(cultures);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="WixLightSettings.Cultures"/></em></p>
        ///   <p>semicolon or comma delimited list of localized string cultures to load from .wxl files and libraries. Precedence of cultures is from left to right.</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ClearCultures(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CulturesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixLightSettings.Cultures"/></em></p>
        ///   <p>semicolon or comma delimited list of localized string cultures to load from .wxl files and libraries. Precedence of cultures is from left to right.</p>
        /// </summary>
        [Pure]
        public static WixLightSettings RemoveCultures(this WixLightSettings toolSettings, params string[] cultures)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(cultures);
            toolSettings.CulturesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixLightSettings.Cultures"/></em></p>
        ///   <p>semicolon or comma delimited list of localized string cultures to load from .wxl files and libraries. Precedence of cultures is from left to right.</p>
        /// </summary>
        [Pure]
        public static WixLightSettings RemoveCultures(this WixLightSettings toolSettings, IEnumerable<string> cultures)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(cultures);
            toolSettings.CulturesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region SuppressLocalization
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.SuppressLocalization"/></em></p>
        ///   <p>suppress localization</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetSuppressLocalization(this WixLightSettings toolSettings, bool? suppressLocalization)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressLocalization = suppressLocalization;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixLightSettings.SuppressLocalization"/></em></p>
        ///   <p>suppress localization</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ResetSuppressLocalization(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressLocalization = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixLightSettings.SuppressLocalization"/></em></p>
        ///   <p>suppress localization</p>
        /// </summary>
        [Pure]
        public static WixLightSettings EnableSuppressLocalization(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressLocalization = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixLightSettings.SuppressLocalization"/></em></p>
        ///   <p>suppress localization</p>
        /// </summary>
        [Pure]
        public static WixLightSettings DisableSuppressLocalization(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressLocalization = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixLightSettings.SuppressLocalization"/></em></p>
        ///   <p>suppress localization</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ToggleSuppressLocalization(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressLocalization = !toolSettings.SuppressLocalization;
            return toolSettings;
        }
        #endregion
        #region WixOutFormat
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.WixOutFormat"/></em></p>
        ///   <p>output wixout format instead of MSI format</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetWixOutFormat(this WixLightSettings toolSettings, bool? wixOutFormat)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WixOutFormat = wixOutFormat;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixLightSettings.WixOutFormat"/></em></p>
        ///   <p>output wixout format instead of MSI format</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ResetWixOutFormat(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WixOutFormat = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixLightSettings.WixOutFormat"/></em></p>
        ///   <p>output wixout format instead of MSI format</p>
        /// </summary>
        [Pure]
        public static WixLightSettings EnableWixOutFormat(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WixOutFormat = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixLightSettings.WixOutFormat"/></em></p>
        ///   <p>output wixout format instead of MSI format</p>
        /// </summary>
        [Pure]
        public static WixLightSettings DisableWixOutFormat(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WixOutFormat = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixLightSettings.WixOutFormat"/></em></p>
        ///   <p>output wixout format instead of MSI format</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ToggleWixOutFormat(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WixOutFormat = !toolSettings.WixOutFormat;
            return toolSettings;
        }
        #endregion
        #region BackwardsCompatableGuids
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.BackwardsCompatableGuids"/></em></p>
        ///   <p>use backwards compatible guid generation algorithm (almost never needed)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetBackwardsCompatableGuids(this WixLightSettings toolSettings, bool? backwardsCompatableGuids)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BackwardsCompatableGuids = backwardsCompatableGuids;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixLightSettings.BackwardsCompatableGuids"/></em></p>
        ///   <p>use backwards compatible guid generation algorithm (almost never needed)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ResetBackwardsCompatableGuids(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BackwardsCompatableGuids = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixLightSettings.BackwardsCompatableGuids"/></em></p>
        ///   <p>use backwards compatible guid generation algorithm (almost never needed)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings EnableBackwardsCompatableGuids(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BackwardsCompatableGuids = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixLightSettings.BackwardsCompatableGuids"/></em></p>
        ///   <p>use backwards compatible guid generation algorithm (almost never needed)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings DisableBackwardsCompatableGuids(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BackwardsCompatableGuids = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixLightSettings.BackwardsCompatableGuids"/></em></p>
        ///   <p>use backwards compatible guid generation algorithm (almost never needed)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ToggleBackwardsCompatableGuids(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BackwardsCompatableGuids = !toolSettings.BackwardsCompatableGuids;
            return toolSettings;
        }
        #endregion
        #region CachePath
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.CachePath"/></em></p>
        ///   <p>path to cache built cabinets (will not be deleted after linking)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetCachePath(this WixLightSettings toolSettings, string cachePath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CachePath = cachePath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixLightSettings.CachePath"/></em></p>
        ///   <p>path to cache built cabinets (will not be deleted after linking)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ResetCachePath(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CachePath = null;
            return toolSettings;
        }
        #endregion
        #region Threads
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.Threads"/></em></p>
        ///   <p>number of threads to use when creating cabinets (default: %NUMBER_OF_PROCESSORS%)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetThreads(this WixLightSettings toolSettings, int? threads)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Threads = threads;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixLightSettings.Threads"/></em></p>
        ///   <p>number of threads to use when creating cabinets (default: %NUMBER_OF_PROCESSORS%)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ResetThreads(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Threads = null;
            return toolSettings;
        }
        #endregion
        #region CompressionLevel
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.CompressionLevel"/></em></p>
        ///   <p>set default cabinet compression level (low, medium, high, none, mszip; mszip default)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetCompressionLevel(this WixLightSettings toolSettings, CompressionLevel compressionLevel)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CompressionLevel = compressionLevel;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixLightSettings.CompressionLevel"/></em></p>
        ///   <p>set default cabinet compression level (low, medium, high, none, mszip; mszip default)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ResetCompressionLevel(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CompressionLevel = null;
            return toolSettings;
        }
        #endregion
        #region ExactAssemblyVersions
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.ExactAssemblyVersions"/></em></p>
        ///   <p>exact assembly versions (breaks .NET 1.1 RTM compatibility)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetExactAssemblyVersions(this WixLightSettings toolSettings, bool? exactAssemblyVersions)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExactAssemblyVersions = exactAssemblyVersions;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixLightSettings.ExactAssemblyVersions"/></em></p>
        ///   <p>exact assembly versions (breaks .NET 1.1 RTM compatibility)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ResetExactAssemblyVersions(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExactAssemblyVersions = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixLightSettings.ExactAssemblyVersions"/></em></p>
        ///   <p>exact assembly versions (breaks .NET 1.1 RTM compatibility)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings EnableExactAssemblyVersions(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExactAssemblyVersions = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixLightSettings.ExactAssemblyVersions"/></em></p>
        ///   <p>exact assembly versions (breaks .NET 1.1 RTM compatibility)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings DisableExactAssemblyVersions(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExactAssemblyVersions = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixLightSettings.ExactAssemblyVersions"/></em></p>
        ///   <p>exact assembly versions (breaks .NET 1.1 RTM compatibility)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ToggleExactAssemblyVersions(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExactAssemblyVersions = !toolSettings.ExactAssemblyVersions;
            return toolSettings;
        }
        #endregion
        #region AddFileVersionEntry
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.AddFileVersionEntry"/></em></p>
        ///   <p>add a 'fileVersion' entry to the MsiAssemblyName table (rarely needed)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetAddFileVersionEntry(this WixLightSettings toolSettings, bool? addFileVersionEntry)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AddFileVersionEntry = addFileVersionEntry;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixLightSettings.AddFileVersionEntry"/></em></p>
        ///   <p>add a 'fileVersion' entry to the MsiAssemblyName table (rarely needed)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ResetAddFileVersionEntry(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AddFileVersionEntry = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixLightSettings.AddFileVersionEntry"/></em></p>
        ///   <p>add a 'fileVersion' entry to the MsiAssemblyName table (rarely needed)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings EnableAddFileVersionEntry(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AddFileVersionEntry = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixLightSettings.AddFileVersionEntry"/></em></p>
        ///   <p>add a 'fileVersion' entry to the MsiAssemblyName table (rarely needed)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings DisableAddFileVersionEntry(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AddFileVersionEntry = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixLightSettings.AddFileVersionEntry"/></em></p>
        ///   <p>add a 'fileVersion' entry to the MsiAssemblyName table (rarely needed)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ToggleAddFileVersionEntry(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AddFileVersionEntry = !toolSettings.AddFileVersionEntry;
            return toolSettings;
        }
        #endregion
        #region PdbOut
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.PdbOut"/></em></p>
        ///   <p>save the WixPdb to a specific file (default: same name as output with wixpdb extension)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetPdbOut(this WixLightSettings toolSettings, string pdbOut)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PdbOut = pdbOut;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixLightSettings.PdbOut"/></em></p>
        ///   <p>save the WixPdb to a specific file (default: same name as output with wixpdb extension)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ResetPdbOut(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PdbOut = null;
            return toolSettings;
        }
        #endregion
        #region ReuseCab
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.ReuseCab"/></em></p>
        ///   <p>reuse cabinets from cabinet cache</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetReuseCab(this WixLightSettings toolSettings, bool? reuseCab)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReuseCab = reuseCab;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixLightSettings.ReuseCab"/></em></p>
        ///   <p>reuse cabinets from cabinet cache</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ResetReuseCab(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReuseCab = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixLightSettings.ReuseCab"/></em></p>
        ///   <p>reuse cabinets from cabinet cache</p>
        /// </summary>
        [Pure]
        public static WixLightSettings EnableReuseCab(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReuseCab = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixLightSettings.ReuseCab"/></em></p>
        ///   <p>reuse cabinets from cabinet cache</p>
        /// </summary>
        [Pure]
        public static WixLightSettings DisableReuseCab(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReuseCab = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixLightSettings.ReuseCab"/></em></p>
        ///   <p>reuse cabinets from cabinet cache</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ToggleReuseCab(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReuseCab = !toolSettings.ReuseCab;
            return toolSettings;
        }
        #endregion
        #region SuppressAssemblies
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.SuppressAssemblies"/></em></p>
        ///   <p>suppress assemblies: do not get assembly name information for assemblies</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetSuppressAssemblies(this WixLightSettings toolSettings, bool? suppressAssemblies)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAssemblies = suppressAssemblies;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixLightSettings.SuppressAssemblies"/></em></p>
        ///   <p>suppress assemblies: do not get assembly name information for assemblies</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ResetSuppressAssemblies(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAssemblies = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixLightSettings.SuppressAssemblies"/></em></p>
        ///   <p>suppress assemblies: do not get assembly name information for assemblies</p>
        /// </summary>
        [Pure]
        public static WixLightSettings EnableSuppressAssemblies(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAssemblies = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixLightSettings.SuppressAssemblies"/></em></p>
        ///   <p>suppress assemblies: do not get assembly name information for assemblies</p>
        /// </summary>
        [Pure]
        public static WixLightSettings DisableSuppressAssemblies(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAssemblies = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixLightSettings.SuppressAssemblies"/></em></p>
        ///   <p>suppress assemblies: do not get assembly name information for assemblies</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ToggleSuppressAssemblies(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAssemblies = !toolSettings.SuppressAssemblies;
            return toolSettings;
        }
        #endregion
        #region SuppressResettingAcls
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.SuppressResettingAcls"/></em></p>
        ///   <p>suppress resetting ACLs (useful when laying out image to a network share)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetSuppressResettingAcls(this WixLightSettings toolSettings, bool? suppressResettingAcls)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressResettingAcls = suppressResettingAcls;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixLightSettings.SuppressResettingAcls"/></em></p>
        ///   <p>suppress resetting ACLs (useful when laying out image to a network share)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ResetSuppressResettingAcls(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressResettingAcls = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixLightSettings.SuppressResettingAcls"/></em></p>
        ///   <p>suppress resetting ACLs (useful when laying out image to a network share)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings EnableSuppressResettingAcls(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressResettingAcls = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixLightSettings.SuppressResettingAcls"/></em></p>
        ///   <p>suppress resetting ACLs (useful when laying out image to a network share)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings DisableSuppressResettingAcls(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressResettingAcls = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixLightSettings.SuppressResettingAcls"/></em></p>
        ///   <p>suppress resetting ACLs (useful when laying out image to a network share)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ToggleSuppressResettingAcls(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressResettingAcls = !toolSettings.SuppressResettingAcls;
            return toolSettings;
        }
        #endregion
        #region SuppressFiles
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.SuppressFiles"/></em></p>
        ///   <p>suppress files: do not get any file information (equivalent to -sa and -sh)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetSuppressFiles(this WixLightSettings toolSettings, bool? suppressFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressFiles = suppressFiles;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixLightSettings.SuppressFiles"/></em></p>
        ///   <p>suppress files: do not get any file information (equivalent to -sa and -sh)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ResetSuppressFiles(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressFiles = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixLightSettings.SuppressFiles"/></em></p>
        ///   <p>suppress files: do not get any file information (equivalent to -sa and -sh)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings EnableSuppressFiles(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressFiles = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixLightSettings.SuppressFiles"/></em></p>
        ///   <p>suppress files: do not get any file information (equivalent to -sa and -sh)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings DisableSuppressFiles(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressFiles = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixLightSettings.SuppressFiles"/></em></p>
        ///   <p>suppress files: do not get any file information (equivalent to -sa and -sh)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ToggleSuppressFiles(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressFiles = !toolSettings.SuppressFiles;
            return toolSettings;
        }
        #endregion
        #region SuppressFileInfo
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.SuppressFileInfo"/></em></p>
        ///   <p>suppress file info: do not get hash, version, language, etc</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetSuppressFileInfo(this WixLightSettings toolSettings, bool? suppressFileInfo)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressFileInfo = suppressFileInfo;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixLightSettings.SuppressFileInfo"/></em></p>
        ///   <p>suppress file info: do not get hash, version, language, etc</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ResetSuppressFileInfo(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressFileInfo = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixLightSettings.SuppressFileInfo"/></em></p>
        ///   <p>suppress file info: do not get hash, version, language, etc</p>
        /// </summary>
        [Pure]
        public static WixLightSettings EnableSuppressFileInfo(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressFileInfo = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixLightSettings.SuppressFileInfo"/></em></p>
        ///   <p>suppress file info: do not get hash, version, language, etc</p>
        /// </summary>
        [Pure]
        public static WixLightSettings DisableSuppressFileInfo(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressFileInfo = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixLightSettings.SuppressFileInfo"/></em></p>
        ///   <p>suppress file info: do not get hash, version, language, etc</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ToggleSuppressFileInfo(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressFileInfo = !toolSettings.SuppressFileInfo;
            return toolSettings;
        }
        #endregion
        #region SuppressLayout
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.SuppressLayout"/></em></p>
        ///   <p>suppress layout</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetSuppressLayout(this WixLightSettings toolSettings, bool? suppressLayout)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressLayout = suppressLayout;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixLightSettings.SuppressLayout"/></em></p>
        ///   <p>suppress layout</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ResetSuppressLayout(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressLayout = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixLightSettings.SuppressLayout"/></em></p>
        ///   <p>suppress layout</p>
        /// </summary>
        [Pure]
        public static WixLightSettings EnableSuppressLayout(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressLayout = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixLightSettings.SuppressLayout"/></em></p>
        ///   <p>suppress layout</p>
        /// </summary>
        [Pure]
        public static WixLightSettings DisableSuppressLayout(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressLayout = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixLightSettings.SuppressLayout"/></em></p>
        ///   <p>suppress layout</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ToggleSuppressLayout(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressLayout = !toolSettings.SuppressLayout;
            return toolSettings;
        }
        #endregion
        #region SuppressWixPdb
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.SuppressWixPdb"/></em></p>
        ///   <p>suppress outputting the WixPdb</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetSuppressWixPdb(this WixLightSettings toolSettings, bool? suppressWixPdb)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWixPdb = suppressWixPdb;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixLightSettings.SuppressWixPdb"/></em></p>
        ///   <p>suppress outputting the WixPdb</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ResetSuppressWixPdb(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWixPdb = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixLightSettings.SuppressWixPdb"/></em></p>
        ///   <p>suppress outputting the WixPdb</p>
        /// </summary>
        [Pure]
        public static WixLightSettings EnableSuppressWixPdb(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWixPdb = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixLightSettings.SuppressWixPdb"/></em></p>
        ///   <p>suppress outputting the WixPdb</p>
        /// </summary>
        [Pure]
        public static WixLightSettings DisableSuppressWixPdb(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWixPdb = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixLightSettings.SuppressWixPdb"/></em></p>
        ///   <p>suppress outputting the WixPdb</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ToggleSuppressWixPdb(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWixPdb = !toolSettings.SuppressWixPdb;
            return toolSettings;
        }
        #endregion
        #region SuppressPatchSequenceData
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.SuppressPatchSequenceData"/></em></p>
        ///   <p>suppress patch sequence data in patch XML to decrease bundle size and increase patch applicability performance (patch packages themselves are not modified)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetSuppressPatchSequenceData(this WixLightSettings toolSettings, bool? suppressPatchSequenceData)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressPatchSequenceData = suppressPatchSequenceData;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixLightSettings.SuppressPatchSequenceData"/></em></p>
        ///   <p>suppress patch sequence data in patch XML to decrease bundle size and increase patch applicability performance (patch packages themselves are not modified)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ResetSuppressPatchSequenceData(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressPatchSequenceData = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixLightSettings.SuppressPatchSequenceData"/></em></p>
        ///   <p>suppress patch sequence data in patch XML to decrease bundle size and increase patch applicability performance (patch packages themselves are not modified)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings EnableSuppressPatchSequenceData(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressPatchSequenceData = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixLightSettings.SuppressPatchSequenceData"/></em></p>
        ///   <p>suppress patch sequence data in patch XML to decrease bundle size and increase patch applicability performance (patch packages themselves are not modified)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings DisableSuppressPatchSequenceData(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressPatchSequenceData = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixLightSettings.SuppressPatchSequenceData"/></em></p>
        ///   <p>suppress patch sequence data in patch XML to decrease bundle size and increase patch applicability performance (patch packages themselves are not modified)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ToggleSuppressPatchSequenceData(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressPatchSequenceData = !toolSettings.SuppressPatchSequenceData;
            return toolSettings;
        }
        #endregion
        #region SuppressValidation
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.SuppressValidation"/></em></p>
        ///   <p>suppress MSI/MSM validation</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetSuppressValidation(this WixLightSettings toolSettings, bool? suppressValidation)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressValidation = suppressValidation;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixLightSettings.SuppressValidation"/></em></p>
        ///   <p>suppress MSI/MSM validation</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ResetSuppressValidation(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressValidation = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixLightSettings.SuppressValidation"/></em></p>
        ///   <p>suppress MSI/MSM validation</p>
        /// </summary>
        [Pure]
        public static WixLightSettings EnableSuppressValidation(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressValidation = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixLightSettings.SuppressValidation"/></em></p>
        ///   <p>suppress MSI/MSM validation</p>
        /// </summary>
        [Pure]
        public static WixLightSettings DisableSuppressValidation(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressValidation = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixLightSettings.SuppressValidation"/></em></p>
        ///   <p>suppress MSI/MSM validation</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ToggleSuppressValidation(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressValidation = !toolSettings.SuppressValidation;
            return toolSettings;
        }
        #endregion
        #region Parameter
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.Parameter"/> to a new dictionary</em></p>
        ///   <p>define a parameter for the preprocessor</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetParameter(this WixLightSettings toolSettings, IDictionary<string, string> parameter)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParameterInternal = parameter.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="WixLightSettings.Parameter"/></em></p>
        ///   <p>define a parameter for the preprocessor</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ClearParameter(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParameterInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="WixLightSettings.Parameter"/></em></p>
        ///   <p>define a parameter for the preprocessor</p>
        /// </summary>
        [Pure]
        public static WixLightSettings AddParameter(this WixLightSettings toolSettings, string parameterKey, string parameterValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParameterInternal.Add(parameterKey, parameterValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="WixLightSettings.Parameter"/></em></p>
        ///   <p>define a parameter for the preprocessor</p>
        /// </summary>
        [Pure]
        public static WixLightSettings RemoveParameter(this WixLightSettings toolSettings, string parameterKey)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParameterInternal.Remove(parameterKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="WixLightSettings.Parameter"/></em></p>
        ///   <p>define a parameter for the preprocessor</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetParameter(this WixLightSettings toolSettings, string parameterKey, string parameterValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParameterInternal[parameterKey] = parameterValue;
            return toolSettings;
        }
        #endregion
        #region Extension
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.Extension"/> to a new list</em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetExtension(this WixLightSettings toolSettings, params string[] extension)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionInternal = extension.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.Extension"/> to a new list</em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetExtension(this WixLightSettings toolSettings, IEnumerable<string> extension)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionInternal = extension.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixLightSettings.Extension"/></em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixLightSettings AddExtension(this WixLightSettings toolSettings, params string[] extension)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionInternal.AddRange(extension);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixLightSettings.Extension"/></em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixLightSettings AddExtension(this WixLightSettings toolSettings, IEnumerable<string> extension)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionInternal.AddRange(extension);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="WixLightSettings.Extension"/></em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ClearExtension(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixLightSettings.Extension"/></em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixLightSettings RemoveExtension(this WixLightSettings toolSettings, params string[] extension)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(extension);
            toolSettings.ExtensionInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixLightSettings.Extension"/></em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixLightSettings RemoveExtension(this WixLightSettings toolSettings, IEnumerable<string> extension)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(extension);
            toolSettings.ExtensionInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Localization
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.Localization"/></em></p>
        ///   <p>read localization strings from .wxl file</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetLocalization(this WixLightSettings toolSettings, string localization)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Localization = localization;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixLightSettings.Localization"/></em></p>
        ///   <p>read localization strings from .wxl file</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ResetLocalization(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Localization = null;
            return toolSettings;
        }
        #endregion
        #region NoLogo
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetNoLogo(this WixLightSettings toolSettings, bool? noLogo)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = noLogo;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixLightSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ResetNoLogo(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixLightSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixLightSettings EnableNoLogo(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixLightSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixLightSettings DisableNoLogo(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixLightSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ToggleNoLogo(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = !toolSettings.NoLogo;
            return toolSettings;
        }
        #endregion
        #region NoTidy
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.NoTidy"/></em></p>
        ///   <p>do not delete temporary files (useful for debugging)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetNoTidy(this WixLightSettings toolSettings, bool? noTidy)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoTidy = noTidy;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixLightSettings.NoTidy"/></em></p>
        ///   <p>do not delete temporary files (useful for debugging)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ResetNoTidy(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoTidy = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixLightSettings.NoTidy"/></em></p>
        ///   <p>do not delete temporary files (useful for debugging)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings EnableNoTidy(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoTidy = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixLightSettings.NoTidy"/></em></p>
        ///   <p>do not delete temporary files (useful for debugging)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings DisableNoTidy(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoTidy = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixLightSettings.NoTidy"/></em></p>
        ///   <p>do not delete temporary files (useful for debugging)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ToggleNoTidy(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoTidy = !toolSettings.NoTidy;
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.Output"/></em></p>
        ///   <p>specify output file (default: write to current directory)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetOutput(this WixLightSettings toolSettings, string output)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixLightSettings.Output"/></em></p>
        ///   <p>specify output file (default: write to current directory)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ResetOutput(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
        #region InputFiles
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.InputFiles"/> to a new list</em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetInputFiles(this WixLightSettings toolSettings, params string[] inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal = inputFiles.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.InputFiles"/> to a new list</em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetInputFiles(this WixLightSettings toolSettings, IEnumerable<string> inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal = inputFiles.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixLightSettings.InputFiles"/></em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixLightSettings AddInputFiles(this WixLightSettings toolSettings, params string[] inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal.AddRange(inputFiles);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixLightSettings.InputFiles"/></em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixLightSettings AddInputFiles(this WixLightSettings toolSettings, IEnumerable<string> inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal.AddRange(inputFiles);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="WixLightSettings.InputFiles"/></em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ClearInputFiles(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixLightSettings.InputFiles"/></em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixLightSettings RemoveInputFiles(this WixLightSettings toolSettings, params string[] inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(inputFiles);
            toolSettings.InputFilesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixLightSettings.InputFiles"/></em></p>
        ///   <p>input files to process</p>
        /// </summary>
        [Pure]
        public static WixLightSettings RemoveInputFiles(this WixLightSettings toolSettings, IEnumerable<string> inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(inputFiles);
            toolSettings.InputFilesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ResponseFile
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.ResponseFile"/></em></p>
        ///   <p>response file</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetResponseFile(this WixLightSettings toolSettings, string responseFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResponseFile = responseFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixLightSettings.ResponseFile"/></em></p>
        ///   <p>response file</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ResetResponseFile(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResponseFile = null;
            return toolSettings;
        }
        #endregion
        #region Pedantic
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.Pedantic"/></em></p>
        ///   <p>show pedantic messages</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetPedantic(this WixLightSettings toolSettings, bool? pedantic)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pedantic = pedantic;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixLightSettings.Pedantic"/></em></p>
        ///   <p>show pedantic messages</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ResetPedantic(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pedantic = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixLightSettings.Pedantic"/></em></p>
        ///   <p>show pedantic messages</p>
        /// </summary>
        [Pure]
        public static WixLightSettings EnablePedantic(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pedantic = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixLightSettings.Pedantic"/></em></p>
        ///   <p>show pedantic messages</p>
        /// </summary>
        [Pure]
        public static WixLightSettings DisablePedantic(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pedantic = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixLightSettings.Pedantic"/></em></p>
        ///   <p>show pedantic messages</p>
        /// </summary>
        [Pure]
        public static WixLightSettings TogglePedantic(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pedantic = !toolSettings.Pedantic;
            return toolSettings;
        }
        #endregion
        #region SuppressAllWarnings
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.SuppressAllWarnings"/></em></p>
        ///   <p>suppress all warnings</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetSuppressAllWarnings(this WixLightSettings toolSettings, bool? suppressAllWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAllWarnings = suppressAllWarnings;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixLightSettings.SuppressAllWarnings"/></em></p>
        ///   <p>suppress all warnings</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ResetSuppressAllWarnings(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAllWarnings = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixLightSettings.SuppressAllWarnings"/></em></p>
        ///   <p>suppress all warnings</p>
        /// </summary>
        [Pure]
        public static WixLightSettings EnableSuppressAllWarnings(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAllWarnings = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixLightSettings.SuppressAllWarnings"/></em></p>
        ///   <p>suppress all warnings</p>
        /// </summary>
        [Pure]
        public static WixLightSettings DisableSuppressAllWarnings(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAllWarnings = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixLightSettings.SuppressAllWarnings"/></em></p>
        ///   <p>suppress all warnings</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ToggleSuppressAllWarnings(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAllWarnings = !toolSettings.SuppressAllWarnings;
            return toolSettings;
        }
        #endregion
        #region SuppressWarnings
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.SuppressWarnings"/> to a new list</em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetSuppressWarnings(this WixLightSettings toolSettings, params int[] suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWarningsInternal = suppressWarnings.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.SuppressWarnings"/> to a new list</em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetSuppressWarnings(this WixLightSettings toolSettings, IEnumerable<int> suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWarningsInternal = suppressWarnings.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixLightSettings.SuppressWarnings"/></em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixLightSettings AddSuppressWarnings(this WixLightSettings toolSettings, params int[] suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWarningsInternal.AddRange(suppressWarnings);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixLightSettings.SuppressWarnings"/></em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixLightSettings AddSuppressWarnings(this WixLightSettings toolSettings, IEnumerable<int> suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWarningsInternal.AddRange(suppressWarnings);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="WixLightSettings.SuppressWarnings"/></em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ClearSuppressWarnings(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWarningsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixLightSettings.SuppressWarnings"/></em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixLightSettings RemoveSuppressWarnings(this WixLightSettings toolSettings, params int[] suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<int>(suppressWarnings);
            toolSettings.SuppressWarningsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixLightSettings.SuppressWarnings"/></em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixLightSettings RemoveSuppressWarnings(this WixLightSettings toolSettings, IEnumerable<int> suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<int>(suppressWarnings);
            toolSettings.SuppressWarningsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region WarningsAsErrors
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.WarningsAsErrors"/></em></p>
        ///   <p>treat all warnings as an error</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetWarningsAsErrors(this WixLightSettings toolSettings, bool? warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = warningsAsErrors;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixLightSettings.WarningsAsErrors"/></em></p>
        ///   <p>treat all warnings as an error</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ResetWarningsAsErrors(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixLightSettings.WarningsAsErrors"/></em></p>
        ///   <p>treat all warnings as an error</p>
        /// </summary>
        [Pure]
        public static WixLightSettings EnableWarningsAsErrors(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixLightSettings.WarningsAsErrors"/></em></p>
        ///   <p>treat all warnings as an error</p>
        /// </summary>
        [Pure]
        public static WixLightSettings DisableWarningsAsErrors(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixLightSettings.WarningsAsErrors"/></em></p>
        ///   <p>treat all warnings as an error</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ToggleWarningsAsErrors(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = !toolSettings.WarningsAsErrors;
            return toolSettings;
        }
        #endregion
        #region MessageIdAsError
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.MessageIdAsError"/> to a new list</em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetMessageIdAsError(this WixLightSettings toolSettings, params int[] messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MessageIdAsErrorInternal = messageIdAsError.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.MessageIdAsError"/> to a new list</em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetMessageIdAsError(this WixLightSettings toolSettings, IEnumerable<int> messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MessageIdAsErrorInternal = messageIdAsError.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixLightSettings.MessageIdAsError"/></em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixLightSettings AddMessageIdAsError(this WixLightSettings toolSettings, params int[] messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MessageIdAsErrorInternal.AddRange(messageIdAsError);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixLightSettings.MessageIdAsError"/></em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixLightSettings AddMessageIdAsError(this WixLightSettings toolSettings, IEnumerable<int> messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MessageIdAsErrorInternal.AddRange(messageIdAsError);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="WixLightSettings.MessageIdAsError"/></em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ClearMessageIdAsError(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MessageIdAsErrorInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixLightSettings.MessageIdAsError"/></em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixLightSettings RemoveMessageIdAsError(this WixLightSettings toolSettings, params int[] messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<int>(messageIdAsError);
            toolSettings.MessageIdAsErrorInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixLightSettings.MessageIdAsError"/></em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixLightSettings RemoveMessageIdAsError(this WixLightSettings toolSettings, IEnumerable<int> messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<int>(messageIdAsError);
            toolSettings.MessageIdAsErrorInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Verbose
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetVerbose(this WixLightSettings toolSettings, bool? verbose)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = verbose;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixLightSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ResetVerbose(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixLightSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixLightSettings EnableVerbose(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixLightSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixLightSettings DisableVerbose(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixLightSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ToggleVerbose(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = !toolSettings.Verbose;
            return toolSettings;
        }
        #endregion
        #region CubFile
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.CubFile"/></em></p>
        ///   <p>additional .cub file containing ICEs to run</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetCubFile(this WixLightSettings toolSettings, string cubFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CubFile = cubFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixLightSettings.CubFile"/></em></p>
        ///   <p>additional .cub file containing ICEs to run</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ResetCubFile(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CubFile = null;
            return toolSettings;
        }
        #endregion
        #region Ice
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.Ice"/> to a new list</em></p>
        ///   <p>run a specific internal consistency evaluator (ICE)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetIce(this WixLightSettings toolSettings, params string[] ice)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IceInternal = ice.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.Ice"/> to a new list</em></p>
        ///   <p>run a specific internal consistency evaluator (ICE)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetIce(this WixLightSettings toolSettings, IEnumerable<string> ice)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IceInternal = ice.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixLightSettings.Ice"/></em></p>
        ///   <p>run a specific internal consistency evaluator (ICE)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings AddIce(this WixLightSettings toolSettings, params string[] ice)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IceInternal.AddRange(ice);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixLightSettings.Ice"/></em></p>
        ///   <p>run a specific internal consistency evaluator (ICE)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings AddIce(this WixLightSettings toolSettings, IEnumerable<string> ice)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IceInternal.AddRange(ice);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="WixLightSettings.Ice"/></em></p>
        ///   <p>run a specific internal consistency evaluator (ICE)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ClearIce(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IceInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixLightSettings.Ice"/></em></p>
        ///   <p>run a specific internal consistency evaluator (ICE)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings RemoveIce(this WixLightSettings toolSettings, params string[] ice)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(ice);
            toolSettings.IceInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixLightSettings.Ice"/></em></p>
        ///   <p>run a specific internal consistency evaluator (ICE)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings RemoveIce(this WixLightSettings toolSettings, IEnumerable<string> ice)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(ice);
            toolSettings.IceInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region SuppressIce
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.SuppressIce"/> to a new list</em></p>
        ///   <p>suppress an internal consistency evaluator (ICE)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetSuppressIce(this WixLightSettings toolSettings, params string[] suppressIce)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressIceInternal = suppressIce.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="WixLightSettings.SuppressIce"/> to a new list</em></p>
        ///   <p>suppress an internal consistency evaluator (ICE)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings SetSuppressIce(this WixLightSettings toolSettings, IEnumerable<string> suppressIce)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressIceInternal = suppressIce.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixLightSettings.SuppressIce"/></em></p>
        ///   <p>suppress an internal consistency evaluator (ICE)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings AddSuppressIce(this WixLightSettings toolSettings, params string[] suppressIce)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressIceInternal.AddRange(suppressIce);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixLightSettings.SuppressIce"/></em></p>
        ///   <p>suppress an internal consistency evaluator (ICE)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings AddSuppressIce(this WixLightSettings toolSettings, IEnumerable<string> suppressIce)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressIceInternal.AddRange(suppressIce);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="WixLightSettings.SuppressIce"/></em></p>
        ///   <p>suppress an internal consistency evaluator (ICE)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings ClearSuppressIce(this WixLightSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressIceInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixLightSettings.SuppressIce"/></em></p>
        ///   <p>suppress an internal consistency evaluator (ICE)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings RemoveSuppressIce(this WixLightSettings toolSettings, params string[] suppressIce)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(suppressIce);
            toolSettings.SuppressIceInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixLightSettings.SuppressIce"/></em></p>
        ///   <p>suppress an internal consistency evaluator (ICE)</p>
        /// </summary>
        [Pure]
        public static WixLightSettings RemoveSuppressIce(this WixLightSettings toolSettings, IEnumerable<string> suppressIce)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(suppressIce);
            toolSettings.SuppressIceInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region WixTorchSettingsExtensions
    /// <summary>
    ///   Used within <see cref="WixTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class WixTorchSettingsExtensions
    {
        #region TargetInput
        /// <summary>
        ///   <p><em>Sets <see cref="WixTorchSettings.TargetInput"/></em></p>
        ///   <p>Target input</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings SetTargetInput(this WixTorchSettings toolSettings, string targetInput)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetInput = targetInput;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixTorchSettings.TargetInput"/></em></p>
        ///   <p>Target input</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings ResetTargetInput(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetInput = null;
            return toolSettings;
        }
        #endregion
        #region UpdatedInput
        /// <summary>
        ///   <p><em>Sets <see cref="WixTorchSettings.UpdatedInput"/></em></p>
        ///   <p>Updated input</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings SetUpdatedInput(this WixTorchSettings toolSettings, string updatedInput)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdatedInput = updatedInput;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixTorchSettings.UpdatedInput"/></em></p>
        ///   <p>Updated input</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings ResetUpdatedInput(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdatedInput = null;
            return toolSettings;
        }
        #endregion
        #region AdminImage
        /// <summary>
        ///   <p><em>Sets <see cref="WixTorchSettings.AdminImage"/></em></p>
        ///   <p>admin image (generates source file information in the transform) (default with -ax)</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings SetAdminImage(this WixTorchSettings toolSettings, bool? adminImage)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdminImage = adminImage;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixTorchSettings.AdminImage"/></em></p>
        ///   <p>admin image (generates source file information in the transform) (default with -ax)</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings ResetAdminImage(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdminImage = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixTorchSettings.AdminImage"/></em></p>
        ///   <p>admin image (generates source file information in the transform) (default with -ax)</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings EnableAdminImage(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdminImage = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixTorchSettings.AdminImage"/></em></p>
        ///   <p>admin image (generates source file information in the transform) (default with -ax)</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings DisableAdminImage(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdminImage = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixTorchSettings.AdminImage"/></em></p>
        ///   <p>admin image (generates source file information in the transform) (default with -ax)</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings ToggleAdminImage(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdminImage = !toolSettings.AdminImage;
            return toolSettings;
        }
        #endregion
        #region AdminImageWithExtraction
        /// <summary>
        ///   <p><em>Sets <see cref="WixTorchSettings.AdminImageWithExtraction"/></em></p>
        ///   <p>admin image with extraction of binaries (combination of -a and -x)</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings SetAdminImageWithExtraction(this WixTorchSettings toolSettings, string adminImageWithExtraction)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdminImageWithExtraction = adminImageWithExtraction;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixTorchSettings.AdminImageWithExtraction"/></em></p>
        ///   <p>admin image with extraction of binaries (combination of -a and -x)</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings ResetAdminImageWithExtraction(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdminImageWithExtraction = null;
            return toolSettings;
        }
        #endregion
        #region Preserve
        /// <summary>
        ///   <p><em>Sets <see cref="WixTorchSettings.Preserve"/></em></p>
        ///   <p>preserve unmodified content in the output</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings SetPreserve(this WixTorchSettings toolSettings, bool? preserve)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Preserve = preserve;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixTorchSettings.Preserve"/></em></p>
        ///   <p>preserve unmodified content in the output</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings ResetPreserve(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Preserve = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixTorchSettings.Preserve"/></em></p>
        ///   <p>preserve unmodified content in the output</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings EnablePreserve(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Preserve = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixTorchSettings.Preserve"/></em></p>
        ///   <p>preserve unmodified content in the output</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings DisablePreserve(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Preserve = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixTorchSettings.Preserve"/></em></p>
        ///   <p>preserve unmodified content in the output</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings TogglePreserve(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Preserve = !toolSettings.Preserve;
            return toolSettings;
        }
        #endregion
        #region SuppressErrors
        /// <summary>
        ///   <p><em>Sets <see cref="WixTorchSettings.SuppressErrors"/> to a new list</em></p>
        ///   <p>suppress error when applying transform, a - Ignore errors when adding an existing row, b - Ignore errors when deleting a missing row, c - Ignore errors when adding an existing table, d - Ignore errors when deleting a missing table, e - Ignore errors when modifying a missing row, f - Ignore errors when changing the code page</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings SetSuppressErrors(this WixTorchSettings toolSettings, params TorchErrorFlag[] suppressErrors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressErrorsInternal = suppressErrors.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="WixTorchSettings.SuppressErrors"/> to a new list</em></p>
        ///   <p>suppress error when applying transform, a - Ignore errors when adding an existing row, b - Ignore errors when deleting a missing row, c - Ignore errors when adding an existing table, d - Ignore errors when deleting a missing table, e - Ignore errors when modifying a missing row, f - Ignore errors when changing the code page</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings SetSuppressErrors(this WixTorchSettings toolSettings, IEnumerable<TorchErrorFlag> suppressErrors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressErrorsInternal = suppressErrors.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixTorchSettings.SuppressErrors"/></em></p>
        ///   <p>suppress error when applying transform, a - Ignore errors when adding an existing row, b - Ignore errors when deleting a missing row, c - Ignore errors when adding an existing table, d - Ignore errors when deleting a missing table, e - Ignore errors when modifying a missing row, f - Ignore errors when changing the code page</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings AddSuppressErrors(this WixTorchSettings toolSettings, params TorchErrorFlag[] suppressErrors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressErrorsInternal.AddRange(suppressErrors);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixTorchSettings.SuppressErrors"/></em></p>
        ///   <p>suppress error when applying transform, a - Ignore errors when adding an existing row, b - Ignore errors when deleting a missing row, c - Ignore errors when adding an existing table, d - Ignore errors when deleting a missing table, e - Ignore errors when modifying a missing row, f - Ignore errors when changing the code page</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings AddSuppressErrors(this WixTorchSettings toolSettings, IEnumerable<TorchErrorFlag> suppressErrors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressErrorsInternal.AddRange(suppressErrors);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="WixTorchSettings.SuppressErrors"/></em></p>
        ///   <p>suppress error when applying transform, a - Ignore errors when adding an existing row, b - Ignore errors when deleting a missing row, c - Ignore errors when adding an existing table, d - Ignore errors when deleting a missing table, e - Ignore errors when modifying a missing row, f - Ignore errors when changing the code page</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings ClearSuppressErrors(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressErrorsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixTorchSettings.SuppressErrors"/></em></p>
        ///   <p>suppress error when applying transform, a - Ignore errors when adding an existing row, b - Ignore errors when deleting a missing row, c - Ignore errors when adding an existing table, d - Ignore errors when deleting a missing table, e - Ignore errors when modifying a missing row, f - Ignore errors when changing the code page</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings RemoveSuppressErrors(this WixTorchSettings toolSettings, params TorchErrorFlag[] suppressErrors)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<TorchErrorFlag>(suppressErrors);
            toolSettings.SuppressErrorsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixTorchSettings.SuppressErrors"/></em></p>
        ///   <p>suppress error when applying transform, a - Ignore errors when adding an existing row, b - Ignore errors when deleting a missing row, c - Ignore errors when adding an existing table, d - Ignore errors when deleting a missing table, e - Ignore errors when modifying a missing row, f - Ignore errors when changing the code page</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings RemoveSuppressErrors(this WixTorchSettings toolSettings, IEnumerable<TorchErrorFlag> suppressErrors)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<TorchErrorFlag>(suppressErrors);
            toolSettings.SuppressErrorsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ValidationFlags
        /// <summary>
        ///   <p><em>Sets <see cref="WixTorchSettings.ValidationFlags"/> to a new list</em></p>
        ///   <p>use default validation flags for the transform type, g - UpgradeCode must match, l - Language must match, r - Product ID must match, s - Check major version only, t - Check major and minor versions, u - Check major, minor, and upgrade versions, v - Upgrade version less than target version, w - Upgrade version less or equal than target version, x - Upgrade version equals target version, y - Upgrade version greater than target version, z - Upgrade version greater or equal than target version</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings SetValidationFlags(this WixTorchSettings toolSettings, params TorchValidationFlag[] validationFlags)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ValidationFlagsInternal = validationFlags.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="WixTorchSettings.ValidationFlags"/> to a new list</em></p>
        ///   <p>use default validation flags for the transform type, g - UpgradeCode must match, l - Language must match, r - Product ID must match, s - Check major version only, t - Check major and minor versions, u - Check major, minor, and upgrade versions, v - Upgrade version less than target version, w - Upgrade version less or equal than target version, x - Upgrade version equals target version, y - Upgrade version greater than target version, z - Upgrade version greater or equal than target version</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings SetValidationFlags(this WixTorchSettings toolSettings, IEnumerable<TorchValidationFlag> validationFlags)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ValidationFlagsInternal = validationFlags.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixTorchSettings.ValidationFlags"/></em></p>
        ///   <p>use default validation flags for the transform type, g - UpgradeCode must match, l - Language must match, r - Product ID must match, s - Check major version only, t - Check major and minor versions, u - Check major, minor, and upgrade versions, v - Upgrade version less than target version, w - Upgrade version less or equal than target version, x - Upgrade version equals target version, y - Upgrade version greater than target version, z - Upgrade version greater or equal than target version</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings AddValidationFlags(this WixTorchSettings toolSettings, params TorchValidationFlag[] validationFlags)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ValidationFlagsInternal.AddRange(validationFlags);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixTorchSettings.ValidationFlags"/></em></p>
        ///   <p>use default validation flags for the transform type, g - UpgradeCode must match, l - Language must match, r - Product ID must match, s - Check major version only, t - Check major and minor versions, u - Check major, minor, and upgrade versions, v - Upgrade version less than target version, w - Upgrade version less or equal than target version, x - Upgrade version equals target version, y - Upgrade version greater than target version, z - Upgrade version greater or equal than target version</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings AddValidationFlags(this WixTorchSettings toolSettings, IEnumerable<TorchValidationFlag> validationFlags)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ValidationFlagsInternal.AddRange(validationFlags);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="WixTorchSettings.ValidationFlags"/></em></p>
        ///   <p>use default validation flags for the transform type, g - UpgradeCode must match, l - Language must match, r - Product ID must match, s - Check major version only, t - Check major and minor versions, u - Check major, minor, and upgrade versions, v - Upgrade version less than target version, w - Upgrade version less or equal than target version, x - Upgrade version equals target version, y - Upgrade version greater than target version, z - Upgrade version greater or equal than target version</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings ClearValidationFlags(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ValidationFlagsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixTorchSettings.ValidationFlags"/></em></p>
        ///   <p>use default validation flags for the transform type, g - UpgradeCode must match, l - Language must match, r - Product ID must match, s - Check major version only, t - Check major and minor versions, u - Check major, minor, and upgrade versions, v - Upgrade version less than target version, w - Upgrade version less or equal than target version, x - Upgrade version equals target version, y - Upgrade version greater than target version, z - Upgrade version greater or equal than target version</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings RemoveValidationFlags(this WixTorchSettings toolSettings, params TorchValidationFlag[] validationFlags)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<TorchValidationFlag>(validationFlags);
            toolSettings.ValidationFlagsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixTorchSettings.ValidationFlags"/></em></p>
        ///   <p>use default validation flags for the transform type, g - UpgradeCode must match, l - Language must match, r - Product ID must match, s - Check major version only, t - Check major and minor versions, u - Check major, minor, and upgrade versions, v - Upgrade version less than target version, w - Upgrade version less or equal than target version, x - Upgrade version equals target version, y - Upgrade version greater than target version, z - Upgrade version greater or equal than target version</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings RemoveValidationFlags(this WixTorchSettings toolSettings, IEnumerable<TorchValidationFlag> validationFlags)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<TorchValidationFlag>(validationFlags);
            toolSettings.ValidationFlagsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region TransformType
        /// <summary>
        ///   <p><em>Sets <see cref="WixTorchSettings.TransformType"/></em></p>
        ///   <p>use default validation flags for the transform type</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings SetTransformType(this WixTorchSettings toolSettings, TorchTransformType transformType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TransformType = transformType;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixTorchSettings.TransformType"/></em></p>
        ///   <p>use default validation flags for the transform type</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings ResetTransformType(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TransformType = null;
            return toolSettings;
        }
        #endregion
        #region ExtractBinariesToPath
        /// <summary>
        ///   <p><em>Sets <see cref="WixTorchSettings.ExtractBinariesToPath"/></em></p>
        ///   <p>extract binaries to the specified path</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings SetExtractBinariesToPath(this WixTorchSettings toolSettings, string extractBinariesToPath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtractBinariesToPath = extractBinariesToPath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixTorchSettings.ExtractBinariesToPath"/></em></p>
        ///   <p>extract binaries to the specified path</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings ResetExtractBinariesToPath(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtractBinariesToPath = null;
            return toolSettings;
        }
        #endregion
        #region WixInputFormat
        /// <summary>
        ///   <p><em>Sets <see cref="WixTorchSettings.WixInputFormat"/></em></p>
        ///   <p>input WiX format instead of MSI format (.wixout or .wixpdb)</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings SetWixInputFormat(this WixTorchSettings toolSettings, bool? wixInputFormat)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WixInputFormat = wixInputFormat;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixTorchSettings.WixInputFormat"/></em></p>
        ///   <p>input WiX format instead of MSI format (.wixout or .wixpdb)</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings ResetWixInputFormat(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WixInputFormat = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixTorchSettings.WixInputFormat"/></em></p>
        ///   <p>input WiX format instead of MSI format (.wixout or .wixpdb)</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings EnableWixInputFormat(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WixInputFormat = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixTorchSettings.WixInputFormat"/></em></p>
        ///   <p>input WiX format instead of MSI format (.wixout or .wixpdb)</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings DisableWixInputFormat(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WixInputFormat = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixTorchSettings.WixInputFormat"/></em></p>
        ///   <p>input WiX format instead of MSI format (.wixout or .wixpdb)</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings ToggleWixInputFormat(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WixInputFormat = !toolSettings.WixInputFormat;
            return toolSettings;
        }
        #endregion
        #region Wixout
        /// <summary>
        ///   <p><em>Sets <see cref="WixTorchSettings.Wixout"/></em></p>
        ///   <p>output wixout instead of MST format (set by default if -xi is present)</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings SetWixout(this WixTorchSettings toolSettings, bool? wixout)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wixout = wixout;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixTorchSettings.Wixout"/></em></p>
        ///   <p>output wixout instead of MST format (set by default if -xi is present)</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings ResetWixout(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wixout = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixTorchSettings.Wixout"/></em></p>
        ///   <p>output wixout instead of MST format (set by default if -xi is present)</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings EnableWixout(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wixout = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixTorchSettings.Wixout"/></em></p>
        ///   <p>output wixout instead of MST format (set by default if -xi is present)</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings DisableWixout(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wixout = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixTorchSettings.Wixout"/></em></p>
        ///   <p>output wixout instead of MST format (set by default if -xi is present)</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings ToggleWixout(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wixout = !toolSettings.Wixout;
            return toolSettings;
        }
        #endregion
        #region NoLogo
        /// <summary>
        ///   <p><em>Sets <see cref="WixTorchSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings SetNoLogo(this WixTorchSettings toolSettings, bool? noLogo)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = noLogo;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixTorchSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings ResetNoLogo(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixTorchSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings EnableNoLogo(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixTorchSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings DisableNoLogo(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixTorchSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings ToggleNoLogo(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = !toolSettings.NoLogo;
            return toolSettings;
        }
        #endregion
        #region ResponseFile
        /// <summary>
        ///   <p><em>Sets <see cref="WixTorchSettings.ResponseFile"/></em></p>
        ///   <p>response file</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings SetResponseFile(this WixTorchSettings toolSettings, string responseFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResponseFile = responseFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixTorchSettings.ResponseFile"/></em></p>
        ///   <p>response file</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings ResetResponseFile(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResponseFile = null;
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary>
        ///   <p><em>Sets <see cref="WixTorchSettings.Output"/></em></p>
        ///   <p>specify output file (default: write to current directory)</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings SetOutput(this WixTorchSettings toolSettings, string output)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixTorchSettings.Output"/></em></p>
        ///   <p>specify output file (default: write to current directory)</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings ResetOutput(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
        #region Extension
        /// <summary>
        ///   <p><em>Sets <see cref="WixTorchSettings.Extension"/> to a new list</em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings SetExtension(this WixTorchSettings toolSettings, params string[] extension)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionInternal = extension.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="WixTorchSettings.Extension"/> to a new list</em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings SetExtension(this WixTorchSettings toolSettings, IEnumerable<string> extension)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionInternal = extension.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixTorchSettings.Extension"/></em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings AddExtension(this WixTorchSettings toolSettings, params string[] extension)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionInternal.AddRange(extension);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixTorchSettings.Extension"/></em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings AddExtension(this WixTorchSettings toolSettings, IEnumerable<string> extension)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionInternal.AddRange(extension);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="WixTorchSettings.Extension"/></em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings ClearExtension(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixTorchSettings.Extension"/></em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings RemoveExtension(this WixTorchSettings toolSettings, params string[] extension)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(extension);
            toolSettings.ExtensionInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixTorchSettings.Extension"/></em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings RemoveExtension(this WixTorchSettings toolSettings, IEnumerable<string> extension)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(extension);
            toolSettings.ExtensionInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region NoTidy
        /// <summary>
        ///   <p><em>Sets <see cref="WixTorchSettings.NoTidy"/></em></p>
        ///   <p>do not delete temporary files (useful for debugging)</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings SetNoTidy(this WixTorchSettings toolSettings, bool? noTidy)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoTidy = noTidy;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixTorchSettings.NoTidy"/></em></p>
        ///   <p>do not delete temporary files (useful for debugging)</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings ResetNoTidy(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoTidy = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixTorchSettings.NoTidy"/></em></p>
        ///   <p>do not delete temporary files (useful for debugging)</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings EnableNoTidy(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoTidy = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixTorchSettings.NoTidy"/></em></p>
        ///   <p>do not delete temporary files (useful for debugging)</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings DisableNoTidy(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoTidy = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixTorchSettings.NoTidy"/></em></p>
        ///   <p>do not delete temporary files (useful for debugging)</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings ToggleNoTidy(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoTidy = !toolSettings.NoTidy;
            return toolSettings;
        }
        #endregion
        #region Pedantic
        /// <summary>
        ///   <p><em>Sets <see cref="WixTorchSettings.Pedantic"/></em></p>
        ///   <p>show pedantic messages</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings SetPedantic(this WixTorchSettings toolSettings, bool? pedantic)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pedantic = pedantic;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixTorchSettings.Pedantic"/></em></p>
        ///   <p>show pedantic messages</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings ResetPedantic(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pedantic = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixTorchSettings.Pedantic"/></em></p>
        ///   <p>show pedantic messages</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings EnablePedantic(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pedantic = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixTorchSettings.Pedantic"/></em></p>
        ///   <p>show pedantic messages</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings DisablePedantic(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pedantic = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixTorchSettings.Pedantic"/></em></p>
        ///   <p>show pedantic messages</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings TogglePedantic(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pedantic = !toolSettings.Pedantic;
            return toolSettings;
        }
        #endregion
        #region SuppressAllWarnings
        /// <summary>
        ///   <p><em>Sets <see cref="WixTorchSettings.SuppressAllWarnings"/></em></p>
        ///   <p>suppress all warnings</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings SetSuppressAllWarnings(this WixTorchSettings toolSettings, bool? suppressAllWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAllWarnings = suppressAllWarnings;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixTorchSettings.SuppressAllWarnings"/></em></p>
        ///   <p>suppress all warnings</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings ResetSuppressAllWarnings(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAllWarnings = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixTorchSettings.SuppressAllWarnings"/></em></p>
        ///   <p>suppress all warnings</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings EnableSuppressAllWarnings(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAllWarnings = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixTorchSettings.SuppressAllWarnings"/></em></p>
        ///   <p>suppress all warnings</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings DisableSuppressAllWarnings(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAllWarnings = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixTorchSettings.SuppressAllWarnings"/></em></p>
        ///   <p>suppress all warnings</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings ToggleSuppressAllWarnings(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAllWarnings = !toolSettings.SuppressAllWarnings;
            return toolSettings;
        }
        #endregion
        #region SuppressWarnings
        /// <summary>
        ///   <p><em>Sets <see cref="WixTorchSettings.SuppressWarnings"/> to a new list</em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings SetSuppressWarnings(this WixTorchSettings toolSettings, params int[] suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWarningsInternal = suppressWarnings.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="WixTorchSettings.SuppressWarnings"/> to a new list</em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings SetSuppressWarnings(this WixTorchSettings toolSettings, IEnumerable<int> suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWarningsInternal = suppressWarnings.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixTorchSettings.SuppressWarnings"/></em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings AddSuppressWarnings(this WixTorchSettings toolSettings, params int[] suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWarningsInternal.AddRange(suppressWarnings);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixTorchSettings.SuppressWarnings"/></em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings AddSuppressWarnings(this WixTorchSettings toolSettings, IEnumerable<int> suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWarningsInternal.AddRange(suppressWarnings);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="WixTorchSettings.SuppressWarnings"/></em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings ClearSuppressWarnings(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWarningsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixTorchSettings.SuppressWarnings"/></em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings RemoveSuppressWarnings(this WixTorchSettings toolSettings, params int[] suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<int>(suppressWarnings);
            toolSettings.SuppressWarningsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixTorchSettings.SuppressWarnings"/></em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings RemoveSuppressWarnings(this WixTorchSettings toolSettings, IEnumerable<int> suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<int>(suppressWarnings);
            toolSettings.SuppressWarningsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region WarningsAsErrors
        /// <summary>
        ///   <p><em>Sets <see cref="WixTorchSettings.WarningsAsErrors"/></em></p>
        ///   <p>treat all warnings as an error</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings SetWarningsAsErrors(this WixTorchSettings toolSettings, bool? warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = warningsAsErrors;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixTorchSettings.WarningsAsErrors"/></em></p>
        ///   <p>treat all warnings as an error</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings ResetWarningsAsErrors(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixTorchSettings.WarningsAsErrors"/></em></p>
        ///   <p>treat all warnings as an error</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings EnableWarningsAsErrors(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixTorchSettings.WarningsAsErrors"/></em></p>
        ///   <p>treat all warnings as an error</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings DisableWarningsAsErrors(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixTorchSettings.WarningsAsErrors"/></em></p>
        ///   <p>treat all warnings as an error</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings ToggleWarningsAsErrors(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = !toolSettings.WarningsAsErrors;
            return toolSettings;
        }
        #endregion
        #region MessageIdAsError
        /// <summary>
        ///   <p><em>Sets <see cref="WixTorchSettings.MessageIdAsError"/> to a new list</em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings SetMessageIdAsError(this WixTorchSettings toolSettings, params int[] messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MessageIdAsErrorInternal = messageIdAsError.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="WixTorchSettings.MessageIdAsError"/> to a new list</em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings SetMessageIdAsError(this WixTorchSettings toolSettings, IEnumerable<int> messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MessageIdAsErrorInternal = messageIdAsError.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixTorchSettings.MessageIdAsError"/></em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings AddMessageIdAsError(this WixTorchSettings toolSettings, params int[] messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MessageIdAsErrorInternal.AddRange(messageIdAsError);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixTorchSettings.MessageIdAsError"/></em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings AddMessageIdAsError(this WixTorchSettings toolSettings, IEnumerable<int> messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MessageIdAsErrorInternal.AddRange(messageIdAsError);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="WixTorchSettings.MessageIdAsError"/></em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings ClearMessageIdAsError(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MessageIdAsErrorInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixTorchSettings.MessageIdAsError"/></em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings RemoveMessageIdAsError(this WixTorchSettings toolSettings, params int[] messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<int>(messageIdAsError);
            toolSettings.MessageIdAsErrorInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixTorchSettings.MessageIdAsError"/></em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings RemoveMessageIdAsError(this WixTorchSettings toolSettings, IEnumerable<int> messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<int>(messageIdAsError);
            toolSettings.MessageIdAsErrorInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Verbose
        /// <summary>
        ///   <p><em>Sets <see cref="WixTorchSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings SetVerbose(this WixTorchSettings toolSettings, bool? verbose)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = verbose;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixTorchSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings ResetVerbose(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixTorchSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings EnableVerbose(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixTorchSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings DisableVerbose(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixTorchSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixTorchSettings ToggleVerbose(this WixTorchSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = !toolSettings.Verbose;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region WixPyroSettingsExtensions
    /// <summary>
    ///   Used within <see cref="WixTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class WixPyroSettingsExtensions
    {
        #region AllowEmptyProductTransforms
        /// <summary>
        ///   <p><em>Sets <see cref="WixPyroSettings.AllowEmptyProductTransforms"/></em></p>
        ///   <p>allow patches to be created with one or more empty product transforms</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings SetAllowEmptyProductTransforms(this WixPyroSettings toolSettings, bool? allowEmptyProductTransforms)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowEmptyProductTransforms = allowEmptyProductTransforms;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixPyroSettings.AllowEmptyProductTransforms"/></em></p>
        ///   <p>allow patches to be created with one or more empty product transforms</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings ResetAllowEmptyProductTransforms(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowEmptyProductTransforms = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixPyroSettings.AllowEmptyProductTransforms"/></em></p>
        ///   <p>allow patches to be created with one or more empty product transforms</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings EnableAllowEmptyProductTransforms(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowEmptyProductTransforms = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixPyroSettings.AllowEmptyProductTransforms"/></em></p>
        ///   <p>allow patches to be created with one or more empty product transforms</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings DisableAllowEmptyProductTransforms(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowEmptyProductTransforms = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixPyroSettings.AllowEmptyProductTransforms"/></em></p>
        ///   <p>allow patches to be created with one or more empty product transforms</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings ToggleAllowEmptyProductTransforms(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowEmptyProductTransforms = !toolSettings.AllowEmptyProductTransforms;
            return toolSettings;
        }
        #endregion
        #region BindTargetPath
        /// <summary>
        ///   <p><em>Sets <see cref="WixPyroSettings.BindTargetPath"/></em></p>
        ///   <p>new bind path to replace the original target path. It accepts two formats matching the exact light behavior. (example: -bt name1=c:\feature1\component1 -bt c:\feature2)</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings SetBindTargetPath(this WixPyroSettings toolSettings, string bindTargetPath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BindTargetPath = bindTargetPath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixPyroSettings.BindTargetPath"/></em></p>
        ///   <p>new bind path to replace the original target path. It accepts two formats matching the exact light behavior. (example: -bt name1=c:\feature1\component1 -bt c:\feature2)</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings ResetBindTargetPath(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BindTargetPath = null;
            return toolSettings;
        }
        #endregion
        #region BindUpdatePath
        /// <summary>
        ///   <p><em>Sets <see cref="WixPyroSettings.BindUpdatePath"/></em></p>
        ///   <p>new bind paths to replace the bind paths for the updated input. It accepts two formats matching the exact light behavior. example: -bu name1=\\serverA\feature1\component1 -bu \\serverA\feature2</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings SetBindUpdatePath(this WixPyroSettings toolSettings, string bindUpdatePath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BindUpdatePath = bindUpdatePath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixPyroSettings.BindUpdatePath"/></em></p>
        ///   <p>new bind paths to replace the bind paths for the updated input. It accepts two formats matching the exact light behavior. example: -bu name1=\\serverA\feature1\component1 -bu \\serverA\feature2</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings ResetBindUpdatePath(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BindUpdatePath = null;
            return toolSettings;
        }
        #endregion
        #region CachePath
        /// <summary>
        ///   <p><em>Sets <see cref="WixPyroSettings.CachePath"/></em></p>
        ///   <p>path to cache built cabinets</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings SetCachePath(this WixPyroSettings toolSettings, string cachePath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CachePath = cachePath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixPyroSettings.CachePath"/></em></p>
        ///   <p>path to cache built cabinets</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings ResetCachePath(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CachePath = null;
            return toolSettings;
        }
        #endregion
        #region CreateDeltaPatch
        /// <summary>
        ///   <p><em>Sets <see cref="WixPyroSettings.CreateDeltaPatch"/></em></p>
        ///   <p>create binary delta patch (instead of whole file patch)</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings SetCreateDeltaPatch(this WixPyroSettings toolSettings, bool? createDeltaPatch)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateDeltaPatch = createDeltaPatch;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixPyroSettings.CreateDeltaPatch"/></em></p>
        ///   <p>create binary delta patch (instead of whole file patch)</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings ResetCreateDeltaPatch(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateDeltaPatch = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixPyroSettings.CreateDeltaPatch"/></em></p>
        ///   <p>create binary delta patch (instead of whole file patch)</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings EnableCreateDeltaPatch(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateDeltaPatch = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixPyroSettings.CreateDeltaPatch"/></em></p>
        ///   <p>create binary delta patch (instead of whole file patch)</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings DisableCreateDeltaPatch(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateDeltaPatch = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixPyroSettings.CreateDeltaPatch"/></em></p>
        ///   <p>create binary delta patch (instead of whole file patch)</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings ToggleCreateDeltaPatch(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateDeltaPatch = !toolSettings.CreateDeltaPatch;
            return toolSettings;
        }
        #endregion
        #region UpdateFileVersionEntries
        /// <summary>
        ///   <p><em>Sets <see cref="WixPyroSettings.UpdateFileVersionEntries"/></em></p>
        ///   <p>update 'fileVersion' entries in the MsiAssemblyName table</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings SetUpdateFileVersionEntries(this WixPyroSettings toolSettings, bool? updateFileVersionEntries)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateFileVersionEntries = updateFileVersionEntries;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixPyroSettings.UpdateFileVersionEntries"/></em></p>
        ///   <p>update 'fileVersion' entries in the MsiAssemblyName table</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings ResetUpdateFileVersionEntries(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateFileVersionEntries = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixPyroSettings.UpdateFileVersionEntries"/></em></p>
        ///   <p>update 'fileVersion' entries in the MsiAssemblyName table</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings EnableUpdateFileVersionEntries(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateFileVersionEntries = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixPyroSettings.UpdateFileVersionEntries"/></em></p>
        ///   <p>update 'fileVersion' entries in the MsiAssemblyName table</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings DisableUpdateFileVersionEntries(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateFileVersionEntries = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixPyroSettings.UpdateFileVersionEntries"/></em></p>
        ///   <p>update 'fileVersion' entries in the MsiAssemblyName table</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings ToggleUpdateFileVersionEntries(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateFileVersionEntries = !toolSettings.UpdateFileVersionEntries;
            return toolSettings;
        }
        #endregion
        #region PdbOut
        /// <summary>
        ///   <p><em>Sets <see cref="WixPyroSettings.PdbOut"/></em></p>
        ///   <p>save the WixPdb to a specific file (default: same name as output with wixpdb extension)</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings SetPdbOut(this WixPyroSettings toolSettings, string pdbOut)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PdbOut = pdbOut;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixPyroSettings.PdbOut"/></em></p>
        ///   <p>save the WixPdb to a specific file (default: same name as output with wixpdb extension)</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings ResetPdbOut(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PdbOut = null;
            return toolSettings;
        }
        #endregion
        #region ReuseCab
        /// <summary>
        ///   <p><em>Sets <see cref="WixPyroSettings.ReuseCab"/></em></p>
        ///   <p>reuse cabinets from cabinet cache</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings SetReuseCab(this WixPyroSettings toolSettings, bool? reuseCab)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReuseCab = reuseCab;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixPyroSettings.ReuseCab"/></em></p>
        ///   <p>reuse cabinets from cabinet cache</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings ResetReuseCab(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReuseCab = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixPyroSettings.ReuseCab"/></em></p>
        ///   <p>reuse cabinets from cabinet cache</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings EnableReuseCab(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReuseCab = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixPyroSettings.ReuseCab"/></em></p>
        ///   <p>reuse cabinets from cabinet cache</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings DisableReuseCab(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReuseCab = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixPyroSettings.ReuseCab"/></em></p>
        ///   <p>reuse cabinets from cabinet cache</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings ToggleReuseCab(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReuseCab = !toolSettings.ReuseCab;
            return toolSettings;
        }
        #endregion
        #region SuppressAssemblies
        /// <summary>
        ///   <p><em>Sets <see cref="WixPyroSettings.SuppressAssemblies"/></em></p>
        ///   <p>suppress assemblies: do not get assembly name information for assemblies</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings SetSuppressAssemblies(this WixPyroSettings toolSettings, bool? suppressAssemblies)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAssemblies = suppressAssemblies;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixPyroSettings.SuppressAssemblies"/></em></p>
        ///   <p>suppress assemblies: do not get assembly name information for assemblies</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings ResetSuppressAssemblies(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAssemblies = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixPyroSettings.SuppressAssemblies"/></em></p>
        ///   <p>suppress assemblies: do not get assembly name information for assemblies</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings EnableSuppressAssemblies(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAssemblies = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixPyroSettings.SuppressAssemblies"/></em></p>
        ///   <p>suppress assemblies: do not get assembly name information for assemblies</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings DisableSuppressAssemblies(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAssemblies = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixPyroSettings.SuppressAssemblies"/></em></p>
        ///   <p>suppress assemblies: do not get assembly name information for assemblies</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings ToggleSuppressAssemblies(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAssemblies = !toolSettings.SuppressAssemblies;
            return toolSettings;
        }
        #endregion
        #region SuppressFiles
        /// <summary>
        ///   <p><em>Sets <see cref="WixPyroSettings.SuppressFiles"/></em></p>
        ///   <p>suppress files: do not get any file information (equivalent to -sa and -sh)</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings SetSuppressFiles(this WixPyroSettings toolSettings, bool? suppressFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressFiles = suppressFiles;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixPyroSettings.SuppressFiles"/></em></p>
        ///   <p>suppress files: do not get any file information (equivalent to -sa and -sh)</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings ResetSuppressFiles(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressFiles = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixPyroSettings.SuppressFiles"/></em></p>
        ///   <p>suppress files: do not get any file information (equivalent to -sa and -sh)</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings EnableSuppressFiles(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressFiles = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixPyroSettings.SuppressFiles"/></em></p>
        ///   <p>suppress files: do not get any file information (equivalent to -sa and -sh)</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings DisableSuppressFiles(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressFiles = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixPyroSettings.SuppressFiles"/></em></p>
        ///   <p>suppress files: do not get any file information (equivalent to -sa and -sh)</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings ToggleSuppressFiles(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressFiles = !toolSettings.SuppressFiles;
            return toolSettings;
        }
        #endregion
        #region SuppressFileInfo
        /// <summary>
        ///   <p><em>Sets <see cref="WixPyroSettings.SuppressFileInfo"/></em></p>
        ///   <p>suppress file info: do not get hash, version, language, etc</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings SetSuppressFileInfo(this WixPyroSettings toolSettings, bool? suppressFileInfo)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressFileInfo = suppressFileInfo;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixPyroSettings.SuppressFileInfo"/></em></p>
        ///   <p>suppress file info: do not get hash, version, language, etc</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings ResetSuppressFileInfo(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressFileInfo = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixPyroSettings.SuppressFileInfo"/></em></p>
        ///   <p>suppress file info: do not get hash, version, language, etc</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings EnableSuppressFileInfo(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressFileInfo = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixPyroSettings.SuppressFileInfo"/></em></p>
        ///   <p>suppress file info: do not get hash, version, language, etc</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings DisableSuppressFileInfo(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressFileInfo = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixPyroSettings.SuppressFileInfo"/></em></p>
        ///   <p>suppress file info: do not get hash, version, language, etc</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings ToggleSuppressFileInfo(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressFileInfo = !toolSettings.SuppressFileInfo;
            return toolSettings;
        }
        #endregion
        #region SuppressWixPdb
        /// <summary>
        ///   <p><em>Sets <see cref="WixPyroSettings.SuppressWixPdb"/></em></p>
        ///   <p>suppress outputting the WixPdb</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings SetSuppressWixPdb(this WixPyroSettings toolSettings, bool? suppressWixPdb)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWixPdb = suppressWixPdb;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixPyroSettings.SuppressWixPdb"/></em></p>
        ///   <p>suppress outputting the WixPdb</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings ResetSuppressWixPdb(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWixPdb = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixPyroSettings.SuppressWixPdb"/></em></p>
        ///   <p>suppress outputting the WixPdb</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings EnableSuppressWixPdb(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWixPdb = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixPyroSettings.SuppressWixPdb"/></em></p>
        ///   <p>suppress outputting the WixPdb</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings DisableSuppressWixPdb(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWixPdb = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixPyroSettings.SuppressWixPdb"/></em></p>
        ///   <p>suppress outputting the WixPdb</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings ToggleSuppressWixPdb(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWixPdb = !toolSettings.SuppressWixPdb;
            return toolSettings;
        }
        #endregion
        #region BaselineAndTransform
        /// <summary>
        ///   <p><em>Sets <see cref="WixPyroSettings.BaselineAndTransform"/> to a new list</em></p>
        ///   <p>one or more wix transforms and its baseline</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings SetBaselineAndTransform(this WixPyroSettings toolSettings, params string[] baselineAndTransform)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BaselineAndTransformInternal = baselineAndTransform.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="WixPyroSettings.BaselineAndTransform"/> to a new list</em></p>
        ///   <p>one or more wix transforms and its baseline</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings SetBaselineAndTransform(this WixPyroSettings toolSettings, IEnumerable<string> baselineAndTransform)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BaselineAndTransformInternal = baselineAndTransform.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixPyroSettings.BaselineAndTransform"/></em></p>
        ///   <p>one or more wix transforms and its baseline</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings AddBaselineAndTransform(this WixPyroSettings toolSettings, params string[] baselineAndTransform)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BaselineAndTransformInternal.AddRange(baselineAndTransform);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixPyroSettings.BaselineAndTransform"/></em></p>
        ///   <p>one or more wix transforms and its baseline</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings AddBaselineAndTransform(this WixPyroSettings toolSettings, IEnumerable<string> baselineAndTransform)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BaselineAndTransformInternal.AddRange(baselineAndTransform);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="WixPyroSettings.BaselineAndTransform"/></em></p>
        ///   <p>one or more wix transforms and its baseline</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings ClearBaselineAndTransform(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BaselineAndTransformInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixPyroSettings.BaselineAndTransform"/></em></p>
        ///   <p>one or more wix transforms and its baseline</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings RemoveBaselineAndTransform(this WixPyroSettings toolSettings, params string[] baselineAndTransform)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(baselineAndTransform);
            toolSettings.BaselineAndTransformInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixPyroSettings.BaselineAndTransform"/></em></p>
        ///   <p>one or more wix transforms and its baseline</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings RemoveBaselineAndTransform(this WixPyroSettings toolSettings, IEnumerable<string> baselineAndTransform)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(baselineAndTransform);
            toolSettings.BaselineAndTransformInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region NoLogo
        /// <summary>
        ///   <p><em>Sets <see cref="WixPyroSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings SetNoLogo(this WixPyroSettings toolSettings, bool? noLogo)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = noLogo;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixPyroSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings ResetNoLogo(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixPyroSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings EnableNoLogo(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixPyroSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings DisableNoLogo(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixPyroSettings.NoLogo"/></em></p>
        ///   <p>skip printing logo information</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings ToggleNoLogo(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = !toolSettings.NoLogo;
            return toolSettings;
        }
        #endregion
        #region NoTidy
        /// <summary>
        ///   <p><em>Sets <see cref="WixPyroSettings.NoTidy"/></em></p>
        ///   <p>do not delete temporary files (useful for debugging)</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings SetNoTidy(this WixPyroSettings toolSettings, bool? noTidy)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoTidy = noTidy;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixPyroSettings.NoTidy"/></em></p>
        ///   <p>do not delete temporary files (useful for debugging)</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings ResetNoTidy(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoTidy = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixPyroSettings.NoTidy"/></em></p>
        ///   <p>do not delete temporary files (useful for debugging)</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings EnableNoTidy(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoTidy = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixPyroSettings.NoTidy"/></em></p>
        ///   <p>do not delete temporary files (useful for debugging)</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings DisableNoTidy(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoTidy = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixPyroSettings.NoTidy"/></em></p>
        ///   <p>do not delete temporary files (useful for debugging)</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings ToggleNoTidy(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoTidy = !toolSettings.NoTidy;
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary>
        ///   <p><em>Sets <see cref="WixPyroSettings.Output"/></em></p>
        ///   <p>specify output file (default: write to current directory)</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings SetOutput(this WixPyroSettings toolSettings, string output)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixPyroSettings.Output"/></em></p>
        ///   <p>specify output file (default: write to current directory)</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings ResetOutput(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
        #region SuppressAllWarnings
        /// <summary>
        ///   <p><em>Sets <see cref="WixPyroSettings.SuppressAllWarnings"/></em></p>
        ///   <p>suppress all warnings</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings SetSuppressAllWarnings(this WixPyroSettings toolSettings, bool? suppressAllWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAllWarnings = suppressAllWarnings;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixPyroSettings.SuppressAllWarnings"/></em></p>
        ///   <p>suppress all warnings</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings ResetSuppressAllWarnings(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAllWarnings = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixPyroSettings.SuppressAllWarnings"/></em></p>
        ///   <p>suppress all warnings</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings EnableSuppressAllWarnings(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAllWarnings = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixPyroSettings.SuppressAllWarnings"/></em></p>
        ///   <p>suppress all warnings</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings DisableSuppressAllWarnings(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAllWarnings = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixPyroSettings.SuppressAllWarnings"/></em></p>
        ///   <p>suppress all warnings</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings ToggleSuppressAllWarnings(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressAllWarnings = !toolSettings.SuppressAllWarnings;
            return toolSettings;
        }
        #endregion
        #region SuppressWarnings
        /// <summary>
        ///   <p><em>Sets <see cref="WixPyroSettings.SuppressWarnings"/> to a new list</em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings SetSuppressWarnings(this WixPyroSettings toolSettings, params int[] suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWarningsInternal = suppressWarnings.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="WixPyroSettings.SuppressWarnings"/> to a new list</em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings SetSuppressWarnings(this WixPyroSettings toolSettings, IEnumerable<int> suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWarningsInternal = suppressWarnings.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixPyroSettings.SuppressWarnings"/></em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings AddSuppressWarnings(this WixPyroSettings toolSettings, params int[] suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWarningsInternal.AddRange(suppressWarnings);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixPyroSettings.SuppressWarnings"/></em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings AddSuppressWarnings(this WixPyroSettings toolSettings, IEnumerable<int> suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWarningsInternal.AddRange(suppressWarnings);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="WixPyroSettings.SuppressWarnings"/></em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings ClearSuppressWarnings(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SuppressWarningsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixPyroSettings.SuppressWarnings"/></em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings RemoveSuppressWarnings(this WixPyroSettings toolSettings, params int[] suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<int>(suppressWarnings);
            toolSettings.SuppressWarningsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixPyroSettings.SuppressWarnings"/></em></p>
        ///   <p>suppress a specific message ID</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings RemoveSuppressWarnings(this WixPyroSettings toolSettings, IEnumerable<int> suppressWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<int>(suppressWarnings);
            toolSettings.SuppressWarningsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region WarningsAsErrors
        /// <summary>
        ///   <p><em>Sets <see cref="WixPyroSettings.WarningsAsErrors"/></em></p>
        ///   <p>treat all warnings as an error</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings SetWarningsAsErrors(this WixPyroSettings toolSettings, bool? warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = warningsAsErrors;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixPyroSettings.WarningsAsErrors"/></em></p>
        ///   <p>treat all warnings as an error</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings ResetWarningsAsErrors(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixPyroSettings.WarningsAsErrors"/></em></p>
        ///   <p>treat all warnings as an error</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings EnableWarningsAsErrors(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixPyroSettings.WarningsAsErrors"/></em></p>
        ///   <p>treat all warnings as an error</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings DisableWarningsAsErrors(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixPyroSettings.WarningsAsErrors"/></em></p>
        ///   <p>treat all warnings as an error</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings ToggleWarningsAsErrors(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = !toolSettings.WarningsAsErrors;
            return toolSettings;
        }
        #endregion
        #region MessageIdAsError
        /// <summary>
        ///   <p><em>Sets <see cref="WixPyroSettings.MessageIdAsError"/> to a new list</em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings SetMessageIdAsError(this WixPyroSettings toolSettings, params int[] messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MessageIdAsErrorInternal = messageIdAsError.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="WixPyroSettings.MessageIdAsError"/> to a new list</em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings SetMessageIdAsError(this WixPyroSettings toolSettings, IEnumerable<int> messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MessageIdAsErrorInternal = messageIdAsError.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixPyroSettings.MessageIdAsError"/></em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings AddMessageIdAsError(this WixPyroSettings toolSettings, params int[] messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MessageIdAsErrorInternal.AddRange(messageIdAsError);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixPyroSettings.MessageIdAsError"/></em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings AddMessageIdAsError(this WixPyroSettings toolSettings, IEnumerable<int> messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MessageIdAsErrorInternal.AddRange(messageIdAsError);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="WixPyroSettings.MessageIdAsError"/></em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings ClearMessageIdAsError(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MessageIdAsErrorInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixPyroSettings.MessageIdAsError"/></em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings RemoveMessageIdAsError(this WixPyroSettings toolSettings, params int[] messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<int>(messageIdAsError);
            toolSettings.MessageIdAsErrorInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixPyroSettings.MessageIdAsError"/></em></p>
        ///   <p>treat a specific message ID as an error</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings RemoveMessageIdAsError(this WixPyroSettings toolSettings, IEnumerable<int> messageIdAsError)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<int>(messageIdAsError);
            toolSettings.MessageIdAsErrorInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Verbose
        /// <summary>
        ///   <p><em>Sets <see cref="WixPyroSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings SetVerbose(this WixPyroSettings toolSettings, bool? verbose)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = verbose;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixPyroSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings ResetVerbose(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="WixPyroSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings EnableVerbose(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="WixPyroSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings DisableVerbose(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="WixPyroSettings.Verbose"/></em></p>
        ///   <p>verbose output</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings ToggleVerbose(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = !toolSettings.Verbose;
            return toolSettings;
        }
        #endregion
        #region ResponseFile
        /// <summary>
        ///   <p><em>Sets <see cref="WixPyroSettings.ResponseFile"/></em></p>
        ///   <p>response file</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings SetResponseFile(this WixPyroSettings toolSettings, string responseFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResponseFile = responseFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WixPyroSettings.ResponseFile"/></em></p>
        ///   <p>response file</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings ResetResponseFile(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResponseFile = null;
            return toolSettings;
        }
        #endregion
        #region Extension
        /// <summary>
        ///   <p><em>Sets <see cref="WixPyroSettings.Extension"/> to a new list</em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings SetExtension(this WixPyroSettings toolSettings, params string[] extension)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionInternal = extension.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="WixPyroSettings.Extension"/> to a new list</em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings SetExtension(this WixPyroSettings toolSettings, IEnumerable<string> extension)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionInternal = extension.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixPyroSettings.Extension"/></em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings AddExtension(this WixPyroSettings toolSettings, params string[] extension)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionInternal.AddRange(extension);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="WixPyroSettings.Extension"/></em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings AddExtension(this WixPyroSettings toolSettings, IEnumerable<string> extension)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionInternal.AddRange(extension);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="WixPyroSettings.Extension"/></em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings ClearExtension(this WixPyroSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixPyroSettings.Extension"/></em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings RemoveExtension(this WixPyroSettings toolSettings, params string[] extension)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(extension);
            toolSettings.ExtensionInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="WixPyroSettings.Extension"/></em></p>
        ///   <p> extension assembly or 'class, assembly'</p>
        /// </summary>
        [Pure]
        public static WixPyroSettings RemoveExtension(this WixPyroSettings toolSettings, IEnumerable<string> extension)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(extension);
            toolSettings.ExtensionInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HarvestType
    /// <summary>
    ///   Used within <see cref="WixTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<HarvestType>))]
    public partial class HarvestType : Enumeration
    {
        public static HarvestType dir = new HarvestType { Value = "dir" };
        public static HarvestType file = new HarvestType { Value = "file" };
        public static HarvestType payload = new HarvestType { Value = "payload" };
        public static HarvestType perf = new HarvestType { Value = "perf" };
        public static HarvestType project = new HarvestType { Value = "project" };
        public static HarvestType reg = new HarvestType { Value = "reg" };
        public static HarvestType website = new HarvestType { Value = "website" };
    }
    #endregion
    #region Element
    /// <summary>
    ///   Used within <see cref="WixTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<Element>))]
    public partial class Element : Enumeration
    {
        public static Element components = new Element { Value = "components" };
        public static Element container = new Element { Value = "container" };
        public static Element payloadgroup = new Element { Value = "payloadgroup" };
        public static Element layout = new Element { Value = "layout" };
        public static Element packagegroup = new Element { Value = "packagegroup" };
    }
    #endregion
    #region ProjectOutputGroup
    /// <summary>
    ///   Used within <see cref="WixTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<ProjectOutputGroup>))]
    public partial class ProjectOutputGroup : Enumeration
    {
        public static ProjectOutputGroup Binaries = new ProjectOutputGroup { Value = "Binaries" };
        public static ProjectOutputGroup Symbols = new ProjectOutputGroup { Value = "Symbols" };
        public static ProjectOutputGroup Documents = new ProjectOutputGroup { Value = "Documents" };
        public static ProjectOutputGroup Satellites = new ProjectOutputGroup { Value = "Satellites" };
        public static ProjectOutputGroup Sources = new ProjectOutputGroup { Value = "Sources" };
        public static ProjectOutputGroup Content = new ProjectOutputGroup { Value = "Content" };
    }
    #endregion
    #region Template
    /// <summary>
    ///   Used within <see cref="WixTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<Template>))]
    public partial class Template : Enumeration
    {
        public static Template fragment = new Template { Value = "fragment" };
        public static Template module = new Template { Value = "module" };
        public static Template product = new Template { Value = "product" };
    }
    #endregion
    #region CompressionLevel
    /// <summary>
    ///   Used within <see cref="WixTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<CompressionLevel>))]
    public partial class CompressionLevel : Enumeration
    {
        public static CompressionLevel low = new CompressionLevel { Value = "low" };
        public static CompressionLevel medium = new CompressionLevel { Value = "medium" };
        public static CompressionLevel high = new CompressionLevel { Value = "high" };
        public static CompressionLevel none = new CompressionLevel { Value = "none" };
        public static CompressionLevel mszip = new CompressionLevel { Value = "mszip" };
    }
    #endregion
    #region Architecture
    /// <summary>
    ///   Used within <see cref="WixTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<Architecture>))]
    public partial class Architecture : Enumeration
    {
        public static Architecture x86 = new Architecture { Value = "x86" };
        public static Architecture x64 = new Architecture { Value = "x64" };
        public static Architecture ia64 = new Architecture { Value = "ia64" };
    }
    #endregion
    #region TorchErrorFlag
    /// <summary>
    ///   Used within <see cref="WixTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<TorchErrorFlag>))]
    public partial class TorchErrorFlag : Enumeration
    {
        public static TorchErrorFlag a = new TorchErrorFlag { Value = "a" };
        public static TorchErrorFlag b = new TorchErrorFlag { Value = "b" };
        public static TorchErrorFlag c = new TorchErrorFlag { Value = "c" };
        public static TorchErrorFlag d = new TorchErrorFlag { Value = "d" };
        public static TorchErrorFlag e = new TorchErrorFlag { Value = "e" };
        public static TorchErrorFlag f = new TorchErrorFlag { Value = "f" };
    }
    #endregion
    #region TorchValidationFlag
    /// <summary>
    ///   Used within <see cref="WixTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<TorchValidationFlag>))]
    public partial class TorchValidationFlag : Enumeration
    {
        public static TorchValidationFlag g = new TorchValidationFlag { Value = "g" };
        public static TorchValidationFlag l = new TorchValidationFlag { Value = "l" };
        public static TorchValidationFlag r = new TorchValidationFlag { Value = "r" };
        public static TorchValidationFlag s = new TorchValidationFlag { Value = "s" };
        public static TorchValidationFlag t = new TorchValidationFlag { Value = "t" };
        public static TorchValidationFlag u = new TorchValidationFlag { Value = "u" };
        public static TorchValidationFlag v = new TorchValidationFlag { Value = "v" };
        public static TorchValidationFlag w = new TorchValidationFlag { Value = "w" };
        public static TorchValidationFlag x = new TorchValidationFlag { Value = "x" };
        public static TorchValidationFlag y = new TorchValidationFlag { Value = "y" };
        public static TorchValidationFlag z = new TorchValidationFlag { Value = "z" };
    }
    #endregion
    #region TorchTransformType
    /// <summary>
    ///   Used within <see cref="WixTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<TorchTransformType>))]
    public partial class TorchTransformType : Enumeration
    {
        public static TorchTransformType language = new TorchTransformType { Value = "language" };
        public static TorchTransformType instance = new TorchTransformType { Value = "instance" };
        public static TorchTransformType patch = new TorchTransformType { Value = "patch" };
    }
    #endregion
}
