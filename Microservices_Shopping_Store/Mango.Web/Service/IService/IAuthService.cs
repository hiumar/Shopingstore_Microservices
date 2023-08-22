using Mango.Web.Models;
using ResponseDTO = Mango.Web.Models.ResponseDTO;

namespace Mango.Web.Service.IService
{
    public interface IAuthService
    {
        Task<ResponseDTO?> LoginAsync(LoginRequestDto loginRequestDto);
        Task<ResponseDTO?> RegisterAsync(RegistrationRequestDto registrationRequestDto);
        Task<ResponseDTO?> AssignRoleAsync(RegistrationRequestDto registrationRequestDto);
    }
}
