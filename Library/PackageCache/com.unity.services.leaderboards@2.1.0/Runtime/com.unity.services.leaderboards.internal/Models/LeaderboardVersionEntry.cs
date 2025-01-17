using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Scripting;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Unity.Services.Leaderboards.Internal.Http;



namespace Unity.Services.Leaderboards.Internal.Models
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
        /// <param name="rank">rank param</param>
        /// <param name="score">score param</param>
        /// <param name="version">version param</param>
        [Preserve]
        public LeaderboardVersionEntry(string playerId, string playerName, int rank, double score, LeaderboardVersion version = default)
        {
            Version = version;
            PlayerId = playerId;
            PlayerName = playerName;
            Rank = rank;
            Score = score;
        }

        /// <summary>
        /// Parameter version of LeaderboardVersionEntry
        /// </summary>
        [Preserve]
        [DataMember(Name = "version", EmitDefaultValue = false)]
        public LeaderboardVersion Version{ get; }

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
        /// Parameter rank of LeaderboardVersionEntry
        /// </summary>
        [Preserve]
        [DataMember(Name = "rank", IsRequired = true, EmitDefaultValue = true)]
        public int Rank{ get; }

        /// <summary>
        /// Parameter score of LeaderboardVersionEntry
        /// </summary>
        [Preserve]
        [DataMember(Name = "score", IsRequired = true, EmitDefaultValue = true)]
        public double Score{ get; }

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
            serializedModel += "rank," + Rank.ToString() + ",";
            serializedModel += "score," + Score.ToString();
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

            var rankStringValue = Rank.ToString();
            dictionary.Add("rank", rankStringValue);

            var scoreStringValue = Score.ToString();
            dictionary.Add("score", scoreStringValue);

            return dictionary;
        }
    }
}
