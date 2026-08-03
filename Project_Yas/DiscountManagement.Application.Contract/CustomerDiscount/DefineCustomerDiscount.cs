using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application.Contract.CustomerDiscount
{
    public class DefineCustomerDiscount
    {
        public long ProductId { get; set; }//کدام محصول میخواد 
        public int DiscountRate { get; set; } // درصد تخفیف
        public string StartDate { get; set; } // این تخفیف در چهع تاریخی شروع شود
        public string EndDate { get; set; } // در چه تاریخی تمام شود 
        public string Reason { get; set; }
    }
}
