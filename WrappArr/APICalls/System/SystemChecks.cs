using RestSharp;
using WrappArr.Methods;

namespace WrappArr.APICalls.System
{
    public class SystemChecks
    {
        private readonly RestClient _client;
        public SystemChecks(RestClient client)
        {
            _client = client;
        }

        public async Task<RestResponse> GetStatus()
        {
            var req = CreateClientRequest.CreatRequest("api/v3/system/status", Method.Get);
            return await _client.ExecuteAsync(req);
        }

        public async Task<RestResponse> GetRoutes()
        {
            var req = CreateClientRequest.CreatRequest("api/v3/system/routes", Method.Get);
            return await _client.ExecuteAsync(req);
        }

        public async Task<RestResponse> GetRoutesDuplicate()
        {
            var req = CreateClientRequest.CreatRequest("api/v3/system/routes/duplicate", Method.Get);
            return await _client.ExecuteAsync(req);
        }
    }
}