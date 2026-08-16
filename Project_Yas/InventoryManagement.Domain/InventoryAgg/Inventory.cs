using _0_Framework.Domain;
using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.InventoryAgg
{
    public class Inventory : EntityBase
    {
   

        public long ProductId { get; private set; }//مربوط به چه محصولی
        public double UnitPrice { get; private set; } // قیمت این محصول، قیمت داخل انباره چون شاید رنگ یا مدل خاصی داشته باشه
        public bool InStock { get; private set; }// موجود بودن یا نه
        public List<InventoryOperation> Operations { get; private set; }// چه عملیاتی داره 
        public Inventory(long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            InStock = false;//چون هیچ عملیتی براش انجام نشده من این را فالس میزارم
        }
        public void Edit(long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
        }

        // اولین کاری که باید بکنیم اینه محاسبه مقدار فعلی  یعنی چه تعدادی در این انبار موجود است
        public long CalculateInventoryCount()
        {
            //برای دریافت مقدار فعلی انبار باید به صورت زیر پیش رفت
            //ما باید همه ی عملیات هارا اول بگیریم
            //کاهش موجودی ها را باهم جمع کنیم و افزایش موجودی هم با هم و بعد کاهش ها را از افزایش کم کنیم که یک عددی به دست می آید
            var plus = Operations.Where(x => x.Operation).Sum(x => x.Count);//اینجا جست و جو میشه میگه اونایی که عملیاتشون مثبت بوده کانت ها رو سلکت کن و جمع کن
            var mines = Operations.Where(x => !x.Operation).Sum(x => x.Count);//عملیات های منفی را گرفتیم
            return plus - mines;
        }
        /*
         این متد برای افزایش موجودی هست 
        در ابتدا میاد تعداد را میگیرد یعنی چه تعداد میخوای افزایش موجودی انجام بدی؟
        بعد باید اپریتور ایدی را بگیرد یعنی اون کسی که داره این کار را انجام میده 
        و بعد هم باید توضیحات بگیره 
         */
        public void Increase(long count, long operatorId, string description)
        {
            var currentCount = CalculateInventoryCount() + count;// اگر این افزایش صورت بپذیرد مقدار فعلی چه قدر میشود
            //ما باید یک آپریشن بسازیم و اضافه کنیم به آپریشنی که در کلاس اینونتوری داریم
            //حالا یک نمونه میگیریم و مقدار میدیم 
            //اول وقتی افزایش داریم باید ترو بدیم ، تعداد را بعد میدیم 
            //کانت کونت هم بالا حساب کردیم بعد توضیحات و بعد اوردرآیدی که اون را 0 میدیم چون افزایش توسط یک نفر داخل مجموعه انجام میشه
            //و بعد اینونتوری ایدی میدیم که خود ایدی موجود هست
            var operation = new InventoryOperation(true, count, operatorId, currentCount, description, 0, Id);
            Operations.Add(operation);//اضافه کن به لیست بالا 
            InStock = currentCount > 0; // و درنهایت حساب کن ببین ایا با احتساب این اتفاق هنوز موجودی انباز منفی هست یا نه
        }
        
        public void Reduce(long count, long operationId, string description, long orderId)
        {
            var currentCount = CalculateInventoryCount() - count;
            var operation = new InventoryOperation(false, count, operationId, currentCount, description, orderId, Id);
            Operations.Add(operation);
            InStock = currentCount > 0;

        }
    }
    public class InventoryOperation
    {
        public InventoryOperation(bool operation, long count, long operationId, long currentCount,
            string description, long orderId, long inventoryId)
        {
            Operation = operation;
            Count = count;
            OperationId = operationId;
            CurrentCount = currentCount;
            Description = description;
            OrderId = orderId;
            InventoryId = inventoryId;
            OperationDate = DateTime.Now;
        }
        protected InventoryOperation()
        {
        }

        public long Id { get; private set; }
        public bool Operation { get; private set; } //ورود بوده یا خروج
        public long  Count { get; private set; }//چه تعدادی وارد یا خارج شده
        public long OperationId { get; private set; }//چه کسی این کار را انجام داده
        public DateTime OperationDate { get; private set; }//در چه تاریخی این کار صورت گرفته
        public long CurrentCount { get; private set; }//وقتی این کار صورت گرفته مقدار انبار چقدر بوده
        public string Description { get; private set; }//به چه دلیل این کار صورت گرفته
        public long OrderId { get; private set; }//طبغ چه سفارشی این خروج صورت گرفته
        public long InventoryId { get; private set; } //و اینکه این ورود و خروج مربوط به کدام انبار بوده
        public Inventory Inventory { get; private set; }
      


    }
}
