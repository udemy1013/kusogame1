using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Unity.Services.Leaderboards.Authoring.Core.Model;
using Unity.Services.Leaderboards.Authoring.Core.Serialization;

namespace Unity.Services.Leaderboards.Editor.Authoring.Model
{
    class LeaderboardsSerializer : ILeaderboardsSerializer
    {
        enum ErrorMessage
        {
            ParsingError,
            Error,
        }
        static readonly List<string> k_ErrorMessages = new List<string>(Enum.GetNames(typeof(ErrorMessage)));

        static JsonSerializerSettings s_DefaultSerializerSettings = new JsonSerializerSettings()
        {
            // this option is necessary to prevent default values to be set instead of
            // leaving them to null when absent from the json
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate,

            // this is a workaround to make sure this throws an exception in case there
            // is extra characters at the end of the json
            CheckAdditionalContent = true,

            // we want it to fail if an unknown field is present in the json
            MissingMemberHandling = MissingMemberHandling.Error,
        };

        public static bool IsDeserializationError(string error)
        {
            return k_ErrorMessages.Contains(error);
        }

        public string Serialize(ILeaderboardConfig config)
        {
            throw new System.NotImplementedException();
        }

        public LeaderboardConfig Deserialize(string path)
        {
            throw new System.NotImplementedException();
        }

        public void DeserializeAndPopulate(LeaderboardConfig config)
        {
            if (string.IsNullOrEmpty(config.Path))
            {
                throw new ArgumentNullException(nameof(config.Path), "impossible to deserialize an asset with empty path.");
            }
            if (config is null)
            {
                throw new ArgumentNullException(nameof(config));
            }
            try
            {
                var content = File.ReadAllText(config.Path);

                var id = Path.GetFileNameWithoutExtension(config.Path);

                // PopulateObject() will append already existing tiers if FromJson() called more than once
                // see https://www.newtonsoft.com/json/help/html/PopulateObject.htm
                config.TieringConfig?.Tiers?.Clear();

                JsonConvert.PopulateObject(content, config, s_DefaultSerializerSettings);

                // Overriding logic:
                // 1. if Name is not set in JSON, name is same as Id
                // 2. if Id is not set in JSON, Id is same as filename without extension
                config.Id ??= id;
                config.Name ??= config.Id;
            }
            catch (Exception e) when (e is SerializationException
                                          or JsonSerializationException
                                          or JsonReaderException)
            {
                throw new LeaderboardsDeserializeException(ErrorMessage.ParsingError.ToString(), e.Message, e);
            }
            catch (Exception e)
            {
                throw new LeaderboardsDeserializeException(ErrorMessage.Error.ToString(), e.Message, e);
            }
        }
    }

    class LeaderboardsDeserializeException : Exception
    {
        public string ErrorMessage;
        public string Details;

        public LeaderboardsDeserializeException(string message, string details, Exception exception)
            : base(message, exception)
        {
            ErrorMessage = message;
            Details = details;
        }
    }
}
