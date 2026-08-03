using _0_Framework.Applicatio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.ProductCategory
{
    public interface IProductCategoryApplication
    {
        // به این دلیل من این کلاس را ایجاد کردم که بتونم جواب خطایی برگردونم 
        //شما فرض کن به خطا برخوردی خب اگر وید باشد من نمیتونم خطایی برگردونم یا اگر درست هم ثبت شود باز نمیتونم پیغامی برگردونم 
        OperationResult Create(CreateProductCategory command);
        OperationResult Edit(EditProductCategory command);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);
        EditProductCategory GetDetilse(long id);

        //برای نمایش سلکت لیست است 
        List<ProductCategoryViewModel> GetProductCategories();
    }
}
