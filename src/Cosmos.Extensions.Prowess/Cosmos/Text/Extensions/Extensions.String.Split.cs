﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Cosmos.Collections;

// ReSharper disable once CheckNamespace
namespace Cosmos.Text
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// 根据给定的 splitCode 对字符串进行切割
        /// </summary>
        /// <param name="string"></param>
        /// <param name="separator">分隔符</param>
        /// <returns></returns>
        public static string[] Split(this string @string, string separator) => Regex.Split(@string, separator);

        // ReSharper disable once InconsistentNaming
        private static readonly Regex mSplitWords = new Regex(@"\W+");

        /// <summary>
        /// Split in words
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string[] SplitInWords(this string s)
        {
            //
            // Split on all non-word characters.
            // ... Returns an array of all the words.
            //
            return mSplitWords.Split(s);
            // @      special verbatim string syntax
            // \W+    one or more non-word characters together
        }

        /// <summary>
        /// Split in words longer than...
        /// </summary>
        /// <param name="s"></param>
        /// <param name="wordLen"></param>
        /// <returns></returns>
        public static IEnumerable<string> SplitInWordsLongerThan(this string s, int wordLen)
        {
            return mSplitWords.Split(s).Where(word => word.Length > wordLen);
        }

        /// <summary>
        /// Split in lines
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string[] SplitInLines(this string s)
        {
            return s.Split(new[] {Environment.NewLine}, StringSplitOptions.None);
        }

        /// <summary>
        /// Split in lines
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="s"></param>
        /// <returns></returns>
        public static T[] SplitInLinesTyped<T>(this string s) where T : IComparable
        {
            return SplitTyped<T>(s, Environment.NewLine);
        }

        /// <summary>
        /// Split in lines and remove empty
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string[] SplitInLinesRemoveEmptys(this string s)
        {
            return s.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Split by index
        /// </summary>
        /// <param name="text"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static Tuple<string, string> SplitByIndex(this string text, int index)
        {
            if (text.IsNullOrEmpty())
                return new Tuple<string, string>("", "");

            if (index >= text.Length)
                return new Tuple<string, string>(text, "");

            if (index <= 0)
                return new Tuple<string, string>("", text);

            return new Tuple<string, string>(text.Substring(0, index - 1), text.Substring(index - 1));
        }

        /// <summary>
        /// Split words by index
        /// </summary>
        /// <param name="text"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static Tuple<string, string> SplitWordsByIndex(this string text, int index)
        {
            var splitByIndex = text.SplitByIndex(index);
            var res = new Tuple<string, string>(splitByIndex.Item1, splitByIndex.Item2);

            var wordsInItem1 = res.Item1.SplitInWords();
            res = new Tuple<string, string>(wordsInItem1.Take(wordsInItem1.Length - 1).JoinToString(" ").Trim(), wordsInItem1.Last() + splitByIndex.Item2);

            return res;
        }

        /// <summary>
        /// Split
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="me"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static T[] SplitTyped<T>(this string me, char delimiter) where T : IComparable
        {
            if (me.IsNullOrWhiteSpace())
                return new T[] { };

            me = me.Trim();

            var parts = me.Split(new[] {delimiter}, StringSplitOptions.RemoveEmptyEntries);

            var res = new T[parts.Length];

            for (int i = 0; i < parts.Length; i++)
            {
                res[i] = (T) Convert.ChangeType(parts[i], typeof(T));
            }

            return res;
        }

        /// <summary>
        /// Split
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="me"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static T[] SplitTyped<T>(this string me, string delimiter) where T : IComparable
        {
            if (me.IsNullOrWhiteSpace())
                return new T[] { };

            me = me.Trim();

            var parts = me.Split(new[] {delimiter}, StringSplitOptions.RemoveEmptyEntries);

            var res = new T[parts.Length];

            for (int i = 0; i < parts.Length; i++)
            {
                res[i] = (T) Convert.ChangeType(parts[i], typeof(T));
            }

            return res;
        }
    }
}