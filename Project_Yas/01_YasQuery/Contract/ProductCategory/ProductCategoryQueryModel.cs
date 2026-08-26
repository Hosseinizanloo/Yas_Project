using _01_YasQuery.Contract.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_YasQuery.Contract.ProductCategory
{
    public class ProductCategoryQueryModel
    {

        public long Id { get; set; }
        public string Name { get; set; }
        //ما چون مسیر عکس و داخل دیتا بیس ذخیره میکنیم نه خود عکسو
        public string Picture { get; set; }
        public string Description { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Slug { get; set; }
        public string Keywords { get; set; }
        public string MetaDescription { get; set; }
        public List<ProductQuery> Products  { get; set; }
    }
}
