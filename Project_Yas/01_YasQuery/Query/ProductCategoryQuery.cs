using _01_YasQuery.Contract.ProductCategory;
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

        public ProductCategoryQuery(ShopContext shopContext)
        {
            _shopContext = shopContext;
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
    }
}
