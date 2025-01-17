using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Scripting;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Unity.Services.Leaderboards.Internal.Http;


using System.ComponentModel;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Unity.Services.Leaderboards.Internal.Models
{
    /// <summary>
    /// GetLeaderboardPlayerRange400OneOf model
    /// </summary>
    [Preserve]
    [JsonConverter(typeof(GetLeaderboardPlayerRange400OneOfJsonConverter))]
    [DataContract(Name = "GetLeaderboardPlayerRange400OneOf")]
    internal class GetLeaderboardPlayerRange400OneOf : IOneOf
    {
        /// <summary> Value </summary>
        public object Value { get; }
        /// <summary> Type </summary>
        public Type Type { get; }
        private const string DiscriminatorKey = "type";

        /// <summary>GetLeaderboardPlayerRange400OneOf Constructor</summary>
        /// <param name="value">The value as an object for GetLeaderboardPlayerRange400OneOf</param>
        /// <param name="type">The type for GetLeaderboardPlayerRange400OneOf</param>
        public GetLeaderboardPlayerRange400OneOf(object value, Type type)
        {
            this.Value = value;
            this.Type = type;
        }

        private static Dictionary<string, Type> TypeLookup = new Dictionary<string, Type>()
        {
            { "problems/basic", typeof(BasicErrorResponse) },
            { "problems/validation", typeof(ValidationErrorResponse) },
            { "BadRequestErrorResponse", typeof(BasicErrorResponse) },
            { "ValidationErrorResponse", typeof(ValidationErrorResponse) }

        };
        private static List<Type> PossibleTypes = new List<Type>(){ typeof(BasicErrorResponse) , typeof(ValidationErrorResponse)  };

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
        /// Converts the JSON string into an instance of GetLeaderboardPlayerRange400OneOf
        /// </summary>
        /// <param name="jsonString">JSON string</param>
        /// <returns>An instance of GetLeaderboardPlayerRange400OneOf</returns>
        public static GetLeaderboardPlayerRange400OneOf FromJson(string jsonString)
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
                    throw new MissingFieldException("GetLeaderboardPlayerRange400OneOf", DiscriminatorKey);
                }
                string discriminatorValue = parsedJson[DiscriminatorKey].ToString();

                return DeserializeIntoActualObject(discriminatorValue, jsonString);
            }
        }

        private static GetLeaderboardPlayerRange400OneOf DeserializeIntoActualObject(string discriminatorValue, string jsonString)
        {
            object actualObject = null;
            Type concreteType = GetConcreteType(discriminatorValue);

            if (concreteType == null)
            {
                string possibleValues = String.Join(", ", TypeLookup.Keys.ToList());
                throw new InvalidDataException("Failed to lookup discriminator value for " + discriminatorValue + ". Possible values: " + possibleValues);
            }

            actualObject = JsonConvert.DeserializeObject(jsonString, concreteType);

            return new GetLeaderboardPlayerRange400OneOf(actualObject, concreteType);
        }

        private static GetLeaderboardPlayerRange400OneOf DeserializeIntoActualObject(string jsonString)
        {
            var results = new List<(object ActualObject, Type ActualType)>();
            foreach (Type t in PossibleTypes)
            {
                try
                {
                    var deserializedClass = JsonConvert.DeserializeObject(jsonString, t);
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

            return new GetLeaderboardPlayerRange400OneOf(results.First().ActualObject, results.First().ActualType);
        }
    }

    /// <summary>
    /// Custom JSON converter for GetLeaderboardPlayerRange400OneOf to allow for deserialization into OneOf type
    /// </summary>
    [Preserve]
    internal class GetLeaderboardPlayerRange400OneOfJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if(reader.TokenType != JsonToken.Null)
            {
                return GetLeaderboardPlayerRange400OneOf.FromJson(JObject.Load(reader).ToString(Formatting.None));
            }
            return null;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(GetLeaderboardPlayerRange400OneOf);
        }
    }
}


