﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Cosmos.Reflection;
using Cosmos.Validation;
using CosmosProwessUT.OvUT.Helpers;
using CosmosProwessUT.OvUT.Model;
using Xunit;

namespace CosmosProwessUT.OvUT
{
    [Trait("Validation Rules", "Normal")]
    public class ValidationRuleGenericTests : Prepare
    {
        public ValidationRuleGenericTests()
        {
            Data = new NiceAct2(true);
        }

        public NiceAct2 Data { get; set; }

        [Fact(DisplayName = "Equal `1 Token with Str")]
        public void StringEqualTest()
        {
            var v = ObjectVisitorFactory.Create(Data);
            v.VerifiableEntry.ForMember(x => x.Str, c => c.Equal("StrStr"));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Str, c => c.Equal("Str").OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "Equal `1 Token with Int16")]
        public void Int16EqualTest()
        {
            var v = ObjectVisitorFactory.Create(Data);
            v.VerifiableEntry.ForMember(x => x.Int16, c => c.Equal(16));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Int16, c => c.Equal(99).OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "Equal `1 Token with Int32")]
        public void Int32EqualTest()
        {
            var v = ObjectVisitorFactory.Create(Data);
            v.VerifiableEntry.ForMember(x => x.Int32, c => c.Equal(32));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Int32, c => c.Equal(99).OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "Equal `1 Token with Int64")]
        public void Int64EqualTest()
        {
            var v = ObjectVisitorFactory.Create(Data);
            v.VerifiableEntry.ForMember(x => x.Int64, c => c.Equal(64));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Int64, c => c.Equal(99).OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "Equal `1 Token with Char")]
        public void CharEqualTest()
        {
            var v = ObjectVisitorFactory.Create(Data);
            v.VerifiableEntry.ForMember(x => x.Char, c => c.Equal('c'));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Char, c => c.Equal('d').OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "Equal `1 Token with Obj")]
        public void ObjEqualTest()
        {
            var v = ObjectVisitorFactory.Create(Data);
            v.VerifiableEntry.ForMember(x => x.SomeObj, c => c.Equal(Data.SomeObj));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.SomeObj, c => c.Equal(new NiceAct2()).OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "Not Equal `1 Token with Str")]
        public void StringNotEqualTest()
        {
            var v = ObjectVisitorFactory.Create(Data);
            v.VerifiableEntry.ForMember(x => x.Str, c => c.NotEqual("StrStr"));

            var r = v.Verify();
            Assert.False(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Str, c => c.NotEqual("Str").OverwriteRule());

            r = v.Verify();
            Assert.True(r.IsValid);
        }

        [Fact(DisplayName = "Not Equal `1 Token with Int16")]
        public void Int16NotEqualTest()
        {
            var v = ObjectVisitorFactory.Create(Data);
            v.VerifiableEntry.ForMember(x => x.Int16, c => c.NotEqual(16));

            var r = v.Verify();
            Assert.False(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Int16, c => c.NotEqual(99).OverwriteRule());

            r = v.Verify();
            Assert.True(r.IsValid);
        }

        [Fact(DisplayName = "Not Equal `1 Token with Int32")]
        public void Int32NotEqualTest()
        {
            var v = ObjectVisitorFactory.Create(Data);
            v.VerifiableEntry.ForMember(x => x.Int32, c => c.NotEqual(32));

            var r = v.Verify();
            Assert.False(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Int32, c => c.NotEqual(99).OverwriteRule());

            r = v.Verify();
            Assert.True(r.IsValid);
        }

        [Fact(DisplayName = "Not Equal `1 Token with Int64")]
        public void Int64NotEqualTest()
        {
            var v = ObjectVisitorFactory.Create(Data);
            v.VerifiableEntry.ForMember(x => x.Int64, c => c.NotEqual(64));

            var r = v.Verify();
            Assert.False(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Int64, c => c.NotEqual(99).OverwriteRule());

            r = v.Verify();
            Assert.True(r.IsValid);
        }

        [Fact(DisplayName = "Not Equal `1 Token with Char")]
        public void CharNotEqualTest()
        {
            var v = ObjectVisitorFactory.Create(Data);
            v.VerifiableEntry.ForMember(x => x.Char, c => c.NotEqual('c'));

            var r = v.Verify();
            Assert.False(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Char, c => c.NotEqual('d').OverwriteRule());

            r = v.Verify();
            Assert.True(r.IsValid);
        }

        [Fact(DisplayName = "Not Equal `1 Token with Obj")]
        public void ObjNotEqualTest()
        {
            var v = ObjectVisitorFactory.Create(Data);
            v.VerifiableEntry.ForMember(x => x.SomeObj, c => c.NotEqual(Data.SomeObj));

            var r = v.Verify();
            Assert.False(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.SomeObj, c => c.NotEqual(new NiceAct2()).OverwriteRule());

            r = v.Verify();
            Assert.True(r.IsValid);
        }

        [Fact(DisplayName = "Range`1 Token with int16")]
        public void Int16RangeTest()
        {
            var v = ObjectVisitorFactory.Create(Data);
            v.VerifiableEntry.ForMember(x => x.Int16, c => c.Range(1, 100));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Int16, c => c.Range(88, 100));

            r = v.Verify();
            Assert.False(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Int16, c => c.RangeWithCloseInterval(16, 17).OverwriteRule());

            r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Int16, c => c.RangeWithOpenInterval(16, 17).OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "Range`1 Token with int32")]
        public void Int32RangeTest()
        {
            var v = ObjectVisitorFactory.Create(Data);
            v.VerifiableEntry.ForMember(x => x.Int32, c => c.Range(1, 100));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Int32, c => c.Range(88, 100));

            r = v.Verify();
            Assert.False(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Int32, c => c.RangeWithCloseInterval(32, 33).OverwriteRule());

            r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Int32, c => c.RangeWithOpenInterval(32, 33).OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "Range`1 Token with int64")]
        public void Int64RangeTest()
        {
            var v = ObjectVisitorFactory.Create(Data);
            v.VerifiableEntry.ForMember(x => x.Int64, c => c.Range(1, 100));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Int64, c => c.Range(88, 100));

            r = v.Verify();
            Assert.False(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Int64, c => c.RangeWithCloseInterval(64, 65).OverwriteRule());

            r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Int64, c => c.RangeWithOpenInterval(64, 65).OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "Range`1 Token with Char")]
        public void CharRangeTest()
        {
            var v = ObjectVisitorFactory.Create(Data);
            v.VerifiableEntry.ForMember(x => x.Char, c => c.Range('a', 'd'));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Char, c => c.Range('x', 'z'));

            r = v.Verify();
            Assert.False(r.IsValid);

            r = v.Verify();
            Assert.False(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Char, c => c.RangeWithCloseInterval('c', 'd').OverwriteRule());

            r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Char, c => c.RangeWithOpenInterval('c', 'd').OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "Range`1 Token with DateTime")]
        public void DateTimeRangeTest()
        {
            var v = ObjectVisitorFactory.Create(Data);
            v.VerifiableEntry.ForMember(x => x.DateTime, c => c.Range(DateTime.Today.AddDays(-1), DateTime.Today.AddDays(1)));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.DateTime, c => c.Range(DateTime.Today.AddDays(1), DateTime.Today.AddDays(2)));

            r = v.Verify();
            Assert.False(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.DateTime, c => c.RangeWithCloseInterval(DateTime.Today, DateTime.Today.AddDays(1)).OverwriteRule());

            r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.DateTime, c => c.RangeWithOpenInterval(DateTime.Today, DateTime.Today.AddDays(1)).OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "Range`1 Token with DateTimeOffset")]
        public void DateTimeOffsetRangeTest()
        {
            var v = ObjectVisitorFactory.Create(Data);
            v.VerifiableEntry.ForMember(x => x.DateTimeOffset, c => c.Range(DateTime.Today.AddDays(-1), DateTime.Today.AddDays(1)));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.DateTimeOffset, c => c.Range(DateTime.Today.AddDays(1), DateTime.Today.AddDays(2)));

            r = v.Verify();
            Assert.False(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.DateTimeOffset, c => c.RangeWithCloseInterval(DateTime.Today, DateTime.Today.AddDays(1)).OverwriteRule());

            r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.DateTimeOffset, c => c.RangeWithOpenInterval(DateTime.Today, DateTime.Today.AddDays(1)).OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "Any Token with Bytes")]
        public void BytesAnyTest()
        {
            var v = ObjectVisitorFactory.Create(Data);

            v.VerifiableEntry.ForMember(x => x.Bytes, c => c.Any(x => x == 0));

            var r = v.Verify();
            Assert.True(r.IsValid);
        }

        [Fact(DisplayName = "Any Token with Array")]
        public void ObjArrayAnyTest()
        {
            var v = ObjectVisitorFactory.Create(Data);
            var o = v.GetValue(x => x.SomeObj);

            v.VerifiableEntry.ForMember(x => x.SomeNiceActArray, c => c.Any(s => s == o));

            var r = v.Verify();
            Assert.True(r.IsValid);
        }

        [Fact(DisplayName = "Any Token with List")]
        public void ObjListAnyTest()
        {
            var v = ObjectVisitorFactory.Create(Data);
            var o = v.GetValue(x => x.SomeObj);

            v.VerifiableEntry.ForMember(x => x.SomeNiceActList, c => c.Any<NiceAct2, List<NiceAct>, NiceAct>(s => s == o));

            var r = v.Verify();
            Assert.True(r.IsValid);
        }

        [Fact(DisplayName = "All Token with Bytes")]
        public void BytesAllTest()
        {
            var v = ObjectVisitorFactory.Create(Data);

            v.VerifiableEntry.ForMember(x => x.Bytes, c => c.All(b => b == 0));

            var r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "All Token with Array")]
        public void ObjArrayAllTest()
        {
            var n = new NiceAct();
            var d = new NiceAct2(true);
            var o = (NiceAct) d.SomeObj;
            d.SomeNiceActArray = new[] {o, n, o, n, o, n};

            var v = ObjectVisitorFactory.Create(d);

            v.VerifiableEntry.ForMember(x => x.SomeNiceActArray, c => c.All(s => s == o));

            var r = v.Verify();
            Assert.False(r.IsValid);

            var v2 = ObjectVisitorFactory.Create(Data);
            var o2 = v2.GetValue(x => x.SomeObj);
            v.VerifiableEntry.ForMember(x => x.SomeNiceActArray, c => c.All(s => s == o2));

            var r2 = v2.Verify();
            Assert.True(r2.IsValid);
        }

        [Fact(DisplayName = "All Token with List")]
        public void ObjListAllTest()
        {
            var n = new NiceAct();
            var d = new NiceAct2(true);
            var o = (NiceAct) d.SomeObj;
            d.SomeNiceActList = new List<NiceAct> {o, n, o, n, o, n};

            var v = ObjectVisitorFactory.Create(d);

            v.VerifiableEntry.ForMember(x => x.SomeNiceActList, c => c.All<NiceAct2, List<NiceAct>, NiceAct>(s => s == o));

            var r = v.Verify();
            Assert.False(r.IsValid);

            var v2 = ObjectVisitorFactory.Create(Data);
            var o2 = v2.GetValue(x => x.SomeObj);
            v.VerifiableEntry.ForMember(x => x.SomeNiceActList, c => c.All<NiceAct2, List<NiceAct>, NiceAct>(s => s == o2));

            var r2 = v2.Verify();
            Assert.True(r2.IsValid);
        }

        [Fact(DisplayName = "In/NotIn Token with Str")]
        public void StrInTest()
        {
            var v = ObjectVisitorFactory.Create(Data);

            v.VerifiableEntry.ForMember(x => x.Str, c => c.In(new List<string> {"Str", "StrStr"}));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Str, c => c.NotIn(new List<string> {"Str", "StrStr"}).OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "In/NotIn Token with Int16")]
        public void Int16InTest()
        {
            var v = ObjectVisitorFactory.Create(Data);

            v.VerifiableEntry.ForMember(x => x.Int16, c => c.In(new List<Int16> {16, 17}));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Int16, c => c.NotIn(new List<Int16> {16, 17}).OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "In/NotIn Token with Int32")]
        public void Int32InTest()
        {
            var v = ObjectVisitorFactory.Create(Data);

            v.VerifiableEntry.ForMember(x => x.Int32, c => c.In(new List<Int32> {32, 33}));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Int32, c => c.NotIn(new List<Int32> {32, 33}).OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "In/NotIn Token with Int64")]
        public void Int64InTest()
        {
            var v = ObjectVisitorFactory.Create(Data);

            v.VerifiableEntry.ForMember(x => x.Int64, c => c.In(new List<Int64> {64, 65}));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Int64, c => c.NotIn(new List<Int64> {64, 65}).OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "In/NotIn Token with Char")]
        public void CharInTest()
        {
            var v = ObjectVisitorFactory.Create(Data);

            v.VerifiableEntry.ForMember(x => x.Char, c => c.In(new List<Char> {'c', 'd'}));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Char, c => c.NotIn(new List<Char> {'c', 'd'}).OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }


        [Fact(DisplayName = "LessThan Token with Char")]
        public void CharLessThanTest()
        {
            var v = ObjectVisitorFactory.Create(Data);

            v.VerifiableEntry.ForMember(x => x.Char, c => c.LessThan('d'));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Char, c => c.LessThan('c').OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "LessThan Token with Int16")]
        public void Int16LessThanTest()
        {
            var v = ObjectVisitorFactory.Create(Data);

            v.VerifiableEntry.ForMember(x => x.Int16, c => c.LessThan(17));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Int16, c => c.LessThan(16).OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "LessThan Token with Int32")]
        public void Int32LessThanTest()
        {
            var v = ObjectVisitorFactory.Create(Data);

            v.VerifiableEntry.ForMember(x => x.Int32, c => c.LessThan(33));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Int32, c => c.LessThan(32).OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "LessThan Token with Int64")]
        public void Int64LessThanTest()
        {
            var v = ObjectVisitorFactory.Create(Data);

            v.VerifiableEntry.ForMember(x => x.Int64, c => c.LessThan(65));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Int64, c => c.LessThan(64).OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "LessThan Token with DateTime")]
        public void DateTimeLessThanTest()
        {
            var v = ObjectVisitorFactory.Create(Data);

            v.VerifiableEntry.ForMember(x => x.DateTime, c => c.LessThan(DateTime.Today.AddDays(1)));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.DateTime, c => c.LessThan(DateTime.Today).OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "LessThanOrEqual Token with Char")]
        public void CharLessThanOrEqualTest()
        {
            var v = ObjectVisitorFactory.Create(Data);

            v.VerifiableEntry.ForMember(x => x.Char, c => c.LessThanOrEqual('c'));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Char, c => c.LessThanOrEqual('b').OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "LessThanOrEqual Token with Int16")]
        public void Int16LessThanOrEqualTest()
        {
            var v = ObjectVisitorFactory.Create(Data);

            v.VerifiableEntry.ForMember(x => x.Int16, c => c.LessThanOrEqual(16));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Int16, c => c.LessThanOrEqual(15).OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "LessThanOrEqual Token with Int32")]
        public void Int32LessThanOrEqualTest()
        {
            var v = ObjectVisitorFactory.Create(Data);

            v.VerifiableEntry.ForMember(x => x.Int32, c => c.LessThanOrEqual(32));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Int32, c => c.LessThanOrEqual(31).OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "LessThanOrEqual Token with Int64")]
        public void Int64LessThanOrEqualTest()
        {
            var v = ObjectVisitorFactory.Create(Data);

            v.VerifiableEntry.ForMember(x => x.Int64, c => c.LessThanOrEqual(64));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Int64, c => c.LessThanOrEqual(63).OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "LessThanOrEqual Token with DateTime")]
        public void DateTimeLessThanOrEqualTest()
        {
            var v = ObjectVisitorFactory.Create(Data);

            v.VerifiableEntry.ForMember(x => x.DateTime, c => c.LessThanOrEqual(DateTime.Today));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.DateTime, c => c.LessThanOrEqual(DateTime.Today.AddDays(-1)).OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "GreaterThan Token with Char")]
        public void CharGreaterThanTest()
        {
            var v = ObjectVisitorFactory.Create(Data);

            v.VerifiableEntry.ForMember(x => x.Char, c => c.GreaterThan('b'));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Char, c => c.GreaterThan('c').OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "GreaterThan Token with Int16")]
        public void Int16GreaterThanTest()
        {
            var v = ObjectVisitorFactory.Create(Data);

            v.VerifiableEntry.ForMember(x => x.Int16, c => c.GreaterThan(15));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Int16, c => c.GreaterThan(16).OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "GreaterThan Token with Int32")]
        public void Int32GreaterThanTest()
        {
            var v = ObjectVisitorFactory.Create(Data);

            v.VerifiableEntry.ForMember(x => x.Int32, c => c.GreaterThan(31));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Int32, c => c.GreaterThan(32).OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "GreaterThan Token with Int64")]
        public void Int64GreaterThanTest()
        {
            var v = ObjectVisitorFactory.Create(Data);

            v.VerifiableEntry.ForMember(x => x.Int64, c => c.GreaterThan(63));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Int64, c => c.GreaterThan(64).OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "GreaterThan Token with DateTime")]
        public void DateTimeGreaterThanTest()
        {
            var v = ObjectVisitorFactory.Create(Data);

            v.VerifiableEntry.ForMember(x => x.DateTime, c => c.GreaterThan(DateTime.Today.AddDays(-1)));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.DateTime, c => c.GreaterThan(DateTime.Today).OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "GreaterThanOrEqual Token with Char")]
        public void CharGreaterThanOrEqualTest()
        {
            var v = ObjectVisitorFactory.Create(Data);

            v.VerifiableEntry.ForMember(x => x.Char, c => c.GreaterThanOrEqual('c'));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Char, c => c.GreaterThanOrEqual('d').OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "GreaterThanOrEqual Token with Int16")]
        public void Int16GreaterThanOrEqualTest()
        {
            var v = ObjectVisitorFactory.Create(Data);

            v.VerifiableEntry.ForMember(x => x.Int16, c => c.GreaterThanOrEqual(16));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Int16, c => c.GreaterThanOrEqual(17).OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "GreaterThanOrEqual Token with Int32")]
        public void Int32GreaterThanOrEqualTest()
        {
            var v = ObjectVisitorFactory.Create(Data);

            v.VerifiableEntry.ForMember(x => x.Int32, c => c.GreaterThanOrEqual(32));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Int32, c => c.GreaterThanOrEqual(33).OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "GreaterThanOrEqual Token with Int64")]
        public void Int64GreaterThanOrEqualTest()
        {
            var v = ObjectVisitorFactory.Create(Data);

            v.VerifiableEntry.ForMember(x => x.Int64, c => c.GreaterThanOrEqual(64));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Int64, c => c.GreaterThanOrEqual(65).OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "GreaterThanOrEqual Token with DateTime")]
        public void DateTimeGreaterThanOrEqualTest()
        {
            var v = ObjectVisitorFactory.Create(Data);

            v.VerifiableEntry.ForMember(x => x.DateTime, c => c.GreaterThanOrEqual(DateTime.Today));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.DateTime, c => c.GreaterThanOrEqual(DateTime.Today.AddDays(1)).OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "RequireType(s) Token with String")]
        public void StringTypeRequireTest()
        {
            var v = ObjectVisitorFactory.Create(Data);

            v.VerifiableEntry.ForMember(x => x.Str, c => c.RequiredType(typeof(string)));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Str, c => c.RequiredTypes<string>().OverwriteRule());

            r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Str, c => c.RequiredTypes<char, string>().OverwriteRule());

            r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Str, c => c.RequiredType(typeof(char)).OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Str, c => c.RequiredTypes(typeof(string), typeof(char)).OverwriteRule());

            r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Str, c => c.RequiredTypes<DateTime, int>().OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "RequireType(s) Token with Char")]
        public void CharTypeRequireTest()
        {
            var v = ObjectVisitorFactory.Create(Data);

            v.VerifiableEntry.ForMember(x => x.Char, c => c.RequiredType(typeof(char)));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Char, c => c.RequiredTypes<char>().OverwriteRule());

            r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Char, c => c.RequiredTypes<char, string>().OverwriteRule());

            r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Char, c => c.RequiredType(typeof(string)).OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Char, c => c.RequiredTypes(typeof(string), typeof(char)).OverwriteRule());

            r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Char, c => c.RequiredTypes<DateTime, string>().OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "RequireType(s) Token with Int32")]
        public void Int32TypeRequireTest()
        {
            var v = ObjectVisitorFactory.Create(Data);

            v.VerifiableEntry.ForMember(x => x.Int32, c => c.RequiredType(typeof(Int32)));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Int32, c => c.RequiredTypes<Int32>().OverwriteRule());

            r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Int32, c => c.RequiredTypes<Int32, string>().OverwriteRule());

            r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Int32, c => c.RequiredType(typeof(string)).OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Int32, c => c.RequiredTypes(typeof(string), typeof(Int32)).OverwriteRule());

            r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.Int32, c => c.RequiredTypes<DateTime, string>().OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "RequireType(s) Token with DateTime")]
        public void DateTimeTypeRequireTest()
        {
            var v = ObjectVisitorFactory.Create(Data);

            v.VerifiableEntry.ForMember(x => x.DateTime, c => c.RequiredType(typeof(DateTime)));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.DateTime, c => c.RequiredTypes<DateTime>().OverwriteRule());

            r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.DateTime, c => c.RequiredTypes<DateTime, string>().OverwriteRule());

            r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.DateTime, c => c.RequiredType(typeof(string)).OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.DateTime, c => c.RequiredTypes(typeof(string), typeof(DateTime)).OverwriteRule());

            r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.DateTime, c => c.RequiredTypes<DateTimeOffset, string>().OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "RequireType(s) Token with Obj")]
        public void ObjTypeRequireTest()
        {
            var v = ObjectVisitorFactory.Create(Data);

            v.VerifiableEntry.ForMember(x => x.SomeObj, c => c.RequiredType(typeof(NiceAct)));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.SomeObj, c => c.RequiredTypes<NiceAct>().OverwriteRule());

            r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.SomeObj, c => c.RequiredTypes<NiceAct, string>().OverwriteRule());

            r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.SomeObj, c => c.RequiredType(typeof(string)).OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.SomeObj, c => c.RequiredTypes(typeof(string), typeof(NiceAct)).OverwriteRule());

            r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.SomeObj, c => c.RequiredTypes<long, int, string>().OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "RequireType(s) Token with NullObj")]
        public void NullObjTypeRequireTest()
        {
            var v = ObjectVisitorFactory.Create(Data);

            v.VerifiableEntry.ForMember(x => x.MustByNullObj, c => c.RequiredType(typeof(object)));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.MustByNullObj, c => c.RequiredTypes<object>().OverwriteRule());

            r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.MustByNullObj, c => c.RequiredTypes<object, string>().OverwriteRule());

            r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.MustByNullObj, c => c.RequiredType(typeof(string)).OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.MustByNullObj, c => c.RequiredTypes(typeof(object), typeof(NiceAct)).OverwriteRule());

            r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.MustByNullObj, c => c.RequiredTypes<long, int, string>().OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "RequireType(s) Token with ObjArray")]
        public void ObjArrayTypeRequireTest()
        {
            var v = ObjectVisitorFactory.Create(Data);

            v.VerifiableEntry.ForMember(x => x.SomeNiceActArray, c => c.RequiredType(typeof(NiceAct[])));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.SomeNiceActArray, c => c.RequiredTypes<NiceAct[]>().OverwriteRule());

            r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.SomeNiceActArray, c => c.RequiredTypes<NiceAct[], string>().OverwriteRule());

            r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.SomeNiceActArray, c => c.RequiredType(typeof(string)).OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.SomeNiceActArray, c => c.RequiredTypes(typeof(string), typeof(NiceAct[])).OverwriteRule());

            r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.SomeNiceActArray, c => c.RequiredTypes<long, NiceAct, string>().OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "RequireType(s) Token with ObjList")]
        public void ObjListTypeRequireTest()
        {
            var v = ObjectVisitorFactory.Create(Data);

            v.VerifiableEntry.ForMember(x => x.SomeNiceActList, c => c.RequiredType(typeof(List<NiceAct>)));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.SomeNiceActList, c => c.RequiredTypes<List<NiceAct>>().OverwriteRule());

            r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.SomeNiceActList, c => c.RequiredTypes<List<NiceAct>, string>().OverwriteRule());

            r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.SomeNiceActList, c => c.RequiredType(typeof(string)).OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.SomeNiceActList, c => c.RequiredTypes(typeof(string), typeof(List<NiceAct>)).OverwriteRule());

            r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(x => x.SomeNiceActList, c => c.RequiredTypes<long, NiceAct[], string>().OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "ScalePrecision Token with Decimal and should be valid")]
        public void DecimalScalePrecisionShouldBeValidTest()
        {
            var v = ObjectVisitorFactory.Create<NiceAct2>();
            v.VerifiableEntry.ForMember(x => x.Discount, c => c.ScalePrecision(2, 4));

            v.SetValue(x => x.Discount, 12.34M);
            var r = v.Verify();
            Assert.True(r.IsValid);

            v.SetValue(x => x.Discount, 2.34M);
            r = v.Verify();
            Assert.True(r.IsValid);

            v.SetValue(x => x.Discount, -2.34M);
            r = v.Verify();
            Assert.True(r.IsValid);

            v.SetValue(x => x.Discount, 0.34M);
            r = v.Verify();
            Assert.True(r.IsValid);
        }

        [Fact(DisplayName = "ScalePrecision Token with Decimal and should not be valid")]
        public void DecimalScalePrecisionShouldNotBeValidTest()
        {
            var v = ObjectVisitorFactory.Create<NiceAct2>();
            v.VerifiableEntry.ForMember(x => x.Discount, c => c.ScalePrecision(2, 4));

            v.SetValue(x => x.Discount, 123.456778M);
            var r = v.Verify();
            Assert.False(r.IsValid);

            v.SetValue(x => x.Discount, 12.341M);
            r = v.Verify();
            Assert.False(r.IsValid);

            v.SetValue(x => x.Discount, 1.341M);
            r = v.Verify();
            Assert.False(r.IsValid);

            v.SetValue(x => x.Discount, 134.1M);
            r = v.Verify();
            Assert.False(r.IsValid);

            v.SetValue(x => x.Discount, 13.401M);
            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "ScalePrecision Token with Decimal and should be valid when equal")]
        public void DecimalScalePrecisionShouldBeValidWhenEqualTest()
        {
            var v = ObjectVisitorFactory.Create<NiceAct2>();
            v.VerifiableEntry.ForMember(x => x.Discount, c => c.ScalePrecision(2, 2));

            v.SetValue(x => x.Discount, 0.34M);
            var r = v.Verify();
            Assert.True(r.IsValid);

            v.SetValue(x => x.Discount, 0.3M);
            r = v.Verify();
            Assert.True(r.IsValid);

            v.SetValue(x => x.Discount, 0M);
            r = v.Verify();
            Assert.True(r.IsValid);

            v.SetValue(x => x.Discount, -0.34M);
            r = v.Verify();
            Assert.True(r.IsValid);
        }

        [Fact(DisplayName = "ScalePrecision Token with Decimal and should not be valid when equal")]
        public void DecimalScalePrecisionShouldNotBeValidWhenEqualTest()
        {
            var v = ObjectVisitorFactory.Create<NiceAct2>();
            v.VerifiableEntry.ForMember(x => x.Discount, c => c.ScalePrecision(2, 2));

            v.SetValue(x => x.Discount, 123.456778M);
            var r = v.Verify();
            Assert.False(r.IsValid);

            v.SetValue(x => x.Discount, 0.331M);
            r = v.Verify();
            Assert.False(r.IsValid);

            v.SetValue(x => x.Discount, 1.34M);
            r = v.Verify();
            Assert.False(r.IsValid);

            v.SetValue(x => x.Discount, 1M);
            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "ScalePrecision Token with Decimal and should be valid when ignore trailing zeroes")]
        public void DecimalScalePrecisionShouldBeValidWhenIgnoreTrailingZeroesTest()
        {
            var v = ObjectVisitorFactory.Create<NiceAct2>();
            v.VerifiableEntry.ForMember(x => x.Discount, c => c.ScalePrecision(2, 4, true));

            v.SetValue(x => x.Discount, 15.0000000000000000000000000M);
            var r = v.Verify();
            Assert.True(r.IsValid);

            v.SetValue(x => x.Discount, 0000000000000000000015.0000000000000000000000000M);
            r = v.Verify();
            Assert.True(r.IsValid);

            v.SetValue(x => x.Discount, 65.430M);
            r = v.Verify();
            Assert.True(r.IsValid);
        }

        [Fact(DisplayName = "ScalePrecision Token with Decimal and should not be valid when ignore trailing zeroes")]
        public void DecimalScalePrecisionShouldNotBeValidWhenIgnoreTrailingZeroesTest()
        {
            var v = ObjectVisitorFactory.Create<NiceAct2>();
            v.VerifiableEntry.ForMember(x => x.Discount, c => c.ScalePrecision(2, 4, true));

            v.SetValue(x => x.Discount, 1565.0M);
            var r = v.Verify();
            Assert.False(r.IsValid);

            v.SetValue(x => x.Discount, 15.0000000000000000000000001M);
            r = v.Verify();
            Assert.False(r.IsValid);
        }


        [Fact(DisplayName = "Enum Token basic test")]
        public void EnumValidTest()
        {
            var n1 = new NiceAct2() {Country = Country.China};
            var n2 = new NiceAct2() {Country = (Country) 1};

            var v1 = ObjectVisitorFactory.Create(n1);
            var v2 = ObjectVisitorFactory.Create(n2);

            v1.VerifiableEntry.ForMember(z => z.Country, x => x.InEnum(typeof(Country)));
            v2.VerifiableEntry.ForMember(z => z.Country, x => x.InEnum(typeof(Country)));

            var r1 = v1.Verify();
            var r2 = v2.Verify();
            Assert.True(r1.IsValid);
            Assert.True(r2.IsValid);

            v1.VerifiableEntry.ForMember(z => z.Country, c => c.InEnum<Country>().OverwriteRule());
            v2.VerifiableEntry.ForMember(z => z.Country, c => c.InEnum<Country>().OverwriteRule());

            r1 = v1.Verify();
            r2 = v2.Verify();
            Assert.True(r1.IsValid);
            Assert.True(r2.IsValid);
        }

        [Fact(DisplayName = "Enum Token with non-init enum value should not be valid")]
        public void EnumWithValidValueAndWithoutInitThenShouldBeFailTest()
        {
            var v = ObjectVisitorFactory.Create<NiceAct2>();

            v.VerifiableEntry.ForMember(z => z.Country, x => x.InEnum(typeof(Country)));

            var r = v.Verify();
            Assert.False(r.IsValid);

            v.VerifiableEntry.ForMember(z => z.Country, c => c.InEnum<Country>().OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "Enum Token with invalid value should not be valid")]
        public void EnumWithInvalidValueThenShouldBeFailTest()
        {
            var v = ObjectVisitorFactory.Create<NiceAct2>();
            v["Country"] = (Country) 100;

            v.VerifiableEntry.ForMember(z => z.Country, x => x.InEnum(typeof(Country)));

            var r = v.Verify();
            Assert.False(r.IsValid);

            v.VerifiableEntry.ForMember(z => z.Country, c => c.InEnum<Country>().OverwriteRule());

            r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "Enum Token with nullable value without init should not valid")]
        public void EnumWithNullableTypeAndWithoutInitTest()
        {
            var v = ObjectVisitorFactory.Create(new NiceAct3());
            v.VerifiableEntry.ForMember(z => z.Country, c => c.InEnum(typeof(Country)));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.VerifiableEntry.ForMember(z => z.Country, c => c.InEnum<Country>().OverwriteRule());

            r = v.Verify();
            Assert.True(r.IsValid);
        }

        [Fact(DisplayName = "Enum Token with nullable value with init should not valid")]
        public void EnumWithNullableTypeAndWithInitTest()
        {
            var v1 = ObjectVisitorFactory.Create(new NiceAct3() {Country = Country.China});
            var v2 = ObjectVisitorFactory.Create(new NiceAct3() {Country = (Country) 1});

            v1.VerifiableEntry.ForMember(z => z.Country, c => c.InEnum(typeof(Country)));
            v2.VerifiableEntry.ForMember(z => z.Country, c => c.InEnum(typeof(Country)));

            var r1 = v1.Verify();
            var r2 = v2.Verify();
            Assert.True(r1.IsValid);
            Assert.True(r2.IsValid);

            v1.VerifiableEntry.ForMember(z => z.Country, c => c.InEnum<Country>().OverwriteRule());
            v2.VerifiableEntry.ForMember(z => z.Country, c => c.InEnum<Country>().OverwriteRule());

            r1 = v1.Verify();
            r2 = v2.Verify();
            Assert.True(r1.IsValid);
            Assert.True(r2.IsValid);
        }

        [Fact(DisplayName = "Enum Token with flag value when using bitwise value should valid")]
        public void FlagEnumWhenUsingBitwiseValueTest()
        {
            var m = new FlagsEnumModel();
            m.PopulateWithValidValues();

            var v = ObjectVisitorFactory.Create(m);

            v.VerifiableEntry
             .ForMember(z => z.SByteValue, c => c.InEnum(typeof(SByteEnum)))
             .ForMember(z => z.ByteValue, c => c.InEnum(typeof(ByteEnum)))
             .ForMember(z => z.Int16Value, c => c.InEnum(typeof(Int16Enum)))
             .ForMember(z => z.Int32Value, c => c.InEnum(typeof(Int32Enum)))
             .ForMember(z => z.Int64Value, c => c.InEnum(typeof(Int64Enum)))
             .ForMember(z => z.UInt16Value, c => c.InEnum(typeof(UInt16Enum)))
             .ForMember(z => z.UInt32Value, c => c.InEnum(typeof(UInt32Enum)))
             .ForMember(z => z.UInt64Value, c => c.InEnum(typeof(UInt64Enum)))
             .ForMember(z => z.EnumWithNegativesValue, c => c.InEnum(typeof(EnumWithNegatives)))
             .ForMember(z => z.EnumWithOverlappingFlagsValue, c => c.InEnum(typeof(EnumWithOverlappingFlags)));

            var r = v.Verify();
            Assert.True(r.IsValid);

            v.SetValue(z => z.EnumWithNegativesValue, EnumWithNegatives.All);

            r = v.Verify();
            Assert.True(r.IsValid);
        }

        [Fact(DisplayName = "Enum Token with flag value and OverlappingFlags when using bitwise value should valid")]
        public void FlagEnumWhenUsingBitwiseValueWithOverlappingFlagsTest()
        {
            var m = new FlagsEnumModel();
            var v = ObjectVisitorFactory.Create(m);
            v.VerifiableEntry.ForMember(z => z.EnumWithOverlappingFlagsValue, c => c.InEnum(typeof(EnumWithOverlappingFlags)));

            VerifyResult r = null;

            v["EnumWithOverlappingFlagsValue"] = EnumWithOverlappingFlags.A | EnumWithOverlappingFlags.B;
            r = v.Verify();
            Assert.True(r.IsValid);

            v["EnumWithOverlappingFlagsValue"] = EnumWithOverlappingFlags.B | EnumWithOverlappingFlags.C;
            r = v.Verify();
            Assert.True(r.IsValid);

            v["EnumWithOverlappingFlagsValue"] = EnumWithOverlappingFlags.A | EnumWithOverlappingFlags.C;
            r = v.Verify();
            Assert.True(r.IsValid);

            v["EnumWithOverlappingFlagsValue"] = EnumWithOverlappingFlags.A | EnumWithOverlappingFlags.B | EnumWithOverlappingFlags.C;
            r = v.Verify();
            Assert.True(r.IsValid);
        }

        [Fact(DisplayName = "Enum Token with flag value when using zero value")]
        public void FlagEnumWhenUsingZeroValueTest()
        {
            var m = new FlagsEnumModel();
            var v = ObjectVisitorFactory.Create(m);

            v.VerifiableEntry
             .ForMember(z => z.SByteValue, c => c.InEnum(typeof(SByteEnum)))
             .ForMember(z => z.ByteValue, c => c.InEnum(typeof(ByteEnum)))
             .ForMember(z => z.Int16Value, c => c.InEnum(typeof(Int16Enum)))
             .ForMember(z => z.Int32Value, c => c.InEnum(typeof(Int32Enum)))
             .ForMember(z => z.Int64Value, c => c.InEnum(typeof(Int64Enum)))
             .ForMember(z => z.UInt16Value, c => c.InEnum(typeof(UInt16Enum)))
             .ForMember(z => z.UInt32Value, c => c.InEnum(typeof(UInt32Enum)))
             .ForMember(z => z.UInt64Value, c => c.InEnum(typeof(UInt64Enum)))
             .ForMember(z => z.EnumWithNegativesValue, c => c.InEnum(typeof(EnumWithNegatives)))
             .ForMember(z => z.EnumWithOverlappingFlagsValue, c => c.InEnum(typeof(EnumWithOverlappingFlags)));

            var r = v.Verify();
            Assert.False(r.IsValid);
            Assert.NotNull(r.Errors.SingleOrDefault(x => x.PropertyName == "EnumWithNegativesValue"));
            Assert.NotNull(r.Errors.SingleOrDefault(x => x.PropertyName == "EnumWithOverlappingFlagsValue"));
            Assert.Equal(2, r.Errors.Count);
        }

        [Fact(DisplayName = "Enum Token with flag value when using positive value")]
        public void FlagEnumWhenUsingOutOfRangePositiveValueTest()
        {
            var m = new FlagsEnumModel();
            m.PopulateWithInvalidPositiveValues();
            var v = ObjectVisitorFactory.Create(m);

            v.VerifiableEntry
             .ForMember(z => z.SByteValue, c => c.InEnum(typeof(SByteEnum)))
             .ForMember(z => z.ByteValue, c => c.InEnum(typeof(ByteEnum)))
             .ForMember(z => z.Int16Value, c => c.InEnum(typeof(Int16Enum)))
             .ForMember(z => z.Int32Value, c => c.InEnum(typeof(Int32Enum)))
             .ForMember(z => z.Int64Value, c => c.InEnum(typeof(Int64Enum)))
             .ForMember(z => z.UInt16Value, c => c.InEnum(typeof(UInt16Enum)))
             .ForMember(z => z.UInt32Value, c => c.InEnum(typeof(UInt32Enum)))
             .ForMember(z => z.UInt64Value, c => c.InEnum(typeof(UInt64Enum)))
             .ForMember(z => z.EnumWithNegativesValue, c => c.InEnum(typeof(EnumWithNegatives)))
             .ForMember(z => z.EnumWithOverlappingFlagsValue, c => c.InEnum(typeof(EnumWithOverlappingFlags)));

            var r = v.Verify();
            Assert.False(r.IsValid);
            Assert.NotNull(r.Errors.SingleOrDefault(x => x.PropertyName == "SByteValue"));
            Assert.NotNull(r.Errors.SingleOrDefault(x => x.PropertyName == "ByteValue"));
            Assert.NotNull(r.Errors.SingleOrDefault(x => x.PropertyName == "Int16Value"));
            Assert.NotNull(r.Errors.SingleOrDefault(x => x.PropertyName == "Int32Value"));
            Assert.NotNull(r.Errors.SingleOrDefault(x => x.PropertyName == "Int64Value"));
            Assert.NotNull(r.Errors.SingleOrDefault(x => x.PropertyName == "UInt16Value"));
            Assert.NotNull(r.Errors.SingleOrDefault(x => x.PropertyName == "UInt32Value"));
            Assert.NotNull(r.Errors.SingleOrDefault(x => x.PropertyName == "UInt64Value"));
            Assert.NotNull(r.Errors.SingleOrDefault(x => x.PropertyName == "EnumWithNegativesValue"));
        }

        [Fact(DisplayName = "Enum Token with flag value when using negative value")]
        public void FlagEnumWhenUsingOutOfRangeNegativeValueTest()
        {
            var m = new FlagsEnumModel();
            m.PopulateWithInvalidNegativeValues();
            var v = ObjectVisitorFactory.Create(m);

            v.VerifiableEntry
             .ForMember(z => z.SByteValue, c => c.InEnum(typeof(SByteEnum)))
             .ForMember(z => z.ByteValue, c => c.InEnum(typeof(ByteEnum)))
             .ForMember(z => z.Int16Value, c => c.InEnum(typeof(Int16Enum)))
             .ForMember(z => z.Int32Value, c => c.InEnum(typeof(Int32Enum)))
             .ForMember(z => z.Int64Value, c => c.InEnum(typeof(Int64Enum)))
             .ForMember(z => z.UInt16Value, c => c.InEnum(typeof(UInt16Enum)))
             .ForMember(z => z.UInt32Value, c => c.InEnum(typeof(UInt32Enum)))
             .ForMember(z => z.UInt64Value, c => c.InEnum(typeof(UInt64Enum)))
             .ForMember(z => z.EnumWithNegativesValue, c => c.InEnum(typeof(EnumWithNegatives)))
             .ForMember(z => z.EnumWithOverlappingFlagsValue, c => c.InEnum(typeof(EnumWithOverlappingFlags)));

            var r = v.Verify();
            Assert.False(r.IsValid);
            Assert.NotNull(r.Errors.SingleOrDefault(x => x.PropertyName == "SByteValue"));
            Assert.NotNull(r.Errors.SingleOrDefault(x => x.PropertyName == "Int16Value"));
            Assert.NotNull(r.Errors.SingleOrDefault(x => x.PropertyName == "Int32Value"));
            Assert.NotNull(r.Errors.SingleOrDefault(x => x.PropertyName == "Int64Value"));
        }

        [Fact(DisplayName = "StringEnum Token with CaseInsensitive and CaseCorrect")]
        public void StringEnumCaseInsensitiveAndCaseCorrectTest()
        {
            var v1 = ObjectVisitorFactory.Create(new NiceAct3() {CountryString = "China"});
            var v2 = ObjectVisitorFactory.Create(new NiceAct3() {CountryString = "USA"});

            v1.VerifiableEntry.ForMember(x => x.CountryString, c => c.IsEnumName(typeof(Country), false));
            v2.VerifiableEntry.ForMember(x => x.CountryString, c => c.IsEnumName(typeof(Country), false));

            var r1 = v1.Verify();
            var r2 = v2.Verify();

            Assert.True(r1.IsValid);
            Assert.True(r2.IsValid);

            v1.VerifiableEntry.ForMember(x => x.CountryString, c => c.IsEnumName<Country>(false).OverwriteRule());
            v2.VerifiableEntry.ForMember(x => x.CountryString, c => c.IsEnumName<Country>(false).OverwriteRule());

            r1 = v1.Verify();
            r2 = v2.Verify();

            Assert.True(r1.IsValid);
            Assert.True(r2.IsValid);
        }

        [Fact(DisplayName = "StringEnum Token with CaseInsensitive and CaseIncorrect")]
        public void StringEnumCaseInsensitiveAndCaseIncorrectTest()
        {
            var v1 = ObjectVisitorFactory.Create(new NiceAct3() {CountryString = "chinA"});
            var v2 = ObjectVisitorFactory.Create(new NiceAct3() {CountryString = "usa"});

            v1.VerifiableEntry.ForMember(x => x.CountryString, c => c.IsEnumName(typeof(Country), false));
            v2.VerifiableEntry.ForMember(x => x.CountryString, c => c.IsEnumName(typeof(Country), false));

            var r1 = v1.Verify();
            var r2 = v2.Verify();

            Assert.True(r1.IsValid);
            Assert.True(r2.IsValid);

            v1.VerifiableEntry.ForMember(x => x.CountryString, c => c.IsEnumName<Country>(false).OverwriteRule());
            v2.VerifiableEntry.ForMember(x => x.CountryString, c => c.IsEnumName<Country>(false).OverwriteRule());

            r1 = v1.Verify();
            r2 = v2.Verify();

            Assert.True(r1.IsValid);
            Assert.True(r2.IsValid);
        }

        [Fact(DisplayName = "StringEnum Token with CaseSensitive and CaseCorrect")]
        public void StringEnumCaseSensitiveAndCaseCorrectTest()
        {
            var v1 = ObjectVisitorFactory.Create(new NiceAct3() {CountryString = "China"});
            var v2 = ObjectVisitorFactory.Create(new NiceAct3() {CountryString = "USA"});

            v1.VerifiableEntry.ForMember(x => x.CountryString, c => c.IsEnumName(typeof(Country), true));
            v2.VerifiableEntry.ForMember(x => x.CountryString, c => c.IsEnumName(typeof(Country), true));

            var r1 = v1.Verify();
            var r2 = v2.Verify();

            Assert.True(r1.IsValid);
            Assert.True(r2.IsValid);

            v1.VerifiableEntry.ForMember(x => x.CountryString, c => c.IsEnumName<Country>(true).OverwriteRule());
            v2.VerifiableEntry.ForMember(x => x.CountryString, c => c.IsEnumName<Country>(true).OverwriteRule());

            r1 = v1.Verify();
            r2 = v2.Verify();

            Assert.True(r1.IsValid);
            Assert.True(r2.IsValid);
        }

        [Fact(DisplayName = "StringEnum Token with CaseSensitive and CaseIncorrect")]
        public void StringEnumCaseSensitiveAndCaseIncorrectTest()
        {
            var v1 = ObjectVisitorFactory.Create(new NiceAct3() {CountryString = "chinA"});
            var v2 = ObjectVisitorFactory.Create(new NiceAct3() {CountryString = "uSA"});

            v1.VerifiableEntry.ForMember(x => x.CountryString, c => c.IsEnumName(typeof(Country), true));
            v2.VerifiableEntry.ForMember(x => x.CountryString, c => c.IsEnumName(typeof(Country), true));

            var r1 = v1.Verify();
            var r2 = v2.Verify();

            Assert.False(r1.IsValid);
            Assert.False(r2.IsValid);

            v1.VerifiableEntry.ForMember(x => x.CountryString, c => c.IsEnumName<Country>(true).OverwriteRule());
            v2.VerifiableEntry.ForMember(x => x.CountryString, c => c.IsEnumName<Country>(true).OverwriteRule());

            r1 = v1.Verify();
            r2 = v2.Verify();

            Assert.False(r1.IsValid);
            Assert.False(r2.IsValid);
        }

        [Fact(DisplayName = "StringEnum Token with wrong value")]
        public void StringEnumWithWrongValueTest()
        {
            var v = ObjectVisitorFactory.Create(new NiceAct3() {CountryString = "VVVV"});
            v.VerifiableEntry.ForMember(x => x.CountryString, c => c.IsEnumName(typeof(Country), true));
            var r = v.Verify();
            Assert.False(r.IsValid);
        }

        [Fact(DisplayName = "StringEnum Token with empty value")]
        public void StringEnumWithEmptyValueTest()
        {
            var v = ObjectVisitorFactory.Create(new NiceAct3() {CountryString = string.Empty});
            v.VerifiableEntry.ForMember(x => x.CountryString, c => c.IsEnumName(typeof(Country), true));
            var r = v.Verify();
            Assert.False(r.IsValid);
            Assert.Throws<ValidationException>(() => r.Raise(""));
        }

        [Fact(DisplayName = "StringEnum Token with null value")]
        public void StringEnumWithNullValueTest()
        {
            var v = ObjectVisitorFactory.Create(new NiceAct3() {CountryString = null});
            v.VerifiableEntry.ForMember(x => x.CountryString, c => c.IsEnumName(typeof(Country), true));
            var r = v.Verify();
            Assert.True(r.IsValid);
        }

        [Fact(DisplayName = "StringEnum Token with null strategy")]
        public void StringEnumWithNullStrategyTest()
        {
            var v = ObjectVisitorFactory.Create(new NiceAct3() {CountryString = null});
            Assert.Throws<ArgumentNullException>(() =>
            {
                v.VerifiableEntry.ForMember(x => x.CountryString, c => c.IsEnumName(null, true));
                v.VerifyAndThrow();
            });
        }

        [Fact(DisplayName = "RegexExpression Token test")]
        public void RegexExpressionTest()
        {
            var m = new NiceAct3() {StringVal = "53"};
            var v = ObjectVisitorFactory.Create(m);
        
            v.VerifiableEntry.ForMember(x => x.StringVal, c => c.Matches(@"^\w\d$"));
        
            var r = v.Verify();
            Assert.True(r.IsValid);
        
            v["StringVal"] = " 5";
            r = v.Verify();
            Assert.False(r.IsValid);
        
            v["StringVal"] = "S33";
            r = v.Verify();
            Assert.False(r.IsValid);
        
            v["StringVal"] = "";
            r = v.Verify();
            Assert.False(r.IsValid);
        
            v["StringVal"] = null;
            r = v.Verify();
            Assert.False(r.IsValid);
            
            v.VerifiableEntry.ForMember("StringVal", c => c.Matches(@"^\w\d$").WithMessage("OH", false).OverwriteRule());
            r = v.Verify();
            Assert.False(r.IsValid);
            Assert.NotNull(r.Errors.SingleOrDefault(x => x.PropertyName == "StringVal"));
            Assert.Equal("OH", r.Errors.Single(x => x.PropertyName == "StringVal").Details[0].ErrorMessage);
        }
        
        [Fact(DisplayName = "RegexExpression Token with String test")]
        public void RegexExpressionStringTest()
        {
            var m = new NiceAct3() {StringVal = "53", RegexExpression = @"^\w\d$"};
            var v = ObjectVisitorFactory.Create(m);
            
            v.VerifiableEntry.ForMember(x => x.StringVal, c => c.Matches(u => u.RegexExpression));
            
            var r = v.Verify();
            Assert.True(r.IsValid);
            
            v["StringVal"] = " 5";
            r = v.Verify();
            Assert.False(r.IsValid);
            
            v["StringVal"] = "S33";
            r = v.Verify();
            Assert.False(r.IsValid);
            
            v["StringVal"] = "";
            r = v.Verify();
            Assert.False(r.IsValid);
        
            v["StringVal"] = null;
            r = v.Verify();
            Assert.False(r.IsValid);
        }
        
        [Fact(DisplayName = "RegexExpression Token with Regex object test")]
        public void RegexExpressionRegexObjTest()
        {
            var regex = new Regex(@"^\w\d$");
            var m = new NiceAct3() {StringVal = "53", Regex =regex};
            var v = ObjectVisitorFactory.Create(m);
        
            v.VerifiableEntry.ForMember(x => x.StringVal, c => c.Matches(u => u.Regex));
            
            var r = v.Verify();
            Assert.True(r.IsValid);
        
            v["StringVal"] = " 5";
            r = v.Verify();
            Assert.False(r.IsValid);
        
            v["StringVal"] = "S33";
            r = v.Verify();
            Assert.False(r.IsValid);
        
            v["StringVal"] = "";
            r = v.Verify();
            Assert.False(r.IsValid);
        
            v["StringVal"] = null;
            r = v.Verify();
            Assert.False(r.IsValid);
        }
    }
}