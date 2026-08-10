

using _0_Framework.Application;
using ShopManagement.Application.Contract.Product;
using System.ComponentModel.DataAnnotations;

namespace DiscountManagement.Application.Contract.CustomerDiscount
{
    public class DefineCustomerDiscount
    {
        [Range(1, 100000, ErrorMessage = ValidationMessage.IsRequired)]
        public long ProductId { get; set; }//کدام محصول میخواد 
        [Range(1, 100000, ErrorMessage = ValidationMessage.IsRequired)]
        public int DiscountRate { get; set; } // درصد تخفیف
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string StartDate { get; set; } // این تخفیف در چهع تاریخی شروع شود
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string EndDate { get; set; } // در چه تاریخی تمام شود 
        public string Reason { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}
