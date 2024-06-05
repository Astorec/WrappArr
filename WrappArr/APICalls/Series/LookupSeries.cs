using Newtonsoft.Json;
using RestSharp;
using WrappArr.Methods;
namespace WrappArr.APICalls.Series
{
    public class LookupSeries
    {
        private readonly RestClient _client;
        
        public LookupSeries(RestClient client)
        {
            _client = client;
        }
        
        /// <summary>
        /// Search for a series by name
        /// </summary>
        /// <param name="term">The name of the series to search for</param>
        /// <param name="apiKey">The API Key for the server. This is required here as it is needed in the URL as well</param>
        public async Task<List<Classes.Series.Series>> SearchForSeries(string term, string apiKey)
        {
            var req = CreateClientRequest.CreatRequest("api/v3/series/lookup", Method.Get, new Dictionary<string, object>
            {
                {"term", term},
                {"apikey", apiKey}
            });
            return await ExecuteClientRequest.Obj<List<Classes.Series.Series>>(req, _client);
        }
    }
}