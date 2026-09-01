using _01_YasQuery.Contract.Product;
using _01_YasQuery.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using ShopManagement.Domain.ProductAgg;

namespace ServicesHost.Pages
{
    public class SearchModel : PageModel
    {
        public string Value;
        public List<ProductQuery> ProductQueries;
        private readonly IProductQueryModel _productQuery;

        public SearchModel(IProductQueryModel productQuery)
        {
            _productQuery = productQuery;
        }

        public void OnGet(string value)
        {
            Value = value;
            ProductQueries = _productQuery.Search(value);
        }
    }
}
