using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static Mango.Web.Utility.SD;
using ResponseDTO = Mango.Web.Models.ResponseDTO;

namespace Mango.Web.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ResponseDTO?> SendResponseAsyn(RequestDTO requestDTO, bool withBearer)
        {
            try
            {
                // Create an HttpClient instance from the factory
                HttpClient httpClient = _httpClientFactory.CreateClient("MongoApis");

                // Set the request URI from the URL property in requestDTO
                string requestUri = requestDTO.Url;
                    // Create an HttpRequestMessage with the appropriate HTTP method
                    HttpMethod httpMethod = requestDTO.ApiType switch
                {
                    ApiType.GET => HttpMethod.Get,
                    ApiType.PUT => HttpMethod.Put,
                    ApiType.DELETE => HttpMethod.Delete,
                    ApiType.POST => HttpMethod.Post,
                    _ => throw new NotImplementedException("Unsupported API type")
                };

                var requestMessage = new HttpRequestMessage
                {
                    Method = httpMethod,
                    RequestUri = new Uri(requestUri),
                   // System.Net.Http.Headers.Add("Accept", "application/json")
               // Content = new StringContent(requestDTO.Content ?? string.Empty, System.Text.Encoding.UTF8, "application/json")
               };
                if(requestDTO.Data != null)
                    requestMessage.Content = new StringContent(JsonConvert.SerializeObject(requestDTO.Data), Encoding.UTF8, "application/json");
                //requestMessage.Headers.Add("Accept", "application/json");

                // Add any required headers, including AccessToken if needed
                if (!string.IsNullOrEmpty(requestDTO.AccessToken))
                {
                    requestMessage.Headers.Add("Authorization", $"Bearer {requestDTO.AccessToken}");
                }

                // Send the request and get the response
                HttpResponseMessage response = await httpClient.SendAsync(requestMessage);

                // Use switch expression to handle different status codes
                return response.StatusCode switch
                {
                    System.Net.HttpStatusCode.OK => JsonConvert.DeserializeObject<ResponseDTO>(await response.Content.ReadAsStringAsync()),
                    System.Net.HttpStatusCode.NotFound => new ResponseDTO { IsSuccess = false, Message = "Not Found" },
                    System.Net.HttpStatusCode.Forbidden => new ResponseDTO { IsSuccess = false, Message = "Access Denied" },
                    System.Net.HttpStatusCode.Unauthorized => new ResponseDTO { IsSuccess = false, Message = "Unauthorized" },
                    System.Net.HttpStatusCode.InternalServerError => new ResponseDTO { IsSuccess = false, Message = "Internal Server Error" },
                    _ => null // Handle other status codes as needed
                };
            }
           
            catch (HttpRequestException ex)
            {
                // Handle any HTTP request exceptions here
                // You can log the exception and return an error response
                // For example:

                var dto = new ResponseDTO
                {
                    Message = ex.Message,
                    IsSuccess = false
                };
                Console.WriteLine($"HTTP Request Exception: {ex.Message}");
                return dto;
            }
        }
    }
}
