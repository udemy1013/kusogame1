//-----------------------------------------------------------------------------
// <auto-generated>
//     This file was generated by the C# SDK Code Generator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//-----------------------------------------------------------------------------


using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine.Networking;

namespace Unity.Services.Leaderboards.Authoring.Client.Http
{
    /// <summary>
    /// Unity Web Request Helper Functions.
    /// </summary>
    internal static class UnityWebRequestHelpers
    {
        /// <summary>
        /// Function for awaiting on an async operation.
        /// </summary>
        /// <param name="asyncOp">The asynchronous operation.</param>
        /// <returns>The TaskAwaiter for the async operation.</returns>
        public static TaskAwaiter<HttpClientResponse> GetAwaiter(this UnityWebRequestAsyncOperation asyncOp)
        {
            var tcs = new TaskCompletionSource<HttpClientResponse>();
            
            asyncOp.completed += obj =>
            {
                var result = CreateHttpClientResponse((UnityWebRequestAsyncOperation) obj);
                tcs.SetResult(result);
            };
            return tcs.Task.GetAwaiter();
        }

        internal static HttpClientResponse CreateHttpClientResponse(UnityWebRequestAsyncOperation unityResponse)
        {
            var response = unityResponse.webRequest;
            var result = new HttpClientResponse(
                response.GetResponseHeaders(),
                response.responseCode,
#if UNITY_2020_1_OR_NEWER
                response.result == UnityWebRequest.Result.ProtocolError,
                response.result == UnityWebRequest.Result.ConnectionError,
#else
                response.isHttpError,
                response.isNetworkError,
#endif
                response.downloadHandler.data,
                response.error);
            return result;
        }
    }
}