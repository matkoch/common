using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Core.Execution
{
    internal class StronglyConnectedComponent : IEnumerable<TargetDefinition>
    {
        private readonly LinkedList<TargetDefinition> _list;

        public StronglyConnectedComponent ()
        {
            _list = new LinkedList<TargetDefinition> ();
        }

        public void Add (TargetDefinition target)
        {
            _list.AddLast (target);
        }

        public int Count => _list.Count;

        public bool IsCycle => _list.Count > 1;

        public IEnumerator<TargetDefinition> GetEnumerator ()
        {
            return _list.GetEnumerator ();
        }

        IEnumerator IEnumerable.GetEnumerator ()
        {
            return _list.GetEnumerator ();
        }
    }
}