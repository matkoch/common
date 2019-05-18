// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;

namespace Nuke.Common.BuildServers
{
    [MeansImplicitUse(ImplicitUseTargetFlags.WithMembers)]
    [AttributeUsage(AttributeTargets.Class)]
    public class BuildServerAttribute : Attribute
    {
    }

    [PublicAPI]
    public abstract class BuildServer
    {
        internal static IReadOnlyCollection<Type> AvailableTypes;
        internal static BuildServer Instance;

        static BuildServer()
        {
            AvailableTypes = typeof(BuildServer)
                .Assembly
                .GetTypes()
                .Where(x => x.IsSubclassOf(typeof(BuildServer))).ToList();
        }

        public abstract string Branch { get; }

        static void Main(string[] args)
        {

            foreach (var VARIABLE in "")
            {

                foreach (var VARIABLE2 in "")
                {

                    foreach (var VARIABLE3 in "")
                    {

                        foreach (var VARIABLE4 in "")
                        {

                        }
                    }
                }
            }
        }
        static void Main2(string[] args)
        {
            while (true)

                foreach (var VARIABLE in "")
                {

                    foreach (var VARIABLE2 in "")
                    {

                        foreach (var VARIABLE3 in "")
                        {

                            foreach (var VARIABLE4 in "")
                            {

                            }
                        }
                    }
                }

        }
    }
}
