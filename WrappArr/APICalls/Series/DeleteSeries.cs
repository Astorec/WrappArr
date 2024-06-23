using RestSharp;
using WrappArr.Methods;

namespace WrappArr.APICalls.Series
{
    public class DeleteSeries
    {
        private readonly RestClient _client;
        public DeleteSeries(RestClient client)
        {
            _client = client;
        }


        /// <summary>
        /// Delete a series by ID
        /// </summary>
        /// <param name="seriesId">The ID of the series to delete</param>
        /// <param name="apiKey">The API Key for the server. This is required here as it is needed in the URL as well</param>
        /// <param name="deleteFiles">Whether to delete the files associated with the series. False by default</param>
        /// <param name="addImportListExclusion">Whether to add the series to the import list exclusion list. False by Default</param>
        public async Task<RestResponse> Delete(string seriesId, string apiKey, bool deleteFiles = false, bool addImportListExclusion = false)
        {
            var req = CreateClientRequest.CreatRequest("api/v3/series/" + seriesId, Method.Delete, new Dictionary<string, object>
            {
                {"apikey", apiKey},
                {"deleteFiles", deleteFiles},
                {"addImportListExclusion", addImportListExclusion}
            });
            return await _client.ExecuteAsync(req);
        }
    }
}