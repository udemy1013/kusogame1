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


using System.ComponentModel;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Unity.Services.Leaderboards.Authoring.Client.Models
{
    /// <summary>
    /// GetLeaderboardConfigs400Response model
    /// </summary>
    [Preserve]
    [JsonConverter(typeof(GetLeaderboardConfigs400ResponseJsonConverter))]
    [DataContract(Name = "GetLeaderboardConfigs400Response")]
    internal class GetLeaderboardConfigs400Response : IOneOf
    {
        /// <summary> Value </summary>
        public object Value { get; }
        /// <summary> Type </summary>
        public Type Type { get; }
        private const string DiscriminatorKey = "type";

        /// <summary>GetLeaderboardConfigs400Response Constructor</summary>
        /// <param name="value">The value as an object for GetLeaderboardConfigs400Response</param>
        /// <param name="type">The type for GetLeaderboardConfigs400Response</param>
        public GetLeaderboardConfigs400Response(object value, Type type)
        {
            this.Value = value;
            this.Type = type;
        }

        private static Dictionary<string, Type> TypeLookup = new Dictionary<string, Type>()
        {
            { "problems/basic", typeof(BasicErrorResponse) },
            { "problems/validation", typeof(ValidationErrorResponse) },
            { "BasicErrorResponse1", typeof(BasicErrorResponse1) }, 
            { "ValidationErrorResponse1", typeof(ValidationErrorResponse1) }
            
        };
        private static List<Type> PossibleTypes = new List<Type>(){ typeof(BasicErrorResponse1) , typeof(ValidationErrorResponse1)  };

        private static Type GetConcreteType(string type)
        {
            if (!TypeLookup.ContainsKey(type))
            {
                string possibleValues = String.Join(", ", TypeLookup.Keys.ToList());
                throw new ArgumentException("Failed to lookup discriminator value for " + type + ". Possible values: " + possibleValues);
            }
            else
            {
                return TypeLookup[type];
            }
        }

        /// <summary>
        /// Converts the JSON string into an instance of GetLeaderboardConfigs400Response
        /// </summary>
        /// <param name="jsonString">JSON string</param>
        /// <returns>An instance of GetLeaderboardConfigs400Response</returns>
        public static GetLeaderboardConfigs400Response FromJson(string jsonString)
        {
            if (jsonString == null)
            {
                return null;
            }

            if (String.IsNullOrEmpty(DiscriminatorKey))
            {
                return DeserializeIntoActualObject(jsonString);
            }
            else
            {
                var parsedJson = JObject.Parse(jsonString);
                if (!parsedJson.ContainsKey(DiscriminatorKey))
                {
                    throw new MissingFieldException("GetLeaderboardConfigs400Response", DiscriminatorKey);
                }
                string discriminatorValue = parsedJson[DiscriminatorKey].ToString();

                return DeserializeIntoActualObject(discriminatorValue, jsonString);
            }
        }

        private static GetLeaderboardConfigs400Response DeserializeIntoActualObject(string discriminatorValue, string jsonString)
        {
            object actualObject = null;
            Type concreteType = GetConcreteType(discriminatorValue);

            if (concreteType == null)
            {
                string possibleValues = String.Join(", ", TypeLookup.Keys.ToList());
                throw new InvalidDataException("Failed to lookup discriminator value for " + discriminatorValue + ". Possible values: " + possibleValues);
            }

            actualObject = IsolatedJsonConvert.DeserializeObject(jsonString, concreteType);

            return new GetLeaderboardConfigs400Response(actualObject, concreteType);
        }

        private static GetLeaderboardConfigs400Response DeserializeIntoActualObject(string jsonString)
        {
            var results = new List<(object ActualObject, Type ActualType)>();
            foreach (Type t in PossibleTypes)
            {
                try
                {
                    var deserializedClass = IsolatedJsonConvert.DeserializeObject(jsonString, t);
                    results.Add((deserializedClass, t));
                }
                catch (Exception)
                {
                    // Do nothing
                }
            }

            if (results.Count() == 0)
            {
                string message = $"Could not deserialize into any of possible types. Possible types are: {String.Join(", ", PossibleTypes)}";
                throw new ResponseDeserializationException(message);
            }

            if (results.Count() > 1)
            {
                string message = $"Could not deserialize; type is ambiguous. Possible types are: {String.Join(", ", results.Select(p => p.ActualType))}";
                throw new ResponseDeserializationException(message);
            }

            return new GetLeaderboardConfigs400Response(results.First().ActualObject, results.First().ActualType);
        }
    }

    /// <summary>
    /// Custom JSON converter for GetLeaderboardConfigs400Response to allow for deserialization into OneOf type
    /// </summary>
    [Preserve]
    internal class GetLeaderboardConfigs400ResponseJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if(reader.TokenType != JsonToken.Null)
            {
                return GetLeaderboardConfigs400Response.FromJson(JObject.Load(reader).ToString(Formatting.None));
            }
            return null;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(GetLeaderboardConfigs400Response);
        }
    }
}


