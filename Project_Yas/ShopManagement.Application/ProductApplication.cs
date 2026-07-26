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

        public OperatioResult Create(CreateProduct command)
        {
            var operationResult = new OperatioResult();
            if (_repository.Exists(x => x.Name == command.Name))
                return operationResult.Failed(ApplicationMessages.DuplicatedRecord);


            var slug = command.Slug.Slugify();
            var product = new Product(command.Name, command.Code, command.UnitPrice, command.ShortDescription, command.Description, command.Picture, command.PictureAlt, command.PictureTitle, slug, command.Keywords, command.MetaDescription, command.CategoryId);
            _repository.Create(product);
            _repository.SaveChanges();
            return operationResult.Succedded();

        }

        public OperatioResult Edit(EditProduct command)
        {
            var operationResult = new OperatioResult();
            var product = _repository.Get(command.Id);
            if (product == null)
                return operationResult.Failed(ApplicationMessages.RecordNotFuond);
            if (_repository.Exists(x => x.Name == command.Name))
                return operationResult.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            product.Edit(command.Name, command.Code, command.UnitPrice, command.ShortDescription, command.Description, command.Picture, command.PictureAlt, command.PictureTitle, slug, command.Keywords, command.MetaDescription, command.CategoryId); ;
            _repository.SaveChanges();
            return operationResult.Succedded();
        }

        public EditProduct GetDetailse(long id)
        {
            return _repository.GetDetailse(id);
        }

        public OperatioResult IsNotStock(long id)
        {
            var operationResult = new OperatioResult();
            var product = _repository.Get(id);
            if (product == null)
                return operationResult.Failed(ApplicationMessages.RecordNotFuond);

            product.InStock();
            return operationResult.Succedded();
        }
        public OperatioResult IsStock(long id)
        {
            var operationResult = new OperatioResult();
            var product = _repository.Get(id);
            if (product == null)
                return operationResult.Failed(ApplicationMessages.RecordNotFuond);

            product.NotStock();
            return operationResult.Succedded();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            return _repository.Search(searchModel);
        }
    }
}
