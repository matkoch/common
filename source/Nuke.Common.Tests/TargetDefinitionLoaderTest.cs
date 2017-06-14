// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Nuke.Core;
using Nuke.Core.Execution;
using Xunit;

namespace Nuke.Common.Tests
{
    public class TargetDefinitionLoaderTest
    {
        private readonly Build1 _build;
        private readonly TargetDefinitionLoader _loader;

        public TargetDefinitionLoaderTest ()
        {
            _build = new Build1();
            _loader = new TargetDefinitionLoader();
        }

        private void Check (
            string[][][] expectation,
            IEnumerable<string> specifiedTargets = null,
            Target defaultTarget = null,
            bool executeDependencies = true)
        {
            var targetList = _loader.GetTargetList(_build,
                defaultTarget ?? _build.Compile,
                specifiedTargets ?? Enumerable.Empty<string>(),
                executeDependencies);

            var targetStrings = targetList.Select(x => x.Select(y => y.Select(z => z.Name).ToArray()).ToArray()).ToArray();
            targetStrings.ShouldAllBeEquivalentTo(expectation);
        }

        [Fact]
        public void Subset ()
        {
            Check(new[]
                  {
                      new[]
                      {
                          new[] { "InspectCode" },
                          new[] { "FxCop" }
                      },
                      new[]
                      {
                          new[] { "Analysis" }
                      }
                  },
                new[] { "Analysis", "FxCop", "InspectCode" },
                executeDependencies: false);
        }

        [Fact]
        public void FullSet ()
        {
            Check(new[]
                  {
                      new[] { new[] { "Clean" } },
                      new[] { new[] { "Compile" } },
                      new[]
                      {
                          new[] { "Push", "Pack" },
                          new[] { "Analysis", "FxCop", "InspectCode" },
                          new[] { "Test" }
                      },
                      new[] { new[] { "Full" } }
                  },
                new[] { "Full" });
        }

        [Fact]
        public void Subset02 ()
        {
            Check(new[]
                  {
                      new[] { new[] { "Clean" } },
                      new[] { new[] { "Compile" } },
                      new[]
                      {
                          new[] { "Push", "Pack" },
                          new[] { "FxCop" }
                      }
                  },
                new[] { "FxCop", "Push" });
        }

        private class Build1 : Build
        {
            public Target A => _ => _;
            public Target B => _ => _;
            public Target C => _ => _;

            public Target Clean => _ => _;
            public Target Compile => _ => _.DependsOn(Clean);

            public Target Test => _ => _.DependsOn(Compile);

            public Target InspectCode => _ => _.DependsOn(Compile);
            public Target FxCop => _ => _.DependsOn(Compile);
            public Target Analysis => _ => _.DependsOn(InspectCode, FxCop);

            public Target Pack => _ => _.DependsOn(Compile);
            public Target Push => _ => _.DependsOn(Pack);

            public Target Full => _ => _.DependsOn(Push, Analysis, Test);
        }
    }
}
