//-----------------------------------------------------------------------------
// <auto-generated>
//     This file was generated by the C# SDK Code Generator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//-----------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Scripting;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Unity.Services.Leaderboards.Authoring.Client.Http;



namespace Unity.Services.Leaderboards.Authoring.Client.Models
{
    /// <summary>
    /// LeaderboardVersionScoresPage1 model
    /// </summary>
    [Preserve]
    [DataContract(Name = "LeaderboardVersionScoresPage_1")]
    internal class LeaderboardVersionScoresPage1
    {
        /// <summary>
        /// Creates an instance of LeaderboardVersionScoresPage1.
        /// </summary>
        /// <param name="version">version param</param>
        /// <param name="offset">offset param</param>
        /// <param name="limit">limit param</param>
        /// <param name="total">total param</param>
        /// <param name="results">results param</param>
        [Preserve]
        public LeaderboardVersionScoresPage1(LeaderboardVersion1 version = default, int offset = default, int limit = default, int total = default, List<LeaderboardEntry1> results = default)
        {
            Version = version;
            Offset = offset;
            Limit = limit;
            Total = total;
            Results = results;
        }

        /// <summary>
        /// Parameter version of LeaderboardVersionScoresPage1
        /// </summary>
        [Preserve]
        [DataMember(Name = "version", EmitDefaultValue = false)]
        public LeaderboardVersion1 Version{ get; }
        
        /// <summary>
        /// Parameter offset of LeaderboardVersionScoresPage1
        /// </summary>
        [Preserve]
        [DataMember(Name = "offset", EmitDefaultValue = false)]
        public int Offset{ get; }
        
        /// <summary>
        /// Parameter limit of LeaderboardVersionScoresPage1
        /// </summary>
        [Preserve]
        [DataMember(Name = "limit", EmitDefaultValue = false)]
        public int Limit{ get; }
        
        /// <summary>
        /// Parameter total of LeaderboardVersionScoresPage1
        /// </summary>
        [Preserve]
        [DataMember(Name = "total", EmitDefaultValue = false)]
        public int Total{ get; }
        
        /// <summary>
        /// Parameter results of LeaderboardVersionScoresPage1
        /// </summary>
        [Preserve]
        [DataMember(Name = "results", EmitDefaultValue = false)]
        public List<LeaderboardEntry1> Results{ get; }
    
        /// <summary>
        /// Formats a LeaderboardVersionScoresPage1 into a string of key-value pairs for use as a path parameter.
        /// </summary>
        /// <returns>Returns a string representation of the key-value pairs.</returns>
        internal string SerializeAsPathParam()
        {
            var serializedModel = "";

            if (Version != null)
            {
                serializedModel += "version," + Version.ToString() + ",";
            }
            serializedModel += "offset," + Offset.ToString() + ",";
            serializedModel += "limit," + Limit.ToString() + ",";
            serializedModel += "total," + Total.ToString() + ",";
            if (Results != null)
            {
                serializedModel += "results," + Results.ToString();
            }
            return serializedModel;
        }

        /// <summary>
        /// Returns a LeaderboardVersionScoresPage1 as a dictionary of key-value pairs for use as a query parameter.
        /// </summary>
        /// <returns>Returns a dictionary of string key-value pairs.</returns>
        internal Dictionary<string, string> GetAsQueryParam()
        {
            var dictionary = new Dictionary<string, string>();

            var offsetStringValue = Offset.ToString();
            dictionary.Add("offset", offsetStringValue);
            
            var limitStringValue = Limit.ToString();
            dictionary.Add("limit", limitStringValue);
            
            var totalStringValue = Total.ToString();
            dictionary.Add("total", totalStringValue);
            
            return dictionary;
        }
    }
}