using _0_Framework.Domain;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductAgg
{
    public class Product : EntityBase
    {
        public string Name { get; private set; }
        public string Code { get; private set; }
        public double UnitPrice { get; private set; }
        public bool IsInStock { get; set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Slug { get; set; }
        public string MetaDescription { get; set; }
        public string Keywords { get; set; }
        public long CategoryId { get; private set; }
        public ProductCategory Category { get; private set; }

        public List<ProductPicture> ProductPictures { get; set; }
        public Product(string name, string code, string shortDescription, double unitPrice, string description, string picture, string pictureAlt,
       string pictureTitle, string keywords, string metaDescription, string slug, long categoryId)
        {
            Name = name;
            Code = code;
            Description = description;
            ShortDescription = shortDescription;
            UnitPrice = unitPrice;
            Picture = picture;
            PictureTitle = pictureTitle;
            PictureAlt = pictureAlt;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;
            CategoryId = categoryId;
            IsInStock = true;
        }
        public void Edit(string name, string code, string shortDescription, double unitPrice, string description, string picture, string pictureAlt,
      string pictureTitle, string keywords, string metaDescription, string slug, long categoryId)
        {
            Name = name;
            Code = code;
            Description = description;
            ShortDescription = shortDescription;
            UnitPrice = unitPrice;
            Picture = picture;
            PictureTitle = pictureTitle;
            PictureAlt = pictureAlt;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;
            CategoryId = categoryId;
        }


        public void InStock()
        {
            IsInStock = true;
        }

        public void NotInStock()
        {
            IsInStock = false;
        }
    }
}
