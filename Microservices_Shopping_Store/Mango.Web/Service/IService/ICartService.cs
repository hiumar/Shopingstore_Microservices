using Mango.Web.Models;

namespace Mango.Web
{
    public interface ICartService
    {
        Task<ResponseDTO?> GetCartByUserIdAsnyc(string userId);
        Task<ResponseDTO?> UpsertCartAsync(CartDto cartDto);
        Task<ResponseDTO?> RemoveFromCartAsync(int cartDetailsId);
        Task<ResponseDTO?> ApplyCouponAsync(CartDto cartDto);
        Task<ResponseDTO?> EmailCart(CartDto cartDto);
    }
}
