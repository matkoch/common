// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using FluentAssertions;
using Xunit;

// ReSharper disable ArgumentsStyleLiteral

namespace Nuke.Common.Tests
{
    public class ControlFlowTest
    {
        [Fact]
        public void ExecuteWithRetrySucceedsAfterMultipleExceptions()
        {
            var executions = 0;

            void OnSecondExecution()
            {
                executions++;
                if (executions != 2)
                    throw new Exception(executions.ToString());
            }

            ControlFlow.ExecuteWithRetry(OnSecondExecution);
            executions.Should().Be(2);
        }

		[Fact]
        public void ExecuteWithRetryEventuallyThrowsControlFlowException()
        {
            void RepeatedFailure()
            {
				throw new Exception();
            }

            Assert.Throws<ControlFlowException>(() => {
				ControlFlow.ExecuteWithRetry(RepeatedFailure);
			});
        }
    }
}
