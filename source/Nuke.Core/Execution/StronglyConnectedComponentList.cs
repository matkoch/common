using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Core.Execution
{
    internal class StronglyConnectedComponentList : IEnumerable<StronglyConnectedComponent>
    {
        private readonly LinkedList<StronglyConnectedComponent> _collection;

        public StronglyConnectedComponentList ()
        {
            _collection = new LinkedList<StronglyConnectedComponent> ();
        }

        public void Add (StronglyConnectedComponent scc)
        {
            _collection.AddLast (scc);
        }

        public int Count => _collection.Count;

        public IEnumerator<StronglyConnectedComponent> GetEnumerator ()
        {
            return _collection.GetEnumerator ();
        }

        IEnumerator IEnumerable.GetEnumerator ()
        {
            return _collection.GetEnumerator ();
        }

        public IEnumerable<StronglyConnectedComponent> IndependentComponents ()
        {
            return this.Where (c => !c.IsCycle);
        }

        public IEnumerable<StronglyConnectedComponent> Cycles ()
        {
            return this.Where (c => c.IsCycle);
        }
    }
}