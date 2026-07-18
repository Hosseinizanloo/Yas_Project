using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.ProductCategory
{
    public class CreateProductCategory
    {
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Name { get; set; }
        public string Description { get; set; }
        //ما چون مسیر عکس و داخل دیتا بیس ذخیره میکنیم نه خود عکسو
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string MetaDescription { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Keywords { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Slug { get; set; }
    }
}

//ایدی و تاریخ ایجاد را خود سیستم به ما میدهد 
// ما اینجا هر چیزی که یوزر به ما میدهد مینویسیم 
