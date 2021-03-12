﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Cosmos.Reflection.Internals.Members;
using Cosmos.Validation;
using Cosmos.Validation.Registrars;
using Cosmos.Validation.Registrars.Interfaces;
using Cosmos.Validation.Strategies;

namespace Cosmos.Reflection.Correctness
{
    internal class RegisterRuleChain
    {
        private Func<IValidationRegistrar, IValidationRegistrar> RegisterHandler { get; set; }

        private void UpdateRegisterHandler(Func<IValidationRegistrar, IValidationRegistrar> func)
        {
            if (func is not null)
            {
                if (RegisterHandler is null)
                    RegisterHandler = func;
                else
                    RegisterHandler += func;
            }
        }

        public void RegisterStrategy<TStrategy>(StrategyMode mode = StrategyMode.OverallOverwrite) where TStrategy : class, IValidationStrategy, new()
        {
            UpdateRegisterHandler(registrar => registrar.ForStrategy<TStrategy>(mode).TakeEffectAndBack());
        }

        public void RegisterStrategy<TStrategy>(TStrategy strategy, StrategyMode mode = StrategyMode.OverallOverwrite) where TStrategy : class, IValidationStrategy, new()
        {
            UpdateRegisterHandler(registrar => registrar.ForStrategy(strategy, mode).TakeEffectAndBack());
        }

        public void RegisterStrategy<TStrategy, T>(StrategyMode mode = StrategyMode.OverallOverwrite) where TStrategy : class, IValidationStrategy<T>, new()
        {
            UpdateRegisterHandler(registrar => registrar.ForStrategy<TStrategy, T>(mode).TakeEffectAndBack());
        }

        public void RegisterStrategy<TStrategy, T>(TStrategy strategy, StrategyMode mode = StrategyMode.OverallOverwrite) where TStrategy : class, IValidationStrategy<T>, new()
        {
            UpdateRegisterHandler(registrar => registrar.ForStrategy(strategy, mode).TakeEffectAndBack());
        }

        public void RegisterMember(Type declaringType, string memberName, Func<IValueRuleBuilder, IValueRuleBuilder> func)
        {
            if (declaringType is not null && func is not null)
            {
                UpdateRegisterHandler(registrar => registrar.ForType(declaringType).ForMember(memberName).WithConfig(func).TakeEffectAndBack());
            }
        }

        public void RegisterMember(Type declaringType, PropertyInfo propertyInfo, Func<IValueRuleBuilder, IValueRuleBuilder> func)
        {
            if (declaringType is not null && propertyInfo is not null && func is not null)
            {
                UpdateRegisterHandler(registrar => registrar.ForType(declaringType).ForMember(propertyInfo).WithConfig(func).TakeEffectAndBack());
            }
        }

        public void RegisterMember(Type declaringType, FieldInfo fieldInfo, Func<IValueRuleBuilder, IValueRuleBuilder> func)
        {
            if (declaringType is not null && fieldInfo is not null && func is not null)
            {
                UpdateRegisterHandler(registrar => registrar.ForType(declaringType).ForMember(fieldInfo).WithConfig(func).TakeEffectAndBack());
            }
        }

        public void RegisterMember<T>(string memberName, Func<IValueRuleBuilder<T>, IValueRuleBuilder<T>> func)
        {
            if (func is not null)
            {
                UpdateRegisterHandler(registrar => registrar.ForType<T>().ForMember(memberName).WithConfig(func).TakeEffectAndBack());
            }
        }

        public void RegisterMember<T>(PropertyInfo propertyInfo, Func<IValueRuleBuilder<T>, IValueRuleBuilder<T>> func)
        {
            if (propertyInfo is not null && func is not null)
            {
                UpdateRegisterHandler(registrar => registrar.ForType<T>().ForMember(propertyInfo).WithConfig(func).TakeEffectAndBack());
            }
        }

        public void RegisterMember<T>(FieldInfo fieldInfo, Func<IValueRuleBuilder<T>, IValueRuleBuilder<T>> func)
        {
            if (fieldInfo is not null && func is not null)
            {
                UpdateRegisterHandler(registrar => registrar.ForType<T>().ForMember(fieldInfo).WithConfig(func).TakeEffectAndBack());
            }
        }

        public void RegisterMember<T, TVal>(Expression<Func<T, TVal>> expression, Func<IValueRuleBuilder<T, TVal>, IValueRuleBuilder<T, TVal>> func)
        {
            if (expression is not null && func is not null)
            {
                UpdateRegisterHandler(registrar => registrar.ForType<T>().ForMember(expression).WithConfig(func).TakeEffectAndBack());
            }
        }

        public ValidationHandler Build(ValidationOptions options)
        {
            var registrar = ValidationRegistrar.Continue(CorrectnessVerifiableWall.GLOBAL_CORRECT_PROVIDER_KEY);

            return (RegisterHandler?.Invoke(registrar) ?? registrar).TempBuild(options);
        }

        public void Append(RegisterRuleChain chain)
        {
            if (chain is null) throw new ArgumentNullException(nameof(chain));
            if (chain.RegisterHandler is null) return;
            var func = chain.RegisterHandler;
            UpdateRegisterHandler(func);
        }

        public void Override(RegisterRuleChain chain)
        {
            if (chain is null) throw new ArgumentNullException(nameof(chain));
            if (chain.RegisterHandler is null) return;
            var func = chain.RegisterHandler;
            RegisterHandler = func;
        }
    }
}