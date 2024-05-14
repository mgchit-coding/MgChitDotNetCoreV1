using Azure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MgChitDotNetCore.Shared.Services
{
    public class HttpClientService
    {
        private readonly HttpClient _httpClient;
        public HttpClientService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7040");
        }

        public async Task<T?> Execute<T>(string endpoint, EnumHttpMethod httpMethod, object? requestModel = null)
        {
            HttpResponseMessage? httpResponse = null;
            HttpContent? httpContent = null;
            T? model = default;

            if (requestModel is not null)
            {
                var json = requestModel.ToJson();
                httpContent = new StringContent(json, Encoding.UTF8, Application.Json);
            }

            try
            {
                switch (httpMethod)
                {
                    case EnumHttpMethod.GET:
                        httpResponse = await _httpClient.GetAsync(endpoint);
                        break;
                    case EnumHttpMethod.POST:
                        httpResponse = await _httpClient.PostAsync(endpoint, httpContent);
                        break;
                    case EnumHttpMethod.PUT:
                        httpResponse = await _httpClient.PutAsync(endpoint, httpContent);
                        break;
                    case EnumHttpMethod.DELETE:
                        httpResponse = await _httpClient.DeleteAsync(endpoint);
                        break;
                    default:
                        throw new Exception("Invalid Http Method.");
                }
                var responseJson = await httpResponse.Content.ReadAsStringAsync();
                model = JsonConvert.DeserializeObject<T>(responseJson);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return model;
        }
    }

    public enum EnumHttpMethod
    {
        Non,
        GET,
        POST,
        PUT,
        DELETE,
    }
}
