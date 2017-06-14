// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Core.Utilities;

namespace Nuke.Core.Execution
{
    public class TargetDefinition : ITargetDefinition
    {
        public static TargetDefinition Create(string name, Target factory = null)
        {
            return new TargetDefinition(name, factory);
        }

        private TargetDefinition (string name, Target factory = null)
        {
            Name = name;
            Factory = factory;
            DependentTargets = new List<Target>();
            DependentShadowTargets = new List<string>();
            Actions = new List<Action>();
            Conditions = new List<Func<bool>>();
            Dependencies = new List<TargetDefinition>();

            factory?.Invoke(this);
        }

        public string Name { get; }
        [CanBeNull]
        public Target Factory { get; }
        public TimeSpan Duration { get; set; }
        public ExecutionStatus Status { get; set; }
        public List<Func<bool>> Conditions { get; }
        public List<Target> DependentTargets { get; }
        public List<string> DependentShadowTargets { get; }
        public List<Action> Actions { get; }

        internal int Index { get; set; }
        internal int LowLink { get; set; }
        internal List<TargetDefinition> Dependencies { get; set; }

        public ITargetDefinition Executes (params Action[] actions)
        {
            Actions.AddRange(actions);
            return this;
        }

        public ITargetDefinition Executes<T> (Func<T> action)
        {
            return Executes(new Action(() => action()));
        }

        public ITargetDefinition DependsOn (params Target[] targets)
        {
            DependentTargets.AddRange(targets);
            return this;
        }

        public ITargetDefinition DependsOn (params string[] shadowTargets)
        {
            DependentShadowTargets.AddRange(shadowTargets);
            return this;
        }

        public ITargetDefinition OnlyWhen (params Func<bool>[] conditions)
        {
            Conditions.AddRange(conditions);
            return this;
        }

        public override string ToString ()
        {
            return $"Target: {Name} -> {Dependencies.Select(x => x.Name).Join(", ")}";
        }
    }
}
