using _0_Framework.Domain;
using _0_Framework.Infrastructure;
using ShopManagement.Application.Contract.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductAgg
{
    public interface IProductRepository : IRepository<long , Product>
    {
        EditProduct GetDetailse(long id);
        List<ProductViewModel> Search(ProductSearchModel searchModel);
    }
}
