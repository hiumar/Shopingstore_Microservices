using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Mano.Services.Coupan.Model
{
    public class Coupon
    {
        [Key]
        public int CoupanId { get; set; }
        [Required]
        public string CoupanCode{ get; set; }
        [Required]
        public double CoupanDisCount { get; set; }
        public int MinAmount { get; set; }
    }
}
