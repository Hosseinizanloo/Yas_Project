using _0_Framework.Application;
using _01_YasQuery.Contract.Product;
using DiscountManagement.Infrastructure.EF_Core;
using InventoryManagement.Infrastructure.EF_Core;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Infrastructure.EF_Core;

namespace _01_YasQuery.Query
{
    public class ProductQueryModel : IProductQueryModel
    {
        private readonly ShopContext _shopContext;// برای دریافت اطلاعات محصول و دسته بندی
        private readonly InventoryContext _inventoryContext;// برای دریافت قیمت 
        private readonly DiscountContext _discountContext;

        public ProductQueryModel(DiscountContext discountContext, InventoryContext inventoryContext, ShopContext shopContext)
        {
            _discountContext = discountContext;
            _inventoryContext = inventoryContext;
            _shopContext = shopContext;
        }
        public List<ProductQuery> GetLatestArrivals()
        {
            var inventory = _inventoryContext.Inventories.Select(x => new { x.ProductId, x.UnitPrice }).ToList();
            var discounts = _discountContext.CustomerDiscounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new { x.DiscountRate, x.ProductId }).ToList();

            var products = _shopContext.Products.Include(x => x.Category)
                .Select(c => new ProductQuery
                {
                    Id = c.Id,
                    Name = c.Name,
                    Picture = c.Picture,
                    PictureAlt = c.PictureAlt,
                    PictureTitle = c.PictureTitle,
                    Slug = c.Slug
                }).ToList();

            foreach (var product in products)
            {
                var productInventory = inventory.FirstOrDefault(x => x.ProductId == product.Id);
                if (productInventory != null)
                {
                    var price = productInventory.UnitPrice;
                    product.Price = price.ToMoney();
                    var discount = discounts.FirstOrDefault(x => x.ProductId == product.Id);
                    if (discount != null)
                    {
                        int discountRate = discount.DiscountRate;
                        product.DiscountRate = discountRate;
                        product.HasDiscount = discountRate > 0;
                        var discountAmount = Math.Round((price * discountRate) / 100);
                        product.PriceWithDiscount = (price - discountAmount).ToMoney();
                    }
                }
            }


            return products;
        }

    }
}

