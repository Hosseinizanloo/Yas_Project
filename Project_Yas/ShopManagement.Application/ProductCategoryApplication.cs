using _0_Framework.Applicatio;
using _0_Framework.Application;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public OperatioResult Create(CreateProductCategory command)
        {
            var operation = new OperatioResult();
            if (_productCategoryRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            var slug = command.Slug.Slugify();
            var productCategory = new ProductCategory(command.Name, command.Description, command.Picture, 
                command.PictureAlt, command.PictureTitle, command.MetaDescription, command.Keywords, slug);
            _productCategoryRepository.Create(productCategory);
            _productCategoryRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperatioResult Edit(EditProductCategory command)
        {
            var operation = new OperatioResult();
            var productCategory = _productCategoryRepository.Get(command.Id);
            if (productCategory == null)
                return operation.Failed(ApplicationMessages.RecordNotFuond);

            if(_productCategoryRepository.Exists(x=>x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
           
            var slug = command.Slug.Slugify();
            productCategory.Edit(command.Name, command.Description,
                command.Picture, command.PictureAlt, command.PictureTitle,
                command.MetaDescription, command.Keywords, slug);
            _productCategoryRepository.SaveChanges();
            return operation.Succedded();


        }

        public EditProductCategory GetDetilse(long id)
        {
            return _productCategoryRepository.GetDetailse(id);
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            return _productCategoryRepository.Search(searchModel);
        }
    }
}
