using _0_Framework.Application;
using _0_Framework.Infraustructure;
using DiscountManagement.Application.Contract.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;
using ShopManagement.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Infrastructure.EFCore.Repository
{
    public class CustomerDiscountRepository : RepositoryBase<long, CustomerDiscount>, ICustomerDiscountRepository
    {
        private readonly DiscountContext _context;
        private readonly ShopConetext _shopContext;
        public CustomerDiscountRepository(DiscountContext context,ShopConetext shopContext) : base(context)
        {
            _context = context;
            _shopContext = shopContext;
        }

        public EditCustomerDiscount GetDetails(long id)
        {
            return _context.CusomterDiscounts.Select(x => new EditCustomerDiscount
            {
                Id = x.Id,
                ProductId = x.ProductId,
                DiscountRate = x.DiscountRate,
                StartDate = x.StartDate.ToString(),
                EndDate = x.EndDate.ToString(),
                Reason = x.Reason

            }).FirstOrDefault(x => x.Id == id);
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel seachModel)
        {

            var products = _shopContext.Products.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.CusomterDiscounts.Select(x => new CustomerDiscountViewModel
            {
                Id = x.Id,
                DiscountRate = x.DiscountRate,
                StartDate = x.StartDate.ToFarsi(),
                StartDateGr = x.StartDate,
                EndDate = x.EndDate.ToFarsi(),
                EndDateGr = x.EndDate,
                ProductId = x.ProductId,
                Reason = x.Reason,
                CreationDate=x.CreationDate.ToFarsi()
            });

            if (seachModel.ProductId > 0)
                query = query.Where(x => x.ProductId == seachModel.ProductId);

            if (!string.IsNullOrWhiteSpace(seachModel.StartDate))
            {
            
                query = query.Where(x => x.StartDateGr > seachModel.StartDate.ToGeorgianDateTime());

            }
            if (!string.IsNullOrWhiteSpace(seachModel.EndDate))
            {

                query = query.Where(x => x.EndDateGr < seachModel.EndDate.ToGeorgianDateTime());

            }
            var discounts = query.OrderByDescending(x => x.Id).ToList();
            discounts.ForEach(discount =>
            discount.Product = products.FirstOrDefault(x => x.Id == discount.ProductId)?.Name);

            return discounts;
           
        }
    }
}
