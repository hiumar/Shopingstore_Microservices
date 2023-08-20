using Mango.Web.Utility;
using static Mango.Web.Utility.SD;

namespace Mango.Web.Models
{
    public class RequestDTO
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string URL { get; set; }
        public object Data { get; set; }
        public string Content { get; set; }
        public string AccessToken { get; set; }
    }
}
