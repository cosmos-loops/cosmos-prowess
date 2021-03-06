using System;
using System.Collections.Generic;
using Cosmos.Serialization;

namespace Cosmos.Splitters
{
    /// <summary>
    /// Fixed length splitter interface
    /// </summary>
    public interface IFixedLengthSplitter
    {
        /// <summary>
        /// Trim results
        /// </summary>
        /// <returns></returns>
        IFixedLengthSplitter TrimResults();

        /// <summary>
        /// Trim results
        /// </summary>
        /// <param name="trimFunc"></param>
        /// <returns></returns>
        IFixedLengthSplitter TrimResults(Func<string, string> trimFunc);

        /// <summary>
        /// Limit
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        IFixedLengthSplitter Limit(int limit);

        /// <summary>
        /// With KeyValue separator
        /// </summary>
        /// <param name="separator"></param>
        /// <returns></returns>
        IMapSplitter WithKeyValueSeparator(char separator);

        /// <summary>
        /// With KeyValue separator
        /// </summary>
        /// <param name="separator"></param>
        /// <returns></returns>
        IMapSplitter WithKeyValueSeparator(string separator);

        /// <summary>
        /// Split
        /// </summary>
        /// <param name="originalString"></param>
        /// <returns></returns>
        IEnumerable<string> Split(string originalString);

        /// <summary>
        /// Split
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalString"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        IEnumerable<T> Split<T>(string originalString, IObjectSerializer serializer);

        /// <summary>
        /// Split
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalString"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        IEnumerable<T> Split<T>(string originalString, ITypeConverter<string, T> converter);

        /// <summary>
        /// Split
        /// </summary>
        /// <typeparam name="TMiddle"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalString"></param>
        /// <param name="serializer"></param>
        /// <param name="mapper"></param>
        /// <returns></returns>
        IEnumerable<T> Split<TMiddle, T>(string originalString, IObjectSerializer serializer, IGenericObjectMapper mapper);

        /// <summary>
        /// Split to list
        /// </summary>
        /// <param name="originalString"></param>
        /// <returns></returns>
        List<string> SplitToList(string originalString);

        /// <summary>
        /// Split to list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalString"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        List<T> SplitToList<T>(string originalString, IObjectSerializer serializer);

        /// <summary>
        /// Split to list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalString"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        List<T> SplitToList<T>(string originalString, ITypeConverter<string, T> converter);

        /// <summary>
        /// Split to list
        /// </summary>
        /// <typeparam name="TMiddle"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalString"></param>
        /// <param name="serializer"></param>
        /// <param name="mapper"></param>
        /// <returns></returns>
        List<T> SplitToList<TMiddle, T>(string originalString, IObjectSerializer serializer, IGenericObjectMapper mapper);
        
        /// <summary>
        /// Split to array
        /// </summary>
        /// <param name="originalString"></param>
        /// <returns></returns>
        string[] SplitToArray(string originalString);

        /// <summary>
        /// Split to array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalString"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        T[] SplitToArray<T>(string originalString, IObjectSerializer serializer);

        /// <summary>
        /// Split to array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalString"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        T[] SplitToArray<T>(string originalString, ITypeConverter<string, T> converter);

        /// <summary>
        /// Split to array
        /// </summary>
        /// <typeparam name="TMiddle"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalString"></param>
        /// <param name="serializer"></param>
        /// <param name="mapper"></param>
        /// <returns></returns>
        T[] SplitToArray<TMiddle, T>(string originalString, IObjectSerializer serializer, IGenericObjectMapper mapper);
    }
}