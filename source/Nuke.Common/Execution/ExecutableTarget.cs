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
    [DebuggerDisplay("{" + nameof(Name) + "}")]
    public class ExecutableTarget
    {
        internal ExecutableTarget()
        {
        }

        public MemberInfo Member { get; internal set; }
        internal TargetDefinition Definition { get; set; }
        public string Name { get; internal set; }
        public string Description { get; internal set; }
        public bool Listed { get; internal set; }
        public Target Factory { get; internal set; }
        public ICollection<Expression<Func<bool>>> DynamicConditions { get; internal set; } = new List<Expression<Func<bool>>>();
        public ICollection<Expression<Func<bool>>> StaticConditions { get; internal set; } = new List<Expression<Func<bool>>>();
        public DependencyBehavior DependencyBehavior { get; internal set; }
        public bool AssuredAfterFailure { get; internal set; }
        public bool ProceedAfterFailure { get; internal set; }
        public ICollection<LambdaExpression> Requirements { get; internal set; } = new List<LambdaExpression>();
        public ICollection<Action> Actions { get; internal set; } = new List<Action>();
        public ICollection<ExecutableTarget> ExecutionDependencies { get; } = new List<ExecutableTarget>();
        public ICollection<ExecutableTarget> OrderDependencies { get; } = new List<ExecutableTarget>();
        public ICollection<ExecutableTarget> TriggerDependencies { get; } = new List<ExecutableTarget>();
        public ICollection<ExecutableTarget> Triggers { get; } = new List<ExecutableTarget>();

        public IReadOnlyCollection<ExecutableTarget> AllDependencies
            => ExecutionDependencies.Concat(OrderDependencies).Concat(TriggerDependencies).ToList();

        public bool IsDefault { get; internal set; }
        public ExecutionStatus Status { get; internal set; }
        public TimeSpan Duration { get; internal set; }
        public bool Invoked { get; internal set; }
        public string SkipReason { get; internal set; }
    }
}
