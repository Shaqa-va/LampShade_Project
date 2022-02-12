

using _0_Framework.Application;
using Microsoft.AspNetCore.Http;
using ShopManagement.Application.Contracts.ProductCategory;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Contracts.Product
{
    public class CreateProduct
    {
        [Required(ErrorMessage =ValidationMessage.IsRequired)]
        public string Name { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Code { get; set; }
        public double UnitPrice { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public IFormFile Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Slug { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string MetaDescription { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Keywords { get; set; }

        [Range(1,10000,ErrorMessage=ValidationMessage.IsRequired)]
        public long CategoryId { get; set; }
        public List<ProductCatagoryViewModel> Categories { get; set; }

    }
}
