// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using JetBrains.Annotations;
using Nuke.Core.Tooling;
using Xunit;

namespace Nuke.Common.Tests
{
    public abstract class SettingsTestBase<T>
        where T : ToolSettings
    {
        protected T Modify ([InstantHandle] Expression<Func<T>> modification, bool forOutput = false)
        {
            var text = modification.Body.ToString();
            text = text.Substring(text.IndexOf(value: ')') + 2);
            var settings = modification.Compile().Invoke();
            var arguments = forOutput
                ? settings.GetArguments().RenderForOutput()
                : settings.GetArguments().RenderForExecution();

            File.AppendAllLines(
                @"C:\OSS\Nuke\log.txt",
                new[] { text, arguments, string.Empty },
                Encoding.UTF8);

            return settings;
        }

        protected void Throws (Expression<Func<T>> modification)
        {
            var text = modification.Body.ToString();
            text = text.Substring(text.IndexOf(value: ')') + 2);
            var exception = Assert.Throws<Exception>(() => modification.Compile().Invoke().GetArguments());

            File.AppendAllLines(
                @"C:\OSS\Nuke\log.txt",
                new[] { text, exception.Message, Environment.NewLine },
                Encoding.UTF8);
        }
    }
}
