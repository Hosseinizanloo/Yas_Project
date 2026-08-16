using _0_Framework.Applicatio;
using System.Collections;

namespace ShopManagement.Application.Contract.Product
{
    public interface IProductApplication
    {
        OperationResult Create(CreateProduct command);
        OperationResult Edit(EditProduct command);
        //OperationResult IsStock(long id); // چه محصولی فعال است
        //OperationResult IsNotStock(long id);// چه محصولی غیر فعال است
        EditProduct GetDetails(long id);
        List<ProductViewModel> Search(ProductSearchModel searchModel);


        //برای نمایش سلکت لیست است 
        List<ProductViewModel> GetProduct();
    }
}
