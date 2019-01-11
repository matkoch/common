// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Nuke.Common.Execution
{
    [DebuggerDisplay("{" + nameof(ToDebugString) + "}")]
    public class ExecutableTarget
    {
        public ExecutableTarget(
            MemberInfo member,
            object referenceObject,
            object definitionObject,
            bool isDefault,
            string description,
            List<Func<bool>> conditions,
            IReadOnlyList<LambdaExpression> requirements,
            IReadOnlyList<Action> actions)
        {
            Member = member;
            ReferenceObject = referenceObject;
            DefinitionObject = definitionObject;
            IsDefault = isDefault;
            Description = description;
            Conditions = conditions;
            Requirements = requirements;
            Actions = actions;
        }

        public MemberInfo Member { get; }
        public string Name => Member.Name;
        public object ReferenceObject { get; }
        public object DefinitionObject { get; }
        public string Description { get; }
        public List<Func<bool>> Conditions { get; }
        public IReadOnlyList<LambdaExpression> Requirements { get; }
        public IReadOnlyList<Action> Actions { get; }
        public ICollection<ExecutableTarget> ExecutionDependencies { get; } = new List<ExecutableTarget>();
        public ICollection<ExecutableTarget> OrderDependencies { get; } = new List<ExecutableTarget>();
        public ICollection<ExecutableTarget> TriggerDependencies { get; } = new List<ExecutableTarget>();
        public ICollection<ExecutableTarget> Triggers { get; } = new List<ExecutableTarget>();
        public IReadOnlyCollection<ExecutableTarget> AllDependencies
            => ExecutionDependencies.Concat(OrderDependencies).Concat(TriggerDependencies).ToList();
        public bool IsDefault { get; }

        public ExecutionStatus Status { get; set; }
        public TimeSpan Duration { get; set; }
        public bool Invoked { get; set; }

        internal string ToDebugString()
        {
            return Name;
        }
    }
}
