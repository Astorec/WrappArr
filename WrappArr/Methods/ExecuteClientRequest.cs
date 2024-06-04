using Newtonsoft.Json;
using RestSharp;

namespace WrappArr.Methods{
    public static class ExecuteClientRequest
    {
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