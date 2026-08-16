using _0_Framework.Domain;
using _0_Framework.Infrastructure;
using InventoryManagement.Application.Contract.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.InventoryAgg
{
    public interface IInventoryRepository : IRepository<long , Inventory>
    {
        EditInventory Getdetails(long id);
        Inventory GetBy(long ProductId);// از طریق ایدی محصول اون انبار را به من بده
        List<InventoryViewModel> Search(InventorySearchModel searchModel);
        List<InventoryOperationViewModel> GetOperationLog(long inventoryId);

    }
}
