using Newtonsoft.Json;
using RestSharp;
using WrappArr.Classes.Series;
using WrappArr.Methods;

namespace WrappArr.APICalls.Series
{
    public class AddNewSeries
    {
        private readonly RestClient _client;
        public AddNewSeries(RestClient client)
        {
            _client = client;
        }

        public async Task<RestResponse> AddSeries(Classes.Series.Series series, string apiKey, bool moveFiles = false)
        {
            var req = CreateClientRequest.CreatRequest("api/v3/series", Method.Post, new Dictionary<string, object>
            {
                {"moveFiles", moveFiles},
                {"apiKey", apiKey}
            });
            req.AddHeader("accept", "text/plain");
            req.AddHeader("Content-Type", "application/json");

            string json = JsonConvert.SerializeObject(series);
            req.AddJsonBody(json);
            return await _client.ExecuteAsync(req);

        }
    }
}