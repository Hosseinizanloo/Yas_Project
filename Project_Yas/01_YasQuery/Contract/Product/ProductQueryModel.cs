using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_YasQuery.Contract.Product
{
    public class ProductQueryModel // در قسمت یو آی من یک بخشی دارم که دسته بندی ها را به همراه محصولات نمایش میدهد حالا اطلاعاتی مکه دارد این میباشد 
    {
        public long Id { get; set; }

        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double PriceWithDiscount { get; set; }
        public int DiscountRate  { get; set; }
        public string Category  { get; set; }
        public string  Slug { get; set; }
    }
}
