namespace InventoryManagement.Application.Contract.Inventory
{
    public class DecreaseInventory
    {
        public long InventoryId { get; set; }
        public long ProductId { get; set; }// به خاطر اینکه وقتی یوزر کم میکنه من دیگه اونجا اینونتوری را ندارم به جاش پروداکت ایدی را دارم
        public long Count { get; set; }
        public string Description { get; set; }
        public long OrderId { get; set; }

        public DecreaseInventory()
        {

        }

        public DecreaseInventory(long productId, long count, string description, long orderId)
        {
            ProductId = productId;
            Count = count;
            Description = description;
            OrderId = orderId;
        }

    }
}
