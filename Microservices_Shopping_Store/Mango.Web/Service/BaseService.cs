using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;
using Mano.Services.Coupan.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static Mango.Web.Utility.SD;

namespace Mango.Web.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ResponsetDTO?> SendResponseAsyn(RequestDTO requestDTO)
        {
            try
            {
                // Create an HttpClient instance from the factory
                HttpClient httpClient = _httpClientFactory.CreateClient("MongoApis");

                // Set the request URI from the URL property in requestDTO
                string requestUri = requestDTO.URL;

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
                    Content = new StringContent(requestDTO.Content ?? string.Empty, System.Text.Encoding.UTF8, "application/json")
                };

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
                    System.Net.HttpStatusCode.OK => JsonConvert.DeserializeObject<ResponsetDTO>(await response.Content.ReadAsStringAsync()),
                    System.Net.HttpStatusCode.NotFound => new ResponsetDTO { IsSuccess = false, Message = "Not Found" },
                    System.Net.HttpStatusCode.Forbidden => new ResponsetDTO { IsSuccess = false, Message = "Access Denied" },
                    System.Net.HttpStatusCode.Unauthorized => new ResponsetDTO { IsSuccess = false, Message = "Unauthorized" },
                    System.Net.HttpStatusCode.InternalServerError => new ResponsetDTO { IsSuccess = false, Message = "Internal Server Error" },
                    _ => null // Handle other status codes as needed
                };
            }
            catch (HttpRequestException ex)
            {
                // Handle any HTTP request exceptions here
                // You can log the exception and return an error response
                // For example:

                var dto = new ResponsetDTO
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
