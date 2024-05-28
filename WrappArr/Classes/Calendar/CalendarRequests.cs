using RestSharp;
using WrappArr.Classes.Auth;

namespace WrappArr_Console
{
    public class CalendarRequests
    {
        private readonly RestClient _client;

        public CalendarRequests(RestClient client)
        {
            _client = client;
        }
        public async Task<ResponseStatus> GetCalendar()
        {
            var req = new RestRequest("/api/v3/calendar", Method.Get);
            req.AddHeader("accept", "application/json");
            req.AddQueryParameter("unmonitored", "false");
            req.AddQueryParameter("includeSeries", "false");
            req.AddQueryParameter("includeEpisodeFile", "false");
            req.AddQueryParameter("includeEpisodeImages", "false");
            req.AddQueryParameter("apikey", "b2e3bf9ce0384ccf890e9f08c85b5c00");

            var response = await _client.ExecuteAsync(req);
            return response.ResponseStatus;
        }
    }
}