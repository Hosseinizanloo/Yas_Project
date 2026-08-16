using _0_Framework.Applicatio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Contract.Inventory
{
    public interface IInventoryApplication
    {
        OperationResult Create(CreateInventory command);
        OperationResult Edit(EditInventory command);
        OperationResult Increase(IncreaseInventory command);
        OperationResult Reduce(ReduceInventory command);

        //وقتی میخواد خرید بشه ممکنه در سبد خرید چندین کالا وجود داشته باشد
        OperationResult Reduce(List<ReduceInventory> command);
        EditInventory GetDetails(long id);
        List<InventoryViewModel>Search(InventorySearchModel searchModel);
        List<InventoryOperationViewModel> GetOperationLog(long inventoryId);
    }
}
