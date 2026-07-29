using _0_Framework.Domain;
using _0_Framework.Infrastructure;
using ShopManagement.Application.Contract.ProductPicture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductPictureAgg
{
    public interface IProductPictureRepository : IRepository<long , ProductPicture> 
    {
        EditProductPicture GetDetailse(long id);
        List<ProductPictureVeiwModel> Search(ProducPictureSearchModel searchModel);
    }
}
