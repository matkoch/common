using Nuke.Common.Execution;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;

namespace Nuke.Common.Tests.Execution {
    public class HelpTextServiceTest {

        private class DummyBuild : NukeBuild {

            public DummyBuild() {
                ExecutableTargets = new[] { new ExecutableTarget { Name = "Dummy" } };
            }
        }

        private class StringParamWithDescriptionBuild : DummyBuild {
            [Parameter("TestDescription")]
            private readonly string TestParam;
        }

        private class StringParamWithDefaultValueBuild : DummyBuild {
            [Parameter()]
            private readonly string StringParam = "TEST";
        }

        private class EnumParamWithDefaultValueBuild : DummyBuild {
            public enum TestEnum { Yes, No, Maybe }
            [Parameter()]
            private readonly TestEnum EnumParam = TestEnum.Maybe;
        }


        public static IEnumerable<object[]> Data =>
                new List<object[]>
                    {
                        new object[] { new StringParamWithDescriptionBuild(),  "  --test-param         TestDescription." },
                        new object[] { new StringParamWithDefaultValueBuild(), "  --string-param       The Default Value is \"TEST\"." },
                        new object[] { new EnumParamWithDefaultValueBuild(),   "  --enum-param         The available Values are \"Yes\", \"No\", \"Maybe\". The Default Value is \"Maybe\"." },
                    };

        [Theory]
        [MemberData(nameof(Data))]
        public void ParameterHelpText(NukeBuild build, string expectedHelpText) {

            HelpTextService.GetParametersText(build).
                Split(Environment.NewLine).
                Should().Contain(expectedHelpText);
        }

    }
}
