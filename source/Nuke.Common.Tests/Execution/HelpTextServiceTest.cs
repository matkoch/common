using Nuke.Common.Execution;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using System.Linq;

namespace Nuke.Common.Tests.Execution {
    public class HelpTextServiceTest {

        private class DummyBuild : NukeBuild {

            public DummyBuild() {
                ExecutableTargets = new[] { new ExecutableTarget { Name = "Dummy" } };
            }
        }

        private void ParameterHelpText(NukeBuild build, string expectedParamName, string expectedHelpText) {

            var helpTextLine = HelpTextService.GetParametersText(build).Split(Environment.NewLine + "  --").FirstOrDefault(q => q.StartsWith(expectedParamName));
            if (!string.IsNullOrEmpty(helpTextLine) && helpTextLine.Contains(" ")) {
                helpTextLine = helpTextLine.Split(" ", 2)[1];
                helpTextLine = string.Join(" ", helpTextLine.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(q => q.Trim()));
            }
            helpTextLine.Should().EndWith(expectedHelpText);
        }


        private class StringParamWithDescriptionBuild : DummyBuild {
            [Parameter("TestDescription")]
            private readonly string TestParam;
        }

        [Fact]
        public void StringParamWithDescription() {
            ParameterHelpText(new StringParamWithDescriptionBuild(), "test-param", "TestDescription.");
        }

        private class StringParamWithDefaultValueBuild : DummyBuild {
            [Parameter()]
            private readonly string StringParam = "TEST";
        }

        [Fact]
        public void StringParamWithDefaultValue() {
            ParameterHelpText(new StringParamWithDefaultValueBuild(), "string-param", "The Default Value is \"TEST\".");
        }

        private class EnumParamWithDefaultValueBuild : DummyBuild {
            public enum TestEnum { Yes, No, Maybe }
            [Parameter()]
            private readonly TestEnum EnumParam = TestEnum.Maybe;
        }

        [Fact]
        public void EnumParamWithDefaultValue() {
            ParameterHelpText(new EnumParamWithDefaultValueBuild(), "enum-param", "The available Values are \"Yes\", \"No\", \"Maybe\". The Default Value is \"Maybe\".");
        }

    }
}
