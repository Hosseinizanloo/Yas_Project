using _0_Framework.Applicatio;
using _0_Framework.Application;
using Azure;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ShopManagement.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _repository;

        public ProductApplication(IProductRepository repository)
        {
            _repository = repository;
        }

        public OperationResult Create(CreateProduct command)
        {
            var operationResult = new OperationResult();
            if (_repository.Exists(x => x.Name == command.Name))
                return operationResult.Failed(ApplicationMessages.DuplicatedRecord);


            var slug = command.Slug.Slugify();
            var product = new Product(command.Name, command.Code, command.UnitPrice, command.ShortDescription, command.Description, command.Picture, command.PictureAlt, command.PictureTitle, slug, command.Keywords, command.MetaDescription, command.CategoryId);
            _repository.Create(product);
            _repository.SaveChanges();
            return operationResult.Succedded();

        }

        public OperationResult Edit(EditProduct command)
        {
            var operationResult = new OperationResult();
            var product = _repository.Get(command.Id);
            if (product == null)
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            if (_repository.Exists(x => x.Name == command.Name))
                return operationResult.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            product.Edit(command.Name, command.Code, command.UnitPrice, command.ShortDescription, command.Description, command.Picture, command.PictureAlt, command.PictureTitle, slug, command.Keywords, command.MetaDescription, command.CategoryId); ;
            _repository.SaveChanges();
            return operationResult.Succedded();
        }

        public EditProduct GetDetails(long id)
        {
            return _repository.GetDetailse(id);
        }

        public List<ProductViewModel> GetProduct()
        {
            return _repository.GetProduct();
        }

        public OperationResult IsNotStock(long id)
        {
            var operationResult = new OperationResult();
            var product = _repository.Get(id);
            if (product == null)
                return operationResult.Failed(ApplicationMessages.RecordNotFound);

            product.NotStock();
            return operationResult.Succedded();
        }
        public OperationResult IsStock(long id)
        {
            var operationResult = new OperationResult();
            var product = _repository.Get(id);
            if (product == null)
                return operationResult.Failed(ApplicationMessages.RecordNotFound);

            product.InStock();
            return operationResult.Succedded();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            return _repository.Search(searchModel);
        }
    }

}
