﻿using System;
using Cosmos.Reflection;
using CosmosProwessUT.OvUT.Helpers;
using CosmosProwessUT.OvUT.Model;
using Xunit;

namespace CosmosProwessUT.OvUT
{
    [Trait("Validation.Basic", "Validation")]
    public class ValidationTests : Prepare
    {
        [Fact(DisplayName = "直接实例策略验证测试")]
        public void DirectInstanceWithStrategyValidTest()
        {
            var act = new NiceAct()
            {
                Name = "Hu", //2
                Age = 22,
                Country = Country.China,
                Birthday = DateTime.Today
            };

            var type = typeof(NiceAct);
            var v = ObjectVisitorFactory.Create(type, act);

            var context = v.VerifiableEntry;

            Assert.NotNull(context);

            context.SetStrategy<NormalNiceActValidationStrategy>();

            var r1 = v.Verify();
            Assert.False(r1.IsValid);
            Assert.Single(r1.Errors);
            Assert.Single(r1.Errors[0].Details);

            v["Name"] = "Hulu"; //4

            var r2 = v.Verify();
            Assert.True(r2.IsValid);

            v["Name"] = "HuluWayaJavaPojoNovaLomo"; //16，greater than 15

            var r3 = v.Verify();
            Assert.False(r3.IsValid);
            Assert.Single(r3.Errors);
            Assert.Single(r3.Errors[0].Details);

            v["Name"] = ""; //0

            var r4 = v.Verify();
            Assert.False(r4.IsValid);
            Assert.Single(r4.Errors);
            Assert.Equal(2, r4.Errors[0].Details.Count);

            v["Name"] = null; //nil

            var r5 = v.Verify();
            Assert.False(r5.IsValid);
            Assert.Single(r5.Errors);
            Assert.Equal(2, r5.Errors[0].Details.Count);
        }

        [Fact(DisplayName = "直接类型策略验证测试")]
        public void DirectFutureWithStrategyValidTest()
        {
            var type = typeof(NiceAct);
            var v = ObjectVisitorFactory.Create(type);

            var context = v.VerifiableEntry;

            Assert.NotNull(context);

            context.SetStrategy<NormalNiceActValidationStrategy>();

            var r1 = v.Verify();
            Assert.False(r1.IsValid);
            Assert.Single(r1.Errors);
            Assert.Equal(2,r1.Errors[0].Details.Count);

            v["Name"] = "Hulu"; //4

            var r2 = v.Verify();
            Assert.True(r2.IsValid);

            v["Name"] = "HuluWayaJavaPojoNovaLomo"; //16，greater than 15

            var r3 = v.Verify();
            Assert.False(r3.IsValid);
            Assert.Single(r3.Errors);
            Assert.Single(r3.Errors[0].Details);

            v["Name"] = ""; //0

            var r4 = v.Verify();
            Assert.False(r4.IsValid);
            Assert.Single(r4.Errors);
            Assert.Equal(2, r4.Errors[0].Details.Count);

            v["Name"] = null; //nil

            var r5 = v.Verify();
            Assert.False(r5.IsValid);
            Assert.Single(r5.Errors);
            Assert.Equal(2, r5.Errors[0].Details.Count);
        }

        [Fact(DisplayName = "泛型实例策略验证测试")]
        public void GenericInstanceWithStrategyValidTest()
        {
            var act = new NiceAct()
            {
                Name = "Hu",
                Age = 22,
                Country = Country.China,
                Birthday = DateTime.Today
            };

            var v = ObjectVisitorFactory.Create<NiceAct>(act);

            var context = v.VerifiableEntry;

            Assert.NotNull(context);

            context.SetStrategy<GenericNiceActValidationStrategy>();

            var r1 = v.Verify();
            Assert.False(r1.IsValid);
            Assert.Single(r1.Errors);
            Assert.Single(r1.Errors[0].Details);

            v["Name"] = "Hulu"; //4

            var r2 = v.Verify();
            Assert.True(r2.IsValid);

            v["Name"] = "HuluWayaJavaPojoNovaLomo"; //16，greater than 15

            var r3 = v.Verify();
            Assert.False(r3.IsValid);
            Assert.Single(r3.Errors);
            Assert.Single(r3.Errors[0].Details);

            v["Name"] = ""; //0

            var r4 = v.Verify();
            Assert.False(r4.IsValid);
            Assert.Single(r4.Errors);
            Assert.Equal(2, r4.Errors[0].Details.Count);

            v["Name"] = null; //nil

            var r5 = v.Verify();
            Assert.False(r5.IsValid);
            Assert.Single(r5.Errors);
            Assert.Equal(2, r5.Errors[0].Details.Count);
        }

        [Fact(DisplayName = "泛型类型策略验证测试")]
        public void GenericFutureWithStrategyValidTest()
        {
            var v = ObjectVisitorFactory.Create<NiceAct>();

            var context = v.VerifiableEntry;

            Assert.NotNull(context);

            context.SetStrategy<GenericNiceActValidationStrategy>();

            var r1 = v.Verify();
            Assert.False(r1.IsValid);
            Assert.Single(r1.Errors);
            Assert.Equal(2,r1.Errors[0].Details.Count);

            v["Name"] = "Hulu"; //4

            var r2 = v.Verify();
            Assert.True(r2.IsValid);

            v["Name"] = "HuluWayaJavaPojoNovaLomo"; //16，greater than 15

            var r3 = v.Verify();
            Assert.False(r3.IsValid);
            Assert.Single(r3.Errors);
            Assert.Single(r3.Errors[0].Details);

            v["Name"] = ""; //0

            var r4 = v.Verify();
            Assert.False(r4.IsValid);
            Assert.Single(r4.Errors);
            Assert.Equal(2, r4.Errors[0].Details.Count);

            v["Name"] = null; //nil

            var r5 = v.Verify();
            Assert.False(r5.IsValid);
            Assert.Single(r5.Errors);
            Assert.Equal(2, r5.Errors[0].Details.Count);
        }

        [Fact(DisplayName = "直接实例属性规则验证测试")]
        public void DirectInstanceWithValueApiValidTest()
        {
            var act = new NiceAct()
            {
                Name = "Hu",
                Age = 22,
                Country = Country.China,
                Birthday = DateTime.Today
            };

            var type = typeof(NiceAct);
            var v = ObjectVisitorFactory.Create(type, act);

            var context = v.VerifiableEntry;

            Assert.NotNull(context);

            context.ForMember("Name",
                c => c.NotEmpty().MinLength(4).MaxLength(15));

            var r1 = v.Verify();
            Assert.False(r1.IsValid);
            Assert.Single(r1.Errors);
            Assert.Single(r1.Errors[0].Details);

            v["Name"] = "Hulu"; //4

            var r2 = v.Verify();
            Assert.True(r2.IsValid);

            v["Name"] = "HuluWayaJavaPojoNovaLomo"; //16，greater than 15

            var r3 = v.Verify();
            Assert.False(r3.IsValid);
            Assert.Single(r3.Errors);
            Assert.Single(r3.Errors[0].Details);

            v["Name"] = ""; //0

            var r4 = v.Verify();
            Assert.False(r4.IsValid);
            Assert.Single(r4.Errors);
            Assert.Equal(2, r4.Errors[0].Details.Count);

            v["Name"] = null; //nil

            var r5 = v.Verify();
            Assert.False(r5.IsValid);
            Assert.Single(r5.Errors);
            Assert.Equal(2, r5.Errors[0].Details.Count);
        }

        [Fact(DisplayName = "直接类型属性规则验证测试")]
        public void DirectFutureWithValueApiValidTest()
        {
            var type = typeof(NiceAct);
            var v = ObjectVisitorFactory.Create(type);

            var context = v.VerifiableEntry;

            Assert.NotNull(context);

            context.ForMember("Name",
                c => c.NotEmpty().MinLength(4).MaxLength(15));

            var r1 = v.Verify();
            Assert.False(r1.IsValid);
            Assert.Single(r1.Errors);
            Assert.Equal(2,r1.Errors[0].Details.Count);

            v["Name"] = "Hulu"; //4

            var r2 = v.Verify();
            Assert.True(r2.IsValid);

            v["Name"] = "HuluWayaJavaPojoNovaLomo"; //16，greater than 15

            var r3 = v.Verify();
            Assert.False(r3.IsValid);
            Assert.Single(r3.Errors);
            Assert.Single(r3.Errors[0].Details);

            v["Name"] = ""; //0

            var r4 = v.Verify();
            Assert.False(r4.IsValid);
            Assert.Single(r4.Errors);
            Assert.Equal(2, r4.Errors[0].Details.Count);

            v["Name"] = null; //nil

            var r5 = v.Verify();
            Assert.False(r5.IsValid);
            Assert.Single(r5.Errors);
            Assert.Equal(2, r5.Errors[0].Details.Count);
        }

        [Fact(DisplayName = "泛型实例属性规则验证测试")]
        public void GenericInstanceWithValueApiValidTest()
        {
            var act = new NiceAct()
            {
                Name = "Hu",
                Age = 22,
                Country = Country.China,
                Birthday = DateTime.Today
            };

            var v = ObjectVisitorFactory.Create<NiceAct>(act);

            var context = v.VerifiableEntry;

            Assert.NotNull(context);

            context.ForMember(x => x.Name,
                c => c.NotEmpty().MinLength(4).MaxLength(15));

            var r1 = v.Verify();
            Assert.False(r1.IsValid);
            Assert.Single(r1.Errors);
            Assert.Single(r1.Errors[0].Details);

            v["Name"] = "Hulu"; //4

            var r2 = v.Verify();
            Assert.True(r2.IsValid);

            v["Name"] = "HuluWayaJavaPojoNovaLomo"; //16，greater than 15

            var r3 = v.Verify();
            Assert.False(r3.IsValid);
            Assert.Single(r3.Errors);
            Assert.Single(r3.Errors[0].Details);

            v["Name"] = ""; //0

            var r4 = v.Verify();
            Assert.False(r4.IsValid);
            Assert.Single(r4.Errors);
            Assert.Equal(2, r4.Errors[0].Details.Count);

            v["Name"] = null; //nil

            var r5 = v.Verify();
            Assert.False(r5.IsValid);
            Assert.Single(r5.Errors);
            Assert.Equal(2, r5.Errors[0].Details.Count);
        }

        [Fact(DisplayName = "泛型类型属性规则验证测试")]
        public void GenericFutureWithValueApiValidTest()
        {
            var v = ObjectVisitorFactory.Create<NiceAct>();

            var context = v.VerifiableEntry;

            Assert.NotNull(context);

            context.ForMember(x => x.Name,
                c => c.NotEmpty().MinLength(4).MaxLength(15));

            var r1 = v.Verify();
            Assert.False(r1.IsValid);
            Assert.Single(r1.Errors);
            Assert.Equal(2,r1.Errors[0].Details.Count);

            v["Name"] = "Hulu"; //4

            var r2 = v.Verify();
            Assert.True(r2.IsValid);

            v["Name"] = "HuluWayaJavaPojoNovaLomo"; //16，greater than 15

            var r3 = v.Verify();
            Assert.False(r3.IsValid);
            Assert.Single(r3.Errors);
            Assert.Single(r3.Errors[0].Details);

            v["Name"] = ""; //0

            var r4 = v.Verify();
            Assert.False(r4.IsValid);
            Assert.Single(r4.Errors);
            Assert.Equal(2, r4.Errors[0].Details.Count);

            v["Name"] = null; //nil

            var r5 = v.Verify();
            Assert.False(r5.IsValid);
            Assert.Single(r5.Errors);
            Assert.Equal(2, r5.Errors[0].Details.Count);
        }
    }
}