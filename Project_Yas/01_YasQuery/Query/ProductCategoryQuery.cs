using _0_Framework.Application;
using _01_YasQuery.Contract.Product;
using _01_YasQuery.Contract.ProductCategory;
using DiscountManagement.Infrastructure.EF_Core;
using InventoryManagement.Infrastructure.EF_Core;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Infrastructure.EF_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_YasQuery.Query
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopContext _shopContext;// برای دریافت اطلاعات محصول و دسته بندی
        private readonly InventoryContext _inventoryContext;// برای دریافت قیمت 
        private readonly DiscountContext _discountContext;
        public ProductCategoryQuery(ShopContext shopContext, InventoryContext inventoryContext, DiscountContext discountContext)
        {
            _shopContext = shopContext;
            _inventoryContext = inventoryContext;
            _discountContext = discountContext;
        }

        public List<ProductCategoryQueryModel> GetProductCategories()
        {
            return _shopContext.ProductCategories.Select(c => new ProductCategoryQueryModel
            {
                Id = c.Id,
                Name = c.Name,
                Picture = c.Picture,
                PictureAlt = c.PictureAlt,
                PictureTitle = c.PictureTitle,
                Slug = c.Slug
            }).ToList();
        }

        public List<ProductCategoryQueryModel> GetProductCategoriesWhithProducts()
        {
            //اول باید پروداکت ها را بخوانیم و پروداکت کتگوری ها را هم بخوانیم  
            var inventory = _inventoryContext.Inventories.Select
                (x => new { x.UnitPrice, x.ProductId }).ToList();

            var discount = _discountContext.CustomerDiscounts.
                Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new { x.DiscountRate, x.ProductId }).ToList();

            var categories = _shopContext.ProductCategories.Include(x => x.Products)
                //.ThenInclude(x=>x.Category)
                .Select(x => new ProductCategoryQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Products = MapProducts(x.Products)
                }).ToList();

            foreach (var categoriy in categories)
            {
                foreach (var product in categoriy.Products)
                {
                    var inventories = inventory.FirstOrDefault(x => x.ProductId == product.Id);
                    if (inventories != null)
                    {
                        var price = inventories.UnitPrice;
                        product.Price = price.ToMoney();
                        var discounts = discount.FirstOrDefault(x => x.ProductId == product.Id);

                        if (discounts != null)
                        {
                            int discountRate = discounts.DiscountRate;

                            product.DiscountRate = discountRate;
                            product.HasDiscount = discountRate > 0;

                            var discountAmount = Math.Round(price * discountRate / 100);// مقدار تخفیف
                            product.PriceWithDiscount = (price - discountAmount).ToMoney();
                        }
                    }

                }
            }

            return categories;
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

        public ProductCategoryQueryModel GetProductCategoeyWhitProductsBy(string slug)
        {
            //اول باید پروداکت ها را بخوانیم و پروداکت کتگوری ها را هم بخوانیم  
            var inventory = _inventoryContext.Inventories.Select
                (x => new { x.UnitPrice, x.ProductId }).ToList();

            var discount = _discountContext.CustomerDiscounts.
                Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new { x.DiscountRate, x.ProductId , x.EndDate }).ToList();

            var category = _shopContext.ProductCategories.Include(x => x.Products)
                //.ThenInclude(x=>x.Category)
                .Select(x => new ProductCategoryQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    MetaDescription = x.MetaDescription,
                    Keywords = x.Keywords,
                    Slug = x.Slug,
                    Products = MapProducts(x.Products)
                }).FirstOrDefault(x => x.Slug == slug);


            foreach (var product in category.Products)
            {
                var inventories = inventory.FirstOrDefault(x => x.ProductId == product.Id);
                if (inventories != null)
                {
                    var price = inventories.UnitPrice;
                    product.Price = price.ToMoney();
                    var discounts = discount.FirstOrDefault(x => x.ProductId == product.Id);

                    if (discounts != null)
                    {
                        int discountRate = discounts.DiscountRate;

                        product.DiscountRate = discountRate;
                        ////product.DiscountExpireDate = discount.EndDate.ToFarsi();
                        product.HasDiscount = discountRate > 0;

                        var discountAmount = Math.Round(price * discountRate / 100);// مقدار تخفیف
                        product.PriceWithDiscount = (price - discountAmount).ToMoney();
                    }
                }

            }
            return category;

        }
    }
}
