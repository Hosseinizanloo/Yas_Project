using _0_Framework.Application;
using _01_YasQuery.Contract.Product;
using _01_YasQuery.Contract.ProductCategory;
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
                }).OrderByDescending(x=>x.Id).Take(6).ToList();

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

        public List<ProductQuery> Search(string value)
        {
            var inventory = _inventoryContext.Inventories.Select(x =>
                new { x.ProductId, x.UnitPrice }).ToList();
            var discounts = _discountContext.CustomerDiscounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new { x.DiscountRate, x.ProductId, x.EndDate }).ToList();

            var query = _shopContext.Products
                .Include(x => x.Category)
                .Select(product => new ProductQuery
                {
                    Id = product.Id,
                    Category = product.Category.Name,
                    Name = product.Name,
                    Picture = product.Picture,
                    PictureAlt = product.PictureAlt,
                    PictureTitle = product.PictureTitle,
                    ShortDescription = product.ShortDescription,
                    CategorySlug = product.Category.Slug,
                    Slug = product.Slug
                }).AsNoTracking();

            if (!string.IsNullOrWhiteSpace(value))
                query = query.Where(x => x.Name.Contains(value) || x.ShortDescription.Contains(value));

            var products = query.OrderByDescending(x => x.Id).ToList();
            ;

            foreach (var product in products)
            {
                var productInventory = inventory.FirstOrDefault(x => x.ProductId == product.Id);
                if (productInventory != null)
                {
                    var price = productInventory.UnitPrice;
                    product.Price = price.ToMoney();
                    var discount = discounts.FirstOrDefault(x => x.ProductId == product.Id);
                    if (discount == null) continue;

                    var discountRate = discount.DiscountRate;
                    product.DiscountRate = discountRate;
                    product.DiscountExpireDate = discount.EndDate.ToDiscountFormat();
                    product.HasDiscount = discountRate > 0;
                    var discountAmount = Math.Round((price * discountRate) / 100);
                    product.PriceWithDiscount = (price - discountAmount).ToMoney();
                }
            }

            return products;
        }

        private static List<Contract.Product.ProductQuery> MapProducts(List<Product> products)
        {
            //نکتهی بسیار محم متد های استاتیک سطح کلاس را نمیبینند

            return products.Select(product => new ProductQuery
            {
                Id = product.Id,
                Name = product.Name,
                Picture = product.Picture,
                PictureAlt = product.PictureAlt,
                PictureTitle = product.PictureTitle,
                Slug = product.Slug
                //Category = product.Category.Name
            }).ToList();
        }

    }
}

