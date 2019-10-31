// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.Utilities.Collections
{
    public static partial class DictionaryExtensions
    {
        public static IDictionary<TKey, TValue> AddKeyValue<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key,
            [CanBeNull] TValue value = default)
        {
            dictionary.Add(key, value);
            return dictionary;
        }

        public static IDictionary<TKey, TValue> AddKeyValueWhenNotNull<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            [CanBeNull] TKey key,
            [CanBeNull] TValue value = default)
            where TKey : class
        {
            return key != null
                ? dictionary.AddKeyValue(key, value)
                : dictionary;
        }

        public static Dictionary<TKey, TValue> AddDictionary<TKey, TValue>(
            this Dictionary<TKey, TValue> dictionary,
            IReadOnlyDictionary<TKey, TValue> otherDictionary)
        {
            foreach (var (key, value) in otherDictionary)
                dictionary.AddKeyValue(key, value);
            return dictionary;
        }
    }
}
