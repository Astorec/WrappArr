using Newtonsoft.Json;
using RestSharp;
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

        public async Task<Classes.Series.Series> GetSeries(int id)
        {
            var req = new RestRequest("api/v3/series/{id}", Method.Get);
             req.AddUrlSegment("id", id.ToString());
            req.AddHeader("accept", "application/json");
            req.AddQueryParameter("includeSeasonImages", "false");

            var response = await _client.ExecuteAsync(req);
            Console.WriteLine(response.StatusCode.ToString());
            try
            {
                var content = JsonConvert.DeserializeObject<Classes.Series.Series>(response.Content);
                return content;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}