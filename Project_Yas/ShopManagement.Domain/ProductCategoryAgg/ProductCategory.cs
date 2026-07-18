using _0_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public class ProductCategory : EntityBase
    {
        public ProductCategory(string name, string description, string picture, string pictureAlt, string pictureTitle, string metaDescription, string keywords, string slug)
        {
            Name = name;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            MetaDescription = metaDescription;
            Keywords = keywords;
            Slug = slug;
        }
        public void Edit(string name, string description, string picture, string pictureAlt, string pictureTitle, string metaDescription, string keywords, string slug)
        {
            Name = name;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            MetaDescription = metaDescription;
            Keywords = keywords;
            Slug = slug;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        //ما چون مسیر عکس و داخل دیتا بیس ذخیره میکنیم نه خود عکسو
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string MetaDescription { get; private set; }
        public string Keywords { get; private set; }
        public string Slug { get; private set; }

    }
}
