// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Nuke.Common.Execution;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Utilities
{
    public static class CompletionUtility
    {
        public static IEnumerable<string> GetRelevantCompletionItems(
            string words,
            IDictionary<string, string[]> completionItems,
            bool includeDescriptions = false)
        {
            completionItems = new Dictionary<string, string[]>(completionItems, StringComparer.OrdinalIgnoreCase);
            var suggestedItems = new List<string>();

            var parts = words.Split(separator: ' ');
            var currentWord = parts.Last() != string.Empty ? parts.Last() : null;
            var parameters = parts.Where(ParameterService.IsParameter).Select(ParameterService.GetParameterMemberName).ToList();
            var lastParameter = parameters.LastOrDefault();

            void AddParameters()
            {
                var useDashes = currentWord == null ||
                                currentWord.TrimStart('-').Length == 0 ||
                                currentWord.StartsWith("--");
                var items = completionItems.Keys
                    .Select(GetItemWithDescription)
                    .Where(x => !parameters.Contains(x.Item, StringComparer.InvariantCultureIgnoreCase))
                    .Select(x => (
                        Item: useDashes
                            ? $"--{ParameterService.GetParameterDashedName(x.Item)}"
                            : $"-{x.Item}",
                        x.Description));

                AddItems(items);
            }

            void AddTargetsOrValues(string parameter)
            {
                var passedItems = parts
                    .Reverse()
                    .TakeWhile(x => !ParameterService.IsParameter(x))
                    .Select(ParameterService.GetParameterMemberName);

                var items = completionItems
                                .SingleOrDefault(x => x.Key.EqualsOrdinalIgnoreCase(parameter) || x.Key.StartsWith($"{parameter}#"))
                                .Value?
                                .Select(GetItemWithDescription)
                                .Where(x => !passedItems.Contains(x.Item, StringComparer.InvariantCultureIgnoreCase)) ??
                            new List<(string Item, string Description)>();

                if (parameter.EqualsOrdinalIgnoreCase(Constants.InvokedTargetsParameterName))
                {
                    items = items.Select(x => (
                        Item: x.Item.SplitCamelHumpsWithSeparator("-", Constants.KnownWords),
                        x.Description));
                }

                AddItems(items);
            }

            void AddItems(IEnumerable<(string Item, string Description)> itemsWithDescriptions)
            {
                foreach (var (item, description) in itemsWithDescriptions)
                {
                    if (currentWord == null)
                        suggestedItems.Add(item);
                    else if (item.StartsWithOrdinalIgnoreCase(currentWord))
                    {
                        var normalizedItem = item.ReplaceRegex(currentWord, x => currentWord, RegexOptions.IgnoreCase);
                        if (normalizedItem != item)
                        {
                            var letters = currentWord.Where(char.IsLetter).ToList();
                            if (letters.All(char.IsUpper))
                                normalizedItem = normalizedItem.ToUpperInvariant();
                            else if (letters.All(char.IsLower))
                                normalizedItem = normalizedItem.ToLowerInvariant();
                        }

                        suggestedItems.Add(normalizedItem);
                    }

                    if (includeDescriptions)
                    {
                        var lastIndex = suggestedItems.Count - 1;
                        suggestedItems[lastIndex] = $"{suggestedItems[lastIndex]}#{description}";
                    }
                }
            }

            (string Item, string Description) GetItemWithDescription(string rawItem)
            {
                var values = rawItem.Split(new[] { '#' }, count: 2);
                return (values.First(), values.Skip(1).FirstOrDefault());
            }

            if (lastParameter == null)
                AddTargetsOrValues(Constants.InvokedTargetsParameterName);
            else if (currentWord != lastParameter)
                AddTargetsOrValues(lastParameter);

            if (currentWord == null || ParameterService.IsParameter(currentWord))
                AddParameters();

            return suggestedItems;
        }
    }
}
