using DiscountManagement.Application;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using DiscountManagement.Application.Contract.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.Product;

namespace ServicesHost.Areas.Administration.Pages.Discounts.ColleagueDiscount
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public ColleagueSearchModel SearchModel;
        public List<ColleagueViewModel> ColleagueDiscount;
        public SelectList Product;
        private readonly IProductApplication _productApplication;
        private readonly IColleagueDiscountApplication _colleaugeDiscountApplication;
        public IndexModel(IProductApplication productApplication, IColleagueDiscountApplication colleaugeDiscountApplication)
        {
            _productApplication = productApplication;
            _colleaugeDiscountApplication = colleaugeDiscountApplication;
        }
        public void OnGet(ColleagueSearchModel searchModel)
        {
            Product = new SelectList(_productApplication.GetProduct(), "Id", "Name");
            ColleagueDiscount = _colleaugeDiscountApplication.Search(searchModel);
        }
        public IActionResult OnGetCreate()
        {
            var command = new DefineColleagueDiscount
            {
                Products = _productApplication.GetProduct()
            };
            return Partial("./Create" , command);
        }
        //چون من داخل لایه اپلیکیشن از متد اوپریشن ریزالت استفاده کردم باید اینجا نوع متد را جیسون قرار دهم که بتواند آن را برگردنداند
        public JsonResult OnPostCreate(DefineColleagueDiscount command)
        {
            var result = _colleaugeDiscountApplication.Define(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var colleagueDiscount = _colleaugeDiscountApplication.GetDetailse(id);
            colleagueDiscount.Products = _productApplication.GetProduct();
            return Partial("./Edit", colleagueDiscount);
        }

        public JsonResult OnPostEdit(EditColleagueDiscount command)
        {
            var result = _colleaugeDiscountApplication.Edit(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemove(long id)
        {
            _colleaugeDiscountApplication.Remove(id);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRestore(long id)
        {
            _colleaugeDiscountApplication.Resome(id);
            return RedirectToPage("./Index");
        }

    }
}
