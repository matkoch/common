using JetBrains.Annotations;
using Nuke.Common.Execution;
using Nuke.Common.Tooling;
using System.Reflection;

namespace Nuke.Common.Tools.Nbgv
{
    [PublicAPI]
    [UsedImplicitly(ImplicitUseKindFlags.Default)]
    public class NbgvAttribute : InjectionAttributeBase
    {
        public override object GetValue(MemberInfo member, object instance)
        {
            return NbgvTasks.NbgvGetVersion(s => s.SetFormat(NbgvFormat.json).DisableLogOutput()).Result;
        }
    }
}
