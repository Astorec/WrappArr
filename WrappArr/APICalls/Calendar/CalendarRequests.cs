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

        /// <summary>
        /// Get the calendar for the server
        /// </summary>
        /// <param name="startDate">The start date of the calendar</param>
        /// <param name="endDate">The end date of the calendar</param>
        /// <param name="tags">Tags to filter the calendar by</param>
        /// <param name="unmonitored">Whether to include unmonitored items in the calendar</param>
        /// <param name="includeSeries">Whether to include series in the calendar</param>
        /// <param name="includeEpisodeFile">Whether to include episode files in the calendar</param>
        /// <param name="includeEpisodeImages">Whether to include episode images in the calendar</param>
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

            Console.WriteLine("Client headers:");
            foreach (var header in _client.DefaultParameters)
            {
                Console.WriteLine($"Name: {header.Name}, Value: {header.Value}");
            }

            Console.WriteLine("Request headers:");
            foreach (var header in req.Parameters.Where(p => p.Type == ParameterType.HttpHeader))
            {
                Console.WriteLine($"Name: {header.Name}, Value: {header.Value}");
            }

            return await ExecuteClientRequest.Obj<List<Classes.Calendar.Calendar>>(req, _client);
        }
    }
}