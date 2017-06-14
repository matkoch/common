// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Core.Execution
{
    internal class StronglyConnectedComponentFinder
    {
        private StronglyConnectedComponentList _stronglyConnectedComponents;
        private Stack<TargetDefinition> _stack;
        private int _index;

        /// <summary>
        /// Calculates the sets of strongly connected vertices.
        /// </summary>
        /// <param name="graph">Graph to detect cycles within.</param>
        /// <returns>Set of strongly connected components (sets of vertices)</returns>
        public StronglyConnectedComponentList DetectCycle (IEnumerable<TargetDefinition> graph)
        {
            _stronglyConnectedComponents = new StronglyConnectedComponentList ();
            _index = 0;
            _stack = new Stack<TargetDefinition> ();
            foreach (var v in graph)
            {
                if (v.Index < 0)
                    StrongConnect (v);
            }
            return _stronglyConnectedComponents;
        }

        private void StrongConnect (TargetDefinition v)
        {
            v.Index = _index;
            v.LowLink = _index;
            _index++;
            _stack.Push (v);

            foreach (var w1 in v.Dependencies)
            {
                if (w1.Index < 0)
                {
                    StrongConnect (w1);
                    v.LowLink = Math.Min (v.LowLink, w1.LowLink);
                }
                else if (_stack.Contains (w1))
                {
                    v.LowLink = Math.Min (v.LowLink, w1.Index);
                }
            }

            if (v.LowLink != v.Index)
                return;

            var scc = new StronglyConnectedComponent ();
            TargetDefinition w2;
            do
            {
                w2 = _stack.Pop ();
                scc.Add (w2);
            } while (v != w2);
            _stronglyConnectedComponents.Add (scc);
        }
    }
}
