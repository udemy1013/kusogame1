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
    /// LeaderboardIdConfig1 model
    /// </summary>
    [Preserve]
    [DataContract(Name = "LeaderboardIdConfig_1")]
    internal class LeaderboardIdConfig1
    {
        /// <summary>
        /// Creates an instance of LeaderboardIdConfig1.
        /// </summary>
        /// <param name="id">id param</param>
        /// <param name="name">name param</param>
        /// <param name="sortOrder">The Sort Order of the Leaderboard, either Ascending (asc) or Descending (desc)</param>
        /// <param name="updateType">The Update Type of the Leaderboard, currently limited to Keep Best Score (keepBest), Keep Latest Score (keepLatest), Keep Total Score (aggregate)</param>
        /// <param name="bucketSize">bucketSize param</param>
        /// <param name="resetConfig">resetConfig param</param>
        /// <param name="tieringConfig">tieringConfig param</param>
        [Preserve]
        public LeaderboardIdConfig1(string id, string name, SortOrderOptions sortOrder, UpdateTypeOptions updateType, int bucketSize = default, LeaderboardConfig1ResetConfig resetConfig = default, LeaderboardConfig1TieringConfig tieringConfig = default)
        {
            Id = id;
            BucketSize = bucketSize;
            Name = name;
            SortOrder = sortOrder;
            UpdateType = updateType;
            ResetConfig = resetConfig;
            TieringConfig = tieringConfig;
        }

        /// <summary>
        /// Parameter id of LeaderboardIdConfig1
        /// </summary>
        [Preserve]
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public string Id{ get; }
        
        /// <summary>
        /// Parameter bucketSize of LeaderboardIdConfig1
        /// </summary>
        [Preserve]
        [DataMember(Name = "bucketSize", EmitDefaultValue = false)]
        public int BucketSize{ get; }
        
        /// <summary>
        /// Parameter name of LeaderboardIdConfig1
        /// </summary>
        [Preserve]
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name{ get; }
        
        /// <summary>
        /// The Sort Order of the Leaderboard, either Ascending (asc) or Descending (desc)
        /// </summary>
        [Preserve]
        [JsonConverter(typeof(StringEnumConverter))]
        [DataMember(Name = "sortOrder", IsRequired = true, EmitDefaultValue = true)]
        public SortOrderOptions SortOrder{ get; }
        
        /// <summary>
        /// The Update Type of the Leaderboard, currently limited to Keep Best Score (keepBest), Keep Latest Score (keepLatest), Keep Total Score (aggregate)
        /// </summary>
        [Preserve]
        [JsonConverter(typeof(StringEnumConverter))]
        [DataMember(Name = "updateType", IsRequired = true, EmitDefaultValue = true)]
        public UpdateTypeOptions UpdateType{ get; }
        
        /// <summary>
        /// Parameter resetConfig of LeaderboardIdConfig1
        /// </summary>
        [Preserve]
        [DataMember(Name = "resetConfig", EmitDefaultValue = false)]
        public LeaderboardConfig1ResetConfig ResetConfig{ get; }
        
        /// <summary>
        /// Parameter tieringConfig of LeaderboardIdConfig1
        /// </summary>
        [Preserve]
        [DataMember(Name = "tieringConfig", EmitDefaultValue = false)]
        public LeaderboardConfig1TieringConfig TieringConfig{ get; }
    
        /// <summary>
        /// The Sort Order of the Leaderboard, either Ascending (asc) or Descending (desc)
        /// </summary>
        /// <value>The Sort Order of the Leaderboard, either Ascending (asc) or Descending (desc)</value>
        [Preserve]
        [JsonConverter(typeof(StringEnumConverter))]
        public enum SortOrderOptions
        {
            /// <summary>
            /// Enum Asc for value: asc
            /// </summary>
            [EnumMember(Value = "asc")]
            Asc = 1,
            /// <summary>
            /// Enum Desc for value: desc
            /// </summary>
            [EnumMember(Value = "desc")]
            Desc = 2
        }

        /// <summary>
        /// The Update Type of the Leaderboard, currently limited to Keep Best Score (keepBest), Keep Latest Score (keepLatest), Keep Total Score (aggregate)
        /// </summary>
        /// <value>The Update Type of the Leaderboard, currently limited to Keep Best Score (keepBest), Keep Latest Score (keepLatest), Keep Total Score (aggregate)</value>
        [Preserve]
        [JsonConverter(typeof(StringEnumConverter))]
        public enum UpdateTypeOptions
        {
            /// <summary>
            /// Enum KeepBest for value: keepBest
            /// </summary>
            [EnumMember(Value = "keepBest")]
            KeepBest = 1,
            /// <summary>
            /// Enum KeepLatest for value: keepLatest
            /// </summary>
            [EnumMember(Value = "keepLatest")]
            KeepLatest = 2,
            /// <summary>
            /// Enum Aggregate for value: aggregate
            /// </summary>
            [EnumMember(Value = "aggregate")]
            Aggregate = 3
        }

        /// <summary>
        /// Formats a LeaderboardIdConfig1 into a string of key-value pairs for use as a path parameter.
        /// </summary>
        /// <returns>Returns a string representation of the key-value pairs.</returns>
        internal string SerializeAsPathParam()
        {
            var serializedModel = "";

            if (Id != null)
            {
                serializedModel += "id," + Id + ",";
            }
            serializedModel += "bucketSize," + BucketSize.ToString() + ",";
            if (Name != null)
            {
                serializedModel += "name," + Name + ",";
            }
            serializedModel += "sortOrder," + SortOrder + ",";
            serializedModel += "updateType," + UpdateType + ",";
            if (ResetConfig != null)
            {
                serializedModel += "resetConfig," + ResetConfig.ToString() + ",";
            }
            if (TieringConfig != null)
            {
                serializedModel += "tieringConfig," + TieringConfig.ToString();
            }
            return serializedModel;
        }

        /// <summary>
        /// Returns a LeaderboardIdConfig1 as a dictionary of key-value pairs for use as a query parameter.
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
            
            var bucketSizeStringValue = BucketSize.ToString();
            dictionary.Add("bucketSize", bucketSizeStringValue);
            
            if (Name != null)
            {
                var nameStringValue = Name.ToString();
                dictionary.Add("name", nameStringValue);
            }
            
            var sortOrderStringValue = SortOrder.ToString();
            dictionary.Add("sortOrder", sortOrderStringValue);
            
            var updateTypeStringValue = UpdateType.ToString();
            dictionary.Add("updateType", updateTypeStringValue);
            
            return dictionary;
        }
    }
}
