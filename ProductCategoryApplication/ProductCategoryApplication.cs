using _0_Framework.Application;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCategory.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public OperationResult Create(CreateProductCategory command)
        {
            var operation = new OperationResult();
            if (_productCategoryRepository.Exists(x => x.Name == command.Name))
                return operation.Failed("امکان ثبت رکورد تکراری وجود ندارد ، لطفا مجدد تلاش نفرمایید.");

            var sulg = command.Slug.Slugify();
            var propductCategory = new ShopManagement.Domain.ProductCategoryAgg.ProductCategory(command.Name, command.Description,
                command.Picture, command.PictureTitle, command.PictureAlt,
                command.Keywords, command.MetaDescription, sulg);
            _productCategoryRepository.Create(propductCategory);
            _productCategoryRepository.SaveChanges();
            return operation.Seccedded();
        }

        public OperationResult Edit(EditProductCategory command)
        {
            var operation = new OperationResult();
            var productCategory = _productCategoryRepository.Get(command.Id);
            if (productCategory == null)
                return operation.Failed("رکورد با اطلاعات درخواست شده یافت نشد. لطفا مجدد تلاش بفرمایید. ");
            if (_productCategoryRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed("امکان ثبت رکورد تکراری وجود ندارد ، لطفا مجدد تلاش نفرمایید.");

            var sulg = command.Slug.Slugify();
            productCategory.Edit(command.Name, command.Description,
                 command.Picture, command.PictureTitle, command.PictureAlt,
                 command.Keywords, command.MetaDescription, sulg);
            _productCategoryRepository.SaveChanges();
            return operation.Seccedded();
        }

        public EditProductCategory GetDetails(long id)
        {
            return _productCategoryRepository.GetDetails(id);
        }

        public List<ProductCatagoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            return _productCategoryRepository.Search(searchModel);
        }
    }
}
