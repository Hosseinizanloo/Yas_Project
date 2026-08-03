using _01_YasQuery.Contract.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServicesHost.ViewComponents
{
    public class ProductCategoryViewComponent : ViewComponent
    {
        private readonly IProductCategoryQuery _productCategoryQuery;

        public ProductCategoryViewComponent(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }

        // به طور کلی باید از 
        //IViewComponentResult
        //استفاده شود 
        public IViewComponentResult Invoke() 
        {
            var productCategory = _productCategoryQuery.GetProductCategories();
            return View(productCategory);
        }
    }
}
