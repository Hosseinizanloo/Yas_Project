using _0_Framework.Applicatio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.Slide
{
    public interface ISlideApplication
    {
        OperatioResult Create(CreateSlide command);
        OperatioResult Edit(EditSlide command);
        OperatioResult Remove(long id);
        OperatioResult Restore(long id);
        EditSlide GetDetilse(long id);
        List<SlideViewModel> GetList();
    }
}
