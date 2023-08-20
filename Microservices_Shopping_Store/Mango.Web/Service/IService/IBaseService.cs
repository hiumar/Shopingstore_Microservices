using Mango.Web.Models;
using Mano.Services.Coupan.Model.DTO;

namespace Mango.Web.Service.IService
{
    public interface IBaseService
    {
       Task<ResponsetDTO?> SendResponseAsyn(RequestDTO requestDTO);
    }
}
