﻿using System;
using System.Collections.Generic;
using System.Reflection;
using Cosmos.Reflection.Internals;
using Cosmos.Validation;
using Cosmos.Validation.Strategies;

namespace Cosmos.Reflection.Correctness
{
    internal class CorrectnessContext : IValidationEntry
    {
        private readonly ICoreVisitor _visitor;

        public CorrectnessContext(ICoreVisitor visitor, bool strictMode)
        {
            _visitor = visitor ?? throw new ArgumentNullException(nameof(visitor));
            Options = CorrectnessOptions.Copy();
            StrictMode = strictMode;
            CorrectRuleChain = new();
        }

        public bool StrictMode { get; set; }

        public ValidationOptions Options { get; }

        #region CorrectRuleChain

        private RegisterRuleChain CorrectRuleChain { get; set; }

        internal RegisterRuleChain ExposeCorrectRuleChain() => CorrectRuleChain;

        #endregion

        #region Register

        public IValidationEntry SetStrategy<TStrategy>(StrategyMode mode = StrategyMode.OverallOverwrite) where TStrategy : class, IValidationStrategy, new()
        {
            CorrectRuleChain.RegisterStrategy<TStrategy>(mode);
            _needToBuild = true;
            return this;
        }

        public IValidationEntry SetStrategy<TStrategy>(TStrategy strategy, StrategyMode mode = StrategyMode.OverallOverwrite) where TStrategy : class, IValidationStrategy, new()
        {
            if (strategy is null) throw new ArgumentNullException(nameof(strategy));
            CorrectRuleChain.RegisterStrategy(strategy, mode);
            _needToBuild = true;
            return this;
        }

        public IValidationEntry ForMember(string name, Func<IValueRuleBuilder, IValueRuleBuilder> func)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            CorrectRuleChain.RegisterMember(_visitor.SourceType, name, func);
            _needToBuild = true;
            return this;
        }

        public IValidationEntry ForMember(PropertyInfo propertyInfo, Func<IValueRuleBuilder, IValueRuleBuilder> func)
        {
            if (propertyInfo is null)
                throw new ArgumentNullException(nameof(propertyInfo));
            CorrectRuleChain.RegisterMember(_visitor.SourceType, propertyInfo, func);
            _needToBuild = true;
            return this;
        }

        public IValidationEntry ForMember(FieldInfo fieldInfo, Func<IValueRuleBuilder, IValueRuleBuilder> func)
        {
            if (fieldInfo is null)
                throw new ArgumentNullException(nameof(fieldInfo));
            CorrectRuleChain.RegisterMember(_visitor.SourceType, fieldInfo, func);
            _needToBuild = true;
            return this;
        }

        #endregion

        #region Handler

        private bool _hasBeenBuilt;
        private bool _needToBuild;

        private ValidationHandler _handler;

        protected ValidationHandler ValidationHandler
        {
            get
            {
                if (_needToBuild || !_hasBeenBuilt)
                {
                    _handler = CorrectRuleChain.Build(Options);
                    _hasBeenBuilt = true;
                    _needToBuild = false;
                }

                return _handler;
            }
        }

        #endregion

        #region Verify

        public virtual VerifyResult Verify(bool withGlobalRules = false)
        {
            if (ValidationHandler is null)
                return VerifyResult.Success;
            return ValidationHandler.Verify(_visitor.SourceType, _visitor.Instance);
        }

        public virtual VerifyResult VerifyOne(string memberName, bool withGlobalRules = false)
        {
            if (ValidationHandler is null)
                return VerifyResult.Success;
            var value = _visitor.ExposeLazyMemberHandler().Value.GetValueObject(memberName);
            return ValidationHandler.VerifyOne(_visitor.SourceType, value, memberName);
        }

        public virtual VerifyResult VerifyOne(string memberName, object value, bool withGlobalRules = false)
        {
            if (ValidationHandler is null)
                return VerifyResult.Success;
            return ValidationHandler.VerifyOne(_visitor.SourceType, value, memberName);
        }

        public virtual VerifyResult VerifyMany(IDictionary<string, object> keyValueCollections, bool withGlobalRules = false)
        {
            if (ValidationHandler is null)
                return VerifyResult.Success;
            return ValidationHandler.VerifyMany(_visitor.SourceType, keyValueCollections);
        }

        #endregion
    }
}