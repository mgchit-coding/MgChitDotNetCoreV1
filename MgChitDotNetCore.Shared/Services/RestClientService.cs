using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MgChitDotNetCore.Shared.Services
{
    public class RestClientService
    {
        private readonly RestClient _client;
        public RestClientService()
        {
            _client = new RestClient(new Uri("https://localhost:7040"));
        }
        public async Task<T?> Execute<T>(string endpoint, EnumHttpMethod httpMethod, object? requestModel = null)
        {
            var restRequest = new RestRequest();
            T? model = default;

            if (requestModel is not null)
            {
                restRequest.AddJsonBody(requestModel);
            }

            try
            {
                switch (httpMethod)
                {
                    case EnumHttpMethod.GET:
                        restRequest = new RestRequest(endpoint, Method.Get);
                        break;
                    case EnumHttpMethod.POST:
                        restRequest = new RestRequest(endpoint, Method.Post);
                        break;
                    case EnumHttpMethod.PUT:
                        restRequest = new RestRequest(endpoint, Method.Put);
                        break;
                    case EnumHttpMethod.DELETE:
                        restRequest = new RestRequest(endpoint, Method.Delete);
                        break;
                    default:
                        throw new Exception("Invalid Http Method.");
                }
                var response = await _client.ExecuteAsync(restRequest);
                model = JsonConvert.DeserializeObject<T>(response.Content!);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return model;
        }
    }
}
