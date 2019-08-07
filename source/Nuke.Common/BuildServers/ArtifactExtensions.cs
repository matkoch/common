// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Nuke.Common.Execution;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.BuildServers
{
    [PublicAPI]
    public static class ArtifactExtensions
    {
        internal static readonly Dictionary<ITargetDefinition, int> Partitions =
            new Dictionary<ITargetDefinition, int>();

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

        public static ITargetDefinition Partition(this ITargetDefinition targetDefinition, int total)
        {
            Partitions.Add(targetDefinition, total);
            return targetDefinition;
        }
    }

    public class PartitionAttribute : ParameterAttribute
    {
        // public PartitionAttribute()
        // {
        //     Total = total;
        // }
        //
        // public int Total { get; }

        public override bool List => false;

        // public override object GetValue(MemberInfo member, object instance)
        // {
        //     var part = ParameterService.Instance.GetParameter<int?>(member);
        //     return part.HasValue
        //         ? new Partition { Part = part.Value, Total = Total }
        //         : Partition.Single;
        // }
    }

    [TypeConverter(typeof(TypeConverter))]
    public class Partition
    {
        public static Partition Single { get; } = new Partition { Part = 1, Total = 1 };

        public int Part { get; set; }
        public int Total { get; set; }

        public class TypeConverter : System.ComponentModel.TypeConverter
        {
            public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
            {
                return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
            }

            public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
            {
                if (value is string stringValue)
                {
                    var values = stringValue.Split('/');
                    return new Partition
                           {
                               Part = int.Parse(values[0]),
                               Total = int.Parse(values[1])
                           };
                }

                return base.ConvertFrom(context, culture, value);
            }
        }
    }

    public static class EnumerableExtensions
    {
        public static IEnumerable<T> GetPartition<T>(this IEnumerable<T> enumerable, [CallerMemberName] string callerMemberName = null)
        {
            var partition = ParameterService.Instance.GetParameter<Partition>("Partition" + callerMemberName)
                            ?? Partition.Single;
            var i = 0;
            foreach (var item in enumerable)
            {
                if (i == partition.Part - 1)
                    yield return item;
                i = (i + 1) % partition.Total;
            }
        }
    }
}
