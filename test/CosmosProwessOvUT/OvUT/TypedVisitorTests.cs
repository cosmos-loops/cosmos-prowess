﻿using System;
using Cosmos.Reflection;
using Cosmos.Reflection.Metadata;
using CosmosProwessUT.OvUT.Helpers;
using CosmosProwessUT.OvUT.Model;
using Xunit;

namespace CosmosProwessUT.OvUT
{
    [Trait("TypedVisitor", "ObjectVisitor")]
    public class TypedVisitorTests : Prepare
    {
        [Fact(DisplayName = "实例扩展方法测试")]
        public void DirectInstanceExtensionsTest()
        {
            var act = new NiceAct()
            {
                Name = "Hu",
                Age = 22,
                Country = Country.China,
                Birthday = DateTime.Today
            };

            var v = act.ToVisitor();

            Assert.False(v.IsStatic);
            Assert.Equal(typeof(NiceAct), v.SourceType);
            Assert.Equal(AlgorithmKind.Precision, v.AlgorithmKind);

            Assert.Equal("Hu", v.GetValue<string>("Name"));
            Assert.Equal(22, v.GetValue<int>("Age"));
            Assert.Equal(Country.China, v.GetValue<Country>("Country"));
            Assert.Equal(DateTime.Today, v.GetValue<DateTime>("Birthday"));
            Assert.False(v.GetValue<bool>("IsValid"));

            v.SetValue("Name", "Du");
            v.SetValue("Age", 55);
            v.SetValue("Country", Country.USA);
            v.SetValue("Birthday", DateTime.Today.AddDays(-1));
            v.SetValue("IsValid", true);

            Assert.Equal("Du", v.GetValue<string>("Name"));
            Assert.Equal(55, v.GetValue<int>("Age"));
            Assert.Equal(Country.USA, v.GetValue<Country>("Country"));
            Assert.Equal(DateTime.Today.AddDays(-1), v.GetValue<DateTime>("Birthday"));
            Assert.True(v.GetValue<bool>("IsValid"));

            v["Name"] = "Au";
            v["Age"] = 77;
            v["Country"] = Country.China;
            v["Birthday"] = DateTime.Today.AddDays(1);
            v["IsValid"] = false;

            Assert.Equal("Au", v.GetValue<string>("Name"));
            Assert.Equal(77, v.GetValue<int>("Age"));
            Assert.Equal(Country.China, v.GetValue<Country>("Country"));
            Assert.Equal(DateTime.Today.AddDays(1), v.GetValue<DateTime>("Birthday"));
            Assert.False(v.GetValue<bool>("IsValid"));

            v.SetValue<NiceAct>(x => x.Name, "Zu");
            v.SetValue<NiceAct>(x => x.Age, 99);
            v.SetValue<NiceAct>(x => x.Country, Country.USA);
            v.SetValue<NiceAct>(x => x.Birthday, DateTime.Today.AddDays(2));
            v.SetValue<NiceAct>(x => x.IsValid, true);

            Assert.Equal("Zu", v.GetValue<NiceAct>(x => x.Name));
            Assert.Equal(99, v.GetValue<NiceAct>(x => x.Age));
            Assert.Equal(Country.USA, v.GetValue<NiceAct>(x => x.Country));
            Assert.Equal(DateTime.Today.AddDays(2), v.GetValue<NiceAct>(x => x.Birthday));
            Assert.True((bool) v.GetValue<NiceAct>(x => x.IsValid));

            v.SetValue<NiceAct, string>(x => x.Name, "Xu");
            v.SetValue<NiceAct, int>(x => x.Age, 199);
            v.SetValue<NiceAct, Country>(x => x.Country, Country.China);
            v.SetValue<NiceAct, DateTime>(x => x.Birthday, DateTime.Today.AddDays(-2));
            v.SetValue<NiceAct, bool>(x => x.IsValid, false);

            Assert.Equal("Xu", v.GetValue(x => x.Name));
            Assert.Equal(199, v.GetValue(x => x.Age));
            Assert.Equal(Country.China, v.GetValue(x => x.Country));
            Assert.Equal(DateTime.Today.AddDays(-2), v.GetValue(x => x.Birthday));
            Assert.False(v.GetValue(x => x.IsValid));

            var d = v.ToDictionary();
            Assert.Equal("Xu", d["Name"]);
            Assert.Equal(199, d["Age"]);
            Assert.Equal(Country.China, d["Country"]);
            Assert.Equal(DateTime.Today.AddDays(-2), d["Birthday"]);
            Assert.False((bool) d["IsValid"]);

            d["Name"] = "Ax";
            d["Age"] = 10086;
            d["Country"] = Country.China;
            d["Birthday"] = DateTime.Today.AddDays(10);
            d["IsValid"] = true;
            
            v.SetValue(d);
            
            Assert.Equal("Ax", d["Name"]);
            Assert.Equal(10086, d["Age"]);
            Assert.Equal(Country.China, d["Country"]);
            Assert.Equal(DateTime.Today.AddDays(10), d["Birthday"]);
            Assert.True((bool) d["IsValid"]);
        }

        [Fact(DisplayName = "类型扩展方法测试")]
        public void DirectTypeExtensionsTest()
        {
            var type = typeof(NiceAct);
            var v = type.ToVisitor();

            Assert.False(v.IsStatic);
            Assert.Equal(typeof(NiceAct), v.SourceType);
            Assert.Equal(AlgorithmKind.Precision, v.AlgorithmKind);

            v.SetValue("Name", "Du");
            v.SetValue("Age", 55);
            v.SetValue("Country", Country.USA);
            v.SetValue("Birthday", DateTime.Today.AddDays(-1));
            v.SetValue("IsValid", true);

            Assert.Equal("Du", v.GetValue<string>("Name"));
            Assert.Equal(55, v.GetValue<int>("Age"));
            Assert.Equal(Country.USA, v.GetValue<Country>("Country"));
            Assert.Equal(DateTime.Today.AddDays(-1), v.GetValue<DateTime>("Birthday"));
            Assert.True(v.GetValue<bool>("IsValid"));

            v["Name"] = "Au";
            v["Age"] = 77;
            v["Country"] = Country.China;
            v["Birthday"] = DateTime.Today.AddDays(1);
            v["IsValid"] = false;

            Assert.Equal("Au", v.GetValue<string>("Name"));
            Assert.Equal(77, v.GetValue<int>("Age"));
            Assert.Equal(Country.China, v.GetValue<Country>("Country"));
            Assert.Equal(DateTime.Today.AddDays(1), v.GetValue<DateTime>("Birthday"));
            Assert.False(v.GetValue<bool>("IsValid"));

            v.SetValue<NiceAct>(x => x.Name, "Zu");
            v.SetValue<NiceAct>(x => x.Age, 99);
            v.SetValue<NiceAct>(x => x.Country, Country.USA);
            v.SetValue<NiceAct>(x => x.Birthday, DateTime.Today.AddDays(2));
            v.SetValue<NiceAct>(x => x.IsValid, true);

            Assert.Equal("Zu", v.GetValue<NiceAct>(x => x.Name));
            Assert.Equal(99, v.GetValue<NiceAct>(x => x.Age));
            Assert.Equal(Country.USA, v.GetValue<NiceAct>(x => x.Country));
            Assert.Equal(DateTime.Today.AddDays(2), v.GetValue<NiceAct>(x => x.Birthday));
            Assert.True((bool) v.GetValue<NiceAct>(x => x.IsValid));

            v.SetValue<NiceAct, string>(x => x.Name, "Xu");
            v.SetValue<NiceAct, int>(x => x.Age, 199);
            v.SetValue<NiceAct, Country>(x => x.Country, Country.China);
            v.SetValue<NiceAct, DateTime>(x => x.Birthday, DateTime.Today.AddDays(-2));
            v.SetValue<NiceAct, bool>(x => x.IsValid, false);

            Assert.Equal("Xu", v.GetValue<NiceAct, string>(x => x.Name));
            Assert.Equal(199, v.GetValue<NiceAct, int>(x => x.Age));
            Assert.Equal(Country.China, v.GetValue<NiceAct, Country>(x => x.Country));
            Assert.Equal(DateTime.Today.AddDays(-2), v.GetValue<NiceAct, DateTime>(x => x.Birthday));
            Assert.False(v.GetValue<NiceAct, bool>(x => x.IsValid));

            var d = v.ToDictionary();
            Assert.Equal("Xu", d["Name"]);
            Assert.Equal(199, d["Age"]);
            Assert.Equal(Country.China, d["Country"]);
            Assert.Equal(DateTime.Today.AddDays(-2), d["Birthday"]);
            Assert.False((bool) d["IsValid"]);

            d["Name"] = "Ax";
            d["Age"] = 10086;
            d["Country"] = Country.China;
            d["Birthday"] = DateTime.Today.AddDays(10);
            d["IsValid"] = true;
            
            v.SetValue(d);
            
            Assert.Equal("Ax", d["Name"]);
            Assert.Equal(10086, d["Age"]);
            Assert.Equal(Country.China, d["Country"]);
            Assert.Equal(DateTime.Today.AddDays(10), d["Birthday"]);
            Assert.True((bool) d["IsValid"]);
        }

        [Fact(DisplayName = "直接实例测试")]
        public void DirectInstanceTest()
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

            Assert.False(v.IsStatic);
            Assert.Equal(typeof(NiceAct), v.SourceType);
            Assert.Equal(AlgorithmKind.Precision, v.AlgorithmKind);

            Assert.Equal("Hu", v.GetValue<string>("Name"));
            Assert.Equal(22, v.GetValue<int>("Age"));
            Assert.Equal(Country.China, v.GetValue<Country>("Country"));
            Assert.Equal(DateTime.Today, v.GetValue<DateTime>("Birthday"));
            Assert.False(v.GetValue<bool>("IsValid"));

            v.SetValue("Name", "Du");
            v.SetValue("Age", 55);
            v.SetValue("Country", Country.USA);
            v.SetValue("Birthday", DateTime.Today.AddDays(-1));
            v.SetValue("IsValid", true);

            Assert.Equal("Du", v.GetValue<string>("Name"));
            Assert.Equal(55, v.GetValue<int>("Age"));
            Assert.Equal(Country.USA, v.GetValue<Country>("Country"));
            Assert.Equal(DateTime.Today.AddDays(-1), v.GetValue<DateTime>("Birthday"));
            Assert.True(v.GetValue<bool>("IsValid"));

            v["Name"] = "Au";
            v["Age"] = 77;
            v["Country"] = Country.China;
            v["Birthday"] = DateTime.Today.AddDays(1);
            v["IsValid"] = false;

            Assert.Equal("Au", v.GetValue<string>("Name"));
            Assert.Equal(77, v.GetValue<int>("Age"));
            Assert.Equal(Country.China, v.GetValue<Country>("Country"));
            Assert.Equal(DateTime.Today.AddDays(1), v.GetValue<DateTime>("Birthday"));
            Assert.False(v.GetValue<bool>("IsValid"));

            v.SetValue<NiceAct>(x => x.Name, "Zu");
            v.SetValue<NiceAct>(x => x.Age, 99);
            v.SetValue<NiceAct>(x => x.Country, Country.USA);
            v.SetValue<NiceAct>(x => x.Birthday, DateTime.Today.AddDays(2));
            v.SetValue<NiceAct>(x => x.IsValid, true);

            Assert.Equal("Zu", v.GetValue<NiceAct>(x => x.Name));
            Assert.Equal(99, v.GetValue<NiceAct>(x => x.Age));
            Assert.Equal(Country.USA, v.GetValue<NiceAct>(x => x.Country));
            Assert.Equal(DateTime.Today.AddDays(2), v.GetValue<NiceAct>(x => x.Birthday));
            Assert.True((bool) v.GetValue<NiceAct>(x => x.IsValid));

            v.SetValue<NiceAct, string>(x => x.Name, "Xu");
            v.SetValue<NiceAct, int>(x => x.Age, 199);
            v.SetValue<NiceAct, Country>(x => x.Country, Country.China);
            v.SetValue<NiceAct, DateTime>(x => x.Birthday, DateTime.Today.AddDays(-2));
            v.SetValue<NiceAct, bool>(x => x.IsValid, false);

            Assert.Equal("Xu", v.GetValue<NiceAct, string>(x => x.Name));
            Assert.Equal(199, v.GetValue<NiceAct, int>(x => x.Age));
            Assert.Equal(Country.China, v.GetValue<NiceAct, Country>(x => x.Country));
            Assert.Equal(DateTime.Today.AddDays(-2), v.GetValue<NiceAct, DateTime>(x => x.Birthday));
            Assert.False(v.GetValue<NiceAct, bool>(x => x.IsValid));

            var d = v.ToDictionary();
            Assert.Equal("Xu", d["Name"]);
            Assert.Equal(199, d["Age"]);
            Assert.Equal(Country.China, d["Country"]);
            Assert.Equal(DateTime.Today.AddDays(-2), d["Birthday"]);
            Assert.False((bool) d["IsValid"]);

            d["Name"] = "Ax";
            d["Age"] = 10086;
            d["Country"] = Country.China;
            d["Birthday"] = DateTime.Today.AddDays(10);
            d["IsValid"] = true;
            
            v.SetValue(d);
            
            Assert.Equal("Ax", d["Name"]);
            Assert.Equal(10086, d["Age"]);
            Assert.Equal(Country.China, d["Country"]);
            Assert.Equal(DateTime.Today.AddDays(10), d["Birthday"]);
            Assert.True((bool) d["IsValid"]);
        }

        [Fact(DisplayName = "直接类型测试")]
        public void DirectFutureTest()
        {
            var type = typeof(NiceAct);
            var v = ObjectVisitorFactory.Create(type);

            Assert.False(v.IsStatic);
            Assert.Equal(typeof(NiceAct), v.SourceType);
            Assert.Equal(AlgorithmKind.Precision, v.AlgorithmKind);

            v.SetValue("Name", "Du");
            v.SetValue("Age", 55);
            v.SetValue("Country", Country.USA);
            v.SetValue("Birthday", DateTime.Today.AddDays(-1));
            v.SetValue("IsValid", true);

            Assert.Equal("Du", v.GetValue<string>("Name"));
            Assert.Equal(55, v.GetValue<int>("Age"));
            Assert.Equal(Country.USA, v.GetValue<Country>("Country"));
            Assert.Equal(DateTime.Today.AddDays(-1), v.GetValue<DateTime>("Birthday"));
            Assert.True(v.GetValue<bool>("IsValid"));

            v["Name"] = "Au";
            v["Age"] = 77;
            v["Country"] = Country.China;
            v["Birthday"] = DateTime.Today.AddDays(1);
            v["IsValid"] = false;
            
            Assert.Equal("Au", v.GetValue<string>("Name"));
            Assert.Equal(77, v.GetValue<int>("Age"));
            Assert.Equal(Country.China, v.GetValue<Country>("Country"));
            Assert.Equal(DateTime.Today.AddDays(1), v.GetValue<DateTime>("Birthday"));
            Assert.False(v.GetValue<bool>("IsValid"));

            v.SetValue<NiceAct>(x => x.Name, "Zu");
            v.SetValue<NiceAct>(x => x.Age, 99);
            v.SetValue<NiceAct>(x => x.Country, Country.USA);
            v.SetValue<NiceAct>(x => x.Birthday, DateTime.Today.AddDays(2));
            v.SetValue<NiceAct>(x => x.IsValid, true);

            Assert.Equal("Zu", v.GetValue<NiceAct>(x => x.Name));
            Assert.Equal(99, v.GetValue<NiceAct>(x => x.Age));
            Assert.Equal(Country.USA, v.GetValue<NiceAct>(x => x.Country));
            Assert.Equal(DateTime.Today.AddDays(2), v.GetValue<NiceAct>(x => x.Birthday));
            Assert.True((bool) v.GetValue<NiceAct>(x => x.IsValid));

            v.SetValue<NiceAct, string>(x => x.Name, "Xu");
            v.SetValue<NiceAct, int>(x => x.Age, 199);
            v.SetValue<NiceAct, Country>(x => x.Country, Country.China);
            v.SetValue<NiceAct, DateTime>(x => x.Birthday, DateTime.Today.AddDays(-2));
            v.SetValue<NiceAct, bool>(x => x.IsValid, false);

            Assert.Equal("Xu", v.GetValue<NiceAct, string>(x => x.Name));
            Assert.Equal(199, v.GetValue<NiceAct, int>(x => x.Age));
            Assert.Equal(Country.China, v.GetValue<NiceAct, Country>(x => x.Country));
            Assert.Equal(DateTime.Today.AddDays(-2), v.GetValue<NiceAct, DateTime>(x => x.Birthday));
            Assert.False(v.GetValue<NiceAct, bool>(x => x.IsValid));

            var d = v.ToDictionary();
            Assert.Equal("Xu", d["Name"]);
            Assert.Equal(199, d["Age"]);
            Assert.Equal(Country.China, d["Country"]);
            Assert.Equal(DateTime.Today.AddDays(-2), d["Birthday"]);
            Assert.False((bool) d["IsValid"]);

            d["Name"] = "Ax";
            d["Age"] = 10086;
            d["Country"] = Country.China;
            d["Birthday"] = DateTime.Today.AddDays(10);
            d["IsValid"] = true;
            
            v.SetValue(d);
            
            Assert.Equal("Ax", d["Name"]);
            Assert.Equal(10086, d["Age"]);
            Assert.Equal(Country.China, d["Country"]);
            Assert.Equal(DateTime.Today.AddDays(10), d["Birthday"]);
            Assert.True((bool) d["IsValid"]);
        }

        [Fact(DisplayName = "泛型实例测试")]
        public void GenericInstanceTest()
        {
            var act = new NiceAct()
            {
                Name = "Hu",
                Age = 22,
                Country = Country.China,
                Birthday = DateTime.Today
            };

            var v = ObjectVisitorFactory.Create<NiceAct>(act);

            Assert.False(v.IsStatic);
            Assert.Equal(typeof(NiceAct), v.SourceType);
            Assert.Equal(AlgorithmKind.Precision, v.AlgorithmKind);

            Assert.Equal("Hu", v.GetValue<string>("Name"));
            Assert.Equal(22, v.GetValue<int>("Age"));
            Assert.Equal(Country.China, v.GetValue<Country>("Country"));
            Assert.Equal(DateTime.Today, v.GetValue<DateTime>("Birthday"));
            Assert.False(v.GetValue<bool>("IsValid"));

            v.SetValue("Name", "Du");
            v.SetValue("Age", 55);
            v.SetValue("Country", Country.USA);
            v.SetValue("Birthday", DateTime.Today.AddDays(-1));
            v.SetValue("IsValid", true);

            Assert.Equal("Du", v.GetValue<string>("Name"));
            Assert.Equal(55, v.GetValue<int>("Age"));
            Assert.Equal(Country.USA, v.GetValue<Country>("Country"));
            Assert.Equal(DateTime.Today.AddDays(-1), v.GetValue<DateTime>("Birthday"));
            Assert.True(v.GetValue<bool>("IsValid"));

            v["Name"] = "Au";
            v["Age"] = 77;
            v["Country"] = Country.China;
            v["Birthday"] = DateTime.Today.AddDays(1);
            v["IsValid"] = false;

            Assert.Equal("Au", v.GetValue<string>("Name"));
            Assert.Equal(77, v.GetValue<int>("Age"));
            Assert.Equal(Country.China, v.GetValue<Country>("Country"));
            Assert.Equal(DateTime.Today.AddDays(1), v.GetValue<DateTime>("Birthday"));
            Assert.False(v.GetValue<bool>("IsValid"));

            v.SetValue<NiceAct>(x => x.Name, "Zu");
            v.SetValue<NiceAct>(x => x.Age, 99);
            v.SetValue<NiceAct>(x => x.Country, Country.USA);
            v.SetValue<NiceAct>(x => x.Birthday, DateTime.Today.AddDays(2));
            v.SetValue<NiceAct>(x => x.IsValid, true);

            Assert.Equal("Zu", v.GetValue<NiceAct>(x => x.Name));
            Assert.Equal(99, v.GetValue<NiceAct>(x => x.Age));
            Assert.Equal(Country.USA, v.GetValue<NiceAct>(x => x.Country));
            Assert.Equal(DateTime.Today.AddDays(2), v.GetValue<NiceAct>(x => x.Birthday));
            Assert.True((bool) v.GetValue<NiceAct>(x => x.IsValid));

            v.SetValue<NiceAct, string>(x => x.Name, "Xu");
            v.SetValue<NiceAct, int>(x => x.Age, 199);
            v.SetValue<NiceAct, Country>(x => x.Country, Country.China);
            v.SetValue<NiceAct, DateTime>(x => x.Birthday, DateTime.Today.AddDays(-2));
            v.SetValue<NiceAct, bool>(x => x.IsValid, false);

            Assert.Equal("Xu", v.GetValue<NiceAct, string>(x => x.Name));
            Assert.Equal(199, v.GetValue<NiceAct, int>(x => x.Age));
            Assert.Equal(Country.China, v.GetValue<NiceAct, Country>(x => x.Country));
            Assert.Equal(DateTime.Today.AddDays(-2), v.GetValue<NiceAct, DateTime>(x => x.Birthday));
            Assert.False(v.GetValue<NiceAct, bool>(x => x.IsValid));

            v.SetValue<string>(x => x.Name, "Lu");
            v.SetValue<int>(x => x.Age, 11);
            v.SetValue<Country>(x => x.Country, Country.USA);
            v.SetValue<DateTime>(x => x.Birthday, DateTime.Today);
            v.SetValue<bool>(x => x.IsValid, true);

            Assert.Equal("Lu", v.GetValue(x => x.Name));
            Assert.Equal(11, v.GetValue(x => x.Age));
            Assert.Equal(Country.USA, v.GetValue(x => x.Country));
            Assert.Equal(DateTime.Today, v.GetValue(x => x.Birthday));
            Assert.True(v.GetValue(x => x.IsValid));

            var d = v.ToDictionary();
            Assert.Equal("Lu", d["Name"]);
            Assert.Equal(11, d["Age"]);
            Assert.Equal(Country.USA, d["Country"]);
            Assert.Equal(DateTime.Today, d["Birthday"]);
            Assert.True((bool) d["IsValid"]);

            d["Name"] = "Ax";
            d["Age"] = 10086;
            d["Country"] = Country.China;
            d["Birthday"] = DateTime.Today.AddDays(10);
            d["IsValid"] = true;
            
            v.SetValue(d);
            
            Assert.Equal("Ax", d["Name"]);
            Assert.Equal(10086, d["Age"]);
            Assert.Equal(Country.China, d["Country"]);
            Assert.Equal(DateTime.Today.AddDays(10), d["Birthday"]);
            Assert.True((bool) d["IsValid"]);
        }

        [Fact(DisplayName = "泛型类型测试")]
        public void GenericFutureTest()
        {
            var v = ObjectVisitorFactory.Create<NiceAct>();

            Assert.False(v.IsStatic);
            Assert.Equal(typeof(NiceAct), v.SourceType);
            Assert.Equal(AlgorithmKind.Precision, v.AlgorithmKind);

            v.SetValue("Name", "Du");
            v.SetValue("Age", 55);
            v.SetValue("Country", Country.USA);
            v.SetValue("Birthday", DateTime.Today.AddDays(-1));
            v.SetValue("IsValid", true);

            Assert.Equal("Du", v.GetValue<string>("Name"));
            Assert.Equal(55, v.GetValue<int>("Age"));
            Assert.Equal(Country.USA, v.GetValue<Country>("Country"));
            Assert.Equal(DateTime.Today.AddDays(-1), v.GetValue<DateTime>("Birthday"));
            Assert.True(v.GetValue<bool>("IsValid"));

            v["Name"] = "Au";
            v["Age"] = 77;
            v["Country"] = Country.China;
            v["Birthday"] = DateTime.Today.AddDays(1);
            v["IsValid"] = false;

            Assert.Equal("Au", v.GetValue<string>("Name"));
            Assert.Equal(77, v.GetValue<int>("Age"));
            Assert.Equal(Country.China, v.GetValue<Country>("Country"));
            Assert.Equal(DateTime.Today.AddDays(1), v.GetValue<DateTime>("Birthday"));
            Assert.False(v.GetValue<bool>("IsValid"));

            v.SetValue<NiceAct>(x => x.Name, "Zu");
            v.SetValue<NiceAct>(x => x.Age, 99);
            v.SetValue<NiceAct>(x => x.Country, Country.USA);
            v.SetValue<NiceAct>(x => x.Birthday, DateTime.Today.AddDays(2));
            v.SetValue<NiceAct>(x => x.IsValid, true);

            Assert.Equal("Zu", v.GetValue<NiceAct>(x => x.Name));
            Assert.Equal(99, v.GetValue<NiceAct>(x => x.Age));
            Assert.Equal(Country.USA, v.GetValue<NiceAct>(x => x.Country));
            Assert.Equal(DateTime.Today.AddDays(2), v.GetValue<NiceAct>(x => x.Birthday));
            Assert.True((bool) v.GetValue<NiceAct>(x => x.IsValid));

            v.SetValue<NiceAct, string>(x => x.Name, "Xu");
            v.SetValue<NiceAct, int>(x => x.Age, 199);
            v.SetValue<NiceAct, Country>(x => x.Country, Country.China);
            v.SetValue<NiceAct, DateTime>(x => x.Birthday, DateTime.Today.AddDays(-2));
            v.SetValue<NiceAct, bool>(x => x.IsValid, false);

            Assert.Equal("Xu", v.GetValue<NiceAct, string>(x => x.Name));
            Assert.Equal(199, v.GetValue<NiceAct, int>(x => x.Age));
            Assert.Equal(Country.China, v.GetValue<NiceAct, Country>(x => x.Country));
            Assert.Equal(DateTime.Today.AddDays(-2), v.GetValue<NiceAct, DateTime>(x => x.Birthday));
            Assert.False(v.GetValue<NiceAct, bool>(x => x.IsValid));

            v.SetValue<string>(x => x.Name, "Lu");
            v.SetValue<int>(x => x.Age, 11);
            v.SetValue<Country>(x => x.Country, Country.USA);
            v.SetValue<DateTime>(x => x.Birthday, DateTime.Today);
            v.SetValue<bool>(x => x.IsValid, true);

            Assert.Equal("Lu", v.GetValue(x => x.Name));
            Assert.Equal(11, v.GetValue(x => x.Age));
            Assert.Equal(Country.USA, v.GetValue(x => x.Country));
            Assert.Equal(DateTime.Today, v.GetValue(x => x.Birthday));
            Assert.True(v.GetValue(x => x.IsValid));
            
            var d = v.ToDictionary();
            Assert.Equal("Lu", d["Name"]);
            Assert.Equal(11, d["Age"]);
            Assert.Equal(Country.USA, d["Country"]);
            Assert.Equal(DateTime.Today, d["Birthday"]);
            Assert.True((bool) d["IsValid"]);

            d["Name"] = "Ax";
            d["Age"] = 10086;
            d["Country"] = Country.China;
            d["Birthday"] = DateTime.Today.AddDays(10);
            d["IsValid"] = true;
            
            v.SetValue(d);
            
            Assert.Equal("Ax", d["Name"]);
            Assert.Equal(10086, d["Age"]);
            Assert.Equal(Country.China, d["Country"]);
            Assert.Equal(DateTime.Today.AddDays(10), d["Birthday"]);
            Assert.True((bool) d["IsValid"]);
        }

        [Fact(DisplayName = "静态类型测试")]
        public void DirectStaticTypeTest()
        {
            StaticNiceAct1.Name = "Hu";
            StaticNiceAct1.Age = 22;
            StaticNiceAct1.Country = Country.China;
            StaticNiceAct1.Birthday = DateTime.Today;

            var type = typeof(StaticNiceAct1);

            var v = ObjectVisitorFactory.Create(type);

            Assert.True(v.IsStatic);
            Assert.Equal(typeof(StaticNiceAct1), v.SourceType);
            Assert.Equal(AlgorithmKind.Precision, v.AlgorithmKind);

            Assert.Equal("Hu", v.GetValue<string>("Name"));
            Assert.Equal(22, v.GetValue<int>("Age"));
            Assert.Equal(Country.China, v.GetValue<Country>("Country"));
            Assert.Equal(DateTime.Today, v.GetValue<DateTime>("Birthday"));
            Assert.False(v.GetValue<bool>("IsValid"));

            v.SetValue("Name", "Du");
            v.SetValue("Age", 55);
            v.SetValue("Country", Country.USA);
            v.SetValue("Birthday", DateTime.Today.AddDays(-1));
            v.SetValue("IsValid", true);

            Assert.Equal("Du", v.GetValue<string>("Name"));
            Assert.Equal(55, v.GetValue<int>("Age"));
            Assert.Equal(Country.USA, v.GetValue<Country>("Country"));
            Assert.Equal(DateTime.Today.AddDays(-1), v.GetValue<DateTime>("Birthday"));
            Assert.True(v.GetValue<bool>("IsValid"));

            v["Name"] = "Au";
            v["Age"] = 77;
            v["Country"] = Country.China;
            v["Birthday"] = DateTime.Today.AddDays(1);
            v["IsValid"] = false;

            Assert.Equal("Au", v.GetValue<string>("Name"));
            Assert.Equal(77, v.GetValue<int>("Age"));
            Assert.Equal(Country.China, v.GetValue<Country>("Country"));
            Assert.Equal(DateTime.Today.AddDays(1), v.GetValue<DateTime>("Birthday"));
            Assert.False(v.GetValue<bool>("IsValid"));

            v.SetValue<NiceAct>(x => x.Name, "Zu");
            v.SetValue<NiceAct>(x => x.Age, 99);
            v.SetValue<NiceAct>(x => x.Country, Country.USA);
            v.SetValue<NiceAct>(x => x.Birthday, DateTime.Today.AddDays(2));
            v.SetValue<NiceAct>(x => x.IsValid, true);

            Assert.Equal("Zu", v.GetValue<NiceAct>(x => x.Name));
            Assert.Equal(99, v.GetValue<NiceAct>(x => x.Age));
            Assert.Equal(Country.USA, v.GetValue<NiceAct>(x => x.Country));
            Assert.Equal(DateTime.Today.AddDays(2), v.GetValue<NiceAct>(x => x.Birthday));
            Assert.True((bool) v.GetValue<NiceAct>(x => x.IsValid));

            v.SetValue<NiceAct, string>(x => x.Name, "Xu");
            v.SetValue<NiceAct, int>(x => x.Age, 199);
            v.SetValue<NiceAct, Country>(x => x.Country, Country.China);
            v.SetValue<NiceAct, DateTime>(x => x.Birthday, DateTime.Today.AddDays(-2));
            v.SetValue<NiceAct, bool>(x => x.IsValid, false);

            Assert.Equal("Xu", v.GetValue<NiceAct, string>(x => x.Name));
            Assert.Equal(199, v.GetValue<NiceAct, int>(x => x.Age));
            Assert.Equal(Country.China, v.GetValue<NiceAct, Country>(x => x.Country));
            Assert.Equal(DateTime.Today.AddDays(-2), v.GetValue<NiceAct, DateTime>(x => x.Birthday));
            Assert.False(v.GetValue<NiceAct, bool>(x => x.IsValid));

            var d = v.ToDictionary();
            Assert.Equal("Xu", d["Name"]);
            Assert.Equal(199, d["Age"]);
            Assert.Equal(Country.China, d["Country"]);
            Assert.Equal(DateTime.Today.AddDays(-2), d["Birthday"]);
            Assert.False((bool) d["IsValid"]);

            d["Name"] = "Ax";
            d["Age"] = 10086;
            d["Country"] = Country.China;
            d["Birthday"] = DateTime.Today.AddDays(10);
            d["IsValid"] = true;
            
            v.SetValue(d);
            
            Assert.Equal("Ax", d["Name"]);
            Assert.Equal(10086, d["Age"]);
            Assert.Equal(Country.China, d["Country"]);
            Assert.Equal(DateTime.Today.AddDays(10), d["Birthday"]);
            Assert.True((bool) d["IsValid"]);
        }

        [Fact(DisplayName = "伪静态类型测试")]
        public void FackStaticTypeTest()
        {
            var act = new StaticNiceAct2();

            StaticNiceAct2.Name = "Hu";
            StaticNiceAct2.Age = 22;
            StaticNiceAct2.Country = Country.China;
            StaticNiceAct2.Birthday = DateTime.Today;

            var type = typeof(StaticNiceAct2);

            var v = ObjectVisitorFactory.Create(type, act);

            Assert.False(v.IsStatic);
            Assert.Equal(typeof(StaticNiceAct2), v.SourceType);
            Assert.Equal(AlgorithmKind.Precision, v.AlgorithmKind);

            Assert.Equal("Hu", v.GetValue<string>("Name"));
            Assert.Equal(22, v.GetValue<int>("Age"));
            Assert.Equal(Country.China, v.GetValue<Country>("Country"));
            Assert.Equal(DateTime.Today, v.GetValue<DateTime>("Birthday"));
            Assert.False(v.GetValue<bool>("IsValid"));

            v.SetValue("Name", "Du");
            v.SetValue("Age", 55);
            v.SetValue("Country", Country.USA);
            v.SetValue("Birthday", DateTime.Today.AddDays(-1));
            v.SetValue("IsValid", true);

            Assert.Equal("Du", v.GetValue<string>("Name"));
            Assert.Equal(55, v.GetValue<int>("Age"));
            Assert.Equal(Country.USA, v.GetValue<Country>("Country"));
            Assert.Equal(DateTime.Today.AddDays(-1), v.GetValue<DateTime>("Birthday"));
            Assert.True(v.GetValue<bool>("IsValid"));

            v["Name"] = "Au";
            v["Age"] = 77;
            v["Country"] = Country.China;
            v["Birthday"] = DateTime.Today.AddDays(1);
            v["IsValid"] = false;

            Assert.Equal("Au", v.GetValue<string>("Name"));
            Assert.Equal(77, v.GetValue<int>("Age"));
            Assert.Equal(Country.China, v.GetValue<Country>("Country"));
            Assert.Equal(DateTime.Today.AddDays(1), v.GetValue<DateTime>("Birthday"));
            Assert.False(v.GetValue<bool>("IsValid"));

            v.SetValue<NiceAct>(x => x.Name, "Zu");
            v.SetValue<NiceAct>(x => x.Age, 99);
            v.SetValue<NiceAct>(x => x.Country, Country.USA);
            v.SetValue<NiceAct>(x => x.Birthday, DateTime.Today.AddDays(2));
            v.SetValue<NiceAct>(x => x.IsValid, true);

            Assert.Equal("Zu", v.GetValue<NiceAct>(x => x.Name));
            Assert.Equal(99, v.GetValue<NiceAct>(x => x.Age));
            Assert.Equal(Country.USA, v.GetValue<NiceAct>(x => x.Country));
            Assert.Equal(DateTime.Today.AddDays(2), v.GetValue<NiceAct>(x => x.Birthday));
            Assert.True((bool) v.GetValue<NiceAct>(x => x.IsValid));

            v.SetValue<NiceAct, string>(x => x.Name, "Xu");
            v.SetValue<NiceAct, int>(x => x.Age, 199);
            v.SetValue<NiceAct, Country>(x => x.Country, Country.China);
            v.SetValue<NiceAct, DateTime>(x => x.Birthday, DateTime.Today.AddDays(-2));
            v.SetValue<NiceAct, bool>(x => x.IsValid, false);

            Assert.Equal("Xu", v.GetValue<NiceAct, string>(x => x.Name));
            Assert.Equal(199, v.GetValue<NiceAct, int>(x => x.Age));
            Assert.Equal(Country.China, v.GetValue<NiceAct, Country>(x => x.Country));
            Assert.Equal(DateTime.Today.AddDays(-2), v.GetValue<NiceAct, DateTime>(x => x.Birthday));
            Assert.False(v.GetValue<NiceAct, bool>(x => x.IsValid));

            var d = v.ToDictionary();
            Assert.Equal("Xu", d["Name"]);
            Assert.Equal(199, d["Age"]);
            Assert.Equal(Country.China, d["Country"]);
            Assert.Equal(DateTime.Today.AddDays(-2), d["Birthday"]);
            Assert.False((bool) d["IsValid"]);

            d["Name"] = "Ax";
            d["Age"] = 10086;
            d["Country"] = Country.China;
            d["Birthday"] = DateTime.Today.AddDays(10);
            d["IsValid"] = true;
            
            v.SetValue(d);
            
            Assert.Equal("Ax", d["Name"]);
            Assert.Equal(10086, d["Age"]);
            Assert.Equal(Country.China, d["Country"]);
            Assert.Equal(DateTime.Today.AddDays(10), d["Birthday"]);
            Assert.True((bool) d["IsValid"]);
        }
    }
}