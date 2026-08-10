using _0_Framework.Application;
using _0_Framework.Infrastructure;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using ShopManagement.Infrastructure.EF_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Infrastructure.EF_Core.Repository
{
    public class ColleagueDiscountRepository : RepositoryBase<long, ColleagueDiscount>, IColleagueDiscountRepository
    {
        private readonly DiscountContext _discountContext;
        private readonly ShopContext _shopContext;

        public ColleagueDiscountRepository(DiscountContext discountContext, ShopContext shopContext) : base(discountContext)
        {
            _discountContext = discountContext;
            _shopContext = shopContext;
        }

        public EditColleagueDiscount GetDetails(long id)
        {
            return _discountContext.ColleagueDiscounts.Select(c => new EditColleagueDiscount
            {
                Id = c.Id,
                ProductId = c.ProductId,
                DiscountRate = c.DiscountRate
            }).FirstOrDefault(x=>x.Id == id);
        }

        public List<ColleagueViewModel> Search(ColleagueSearchModel searchModel)
        {
            var product = _shopContext.Products.Select(x => new { x.Id, x.Name }).ToList();
            var query = _discountContext.ColleagueDiscounts.Select(x=> new ColleagueViewModel 
            {
                Id = x.Id,
                ProductId = x.ProductId,
                DiscountRate = x.DiscountRate,
                IsRemoved = x.IsRemoved,
                CreatingDate = x.CreationDate.ToFarsi()
            });//آگر تولیست کنیم شرط پایین بخش کوئری به مشکل بر میخورد

            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);
            var discount = query.OrderByDescending(x => x.Id).ToList();
            discount.ForEach(discount => 
            discount.Product = product.FirstOrDefault(x => x.Id == discount.ProductId)?.Name);
            return discount;
        }
    }
}

