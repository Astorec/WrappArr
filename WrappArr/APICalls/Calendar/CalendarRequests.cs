using RestSharp;
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
        /// Gets the frist item found from the default calendar call
        /// </summary>
        /// <param name="unmonitored">True or False</param>
        /// <param name="includeSeries">True or False</param>
        /// <param name="includeEpisodeFile">True or False</param>
        /// <param name="includeEpisodeImages">True or False</param>
        /// <returns></returns>
        public async Task<Classes.Calendar.Calendar> GetCalendar(bool unmonitored = false,
        bool includeSeries = false, bool includeEpisodeFile = false, bool includeEpisodeImages = false)
        {

            var req = new RestRequest("/api/v3/calendar", Method.Get);
            req.AddHeader("accept", "application/json");
            req.AddQueryParameter("unmonitored", unmonitored);
            req.AddQueryParameter("includeSeries", includeSeries);
            req.AddQueryParameter("includeEpisodeFile", includeEpisodeFile);
            req.AddQueryParameter("includeEpisodeImages", includeEpisodeImages);

            var response = await _client.ExecuteAsync(req);

            try
            {
                var content = JsonConvert.DeserializeObject<Classes.Calendar.Calendar>(response.Content);
                return content;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// Get a list of Calendar items starting from a specific date
        /// </summary>
        /// <param name="startDate">DateTime for the specified start date</param>
        /// <param name="unmonitored">True or False</param>
        /// <param name="includeSeries">True or False</param>
        /// <param name="includeEpisodeFile">True or False</param>
        /// <param name="includeEpisodeImages">True or False</param>u
        /// <returns>Returns a list of items from the specified date</returns>
        public async Task<List<Classes.Calendar.Calendar>> GetCalendar(DateTime startDate, bool unmonitored = false,
        bool includeSeries = false, bool includeEpisodeFile = false, bool includeEpisodeImages = false)
        {

            var req = new RestRequest("/api/v3/calendar", Method.Get);
            req.AddHeader("accept", "application/json");
            req.AddQueryParameter("start", startDate.ToString("MM-dd-yyyy"));
            req.AddQueryParameter("unmonitored", unmonitored);
            req.AddQueryParameter("includeSeries", includeSeries);
            req.AddQueryParameter("includeEpisodeFile", includeEpisodeFile);
            req.AddQueryParameter("includeEpisodeImages", includeEpisodeImages);


            var response = await _client.ExecuteAsync(req);

            try
            {
                var content = JsonConvert.DeserializeObject<List<Classes.Calendar.Calendar>>(response.Content);
                return content;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// Get a list of Calendar items starting from a specific date
        /// </summary>
        /// <param name="startDate">DateTime for the specified start date</param>
        /// <param name="endDate">DateTime for the specified end date</param>
        /// <param name="unmonitored">True or False</param>
        /// <param name="includeSeries">True or False</param>
        /// <param name="includeEpisodeFile">True or False</param>
        /// <param name="includeEpisodeImages">True or False</param>
        /// <returns>Returns a list of items between the specified Start and End dates</returns>
        public async Task<List<Classes.Calendar.Calendar>> GetCalendar(DateTime startDate, DateTime endDate, bool unmonitored = false,
        bool includeSeries = false, bool includeEpisodeFile = false, bool includeEpisodeImages = false)
        {

            var req = new RestRequest("/api/v3/calendar", Method.Get);
            req.AddHeader("accept", "application/json");
            req.AddQueryParameter("start", startDate.ToString("MM-dd-yyyy"));
            req.AddQueryParameter("end", endDate.ToString("MM-dd-yyyy"));
            req.AddQueryParameter("unmonitored", unmonitored);
            req.AddQueryParameter("includeSeries", includeSeries);
            req.AddQueryParameter("includeEpisodeFile", includeEpisodeFile);
            req.AddQueryParameter("includeEpisodeImages", includeEpisodeImages);

            var response = await _client.ExecuteAsync(req);

            try
            {
                var content = JsonConvert.DeserializeObject<List<Classes.Calendar.Calendar>>(response.Content);
                return content;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// Get a List of calendar items with the specific series id from a specific date
        /// </summary>
        /// <param name="id">ID of the show on the calendar. I don't believe this is tied to the TVDBID</param>
        /// <param name="startDate">DateTime for the specified start date</param>
        /// <param name="unmonitored">True or False</param>
        /// <param name="includeSeries">True or False</param>
        /// <param name="includeEpisodeFile">True or False</param>
        /// <param name="includeEpisodeImages">True or False</param>
        /// <returns>Return a list of items based on the specific ID from the specified start date</returns>
        public async Task<List<Classes.Calendar.Calendar>> GetCalendar(int id, DateTime startDate, bool unmonitored = false,
        bool includeSeries = false, bool includeEpisodeFile = false, bool includeEpisodeImages = false)
        {
            var req = new RestRequest($"/api/v3/calendar/{id}", Method.Get);
            req.AddHeader("accept", "application/json");
            req.AddQueryParameter("start", startDate.ToString("MM-dd-yyyy"));
            req.AddQueryParameter("unmonitored", unmonitored);
            req.AddQueryParameter("includeSeries", includeSeries);
            req.AddQueryParameter("includeEpisodeFile", includeEpisodeFile);
            req.AddQueryParameter("includeEpisodeImages", includeEpisodeImages);

            var response = await _client.ExecuteAsync(req);

            if (response.IsSuccessful)
            {
                try
                {
                    var content = JsonConvert.DeserializeObject<List<Classes.Calendar.Calendar>>(response.Content);

                    return content;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Get a List of calendar items with the specific series id between a specific date range
        /// </summary>
        /// <param name="id">ID of the show on the calendar. I don't believe this is tied to the TVDBID</param>
        /// <param name="startDate">DateTime for the specified start date</param>
        /// <param name="endDate">DateTime for the specified end date</param> 
        /// <param name="tags">Specific tag that can be applied to find specific series with the ID and tag</param>
        /// <param name="unmonitored">True or False</param>
        /// <param name="includeSeries">True or False</param>
        /// <param name="includeEpisodeFile">True or False</param>
        /// <param name="includeEpisodeImages">True or False</param>
        /// <returns>Return a list of items from a specific ID from the specified date range</returns>
        public async Task<List<Classes.Calendar.Calendar>> GetCalendar(int id, DateTime startDate, DateTime endDate, string tags, bool unmonitored = false,
        bool includeSeries = false, bool includeEpisodeFile = false, bool includeEpisodeImages = false)
        {
            var req = new RestRequest($"/api/v3/calendar/{id}", Method.Get);
            req.AddHeader("accept", "application/json");
            req.AddQueryParameter("start", startDate.ToString("MM-dd-yyyy"));
            req.AddQueryParameter("end", endDate.ToString("MM-dd-yyyy"));
            req.AddQueryParameter("unmonitored", unmonitored);
            req.AddQueryParameter("includeSeries", includeSeries);
            req.AddQueryParameter("includeEpisodeFile", includeEpisodeFile);
            req.AddQueryParameter("includeEpisodeImages", includeEpisodeImages);
            req.AddQueryParameter("tags", tags);

            var response = await _client.ExecuteAsync(req);

            if (response.IsSuccessful)
            {
                try
                {
                    var content = JsonConvert.DeserializeObject<List<Classes.Calendar.Calendar>>(response.Content);

                    return content;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}