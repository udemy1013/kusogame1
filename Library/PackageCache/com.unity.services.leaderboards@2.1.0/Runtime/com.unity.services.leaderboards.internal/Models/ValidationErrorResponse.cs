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
    /// Validation error response when a value provided from the client does notpass validation on server.
    /// </summary>
    [Preserve]
    [DataContract(Name = "ValidationErrorResponse")]
    internal class ValidationErrorResponse
    {
        /// <summary>
        /// Validation error response when a value provided from the client does notpass validation on server.
        /// </summary>
        /// <param name="type">type param</param>
        /// <param name="title">title param</param>
        /// <param name="status">status param</param>
        /// <param name="code">code param</param>
        /// <param name="detail">detail param</param>
        /// <param name="errors">errors param</param>
        /// <param name="instance">instance param</param>
        [Preserve]
        public ValidationErrorResponse(string type, string title, int status, int code, string detail, List<ValidationError> errors, string instance = default)
        {
            Type = type;
            Title = title;
            Status = status;
            Code = code;
            Detail = detail;
            Instance = instance;
            Errors = errors;
        }

        /// <summary>
        /// Parameter type of ValidationErrorResponse
        /// </summary>
        [Preserve]
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = true)]
        public string Type{ get; }

        /// <summary>
        /// Parameter title of ValidationErrorResponse
        /// </summary>
        [Preserve]
        [DataMember(Name = "title", IsRequired = true, EmitDefaultValue = true)]
        public string Title{ get; }

        /// <summary>
        /// Parameter status of ValidationErrorResponse
        /// </summary>
        [Preserve]
        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = true)]
        public int Status{ get; }

        /// <summary>
        /// Parameter code of ValidationErrorResponse
        /// </summary>
        [Preserve]
        [DataMember(Name = "code", IsRequired = true, EmitDefaultValue = true)]
        public int Code{ get; }

        /// <summary>
        /// Parameter detail of ValidationErrorResponse
        /// </summary>
        [Preserve]
        [DataMember(Name = "detail", IsRequired = true, EmitDefaultValue = true)]
        public string Detail{ get; }

        /// <summary>
        /// Parameter instance of ValidationErrorResponse
        /// </summary>
        [Preserve]
        [DataMember(Name = "instance", EmitDefaultValue = false)]
        public string Instance{ get; }

        /// <summary>
        /// Parameter errors of ValidationErrorResponse
        /// </summary>
        [Preserve]
        [DataMember(Name = "errors", IsRequired = true, EmitDefaultValue = true)]
        public List<ValidationError> Errors{ get; }

        /// <summary>
        /// Formats a ValidationErrorResponse into a string of key-value pairs for use as a path parameter.
        /// </summary>
        /// <returns>Returns a string representation of the key-value pairs.</returns>
        internal string SerializeAsPathParam()
        {
            var serializedModel = "";

            if (Type != null)
            {
                serializedModel += "type," + Type + ",";
            }
            if (Title != null)
            {
                serializedModel += "title," + Title + ",";
            }
            serializedModel += "status," + Status.ToString() + ",";
            serializedModel += "code," + Code.ToString() + ",";
            if (Detail != null)
            {
                serializedModel += "detail," + Detail + ",";
            }
            if (Instance != null)
            {
                serializedModel += "instance," + Instance + ",";
            }
            if (Errors != null)
            {
                serializedModel += "errors," + Errors.ToString();
            }
            return serializedModel;
        }

        /// <summary>
        /// Returns a ValidationErrorResponse as a dictionary of key-value pairs for use as a query parameter.
        /// </summary>
        /// <returns>Returns a dictionary of string key-value pairs.</returns>
        internal Dictionary<string, string> GetAsQueryParam()
        {
            var dictionary = new Dictionary<string, string>();

            if (Type != null)
            {
                var typeStringValue = Type.ToString();
                dictionary.Add("type", typeStringValue);
            }

            if (Title != null)
            {
                var titleStringValue = Title.ToString();
                dictionary.Add("title", titleStringValue);
            }

            var statusStringValue = Status.ToString();
            dictionary.Add("status", statusStringValue);

            var codeStringValue = Code.ToString();
            dictionary.Add("code", codeStringValue);

            if (Detail != null)
            {
                var detailStringValue = Detail.ToString();
                dictionary.Add("detail", detailStringValue);
            }

            if (Instance != null)
            {
                var instanceStringValue = Instance.ToString();
                dictionary.Add("instance", instanceStringValue);
            }

            return dictionary;
        }
    }
}
