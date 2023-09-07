using Mango.Service.ShoppingCartAPi.Models.Dto;

namespace Mango.Service.ShoppingCartAPi.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
