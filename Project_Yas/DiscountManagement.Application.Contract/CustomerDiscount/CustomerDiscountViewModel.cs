namespace DiscountManagement.Application.Contract.CustomerDiscount
{
    public class CustomerDiscountViewModel
    {
        public long Id { get; set; }
        public long ProductId { get; set; }//کدام محصول میخواد 
        public string Product { get; set; }
        public int DiscountRate { get; set; } // درصد تخفیف
        public string StartDate { get; set; } // این تخفیف در چهع تاریخی شروع شود
        public DateTime StartDateGr { get; set; } // این تخفیف در چهع تاریخی شروع شود
        public DateTime EndDateGr { get; set; } // در چه تاریخی تمام شود 
        public string EndDate { get; set; } // در چه تاریخی تمام شود 
        public string Reason { get; set; }
    }


}
