using RestSharp;

namespace WrappArr.Methods
{
    internal static class CreateClientRequest
    {
        /// <summary>
        /// Create a request with the given parameters
        /// </summary>
        /// <param name="resource">The resource to request</param>
        /// <param name="method">The method to use</param>
        /// <param name="queryParams">The query parameters to use</param>
        public static RestRequest CreatRequest(string resource, Method method,
        Dictionary<string, object> queryParams = null)
        {
            var req = new RestRequest(resource, method);
            req.AddHeader("accept", "application/json");

            if (queryParams != null)
            {
                foreach (var param in queryParams)
                {
                    req.AddQueryParameter(param.Key, param.Value.ToString());
                }
            }
            return req;
        }
    }
}