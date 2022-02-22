using _0_Framework.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Slide
{
   public class CreateSlide
    {
        public IFormFile Picture { get;  set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string PictureAlt { get;  set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string PictureTitle { get; set; }
        public string Heading { get;  set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Title { get;  set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Text { get;  set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string BtnText { get;  set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Link { get; set; }

    }
}
