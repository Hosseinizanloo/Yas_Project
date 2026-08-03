using _0_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Domain.CustomerDiscountAgg
{
    public class CustomerDiscount : EntityBase
    {
        public CustomerDiscount(long productId, int discountRate, DateTime startDate, DateTime endDate, string reason)
        {
            ProductId = productId;
            DiscountRate = discountRate;
            StartDate = startDate;
            EndDate = endDate;
            Reason = reason;
        }
        public void Edit(long productId, int discountRate, DateTime startDate, DateTime endDate, string reason)
        {
            ProductId = productId;
            DiscountRate = discountRate;
            StartDate = startDate;
            EndDate = endDate;
            Reason = reason;
        }

        public long ProductId { get; private set; }//کدام محصول میخواد 
        public int DiscountRate { get; private set; } // درصد تخفیف
        public DateTime StartDate { get; private set; } // این تخفیف در چهع تاریخی شروع شود
        public DateTime EndDate { get; private set; } // در چه تاریخی تمام شود 
        public string Reason { get; private set; } // دلیل تخفیف
    }
}
