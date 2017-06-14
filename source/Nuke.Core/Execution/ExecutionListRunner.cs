// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Nuke.Core.Output;
using Nuke.Core.Tooling;

namespace Nuke.Core.Execution
{
    internal class ExecutionListRunner
    {
        public int Run (TargetList targetList)
        {
            System.Diagnostics.Debugger.Launch();
            return 0;
        }

        public int Run (IReadOnlyCollection<TargetDefinition> executionList)
        {
            foreach (var target in executionList)
            {
                if (target.Factory == null)
                {
                    target.Status = ExecutionStatus.Absent;
                    continue;
                }

                if (target.Conditions.Any(x => !x()))
                {
                    target.Status = ExecutionStatus.Skipped;
                    continue;
                }

                    var stopwatch = Stopwatch.StartNew();
                    try
                    {
                        Execute(target);

                        target.Duration = stopwatch.Elapsed;
                        target.Status = ExecutionStatus.Executed;
                    }
                    catch (Exception exception)
                    {
                        OutputSink.Fail(exception.Message, exception.StackTrace);
                        target.Status = ExecutionStatus.Failed;

                        break;
                    }
                    finally
                    {
                        target.Duration = stopwatch.Elapsed;
                    }
            }

            OutputSink.WriteSummary(executionList);

            return -executionList.Count(x => x.Status == ExecutionStatus.Failed);
        }

        private static void Execute (TargetDefinition target)
        {
            if (!EnvironmentInfo.ArgumentSwitch("parallel") ||
                EnvironmentInfo.ArgumentSwitch("worker"))
            {
                using (OutputSink.WriteBlock(target.Name))
                {
                    target.Actions.ForEach(x => x.Invoke());
                }
            }
            else
            {
                var process = ProcessManager.StartProcessInternal(EnvironmentInfo.BuildAssembly.Location,
                    $"--target={target.Name} --worker --nodeps",
                    EnvironmentInfo.CurrentDirectory,
                    environmentVariables: null,
                    timeout: null,
                    redirectOutput: false,
                    outputFilter: x => x,
                    useShellExecute: true);

                process.AssertZeroExitCode();
            }
        }
    }
}
