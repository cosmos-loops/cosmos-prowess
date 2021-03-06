﻿using System.Dynamic;
using System.Linq.Expressions;
using System.Reflection;

namespace Cosmos.Text
{
    public readonly partial struct ConvertibleStringVal : IDynamicMetaObjectProvider
    {
        /// <inheritdoc />
        DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(Expression parameter)
            => new ValueStringMetaObject(parameter, this);

        private sealed class ValueStringMetaObject : DynamicMetaObject
        {
            // ReSharper disable once MemberHidesStaticFromOuterClass
            private static readonly CacheMan<MethodInfo> CachedMethods = new();

            public ValueStringMetaObject(Expression expression, ConvertibleStringVal value)
                : base(expression, BindingRestrictions.Empty, value) { }

            /// <inheritdoc />
            public override DynamicMetaObject BindConvert(ConvertBinder binder)
            {
                var restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);
                if (binder.Type == LimitType)
                    return binder.FallbackConvert(new DynamicMetaObject(Expression, restrictions, Value));

                var method = CachedMethods.GetOrAdd(binder.Type, t => GetAsMethod(t, false));
                var call = Expression.Call(Expression.Convert(Expression, LimitType), method);
                return new DynamicMetaObject(call, restrictions);
            }
        }
    }
}