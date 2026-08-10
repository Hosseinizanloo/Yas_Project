using _0_Framework.Domain;
using _0_Framework.Infrastructure;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Domain.ColleagueDiscountAgg
{
    public interface IColleagueDiscountRepository :IRepository <long , ColleagueDiscount> 
    {
        EditColleagueDiscount GetDetails(long id);
        List<ColleagueViewModel> Search(ColleagueSearchModel searchModel);

    }
}
