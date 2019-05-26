// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.CloudFoundry
{
    public partial class CloudFoundryBaseSettings
    {
        public string GetToolPath() => CloudFoundryTasks.GetToolPath();
        public override Action<OutputType, string> CustomLogger => CloudFoundryTasks.CloudFoundryLogger;
    }
}
