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
    /// LeaderboardScoresWithNotFoundPlayerIds model
    /// </summary>
    [Preserve]
    [DataContract(Name = "LeaderboardScoresWithNotFoundPlayerIds")]
    internal class LeaderboardScoresWithNotFoundPlayerIds
    {
        /// <summary>
        /// Creates an instance of LeaderboardScoresWithNotFoundPlayerIds.
        /// </summary>
        /// <param name="results">results param</param>
        /// <param name="entriesNotFoundForPlayerIds">entriesNotFoundForPlayerIds param</param>
        [Preserve]
        public LeaderboardScoresWithNotFoundPlayerIds(List<LeaderboardEntry> results = default, List<string> entriesNotFoundForPlayerIds = default)
        {
            Results = results;
            EntriesNotFoundForPlayerIds = entriesNotFoundForPlayerIds;
        }

        /// <summary>
        /// Parameter results of LeaderboardScoresWithNotFoundPlayerIds
        /// </summary>
        [Preserve]
        [DataMember(Name = "results", EmitDefaultValue = false)]
        public List<LeaderboardEntry> Results{ get; }

        /// <summary>
        /// Parameter entriesNotFoundForPlayerIds of LeaderboardScoresWithNotFoundPlayerIds
        /// </summary>
        [Preserve]
        [DataMember(Name = "entriesNotFoundForPlayerIds", EmitDefaultValue = false)]
        public List<string> EntriesNotFoundForPlayerIds{ get; }

        /// <summary>
        /// Formats a LeaderboardScoresWithNotFoundPlayerIds into a string of key-value pairs for use as a path parameter.
        /// </summary>
        /// <returns>Returns a string representation of the key-value pairs.</returns>
        internal string SerializeAsPathParam()
        {
            var serializedModel = "";

            if (Results != null)
            {
                serializedModel += "results," + Results.ToString() + ",";
            }
            if (EntriesNotFoundForPlayerIds != null)
            {
                serializedModel += "entriesNotFoundForPlayerIds," + EntriesNotFoundForPlayerIds.ToString();
            }
            return serializedModel;
        }

        /// <summary>
        /// Returns a LeaderboardScoresWithNotFoundPlayerIds as a dictionary of key-value pairs for use as a query parameter.
        /// </summary>
        /// <returns>Returns a dictionary of string key-value pairs.</returns>
        internal Dictionary<string, string> GetAsQueryParam()
        {
            var dictionary = new Dictionary<string, string>();

            if (EntriesNotFoundForPlayerIds != null)
            {
                var entriesNotFoundForPlayerIdsStringValue = EntriesNotFoundForPlayerIds.ToString();
                dictionary.Add("entriesNotFoundForPlayerIds", entriesNotFoundForPlayerIdsStringValue);
            }

            return dictionary;
        }
    }
}
