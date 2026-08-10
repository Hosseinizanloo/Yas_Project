using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Contract.Inventory
{
    public class IncreaseInventory 
    {
        public long InventoryId { get; set; }// کدام انبار افزایش داده میشه 
        public long Count { get; set; } // چه تعداد افزایش داده میشه 
        public string Description { get; set; }


    }
}
