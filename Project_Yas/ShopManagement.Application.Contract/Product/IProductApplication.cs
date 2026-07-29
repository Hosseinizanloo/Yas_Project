using _0_Framework.Applicatio;
using System.Collections;

namespace ShopManagement.Application.Contract.Product
{
    public interface IProductApplication
    {
        OperatioResult Create(CreateProduct command);
        OperatioResult Edit(EditProduct command);
        OperatioResult IsStock(long id); // چه محصولی فعال است
        OperatioResult IsNotStock(long id);// چه محصولی غیر فعال است
        EditProduct GetDetailse(long id);
        List<ProductViewModel> Search(ProductSearchModel searchModel);


        //برای نمایش سلکت لیست است 
        List<ProductViewModel> GetProduct();
    }
}
