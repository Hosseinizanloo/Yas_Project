using _0_Framework.Domain;
using ShopManagement.Application.Contract.Slide;
using ShopManagement.Domain.ProductPictureAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.SlideAgg
{
    public interface ISlideRepository : IRepository<long, Slide>
    {
        EditSlide GetDetilse(long id);
        List<SlideViewModel> GetList();
    }
}
