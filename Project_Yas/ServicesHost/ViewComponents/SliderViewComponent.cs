using _01_YasQuery.Contract.Slide;
using Microsoft.AspNetCore.Mvc;
namespace ServicesHost.ViewComponents
{
    public class SliderViewComponent : ViewComponent
    {
        private readonly ISlideQuery _slideQuery;

        public SliderViewComponent(ISlideQuery slideQuery)
        {
            _slideQuery = slideQuery;
        }

        public IViewComponentResult Invoke()
        {
            var slide = _slideQuery.GetSlides();
            return View(slide);           
        }
    }
}
