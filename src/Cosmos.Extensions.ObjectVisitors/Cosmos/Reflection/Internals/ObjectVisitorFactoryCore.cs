﻿using System;
using System.Collections.Generic;
using Cosmos.Reflection.Core;
using Cosmos.Reflection.Internals.Visitors;
using Cosmos.Reflection.Metadata;

namespace Cosmos.Reflection.Internals
{
    internal static partial class ObjectVisitorFactoryCore
    {
        public static InstanceVisitor CreateForInstance(Type type, object instance, AlgorithmKind kind, bool repeatable, bool liteMode, bool strictMode)
        {
            var handler = SafeObjectHandleSwitcher.Switch(kind)(type);
            return new InstanceVisitor(handler, type, instance, kind, repeatable, liteMode, strictMode);
        }

        public static InstanceVisitor<T> CreateForInstance<T>(T instance, AlgorithmKind kind, bool repeatable, bool liteMode, bool strictMode)
        {
            var handler = UnsafeObjectHandleSwitcher.Switch<T>(kind)().With<T>();
            return new InstanceVisitor<T>(handler, instance, kind, repeatable, liteMode, strictMode);
        }

        public static FutureInstanceVisitor CreateForFutureInstance(Type type, AlgorithmKind kind, bool repeatable, bool liteMode, bool strictMode, IDictionary<string, object> initialValues = null)
        {
            var handler = SafeObjectHandleSwitcher.Switch(kind)(type);
            return new FutureInstanceVisitor(handler, type, kind, repeatable, initialValues, liteMode, strictMode);
        }

        public static FutureInstanceVisitor<T> CreateForFutureInstance<T>(AlgorithmKind kind, bool repeatable, bool liteMode, bool strictMode, IDictionary<string, object> initialValues = null)
        {
            var handler = UnsafeObjectHandleSwitcher.Switch<T>(kind)().With<T>();
            return new FutureInstanceVisitor<T>(handler, kind, repeatable, initialValues, liteMode, strictMode);
        }

        public static StaticTypeObjectVisitor CreateForStaticType(Type type, AlgorithmKind kind, bool liteMode, bool strictMode)
        {
            var handler = SafeObjectHandleSwitcher.Switch(kind)(type);
            return new StaticTypeObjectVisitor(handler, type, kind, liteMode, strictMode);
        }

        public static StaticTypeObjectVisitor<T> CreateForStaticType<T>(AlgorithmKind kind, bool liteMode, bool strictMode)
        {
            var handler = UnsafeObjectHandleSwitcher.Switch<T>(kind)().With<T>();
            return new StaticTypeObjectVisitor<T>(handler, kind, liteMode, strictMode);
        }
    }
}