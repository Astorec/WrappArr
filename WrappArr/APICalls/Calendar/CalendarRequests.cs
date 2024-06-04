using RestSharp;
using WrappArr.Methods;
using WrappArr.ApiCalls.Auth;
using WrappArr.Classes.Calendar;
using Newtonsoft.Json;

namespace WrappArr.ApiCalls.Calendar
{
    public class CalendarRequests
    {
        private readonly RestClient _client;

        /// <summary>
        /// Constructor for the CalendarRequests class
        /// </summary>
        /// <param name="client">Client that has been previously initalised</param>
        public CalendarRequests(RestClient client)
        {
            _client = client;
        }
        public async Task<List<Classes.Calendar.Calendar>> GetCalendar(DateTime? startDate = null, DateTime? endDate = null, string tags = null, bool unmonitored = false,
        bool includeSeries = false, bool includeEpisodeFile = false, bool includeEpisodeImages = false)
        {
            var req = CreateClientRequest.CreatRequest("api/v3/calendar", Method.Get, new Dictionary<string, object>
        {
            { "unmonitored", unmonitored },
            { "includeSeries", includeSeries },
            { "includeEpisodeFile", includeEpisodeFile },
            { "includeEpisodeImages", includeEpisodeImages }
        });

            req.AddHeader("accept", "application/json");
            if (!string.IsNullOrEmpty(tags))
            {
                req.AddQueryParameter("tags", tags);
            }
            if (startDate != null)
            {
                req.AddQueryParameter("start", startDate.Value.ToString("yyyy-MM-dd"));

                if (endDate != null)
                {
                    req.AddQueryParameter("end", endDate.Value.ToString("yyyy-MM-dd"));
                }
            }
            return await ExecuteClientRequest.Obj<List<Classes.Calendar.Calendar>>(req, _client);
        }
    }
}