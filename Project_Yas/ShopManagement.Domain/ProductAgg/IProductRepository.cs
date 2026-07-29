using _0_Framework.Domain;
using _0_Framework.Infrastructure;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductPicture;
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


        //برای نمایش گروه محصولی میباشد در ماژول محصولات یا دیگر گزینه ها 
        List<ProductViewModel> GetProduct();
    }
}
