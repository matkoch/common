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
    public class ExecutableTarget : IExecutableTarget
    {
        internal ExecutableTarget()
        {
        }

        internal MemberInfo Member { get; set; }
        internal TargetDefinition Definition { get; set; }
        public string Name { get; internal set; }
        public string Description { get; internal set; }
        public bool Listed { get; internal set; }
        internal Target Factory { get; set; }
        internal ICollection<Expression<Func<bool>>> DynamicConditions { get; set; } = new List<Expression<Func<bool>>>();
        internal ICollection<Expression<Func<bool>>> StaticConditions { get; set; } = new List<Expression<Func<bool>>>();
        internal DependencyBehavior DependencyBehavior { get; set; }
        internal bool AssuredAfterFailure { get; set; }
        internal bool ProceedAfterFailure { get; set; }
        internal ICollection<LambdaExpression> Requirements { get; set; } = new List<LambdaExpression>();
        internal ICollection<Action> Actions { get; set; } = new List<Action>();
        internal ICollection<ExecutableTarget> ExecutionDependencies { get; } = new List<ExecutableTarget>();
        internal ICollection<ExecutableTarget> OrderDependencies { get; } = new List<ExecutableTarget>();
        internal ICollection<ExecutableTarget> TriggerDependencies { get; } = new List<ExecutableTarget>();
        internal ICollection<ExecutableTarget> Triggers { get; } = new List<ExecutableTarget>();

        internal IReadOnlyCollection<ExecutableTarget> AllDependencies
            => ExecutionDependencies.Concat(OrderDependencies).Concat(TriggerDependencies).ToList();

        public bool IsDefault { get; internal set; }
        public ExecutionStatus Status { get; internal set; }
        public TimeSpan Duration { get; internal set; }
        public bool Invoked { get; internal set; }
        public string SkipReason { get; internal set; }

        ITargetDefinition IExecutableTarget.Definition => Definition;

        string IExecutableTarget.Name => Name;

        string IExecutableTarget.Description => Description;

        bool IExecutableTarget.Listed => Listed;

        IEnumerable<Expression<Func<bool>>> IExecutableTarget.DynamicConditions => DynamicConditions;

        IEnumerable<Expression<Func<bool>>> IExecutableTarget.StaticConditions => StaticConditions;

        DependencyBehavior IExecutableTarget.DependencyBehavior => DependencyBehavior;

        bool IExecutableTarget.AssuredAfterFailure => AssuredAfterFailure;

        bool IExecutableTarget.ProceedAfterFailure => ProceedAfterFailure;

        IEnumerable<LambdaExpression> IExecutableTarget.Requirements => Requirements;

        IEnumerable<Action> IExecutableTarget.Actions => Actions;

        IEnumerable<IExecutableTarget> IExecutableTarget.ExecutionDependencies => ExecutionDependencies;

        IEnumerable<IExecutableTarget> IExecutableTarget.OrderDependencies => OrderDependencies;

        IEnumerable<IExecutableTarget> IExecutableTarget.TriggerDependencies => TriggerDependencies;

        IEnumerable<IExecutableTarget> IExecutableTarget.Triggers => Triggers;

        IEnumerable<IExecutableTarget> IExecutableTarget.AllDependencies => AllDependencies;
    }
}
