﻿using System;
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
    /// LeaderboardVersionScoresWithNotFoundPlayerIds model
    /// </summary>
    [Preserve]
    [DataContract(Name = "LeaderboardVersionScoresWithNotFoundPlayerIds")]
    internal class LeaderboardVersionScoresWithNotFoundPlayerIds
    {
        /// <summary>
        /// Creates an instance of LeaderboardVersionScoresWithNotFoundPlayerIds.
        /// </summary>
        /// <param name="version">version param</param>
        /// <param name="results">results param</param>
        /// <param name="entriesNotFoundForPlayerIds">entriesNotFoundForPlayerIds param</param>
        [Preserve]
        public LeaderboardVersionScoresWithNotFoundPlayerIds(LeaderboardVersion version = default, List<LeaderboardEntry> results = default, List<string> entriesNotFoundForPlayerIds = default)
        {
            Version = version;
            Results = results;
            EntriesNotFoundForPlayerIds = entriesNotFoundForPlayerIds;
        }

        /// <summary>
        /// Parameter version of LeaderboardVersionScoresWithNotFoundPlayerIds
        /// </summary>
        [Preserve]
        [DataMember(Name = "version", EmitDefaultValue = false)]
        public LeaderboardVersion Version{ get; }

        /// <summary>
        /// Parameter results of LeaderboardVersionScoresWithNotFoundPlayerIds
        /// </summary>
        [Preserve]
        [DataMember(Name = "results", EmitDefaultValue = false)]
        public List<LeaderboardEntry> Results{ get; }

        /// <summary>
        /// Parameter entriesNotFoundForPlayerIds of LeaderboardVersionScoresWithNotFoundPlayerIds
        /// </summary>
        [Preserve]
        [DataMember(Name = "entriesNotFoundForPlayerIds", EmitDefaultValue = false)]
        public List<string> EntriesNotFoundForPlayerIds{ get; }

        /// <summary>
        /// Formats a LeaderboardVersionScoresWithNotFoundPlayerIds into a string of key-value pairs for use as a path parameter.
        /// </summary>
        /// <returns>Returns a string representation of the key-value pairs.</returns>
        internal string SerializeAsPathParam()
        {
            var serializedModel = "";

            if (Version != null)
            {
                serializedModel += "version," + Version.ToString() + ",";
            }
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
        /// Returns a LeaderboardVersionScoresWithNotFoundPlayerIds as a dictionary of key-value pairs for use as a query parameter.
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
