using AGL.Assessment.ExternalServices.Interfaces;
using RestSharp;
using System.Collections.Generic;

namespace AGL.Assessment.ExternalServices
{
    public class HttpHelper<T> : IHttpHelper<T>
    {
        public List<T> GetContentFromURL(string url)
        {
            var client = new RestClient(url);
            var response = client.Execute<List<T>>(new RestRequest());
            return response.Data;
        }
    }
}
