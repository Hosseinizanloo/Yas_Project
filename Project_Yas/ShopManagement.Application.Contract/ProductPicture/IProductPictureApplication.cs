using _0_Framework.Applicatio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.ProductPicture
{
    public interface IProductPictureApplication
    {
        OperatioResult Create(CreateProductPicture command);
        OperatioResult Edit(EditProductPicture command);
        OperatioResult Remove(long id);
        OperatioResult Restore(long id);
        EditProductPicture GetDetailse(long id);
        List<ProductPictureVeiwModel> search(ProducPictureSearchModel searchModel);

    }
}
