using RestSharp;
using WrappArr.Methods;

namespace WrappArr.APICalls.System
{
    public class SystemCommands
    {
        private readonly RestClient _client;
        public SystemCommands(RestClient client)
        {
            _client = client;
        }

        public async Task<RestResponse> Shutdown()
        {
            var req = CreateClientRequest.CreatRequest("api/v3/system/shutdown", Method.Post);
            return await _client.ExecuteAsync(req);
        }

        public async Task<RestResponse> Restart()
        {
            var req = CreateClientRequest.CreatRequest("api/v3/system/restart", Method.Post);
            return await _client.ExecuteAsync(req);
        }
    }
}