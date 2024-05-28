using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using RestSharp;
using RestSharp.Authenticators;

namespace WrappArr
{
    public class Class1
    {
        public async Task<ResponseStatus> Test()
        {
            try
            {
                var options = new RestClientOptions("http://192.168.1.195:8989");

                var client = new RestClient(options);
                var req = new RestRequest("/api/v3/calendar", Method.Get);
                req.AddHeader("accept", "application/json");
                req.AddHeader("X-Api-Key", "b2e3bf9ce0384ccf890e9f08c85b5c00'");


                req.AddQueryParameter("unmonitored", "false");
                req.AddQueryParameter("includeSeries", "false");
                req.AddQueryParameter("includeEpisodeFile", "false");
                req.AddQueryParameter("includeEpisodeImages", "false");
                req.AddQueryParameter("apikey", "b2e3bf9ce0384ccf890e9f08c85b5c00");
                var response = await client.ExecuteAsync(req);
                Console.WriteLine(response.StatusCode);
                return response.ResponseStatus;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return ResponseStatus.Error;
            }



        }
    }
}

