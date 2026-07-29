using _0_Framework.Applicatio;
using _0_Framework.Application;
using ShopManagement.Application.Contract.ProductPicture;
using ShopManagement.Domain.ProductPictureAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ShopManagement.Application
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IProductPictureRepository _repository;

        public ProductPictureApplication(IProductPictureRepository repository)
        {
            _repository = repository;
        }

        public OperatioResult Create(CreateProductPicture command)
        {
            var operation = new OperatioResult();
            if (_repository.Exists(x => x.Picture == command.Picture && x.ProductId == command.ProductId))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            var productPicture = new ProductPicture(command.ProductId, 
                command.Picture, command.PictureAlt, command.PictureTitle);
            _repository.Create(productPicture);
            _repository.SaveChanges();
            return operation.Succedded();
        }

        public OperatioResult Edit(EditProductPicture command)
        {
            var operation = new OperatioResult();
            var productPicture = _repository.Get(command.Id);
            if (productPicture == null) 
                return operation.Failed(ApplicationMessages.RecordNotFuond);

            if (_repository.Exists(x => x.Picture == command.Picture && x.ProductId == command.ProductId))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            productPicture.Edit(command.ProductId, command.Picture, command.PictureAlt, command.PictureTitle);
            _repository.SaveChanges();
            return operation.Succedded();
        }

        public EditProductPicture GetDetailse(long id)
        {
            return _repository.GetDetailse(id);
        }

        public OperatioResult Remove(long id)
        {
            var operation = new OperatioResult();
            var productPicture = _repository.Get(id);
            if (productPicture == null)
                return operation.Failed(ApplicationMessages.RecordNotFuond);

            productPicture.Removed();
            _repository.SaveChanges();
            return operation.Succedded();
        }
        public OperatioResult Restore(long id)
        {
            var operation = new OperatioResult();
            var productPicture = _repository.Get(id);
            if (productPicture == null)
                return operation.Failed(ApplicationMessages.RecordNotFuond);

            productPicture.Restore();
            _repository.SaveChanges();
            return operation.Succedded();
        }

        public List<ProductPictureVeiwModel> search(ProducPictureSearchModel searchModel)
        {
            return _repository.Search(searchModel);
        }
    }
}
