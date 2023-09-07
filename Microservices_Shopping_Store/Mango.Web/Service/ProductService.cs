using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;

namespace Mango.Web.Service
{
    public class ProductService : IProductService
    {
        private readonly IBaseService _baseService;
        public ProductService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDTO?> CreateProductsAsync(ProductDto productDto)
        {
            return await _baseService.SendResponseAsyn(new RequestDTO()
            {
                ApiType = SD.ApiType.POST,
                Data=productDto,
                URL = SD.ProductAPIBase + "/api/product" ,
                ContentType = SD.ContentType.MultipartFormData
            });
        }

        public async Task<ResponseDTO?> DeleteProductsAsync(int id)
        {
            return await _baseService.SendResponseAsyn(new RequestDTO()
            {
                ApiType = SD.ApiType.DELETE,
                URL = SD.ProductAPIBase + "/api/product/" + id
            }); 
        }

        public async Task<ResponseDTO?> GetAllProductsAsync()
        {
            return await _baseService.SendResponseAsyn(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                URL = SD.ProductAPIBase + "/api/product"
            });
        }

      

        public async Task<ResponseDTO?> GetProductByIdAsync(int id)
        {
            return await _baseService.SendResponseAsyn(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                URL = SD.ProductAPIBase + "/api/product/" + id
            });
        }

        public async Task<ResponseDTO?> UpdateProductsAsync(ProductDto productDto)
        {
            return await _baseService.SendResponseAsyn(new RequestDTO()
            {
                ApiType = SD.ApiType.PUT,
                Data = productDto,
                URL = SD.ProductAPIBase + "/api/product",
                ContentType = SD.ContentType.MultipartFormData
            });
        }
    }
}
