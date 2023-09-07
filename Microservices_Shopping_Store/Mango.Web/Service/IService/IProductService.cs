using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface IProductService
    {
     
        Task<ResponseDTO?> GetAllProductsAsync();
        Task<ResponseDTO?> GetProductByIdAsync(int id);
        Task<ResponseDTO?> CreateProductsAsync(ProductDto productDto);
        Task<ResponseDTO?> UpdateProductsAsync(ProductDto productDto);
        Task<ResponseDTO?> DeleteProductsAsync(int id);
    }
}
