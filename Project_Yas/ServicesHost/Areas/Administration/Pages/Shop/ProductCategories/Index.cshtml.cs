using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contract.ProductCategory;

namespace ServicesHost.Areas.Administration.Pages.Shop.ProductCategories
{
    public class IndexModel : PageModel
    {
        public ProductCategorySearchModel SearchModel;
        public List<ProductCategoryViewModel> ProductCategories;
        private readonly IProductCategoryApplication _productCategoryApplication;
        public IndexModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }
        public void OnGet(ProductCategorySearchModel searchModel)
        {
           ProductCategories = _productCategoryApplication.Search(searchModel);
        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateProductCategory());
        }
        //چون من داخل لایه اپلیکیشن از متد اوپریشن ریزالت استفاده کردم باید اینجا نوع متد را جیسون قرار دهم که بتواند آن را برگردنداند
        public JsonResult OnPostCreate(CreateProductCategory command)
        {
            var result = _productCategoryApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var productcategory = _productCategoryApplication.GetDetilse(id);
            return Partial("./EditProduct", productcategory);
        }

        public JsonResult OnPostEdit(EditProductCategory command)
        {
            var result = _productCategoryApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
