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
    /// LeaderboardVersionId model
    /// </summary>
    [Preserve]
    [DataContract(Name = "LeaderboardVersionId")]
    internal class LeaderboardVersionId
    {
        /// <summary>
        /// Creates an instance of LeaderboardVersionId.
        /// </summary>
        /// <param name="versionId">versionId param</param>
        [Preserve]
        public LeaderboardVersionId(string versionId = default)
        {
            VersionId = versionId;
        }

        /// <summary>
        /// Parameter versionId of LeaderboardVersionId
        /// </summary>
        [Preserve]
        [DataMember(Name = "versionId", EmitDefaultValue = false)]
        public string VersionId{ get; }
    
        /// <summary>
        /// Formats a LeaderboardVersionId into a string of key-value pairs for use as a path parameter.
        /// </summary>
        /// <returns>Returns a string representation of the key-value pairs.</returns>
        internal string SerializeAsPathParam()
        {
            var serializedModel = "";

            if (VersionId != null)
            {
                serializedModel += "versionId," + VersionId;
            }
            return serializedModel;
        }

        /// <summary>
        /// Returns a LeaderboardVersionId as a dictionary of key-value pairs for use as a query parameter.
        /// </summary>
        /// <returns>Returns a dictionary of string key-value pairs.</returns>
        internal Dictionary<string, string> GetAsQueryParam()
        {
            var dictionary = new Dictionary<string, string>();

            if (VersionId != null)
            {
                var versionIdStringValue = VersionId.ToString();
                dictionary.Add("versionId", versionIdStringValue);
            }
            
            return dictionary;
        }
    }
}
