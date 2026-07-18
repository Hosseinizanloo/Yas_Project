using _0_Framework.Domain;
using _0_Framework.Infrastructure;
using ShopManagement.Application.Contract.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    // من میتونم از دامین به کانترکت هام رفرنس بزنم مشکلی ندارد
    public interface IProductCategoryRepository : IRepository<long , ProductCategory> 
    {
        EditProductCategory GetDetailse(long id);// بر اساس ایدی این اطلاعات را برای من بگیر از دیتابیس که من نمایش بدهم در قسمت ادیت
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);// برای من سرچ کن بر اساس نام و ان را به صورت یک لیست نمایش بده 

    }
}
