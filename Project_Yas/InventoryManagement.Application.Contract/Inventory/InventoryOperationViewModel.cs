using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Contract.Inventory
{
    public class InventoryOperationViewModel // دیدن لاگ
    {
        public long Id { get; set; }
        public bool Operation { get; set; } //ورود بوده یا خروج
        public long Count { get; set; }//چه تعدادی وارد یا خارج شده
        public long OperatorId { get; set; }//چه کسی این کار را انجام داده
        public string Operator { get; set; } //اسم اون شخصی که انجام داده 
        public string OperationDate { get; set; }//در چه تاریخی این کار صورت گرفته
        public long CurrentCount { get; set; }//وقتی این کار صورت گرفته مقدار انبار چقدر بوده
        public string Description { get; set; }//به چه دلیل این کار صورت گرفته
        public long OrderId { get; set; }//طبغ چه سفارشی این خروج صورت گرفته
        public long InventoryId { get; set; } //و اینکه این ورود و خروج مربوط به کدام انبار بوده
    }
}
