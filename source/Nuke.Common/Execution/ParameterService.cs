// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.Execution.ReflectionService;

namespace Nuke.Common.Execution
{
    [PublicAPI]
    public class ParameterService
    {
        private static ParameterService s_instance;

        private readonly string[] _commandLineArguments;
        private readonly Func<IReadOnlyDictionary<string, string>> _environmentVariablesProvider;

        public ParameterService(
            [CanBeNull] string[] commandLineArguments = null,
            [CanBeNull] IReadOnlyDictionary<string, string> environmentVariables = null)
        {
            _environmentVariablesProvider = () => environmentVariables ?? EnvironmentInfo.Variables;
            _commandLineArguments = commandLineArguments ?? EnvironmentInfo.CommandLineArguments.Skip(count: 1).ToArray();
        }

        public static ParameterService Instance => s_instance ?? (s_instance = new ParameterService());

        public string GetParameterName<T>(Expression<Func<T>> expression)
        {
            var member = expression.GetMemberInfo();
            return GetParameterName(member);
        }

        public string GetParameterName(MemberInfo member)
        {
            var attribute = member.GetCustomAttribute<ParameterAttribute>();
            return attribute.Name ?? member.Name;
        }

        [CanBeNull]
        public string GetParameterDescription(MemberInfo member)
        {
            var attribute = member.GetCustomAttribute<ParameterAttribute>();
            return attribute.Description?.TrimEnd('.');
        }

        [CanBeNull]
        public IEnumerable<(string Text, object Object)> GetParameterValueSet(MemberInfo member, object instance)
        {
            var attribute = member.GetCustomAttribute<ParameterAttribute>();
            return attribute.GetValueSet(member, instance)?.OrderBy(x => x.Item1);
        }

        [CanBeNull]
        public T GetParameter<T>(Expression<Func<T>> expression)
        {
            return (T) GetParameter(expression.GetMemberInfo(), typeof(T));
        }

        [CanBeNull]
        public T GetParameter<T>(Expression<Func<object>> expression)
        {
            return (T) GetParameter(expression.GetMemberInfo(), typeof(T));
        }

        [CanBeNull]
        public T GetParameter<T>(MemberInfo member)
        {
            return (T) GetParameter(member, typeof(T));
        }

        [CanBeNull]
        internal object GetParameter(MemberInfo member, Type destinationType = null)
        {
            destinationType = destinationType ?? member.GetMemberType();
            var attribute = member.GetCustomAttribute<ParameterAttribute>();
            var separator = (attribute.Separator ?? string.Empty).SingleOrDefault();
            return GetParameter(attribute.Name ?? member.Name, destinationType, separator);
        }

        [CanBeNull]
        public T GetParameter<T>(string parameterName, char? separator = null)
        {
            return (T) GetParameter(parameterName, typeof(T), separator);
        }

        [CanBeNull]
        public T GetCommandLineArgument<T>(string parameterName, char? separator = null)
        {
            return (T) GetCommandLineArgument(parameterName, typeof(T), separator);
        }

        [CanBeNull]
        public T GetCommandLineArgument<T>(int position, char? separator = null)
        {
            return (T) GetCommandLineArgument(position, typeof(T), separator);
        }

        [CanBeNull]
        public T[] GetPositionalCommandLineArguments<T>(char? separator = null)
        {
            return (T[]) GetPositionalCommandLineArguments(typeof(T[]), separator);
        }

        [CanBeNull]
        public T GetEnvironmentVariable<T>(string parameterName, char? separator = null)
        {
            return (T) GetEnvironmentVariable(parameterName, typeof(T), separator);
        }

        [CanBeNull]
        public object GetParameter(string parameterName, Type destinationType, char? separator = null, bool checkNames = false)
        {
            return HasCommandLineArgument(parameterName, checkNames)
                ? GetCommandLineArgument(parameterName, destinationType, separator)
                : GetEnvironmentVariable(parameterName, destinationType, separator);
        }

        [CanBeNull]
        public object GetCommandLineArgument(string argumentName, Type destinationType, char? separator = null, bool checkNames = false)
        {
            var index = GetCommandLineArgumentIndex(argumentName, checkNames);
            if (index == -1)
                return GetDefaultValue(destinationType);

            var values = _commandLineArguments.Skip(index + 1).TakeWhile(x => !x.StartsWith("-")).ToArray();
            return ConvertCommandLineArguments(argumentName, values, destinationType, _commandLineArguments, separator);
        }

        [CanBeNull]
        public object GetCommandLineArgument(int position, Type destinationType, char? separator = null)
        {
            var positionalParametersCount = _commandLineArguments.TakeWhile(x => !x.StartsWith("-")).Count();
            if (position < 0)
                position = positionalParametersCount + position % positionalParametersCount;

            if (positionalParametersCount <= position)
                return null;

            return ConvertCommandLineArguments(
                $"$positional[{position}]",
                new[] { _commandLineArguments[position] },
                destinationType,
                _commandLineArguments,
                separator);
        }

        [CanBeNull]
        public object GetPositionalCommandLineArguments(Type destinationType, char? separator = null)
        {
            var positionalArguments = _commandLineArguments.TakeWhile(x => !x.StartsWith("-")).ToArray();
            if (positionalArguments.Length == 0)
                return GetDefaultValue(destinationType);

            return ConvertCommandLineArguments(
                "$all-positional",
                positionalArguments,
                destinationType,
                _commandLineArguments,
                separator);
        }

        [CanBeNull]
        public object ConvertCommandLineArguments(
            string argumentName,
            string[] values,
            Type destinationType,
            string[] commandLineArguments,
            char? separator = null)
        {
            ControlFlow.Assert(values.Length == 1 || !separator.HasValue || values.All(x => !x.Contains(separator.Value)),
                $"Command-line argument '{argumentName}' with value [ {values.JoinComma()} ] cannot be split with separator '{separator}'.");
            values = separator.HasValue && values.Any(x => x.Contains(separator.Value))
                ? values.SingleOrDefault()?.Split(separator.Value) ?? new string[0]
                : values;

            try
            {
                return ConvertValues(argumentName, values, destinationType);
            }
            catch (Exception ex)
            {
                ControlFlow.Fail(
                    new[] { ex.Message, "Command-line arguments were:" }
                        .Concat(commandLineArguments.Select((x, i) => $"  [{i}] = {x}"))
                        .JoinNewLine());
                // ReSharper disable once HeuristicUnreachableCode
                return null;
            }
        }

        private bool HasCommandLineArgument(string argumentName, bool checkNames)
        {
            return GetCommandLineArgumentIndex(argumentName, checkNames) != -1;
        }

        private int GetCommandLineArgumentIndex(string argumentName, bool checkNames)
        {
            var index = Array.FindLastIndex(_commandLineArguments,
                x => x.StartsWith("-") && x.Replace("-", string.Empty).EqualsOrdinalIgnoreCase(argumentName.Replace("-", string.Empty)));

            if (index == -1 && checkNames)
            {
                var candidates = _commandLineArguments.Where(x => x.StartsWith("-")).Select(x => x.Replace("-", string.Empty));
                CheckNames(argumentName, candidates);
            }

            return index;
        }

        [CanBeNull]
        public object GetEnvironmentVariable(string variableName, Type destinationType, char? separator = null)
        {
            var variables = _environmentVariablesProvider.Invoke();

            if (!variables.TryGetValue(variableName, out var value))
                return GetDefaultValue(destinationType);

            try
            {
                return ConvertValues(variableName, separator.HasValue ? value.Split(separator.Value) : new[] { value }, destinationType);
            }
            catch (Exception ex)
            {
                ControlFlow.Fail(new[] { ex.Message, "Environment variable was:", value }.JoinNewLine());
                // ReSharper disable once HeuristicUnreachableCode
                return null;
            }
        }

        [CanBeNull]
        private object GetDefaultValue(Type type)
        {
            return type.IsNullableType() ? null : Activator.CreateInstance(type);
        }

        [CanBeNull]
        private object ConvertValues(string parameterName, IReadOnlyCollection<string> values, Type destinationType)
        {
            try
            {
                return ConvertValues(values, destinationType);
            }
            catch (Exception ex)
            {
                ControlFlow.Fail(new[] { $"Resolving parameter '{parameterName}' failed.", ex.Message }.JoinNewLine());
                // ReSharper disable once HeuristicUnreachableCode
                return null;
            }
        }

        [CanBeNull]
        private object ConvertValues(IReadOnlyCollection<string> values, Type destinationType)
        {
            ControlFlow.Assert(!destinationType.IsArray || destinationType.GetArrayRank() == 1, "Arrays must have a rank of 1.");
            var elementType = (destinationType.IsArray ? destinationType.GetElementType() : destinationType).NotNull();
            ControlFlow.Assert(values.Count < 2 || elementType != null, "values.Count < 2 || elementType != null");

            if (values.Count == 0)
            {
                if (destinationType.IsArray)
                    return Array.CreateInstance(elementType, length: 0);

                if (destinationType == typeof(bool) || destinationType == typeof(bool?))
                    return true;

                return null;
            }

            var convertedValues = values.Select(x => Convert(x, elementType)).ToList();
            if (!destinationType.IsArray)
            {
                ControlFlow.Assert(convertedValues.Count == 1,
                    $"Value [ {values.JoinComma()} ] cannot be assigned to '{GetPresentableName(destinationType)}'.");
                return convertedValues.Single();
            }

            var array = Array.CreateInstance(elementType, convertedValues.Count);
            convertedValues.ForEach((x, i) => array.SetValue(x, i));
            ControlFlow.Assert(destinationType.IsInstanceOfType(array),
                $"Type '{GetPresentableName(array.GetType())}' is not an instance of '{GetPresentableName(destinationType)}'.");

            return array;
        }

        private void CheckNames(string name, IEnumerable<string> candidates)
        {
            const double similarityThreshold = 0.5;

            name = name.ToLower();
            foreach (var candidate in candidates.Select(x => x.ToLower()))
            {
                var levenshteinDistance = (float) GetLevenshteinDistance(name, candidate);
                if (levenshteinDistance / name.Length < similarityThreshold)
                {
                    Logger.Warn($"Requested parameter '{name}' was not found. Is there a typo with '{candidate}' which was passed?");
                    return;
                }
            }
        }

        private int GetLevenshteinDistance(string a, string b)
        {
            if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b))
                return 0;

            var lengthA = a.Length;
            var lengthB = b.Length;
            var distances = new int[lengthA + 1, lengthB + 1];

            for (var i = 0; i <= lengthA; distances[i, 0] = i++)
            {
            }

            for (var j = 0; j <= lengthB; distances[0, j] = j++)
            {
            }

            for (var i = 1; i <= lengthA; i++)
            for (var j = 1; j <= lengthB; j++)
            {
                var cost = b[j - 1] == a[i - 1] ? 0 : 1;
                distances[i, j] = Math.Min(
                    Math.Min(distances[i - 1, j] + 1, distances[i, j - 1] + 1),
                    distances[i - 1, j - 1] + cost
                );
            }

            return distances[lengthA, lengthB];
        }
    }
}
