// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.BuildServers
{
    public static class ArtifactExtensions
    {
        internal static readonly LookupTable<ITargetDefinition, string> ArtifactProducts =
            new LookupTable<ITargetDefinition, string>();

        internal static readonly LookupTable<ITargetDefinition, (Target, string[])> ArtifactDependencies =
            new LookupTable<ITargetDefinition, (Target, string[])>();

        public static ITargetDefinition Produces(this ITargetDefinition targetDefinition, params string[] artifacts)
        {
            ArtifactProducts.AddRange(targetDefinition, artifacts);
            return targetDefinition;
        }

        public static ITargetDefinition Consumes(this ITargetDefinition targetDefinition, params Target[] targets)
        {
            targets.ForEach(x => targetDefinition.Consumes(x));
            return targetDefinition;
        }

        public static ITargetDefinition Consumes(this ITargetDefinition targetDefinition, Target target, params string[] artifacts)
        {
            ArtifactDependencies.Add(targetDefinition, (target, artifacts));
            return targetDefinition;
        }
    }
}
