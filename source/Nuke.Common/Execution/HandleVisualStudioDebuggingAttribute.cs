// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using JetBrains.Annotations;

namespace Nuke.Common.Execution
{
    [PublicAPI]
    [AttributeUsage(AttributeTargets.Class)]
    public class HandleVisualStudioDebuggingAttribute : Attribute, IPreLogoBuildExtension
    {
        public int TimeoutInMilliseconds { get; } = 10_000;

        public void Execute(
            NukeBuild build,
            IReadOnlyCollection<ExecutableTarget> executableTargets,
            IReadOnlyCollection<ExecutableTarget> executionPlan)
        {
            if (!ParameterService.Instance.GetParameter<bool>(Constants.VisualStudioDebugParameterName))
                return;

            File.WriteAllText(Constants.GetVisualStudioDebugFile(NukeBuild.RootDirectory),
                Process.GetCurrentProcess().Id.ToString());
            ControlFlow.Assert(SpinWait.SpinUntil(() => Debugger.IsAttached, millisecondsTimeout: TimeoutInMilliseconds),
                $"VisualStudio debugger was not attached within {TimeoutInMilliseconds} milliseconds.");
        }
    }
}
