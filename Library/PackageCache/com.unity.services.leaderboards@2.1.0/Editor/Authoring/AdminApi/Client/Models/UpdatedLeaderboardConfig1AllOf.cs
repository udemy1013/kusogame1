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
    /// UpdatedLeaderboardConfig1AllOf model
    /// </summary>
    [Preserve]
    [DataContract(Name = "UpdatedLeaderboardConfig_1_allOf")]
    internal class UpdatedLeaderboardConfig1AllOf
    {
        /// <summary>
        /// Creates an instance of UpdatedLeaderboardConfig1AllOf.
        /// </summary>
        /// <param name="updated">updated param</param>
        /// <param name="created">created param</param>
        /// <param name="lastReset">lastReset param</param>
        /// <param name="versions">versions param</param>
        [Preserve]
        public UpdatedLeaderboardConfig1AllOf(DateTime updated, DateTime created, DateTime lastReset = default, List<LeaderboardVersion1> versions = default)
        {
            Updated = updated;
            Created = created;
            LastReset = lastReset;
            Versions = versions;
        }

        /// <summary>
        /// Parameter updated of UpdatedLeaderboardConfig1AllOf
        /// </summary>
        [Preserve]
        [DataMember(Name = "updated", IsRequired = true, EmitDefaultValue = true)]
        public DateTime Updated{ get; }
        
        /// <summary>
        /// Parameter created of UpdatedLeaderboardConfig1AllOf
        /// </summary>
        [Preserve]
        [DataMember(Name = "created", IsRequired = true, EmitDefaultValue = true)]
        public DateTime Created{ get; }
        
        /// <summary>
        /// Parameter lastReset of UpdatedLeaderboardConfig1AllOf
        /// </summary>
        [Preserve]
        [DataMember(Name = "lastReset", EmitDefaultValue = false)]
        public DateTime LastReset{ get; }
        
        /// <summary>
        /// Parameter versions of UpdatedLeaderboardConfig1AllOf
        /// </summary>
        [Preserve]
        [DataMember(Name = "versions", EmitDefaultValue = false)]
        public List<LeaderboardVersion1> Versions{ get; }
    
        /// <summary>
        /// Formats a UpdatedLeaderboardConfig1AllOf into a string of key-value pairs for use as a path parameter.
        /// </summary>
        /// <returns>Returns a string representation of the key-value pairs.</returns>
        internal string SerializeAsPathParam()
        {
            var serializedModel = "";

            if (Updated != null)
            {
                serializedModel += "updated," + Updated.ToString() + ",";
            }
            if (Created != null)
            {
                serializedModel += "created," + Created.ToString() + ",";
            }
            if (LastReset != null)
            {
                serializedModel += "lastReset," + LastReset.ToString() + ",";
            }
            if (Versions != null)
            {
                serializedModel += "versions," + Versions.ToString();
            }
            return serializedModel;
        }

        /// <summary>
        /// Returns a UpdatedLeaderboardConfig1AllOf as a dictionary of key-value pairs for use as a query parameter.
        /// </summary>
        /// <returns>Returns a dictionary of string key-value pairs.</returns>
        internal Dictionary<string, string> GetAsQueryParam()
        {
            var dictionary = new Dictionary<string, string>();

            if (Updated != null)
            {
                var updatedStringValue = Updated.ToString();
                dictionary.Add("updated", updatedStringValue);
            }
            
            if (Created != null)
            {
                var createdStringValue = Created.ToString();
                dictionary.Add("created", createdStringValue);
            }
            
            if (LastReset != null)
            {
                var lastResetStringValue = LastReset.ToString();
                dictionary.Add("lastReset", lastResetStringValue);
            }
            
            return dictionary;
        }
    }
}
