// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;

namespace Nuke.Common {
    public class ControlFlowException : Exception {
        public ControlFlowException()
        {
        }

        public ControlFlowException (string message)
            : base (message)
        {
        }

        public ControlFlowException (string message, Exception inner)
            : base (message, inner)
        {
        }
    }
}