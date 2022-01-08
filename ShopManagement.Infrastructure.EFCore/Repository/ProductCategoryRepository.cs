using _0_Framework.Application;
using _0_Framework.Infraustructure;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductCategoryRepository : RepositoryBase<long,ProductCategory>, IProductCategoryRepository
    {

        private readonly ShopConetext _context;
        public ProductCategoryRepository(ShopConetext context) : base(context)
        {
            _context = context;
        }

        public EditProductCategory GetDetails(long id)
        {
            return _context.ProductCategories.Select(x => new EditProductCategory() { 
                Id=x.Id,
                Description=x.Description,
                Name=x.Name,
                Keywords=x.Keywords,
                MetaDescription=x.MetaDescription,
                Picture =x.Picture,
                PictureAlt=x.PictureAlt,
                PictureTitle=x.PictureTitle,
                Slug=x.Slug

            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductCatagoryViewModel> GetProductCategories()
        {
            return _context.ProductCategories.Select(x => new ProductCatagoryViewModel
            {
                Id=x.Id,
                Name=x.Name
            }).ToList();
        }

        public List<ProductCatagoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            var query = _context.ProductCategories.Select(x => new ProductCatagoryViewModel
            {
                Id = x.Id,
                Picture = x.Picture,
                Name = x.Name,
                CreationDate = x.CreationDate.ToFarsi()
            });
            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));
            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
