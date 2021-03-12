﻿#if NETFRAMEWORK
using System;
using System.Collections.Generic;
using System.Linq;
using FastMember;

namespace Cosmos.Reflection.Core.TypeHelpers
{
    internal static class TypeAccessorCache
    {
        private static Dictionary<(Type, bool), TypeAccessor> _typeAccessorDict;
        private static Dictionary<(Type, bool), int> _indexOfCache;
        private static int _currentCount;
        private static object _cacheLockObj = new();

        private const int MAX_TYPE_ACCESSOR_CACHE = 1000;

        static TypeAccessorCache()
        {
            _typeAccessorDict = new Dictionary<(Type, bool), TypeAccessor>();
            _indexOfCache = new Dictionary<(Type, bool), int>();
        }

        public static TypeAccessor Touch(Type type, bool allowNonPublishAccessors = false)
        {
            lock (_cacheLockObj)
            {
                if (_currentCount >= MAX_TYPE_ACCESSOR_CACHE)
                    Clear(100);
                return Get(type, allowNonPublishAccessors);
            }
        }

        private static void Clear(int clearNum)
        {
            var top100 = _indexOfCache.Where(pair => pair.Value < clearNum);

            foreach (var pair in top100)
            {
                _indexOfCache.Remove(pair.Key);
                _typeAccessorDict.Remove(pair.Key);
            }

            foreach (var pair in _indexOfCache)
            {
                _indexOfCache[pair.Key] -= clearNum;
            }

            _currentCount -= clearNum;
        }

        private static TypeAccessor Get(Type type, bool allowNonPublishAccessors)
        {
            var key = (type, allowNonPublishAccessors);
            if (_typeAccessorDict.TryGetValue(key, out var accessor))
                return accessor;

            accessor = TypeAccessor.Create(type, allowNonPublishAccessors);
            _currentCount += 1;
            _indexOfCache[key] = _currentCount;
            _typeAccessorDict[key] = accessor;

            return accessor;
        }
    }
}

#endif