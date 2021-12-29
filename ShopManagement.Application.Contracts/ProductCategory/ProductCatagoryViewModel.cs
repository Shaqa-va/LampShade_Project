using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.ProductCategory
{
    public class ProductCatagoryViewModel
    {
        public long Id  { get; set; }
        public string Name  { get; set; }
        public string  Picture { get; set; }
        public string CreationDate { get; set; }
        public long ProductCount { get; set; }
    }
}
