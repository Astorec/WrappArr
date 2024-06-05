using RestSharp;
using WrappArr.Methods;
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
        public async Task<Classes.Series.Series> GetSeriesByID(int id, bool includeSeasonImages = false)
        {
            var req = CreateClientRequest.CreatRequest("api/v3/series/{id}", Method.Get, new Dictionary<string, object>
            {
                    {"includeSeasonImages", includeSeasonImages}
            });

            req.AddHeader("accept", "application/json");
            req.AddUrlSegment("id", id.ToString());

            return await ExecuteClientRequest.Obj<Classes.Series.Series>(req, _client);
        }

        public async Task<Classes.Series.Series> GetSeriesByTVDBID(int tvdbIdid, bool includeSeasonImages = false)
        {
            var req = CreateClientRequest.CreatRequest("api/v3/series", Method.Get, new Dictionary<string, object>
            {
                    {"tvdbId", tvdbIdid},
                    {"includeSeasonImages", includeSeasonImages}
            });

            req.AddHeader("accept", "application/json");

            return await ExecuteClientRequest.Obj<Classes.Series.Series>(req, _client);
        }


        /// <summary>
        /// Get all series
        /// </summary>
        /// <param name="includeSeasonImages">Whether to include season images in the response</param>
        public async Task<List<Classes.Series.Series>> GetAllSeries(bool includeSeasonImages = false)
        {
            var req = CreateClientRequest.CreatRequest("api/v3/series", Method.Get, new Dictionary<string, object>
            {
                    {"includeSeasonImages", includeSeasonImages}
            });

            req.AddHeader("accept", "application/json");

            return await ExecuteClientRequest.Obj<List<Classes.Series.Series>>(req, _client);
        }
    }
}