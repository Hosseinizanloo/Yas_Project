using _01_YasQuery.Contract.Product;
using _01_YasQuery.Contract.ProductCategory;
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
        private readonly ShopContext _shopContext;
        private readonly InventoryContext _inventoryContext;
        public ProductCategoryQuery(ShopContext shopContext, InventoryContext inventoryContext)
        {
            _shopContext = shopContext;
            _inventoryContext = inventoryContext;
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
            var inventory = _inventoryContext
            var categories = _shopContext.ProductCategories.Include(x=>x.Products)
                //.ThenInclude(x=>x.Category)
                .Select(x => new ProductCategoryQueryModel
            {
                Id=x.Id,
                Name = x.Name,
                Products = MapProducts(x.Products)
            }).ToList();

            foreach(var categoriy in categories)
            {
                foreach (var product in categoriy.Products)
                {
                    
                }
            }

            return categories;
        }

        private static List<ProductQueryModel> MapProducts(List<Product> products)
        {
            //نکتهی بسیار محم متد های استاتیک سطح کلاس را نمیبینند
          
            return products.Select(product=> new ProductQueryModel 
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
