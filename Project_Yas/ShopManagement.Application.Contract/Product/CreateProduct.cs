
using _0_Framework.Application;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.ProductCategory;
using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace ShopManagement.Application.Contract.Product
{
    public class CreateProduct
    {
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Name { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Code { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        //public double UnitPrice { get; set; }
        //[Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Slug { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Keywords { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string MetaDescription { get; set; }
        [Range(0,100000 , ErrorMessage = ValidationMessage.IsRequired)]
        public long CategoryId { get; set; } // گروه محصولی ، ایدی ان گروه
        public List<ProductCategoryViewModel> Categories { get; set; }
    }
}