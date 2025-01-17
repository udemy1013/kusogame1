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
    /// LeaderboardVersionEntry model
    /// </summary>
    [Preserve]
    [DataContract(Name = "LeaderboardVersionEntry")]
    internal class LeaderboardVersionEntry
    {
        /// <summary>
        /// Creates an instance of LeaderboardVersionEntry.
        /// </summary>
        /// <param name="playerId">playerId param</param>
        /// <param name="playerName">playerName param</param>
        /// <param name="score">score param</param>
        /// <param name="rank">rank param</param>
        /// <param name="version">version param</param>
        /// <param name="tier">tier param</param>
        [Preserve]
        public LeaderboardVersionEntry(string playerId, string playerName, double score, int rank, LeaderboardVersion2 version = default, string tier = default)
        {
            Version = version;
            PlayerId = playerId;
            PlayerName = playerName;
            Score = score;
            Rank = rank;
            Tier = tier;
        }

        /// <summary>
        /// Parameter version of LeaderboardVersionEntry
        /// </summary>
        [Preserve]
        [DataMember(Name = "version", EmitDefaultValue = false)]
        public LeaderboardVersion2 Version{ get; }
        
        /// <summary>
        /// Parameter playerId of LeaderboardVersionEntry
        /// </summary>
        [Preserve]
        [DataMember(Name = "playerId", IsRequired = true, EmitDefaultValue = true)]
        public string PlayerId{ get; }
        
        /// <summary>
        /// Parameter playerName of LeaderboardVersionEntry
        /// </summary>
        [Preserve]
        [DataMember(Name = "playerName", IsRequired = true, EmitDefaultValue = true)]
        public string PlayerName{ get; }
        
        /// <summary>
        /// Parameter score of LeaderboardVersionEntry
        /// </summary>
        [Preserve]
        [DataMember(Name = "score", IsRequired = true, EmitDefaultValue = true)]
        public double Score{ get; }
        
        /// <summary>
        /// Parameter rank of LeaderboardVersionEntry
        /// </summary>
        [Preserve]
        [DataMember(Name = "rank", IsRequired = true, EmitDefaultValue = true)]
        public int Rank{ get; }
        
        /// <summary>
        /// Parameter tier of LeaderboardVersionEntry
        /// </summary>
        [Preserve]
        [DataMember(Name = "tier", EmitDefaultValue = false)]
        public string Tier{ get; }
    
        /// <summary>
        /// Formats a LeaderboardVersionEntry into a string of key-value pairs for use as a path parameter.
        /// </summary>
        /// <returns>Returns a string representation of the key-value pairs.</returns>
        internal string SerializeAsPathParam()
        {
            var serializedModel = "";

            if (Version != null)
            {
                serializedModel += "version," + Version.ToString() + ",";
            }
            if (PlayerId != null)
            {
                serializedModel += "playerId," + PlayerId + ",";
            }
            if (PlayerName != null)
            {
                serializedModel += "playerName," + PlayerName + ",";
            }
            serializedModel += "score," + Score.ToString() + ",";
            serializedModel += "rank," + Rank.ToString() + ",";
            if (Tier != null)
            {
                serializedModel += "tier," + Tier;
            }
            return serializedModel;
        }

        /// <summary>
        /// Returns a LeaderboardVersionEntry as a dictionary of key-value pairs for use as a query parameter.
        /// </summary>
        /// <returns>Returns a dictionary of string key-value pairs.</returns>
        internal Dictionary<string, string> GetAsQueryParam()
        {
            var dictionary = new Dictionary<string, string>();

            if (PlayerId != null)
            {
                var playerIdStringValue = PlayerId.ToString();
                dictionary.Add("playerId", playerIdStringValue);
            }
            
            if (PlayerName != null)
            {
                var playerNameStringValue = PlayerName.ToString();
                dictionary.Add("playerName", playerNameStringValue);
            }
            
            var scoreStringValue = Score.ToString();
            dictionary.Add("score", scoreStringValue);
            
            var rankStringValue = Rank.ToString();
            dictionary.Add("rank", rankStringValue);
            
            if (Tier != null)
            {
                var tierStringValue = Tier.ToString();
                dictionary.Add("tier", tierStringValue);
            }
            
            return dictionary;
        }
    }
}
