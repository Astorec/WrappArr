using Newtonsoft.Json;
using RestSharp;
using WrappArr.Methods;
using WrappArr.Classes.Series;
namespace WrappArr.APICalls.Series
{
    public class GetExistingSeries
    {
        private readonly RestClient _client;
        public GetExistingSeries(RestClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Get a series by ID
        /// </summary>
        /// <param name="id">The ID of the series to get</param>
        /// <param name="includeSeasonImages">Whether to include season images in the response</param>
        public async Task<Classes.Series.Series> GetSeries(int id, bool includeSeasonImages = false)
        {
            var req = CreateClientRequest.CreatRequest("api/v3/series/{id}", Method.Get, new Dictionary<string, object>
            {
                    {"includeSeasonImages", includeSeasonImages}
            });

            req.AddHeader("accept", "application/json");
            req.AddUrlSegment("id", id.ToString());

            return await ExecuteClientRequest.Obj<Classes.Series.Series>(req, _client);
        }
    }
}