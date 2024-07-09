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
    /// Configuration for tiers to be applied to the Leaderboard.
    /// </summary>
    [Preserve]
    [DataContract(Name = "LeaderboardConfig_1_tieringConfig")]
    internal class LeaderboardConfig1TieringConfig
    {
        /// <summary>
        /// Configuration for tiers to be applied to the Leaderboard.
        /// </summary>
        /// <param name="strategy">The tiering strategy to use when determining what tier a player is in</param>
        /// <param name="tiers">tiers param</param>
        [Preserve]
        public LeaderboardConfig1TieringConfig(StrategyOptions strategy, List<LeaderboardConfig1TieringConfigTiersInner> tiers)
        {
            Strategy = strategy;
            Tiers = tiers;
        }

        /// <summary>
        /// The tiering strategy to use when determining what tier a player is in
        /// </summary>
        [Preserve]
        [JsonConverter(typeof(StringEnumConverter))]
        [DataMember(Name = "strategy", IsRequired = true, EmitDefaultValue = true)]
        public StrategyOptions Strategy{ get; }
        
        /// <summary>
        /// Parameter tiers of LeaderboardConfig1TieringConfig
        /// </summary>
        [Preserve]
        [DataMember(Name = "tiers", IsRequired = true, EmitDefaultValue = true)]
        public List<LeaderboardConfig1TieringConfigTiersInner> Tiers{ get; }
    
        /// <summary>
        /// The tiering strategy to use when determining what tier a player is in
        /// </summary>
        /// <value>The tiering strategy to use when determining what tier a player is in</value>
        [Preserve]
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StrategyOptions
        {
            /// <summary>
            /// Enum Score for value: score
            /// </summary>
            [EnumMember(Value = "score")]
            Score = 1,
            /// <summary>
            /// Enum Rank for value: rank
            /// </summary>
            [EnumMember(Value = "rank")]
            Rank = 2,
            /// <summary>
            /// Enum Percent for value: percent
            /// </summary>
            [EnumMember(Value = "percent")]
            Percent = 3
        }

        /// <summary>
        /// Formats a LeaderboardConfig1TieringConfig into a string of key-value pairs for use as a path parameter.
        /// </summary>
        /// <returns>Returns a string representation of the key-value pairs.</returns>
        internal string SerializeAsPathParam()
        {
            var serializedModel = "";

            serializedModel += "strategy," + Strategy + ",";
            if (Tiers != null)
            {
                serializedModel += "tiers," + Tiers.ToString();
            }
            return serializedModel;
        }

        /// <summary>
        /// Returns a LeaderboardConfig1TieringConfig as a dictionary of key-value pairs for use as a query parameter.
        /// </summary>
        /// <returns>Returns a dictionary of string key-value pairs.</returns>
        internal Dictionary<string, string> GetAsQueryParam()
        {
            var dictionary = new Dictionary<string, string>();

            var strategyStringValue = Strategy.ToString();
            dictionary.Add("strategy", strategyStringValue);
            
            return dictionary;
        }
    }
}
