using RestSharp;

namespace WrappArr.ApiCalls.Auth
{
    public class ApiInit
    {
        private string m_address;
        private int m_port;
        private readonly string m_apiKey;
        private readonly RestClient client;

        /// <summary>
        /// Constructor for the ApiInit class
        /// </summary>
        /// <param name="address">IP Address of the Server</param>
        /// <param name="port">Port that Radarr/Sonarr is running on</param>
        /// <param name="apiKey">The Api Key can be found under General Settings</param>
        public ApiInit(string address, int port, string apiKey)
        {
            m_address = address;
            m_port = port;
            m_apiKey = apiKey;

            var options = new RestClientOptions("http://" + m_address + ":" + m_port);

            client = new RestClient(options);
            client.AddDefaultHeader("X-Api-Key", m_apiKey);
        }

        public async Task Login()
        {
            try
            {
                var req = new RestRequest("/login", Method.Post);
                req.AddHeader("accept", "*/*");

                Console.WriteLine($"Logging in to {m_address}:{m_port}");
                var response = await client.ExecuteAsync(req);
                Console.WriteLine("Response from server: " + response.StatusCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public RestClient GetClient()
        {
            return client;
        }
    }
}