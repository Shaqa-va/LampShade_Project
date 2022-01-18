using _0_Framework.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;
        public ProductApplication(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public OperationResult Create(CreateProduct command)
        {
            var operation = new OperationResult();
            if (_productRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            var sulg = command.Slug.Slugify();
            var product = new ShopManagement.Domain.ProductAgg.Product(command.Name, command.Code, command.ShortDescription, command.Description,
             command.Picture, command.PictureTitle, command.PictureAlt,
             command.Keywords, command.MetaDescription, sulg, command.CategoryId);

            _productRepository.Create(product);
            _productRepository.SaveChanges();
            return operation.Seccedded();
        }

        public OperationResult Edit(EditProduct command)
        {
            var operation = new OperationResult();
            var product = _productRepository.Get(command.Id);
            if (product == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            if (_productRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            var sulg = command.Slug.Slugify();
            product.Edit(command.Name, command.Code, command.ShortDescription, command.Description,
             command.Picture, command.PictureTitle, command.PictureAlt,
             command.Keywords, command.MetaDescription, sulg, command.CategoryId);

            _productRepository.SaveChanges();
            return operation.Seccedded();

        }

        public EditProduct GetDetails(long id)
        {
            return _productRepository.GetDetails(id);
        }

        public List<ProductViewModel> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        //public OperationResult InStock(long id)
        //{
        //    var operation = new OperationResult();
        //    var product = _productRepository.Get(id);
        //    if (product == null)
        //        return operation.Failed(ApplicationMessages.RecordNotFound);


        //    product.InStock();
        //    _productRepository.SaveChanges();
        //    return operation.Seccedded();

        //}

        //public OperationResult NotInStock(long id)
        //{
        //    var operation = new OperationResult();
        //    var product = _productRepository.Get(id);
        //    if (product == null)
        //        return operation.Failed(ApplicationMessages.RecordNotFound);


        //    product.NotInStock();
        //    _productRepository.SaveChanges();
        //    return operation.Seccedded();
        //}

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            return _productRepository.Search(searchModel);
        }
    }
}