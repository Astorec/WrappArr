using RestSharp;

namespace WrappArr.Methods{
    public static class CreateClientRequest
    {
        public static RestRequest CreatRequest(string resource, Method method, Dictionary<string, object> queryParams = null)
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