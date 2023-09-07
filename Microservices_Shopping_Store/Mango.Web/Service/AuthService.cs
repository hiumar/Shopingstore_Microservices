using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;

namespace Mango.Web.Service
{
    public class AuthService : IAuthService
    {
        private readonly IBaseService _baseService;
        public AuthService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDTO?> AssignRoleAsync(RegistrationRequestDto registrationRequestDto)
        {
            return await _baseService.SendResponseAsyn(new RequestDTO()
            {
                ApiType = SD.ApiType.POST,
                Data = registrationRequestDto,
                URL = SD.AuthAPIBase + "/api/auth/AssignRole"
            }, withBearer: false);
        }

        public async Task<ResponseDTO?> LoginAsync(LoginRequestDto loginRequestDto)
        {
            return await _baseService.SendResponseAsyn(new RequestDTO()
            {
                ApiType = SD.ApiType.POST,
                Data = loginRequestDto,
                URL = SD.AuthAPIBase + "/api/auth/login"
            }, withBearer: false);
        }

        public async Task<ResponseDTO?> RegisterAsync(RegistrationRequestDto registrationRequestDto)
        {
            return await _baseService.SendResponseAsyn(new RequestDTO()
            {
                ApiType = SD.ApiType.POST,
                Data = registrationRequestDto,
                URL = SD.AuthAPIBase + "/api/auth/register"
            }, withBearer: false);
        }
    }
}
