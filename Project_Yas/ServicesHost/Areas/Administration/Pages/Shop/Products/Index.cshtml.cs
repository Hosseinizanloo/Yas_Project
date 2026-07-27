using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductCategory;

namespace ServicesHost.Areas.Administration.Pages.Shop.Products
{
    public class IndexModel : PageModel
    {
        public ProductSearchModel SearchModel;
        public List<ProductViewModel> Products;
        public SelectList ProductCategories;
        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _categoryApplication;
        public IndexModel(IProductApplication productApplication, IProductCategoryApplication categoryApplication)
        {
            _productApplication = productApplication;
            _categoryApplication = categoryApplication;
        }
        public void OnGet(ProductSearchModel searchModel)
        {
            ProductCategories = new SelectList(_categoryApplication.GetProductCategories(),"Id" , "Name");
            Products = _productApplication.Search(searchModel);
        }
        public IActionResult OnGetCreate()
        {
            var command = new CreateProduct
            {
                Categories = _categoryApplication.GetProductCategories()
            };
            return Partial("./Create", command);
        }
        //چون من داخل لایه اپلیکیشن از متد اوپریشن ریزالت استفاده کردم باید اینجا نوع متد را جیسون قرار دهم که بتواند آن را برگردنداند
        public JsonResult OnPostCreate(CreateProduct command)
        {
            var result = _productApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var productcategory = _productApplication.GetDetailse(id);
            productcategory.Categories = _categoryApplication.GetProductCategories();
            return Partial("./Edit", productcategory);
        }

        public JsonResult OnPostEdit(EditProduct command)
        {
            var result = _productApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
