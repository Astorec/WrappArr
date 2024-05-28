using RestSharp;
using WrappArr.ApiCalls.Auth;

namespace WrappArr.ApiCalls.Calendar
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

            var response = await _client.ExecuteAsync(req);
            return response.ResponseStatus;
        }

        public async Task<ResponseStatus> GetCalendar(int id)
        {
            var req = new RestRequest($"/api/v3/calendar{id}", Method.Get);
            req.AddHeader("accept", "application/json");
            req.AddQueryParameter("unmonitored", "false");
            req.AddQueryParameter("includeSeries", "false");
            req.AddQueryParameter("includeEpisodeFile", "false");
            req.AddQueryParameter("includeEpisodeImages", "false");

            var response = await _client.ExecuteAsync(req);
            return response.ResponseStatus;
        }
    }
}