using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Application.Contract.ProductPicture;
using System.Runtime.CompilerServices;

namespace ServicesHost.Areas.Administration.Pages.Shop.ProductPictures
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public ProducPictureSearchModel SearchModel;
        public List<ProductPictureVeiwModel> ProductPicture;
        public SelectList Products;
        private readonly IProductApplication _productApplication;
        private readonly IProductPictureApplication _productPictureApplication;
        public IndexModel(IProductApplication productApplication, IProductPictureApplication productPictureApplication)
        {
            _productApplication = productApplication;
            _productPictureApplication = productPictureApplication;
        }
        public void OnGet(ProducPictureSearchModel searchModel)
        {
            Products = new SelectList(_productApplication.GetProduct(),"Id" , "Name");
            ProductPicture = _productPictureApplication.search(searchModel);
        }
        public IActionResult OnGetCreate()
        {
            var command = new CreateProductPicture
            {
                Products = _productApplication.GetProduct()
            };
            return Partial("./Create", command);
        }
        //چون من داخل لایه اپلیکیشن از متد اوپریشن ریزالت استفاده کردم باید اینجا نوع متد را جیسون قرار دهم که بتواند آن را برگردنداند
        public JsonResult OnPostCreate(CreateProductPicture command)
        {
            var result = _productPictureApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var productcategory = _productPictureApplication.GetDetailse(id);
            productcategory.Products = _productApplication.GetProduct();
            return Partial("./Edit", productcategory);
        }

        public JsonResult OnPostEdit(EditProductPicture command)
        {
            var result = _productPictureApplication.Edit(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemove(long id)
        {
           var result = _productPictureApplication.Remove(id);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            Message = result.Message;
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRestore(long id)
        {
         var result = _productPictureApplication.Restore(id);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            Message = result.Message;
            return RedirectToPage("./Index");
        }
    }
}
