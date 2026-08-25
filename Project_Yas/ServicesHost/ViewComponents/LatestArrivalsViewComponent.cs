using _01_YasQuery.Contract.Product;
using Microsoft.AspNetCore.Mvc;

namespace ServicesHost.ViewComponents
{
    public class LatestArrivalsViewComponent : ViewComponent
    {
        private readonly IProductQueryModel _productQueryModel;

        public LatestArrivalsViewComponent(IProductQueryModel productQueryModel)
        {
            _productQueryModel = productQueryModel;
        }

        public IViewComponentResult Invoke()
        {
            var product = _productQueryModel.GetLatestArrivals();
            return View(product);
        }
    }
}
