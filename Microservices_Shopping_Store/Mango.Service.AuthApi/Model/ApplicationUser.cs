using Microsoft.AspNetCore.Identity;

namespace Mango.Service.AuthApi.Model
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
    }
}
