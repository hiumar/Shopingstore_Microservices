using Mango.Web.Models;
using Mango.Web.Service.IService;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using static Mango.Web.Utility.SD;

namespace Mango.Web.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ITokenProvider _tokenProvider;
        public BaseService(IHttpClientFactory httpClientFactory, ITokenProvider tokenProvider)
        {
            _httpClientFactory = httpClientFactory;
            _tokenProvider = tokenProvider;
        }

        public async Task<ResponseDTO?> SendResponseAsyn(RequestDTO requestDto, bool withBearer = true)
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("MangoAPI");
                HttpRequestMessage message = new();
                if (requestDto.ContentType == ContentType.MultipartFormData)
                {
                    message.Headers.Add("Accept", "*/*");
                }
                else
                {
                    message.Headers.Add("Accept", "application/json");
                }
                //token
                if (withBearer)
                {
                    var token = _tokenProvider.GetToken();
                    message.Headers.Add("Authorization", $"Bearer {token}");
                }

                message.RequestUri = new Uri(requestDto.URL);

                if (requestDto.ContentType == ContentType.MultipartFormData)
                {
                    var content = new MultipartFormDataContent();

                    foreach (var prop in requestDto.Data.GetType().GetProperties())
                    {
                        var value = prop.GetValue(requestDto.Data);
                        if (value is FormFile)
                        {
                            var file = (FormFile)value;
                            if (file != null)
                            {
                                content.Add(new StreamContent(file.OpenReadStream()), prop.Name, file.FileName);
                            }
                        }
                        else
                        {
                            content.Add(new StringContent(value == null ? "" : value.ToString()), prop.Name);
                        }
                    }
                    message.Content = content;
                }
                else
                {
                    if (requestDto.Data != null)
                    {
                        message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
                    }
                }





                HttpResponseMessage? apiResponse = null;

                switch (requestDto.ApiType)
                {
                    case ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    case ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                apiResponse = await client.SendAsync(message);

                switch (apiResponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new() { IsSuccess = false, Message = "Not Found" };
                    case HttpStatusCode.Forbidden:
                        return new() { IsSuccess = false, Message = "Access Denied" };
                    case HttpStatusCode.Unauthorized:
                        return new() { IsSuccess = false, Message = "Unauthorized" };
                    case HttpStatusCode.InternalServerError:
                        return new() { IsSuccess = false, Message = "Internal Server Error" };
                    default:
                        var apiContent = await apiResponse.Content.ReadAsStringAsync();
                        var apiResponseDto = JsonConvert.DeserializeObject<ResponseDTO>(apiContent);
                        return apiResponseDto;
                }
            }
            catch (Exception ex)
            {
                var dto = new ResponseDTO
                {
                    Message = ex.Message.ToString(),
                    IsSuccess = false
                };
                return dto;
            }
        }

       
    }
}





//using Mango.Web.Models;
//using Mango.Web.Service.IService;
//using Mango.Web.Utility;
//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
//using System;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;
//using static Mango.Web.Utility.SD;

//namespace Mango.Web.Service
//{
//    public class BaseService : IBaseService
//    {
//        private readonly IHttpClientFactory _httpClientFactory;
//        private readonly ITokenProvider _tokenProvider;

//        public BaseService(IHttpClientFactory httpClientFactory, ITokenProvider tokenProvider)
//        {
//            _httpClientFactory = httpClientFactory;
//            _tokenProvider = tokenProvider;
//        }

//        public async Task<ResponseDTO?> SendResponseAsyn(RequestDTO requestDTO, bool withBearer = true)
//        {
//            try
//            {
//                Create an HttpClient instance from the factory

//               HttpClient httpClient = _httpClientFactory.CreateClient("MongoApis");

//                Set the request URI from the URL property in requestDTO
//                string requestUri = requestDTO.URL;
//                Create an HttpRequestMessage with the appropriate HTTP method
//                    HttpMethod httpMethod = requestDTO.ApiType switch
//                    {
//                        ApiType.GET => HttpMethod.Get,
//                        ApiType.PUT => HttpMethod.Put,
//                        ApiType.DELETE => HttpMethod.Delete,
//                        ApiType.POST => HttpMethod.Post,
//                        _ => throw new NotImplementedException("Unsupported API type")
//                    };

//                var requestMessage = new HttpRequestMessage
//                {
//                    Method = httpMethod,
//                    RequestUri = new Uri(requestUri),
//                    System.Net.Http.Headers.Add("Accept", "application/json")
//                Content = new StringContent(requestDTO.Content ?? string.Empty, System.Text.Encoding.UTF8, "application/json")
//                };
//                if (requestDTO.Data != null)
//                    requestMessage.Content = new StringContent(JsonConvert.SerializeObject(requestDTO.Data), Encoding.UTF8, "application/json");
//                requestMessage.Headers.Add("Accept", "application/json");

//                Add any required headers, including AccessToken if needed
//                if (withBearer)
//                    {
//                        var token = _tokenProvider.GetToken();
//                        requestMessage.Headers.Add("Authorization", $"Bearer {token}");
//                    }

//                Send the request and get the response
//               HttpResponseMessage response = await httpClient.SendAsync(requestMessage);

//                Use switch expression to handle different status codes
//                return response.StatusCode switch
//                {
//                    System.Net.HttpStatusCode.OK => JsonConvert.DeserializeObject<ResponseDTO>(await response.Content.ReadAsStringAsync()),
//                    System.Net.HttpStatusCode.NotFound => new ResponseDTO { IsSuccess = false, Message = "Not Found" },
//                    System.Net.HttpStatusCode.Forbidden => new ResponseDTO { IsSuccess = false, Message = "Access Denied" },
//                    System.Net.HttpStatusCode.Unauthorized => new ResponseDTO { IsSuccess = false, Message = "Unauthorized" },
//                    System.Net.HttpStatusCode.InternalServerError => new ResponseDTO { IsSuccess = false, Message = "Internal Server Error" },
//                    _ => null // Handle other status codes as needed
//                };
//            }

//            catch (HttpRequestException ex)
//            {
//                Handle any HTTP request exceptions here
//                 You can log the exception and return an error response
//                 For example:

//                var dto = new ResponseDTO
//                {
//                    Message = ex.Message,
//                    IsSuccess = false
//                };
//                Console.WriteLine($"HTTP Request Exception: {ex.Message}");
//                return dto;
//            }
//        }
//    }
//}
