// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.Wix
{
    public partial class CopBaseSettings
    {
        public override Action<OutputType, string> CustomLogger { get; }
        
        public string GetToolPath()
        {
            return $@"{EnvironmentInfo.Variable("WIX")}\bin\wixcop.exe";
        }
    }
}
