using Mango.Web.Models;
using ResponseDTO = Mango.Web.Models.ResponseDTO;

namespace Mango.Web.Service.IService
{
    public interface IBaseService
    {
       Task<ResponseDTO?> SendResponseAsyn(RequestDTO requestDTO, bool withBearer = true);
    }
}
