using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_YasQuery.Contract.Product
{
    public interface IProductQueryModel
    {
        List<ProductQuery> GetLatestArrivals();
    }
}
