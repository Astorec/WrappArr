using Newtonsoft.Json;
using RestSharp;

namespace WrappArr.Methods
{
    internal static class ExecuteClientRequest
    {
        /// <summary>
        /// Execute a request and return the response as a string
        /// </summary>
        /// <param name="req">The request to execute</param>
        /// <param name="_client">The client to execute the request with</param>
        public static async Task<T> Obj<T>(RestRequest req, RestClient _client)
        {
            var response = await _client.ExecuteAsync(req);

            if (response.IsSuccessful)
            {
                try
                {
                    var content = JsonConvert.DeserializeObject<T>(response.Content);
                    return content;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error deserializing response", ex);
                }
            }
            else
            {
                throw new Exception("Error executing request", response.ErrorException);
            }
        }
    }
}