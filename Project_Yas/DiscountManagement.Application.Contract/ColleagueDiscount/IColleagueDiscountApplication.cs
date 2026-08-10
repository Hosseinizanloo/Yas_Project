using _0_Framework.Applicatio;

namespace DiscountManagement.Application.Contract.ColleagueDiscount
{
    public interface IColleagueDiscountApplication
    {
        OperationResult Define(DefineColleagueDiscount command);
        OperationResult Edit(EditColleagueDiscount command);
        EditColleagueDiscount GetDetailse(long id);
        OperationResult Remove(long id);
        OperationResult Resome(long id);
        List<ColleagueViewModel> Search(ColleagueSearchModel searchModel);
    }
}
