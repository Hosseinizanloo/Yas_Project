using _01_YasQuery.Contract.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServicesHost.Pages
{
    public class ProductCategoryModel : PageModel
    {
        public ProductCategoryQueryModel ProductCategoryQueryModel { get; set; }
        private readonly IProductCategoryQuery _productCategoryQuery;
        public ProductCategoryModel(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }

        public void OnGet(string id)
        {
            ProductCategoryQueryModel = _productCategoryQuery.GetProductCategoeyWhitProductsBy(id);     
        }
    }
}
