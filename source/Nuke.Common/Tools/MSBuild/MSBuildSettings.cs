// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;

namespace Nuke.Common.Tools.MSBuild
{
    public class MSBuildVerbosityMappingAttribute : VerbosityMappingAttribute
    {
        public MSBuildVerbosityMappingAttribute()
            : base(typeof(MSBuildVerbosity))
        {
            Quiet = nameof(MSBuildVerbosity.Quiet);
            Minimal = nameof(MSBuildVerbosity.Minimal);
            Normal = nameof(MSBuildVerbosity.Minimal);
            Verbose = nameof(MSBuildVerbosity.Detailed);
        }
    }

    partial class MSBuildSettings
    {
        [CanBeNull]
        private string GetTargetPlatform()
        {
            if (TargetPlatform == null)
                return null;

            if (Equals(TargetPlatform, MSBuildTargetPlatform.MSIL))
            {
                return TargetPath == null || TargetPath.EndsWithOrdinalIgnoreCase(".sln")
                    ? "Any CPU".DoubleQuote()
                    : "AnyCPU";
            }

            return TargetPlatform.ToString();
        }

        private string GetToolPath()
        {
            return MSBuildToolPathResolver.Resolve(MSBuildVersion, MSBuildPlatform);
        }


        internal string GetFileLogger()
        {
            if (FileLogger == null)
                return null;

            var result = new StringBuilder();

            // A maximum of 9 loggers are supported.
            for (var i = 0; i < FileLogger.Count && i < 9; i++)
            {
                if (i != 0)
                    result.Append(' ');

                var fileLogger = FileLogger[i];
                var builder = new MSBuildParameterBuilder($"/flp{i + 1}", true)
                   .Add("PerformanceSummary", fileLogger.PerformanceSummary)
                   .Add("Summary", "NoSummary", fileLogger.Summary)
                   .Add("ErrorsOnly", fileLogger.ErrorsOnly)
                   .Add("WarningsOnly", fileLogger.WarningsOnly)
                   .Add("NoItemAndPropertyList", fileLogger.NoItemAndPropertyList)
                   .Add("ShowCommandLine", fileLogger.ShowCommandLine)
                   .Add("ShowTimestamp", fileLogger.ShowTimestamp)
                   .Add("ShowEventId", fileLogger.ShowEventId)
                   .Add("EnableMPLogging", "DisableMPLogging", fileLogger.MultiProcessorLogging)
                   .Add("Verbosity", fileLogger.Verbosity?.ToString())
                   .Add("LogFile", fileLogger.LogFile)
                   .Add("Append", fileLogger.Append)
                   .Add("Encoding", fileLogger.Encoding);

                result.Append(builder.Render());
            }

            return result.ToString();
        }

        internal string GetConsoleLogger()
        {
            if (ConsoleLogger == null)
                return null;

            var builder = new MSBuildParameterBuilder("/consoleLoggerParameters", emptyParametersAllowed: false)
               .Add("PerformanceSummary", ConsoleLogger.PerformanceSummary)
               .Add("Summary", "NoSummary", ConsoleLogger.Summary)
               .Add("ErrorsOnly", ConsoleLogger.ErrorsOnly)
               .Add("WarningsOnly", ConsoleLogger.WarningsOnly)
               .Add("NoItemAndPropertyList", ConsoleLogger.NoItemAndPropertyList)
               .Add("ShowCommandLine", ConsoleLogger.ShowCommandLine)
               .Add("ShowTimestamp", ConsoleLogger.ShowTimestamp)
               .Add("ShowEventId", ConsoleLogger.ShowEventId)
               .Add("ForceNoAlign", ConsoleLogger.ForceNoAlign)
               .Add(null, "DisableConsoleColor", ConsoleLogger.ConsoleColor)
               .Add("EnableMPLogging", "DisableMPLogging", ConsoleLogger.MultiProcessorLogging)
               .Add("Verbosity", ConsoleLogger.Verbosity?.ToString());

            return builder.Render();
        }

        private class MSBuildParameterBuilder
        {
            private List<(string Name, string Value)> _parameters = new List<(string Name, string Value)>();
            private readonly bool _emptyParametersAllowed;

            public MSBuildParameterBuilder(string argumentName, bool emptyParametersAllowed)
            {
                _emptyParametersAllowed = emptyParametersAllowed;
                ArgumentName = argumentName;
            }

            public string ArgumentName { get; }

            public MSBuildParameterBuilder Add(string name, bool? value)
            {
                if (value == true)
                    _parameters.Add((name, null));

                return this;
            }

            public MSBuildParameterBuilder Add(string nameIfTrue, string nameIfFalse, bool? value)
            {
                if (value == true && nameIfTrue != null)
                    _parameters.Add((nameIfTrue, null));
                else if (value == false && nameIfFalse != null)
                    _parameters.Add((nameIfFalse, null));

                return this;
            }

            public MSBuildParameterBuilder Add(string name, string value)
            {
                if (!string.IsNullOrEmpty(value))
                    _parameters.Add((name, value));

                return this;
            }

            public string Render()
            {
                if (!_emptyParametersAllowed && _parameters.Count == 0)
                    return string.Empty;

                var builder = new StringBuilder(ArgumentName);
                if (_parameters.Count > 0)
                {
                    builder.Append(":\"");
                    foreach (var kvp in _parameters)
                    {
                        builder.Append(kvp.Name);
                        if (!string.IsNullOrEmpty(kvp.Value))
                        {
                            builder.Append('=');
                            builder.Append(kvp.Value);
                        }
                        builder.Append(';');
                    }

                    // Remove trailing ';'
                    builder.Length--;
                    builder.Append('\"');
                }
                return builder.ToString();
            }
        }
    }
}
