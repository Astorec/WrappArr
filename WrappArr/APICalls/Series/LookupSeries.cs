using Newtonsoft.Json;
using RestSharp;
namespace WrappArr.APICalls.Series
{
    public class LookupSeries
    {
        private readonly RestClient _client;
        public LookupSeries(RestClient client)
        {
            _client = client;
        }

        public async Task<List<string>> SearchForSeries(string term)
        {
            var req = new RestRequest("api/v3/series/lookup", Method.Get);
            req.AddHeader("accept", "application/json");
            req.AddQueryParameter("term", term);
            req.AddQueryParameter("includeSeasonImages", "false");
            var response = await _client.ExecuteAsync(req);
            Console.WriteLine(response.StatusCode.ToString());

            try
            {
                var content = JsonConvert.DeserializeObject<List<Classes.SeriesLookup.Series>>(response.Content);
                var seriesList = new List<string>();

                foreach (var series in content)
                {
                    var seriesInfo = $"{series.Title} ({series.Year}) {series.Status} - TVDB ID: {series.TvdbId}";
                    seriesList.Add(seriesInfo);
                }


                return seriesList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new List<string>();
            }
        }


    }
}