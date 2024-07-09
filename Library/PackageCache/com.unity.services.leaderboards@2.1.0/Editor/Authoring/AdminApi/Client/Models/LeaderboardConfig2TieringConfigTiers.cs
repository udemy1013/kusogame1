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
    /// LeaderboardConfig2TieringConfigTiers model
    /// </summary>
    [Preserve]
    [DataContract(Name = "LeaderboardConfig_2_tieringConfig_tiers")]
    internal class LeaderboardConfig2TieringConfigTiers
    {
        /// <summary>
        /// Creates an instance of LeaderboardConfig2TieringConfigTiers.
        /// </summary>
        /// <param name="id">The ID of the tier</param>
        /// <param name="cutoff">The worst value to be included in the tier. For score-based tiers, this will relate to your sort order, so that for a descending leaderboard scores with this value and higher will be in this tier, whereas for an ascending leaderboard scores with this value and lower will be in this tier. For rank and percentage-based tiers, entries with this rank/percent and better will be included in this tier. Percent-based cutoffs can be thought of as rank-based cutoffs that scale with your number of players, for example with 100 players in a leaderboard and a percent-based cutoff of 10%, ranks 0-9 will be in the tier, whereas with 1000 players ranks 0-99 will be in the tier. Percent-based cutoffs should be specified as the percentage desired without the percent symbol, e.g. &#x60;10&#x60; for 10%. </param>
        [Preserve]
        public LeaderboardConfig2TieringConfigTiers(string id, double? cutoff = default)
        {
            Id = id;
            Cutoff = cutoff;
        }

        /// <summary>
        /// The ID of the tier
        /// </summary>
        [Preserve]
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public string Id{ get; }
        
        /// <summary>
        /// The worst value to be included in the tier. For score-based tiers, this will relate to your sort order, so that for a descending leaderboard scores with this value and higher will be in this tier, whereas for an ascending leaderboard scores with this value and lower will be in this tier. For rank and percentage-based tiers, entries with this rank/percent and better will be included in this tier. Percent-based cutoffs can be thought of as rank-based cutoffs that scale with your number of players, for example with 100 players in a leaderboard and a percent-based cutoff of 10%, ranks 0-9 will be in the tier, whereas with 1000 players ranks 0-99 will be in the tier. Percent-based cutoffs should be specified as the percentage desired without the percent symbol, e.g. &#x60;10&#x60; for 10%. 
        /// </summary>
        [Preserve]
        [DataMember(Name = "cutoff", EmitDefaultValue = false)]
        public double? Cutoff{ get; }
    
        /// <summary>
        /// Formats a LeaderboardConfig2TieringConfigTiers into a string of key-value pairs for use as a path parameter.
        /// </summary>
        /// <returns>Returns a string representation of the key-value pairs.</returns>
        internal string SerializeAsPathParam()
        {
            var serializedModel = "";

            if (Id != null)
            {
                serializedModel += "id," + Id + ",";
            }
            if (Cutoff != null)
            {
                serializedModel += "cutoff," + Cutoff.ToString();
            }
            return serializedModel;
        }

        /// <summary>
        /// Returns a LeaderboardConfig2TieringConfigTiers as a dictionary of key-value pairs for use as a query parameter.
        /// </summary>
        /// <returns>Returns a dictionary of string key-value pairs.</returns>
        internal Dictionary<string, string> GetAsQueryParam()
        {
            var dictionary = new Dictionary<string, string>();

            if (Id != null)
            {
                var idStringValue = Id.ToString();
                dictionary.Add("id", idStringValue);
            }
            
            if (Cutoff != null)
            {
                var cutoffStringValue = Cutoff.ToString();
                dictionary.Add("cutoff", cutoffStringValue);
            }
            
            return dictionary;
        }
    }
}