using _0_Framework.Application;
using _0_Framework.Infraustructure;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using ShopManagement.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Infrastructure.EFCore.Repository
{
    public class ColleagueDiscountRepository : RepositoryBase<long, ColleagueDiscount>, IColleagueDiscountRepository
    {
        private readonly DiscountContext _context;
        private readonly ShopConetext _shopContext;
        public ColleagueDiscountRepository(DiscountContext context, ShopConetext shopConetext) :base(context)
        {
            _context = context;
            _shopContext = shopConetext;
        }
        public EditColleagueDiscount GetDetails(long id)
        {
            return _context.ColleagueDiscounts.Select(x => new EditColleagueDiscount
            {
                Id=x.Id,
                DiscountRate=x.DiscountRate,
                ProductId=x.ProductId,
            
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel)
        {
            var products = _shopContext.Products.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.ColleagueDiscounts.Select(x => new ColleagueDiscountViewModel
            {
                Id = x.Id,
                CreationDate = x.CreationDate.ToFarsi(),
                DiscountRate = x.DiscountRate,
                ProductId = x.ProductId,
                IsRemoved = x.IsRemoved
            });

            if (searchModel.ProductId > 0)
            {
                query = query.Where(x => x.ProductId == searchModel.ProductId);
            }

            var discounts = query.OrderByDescending(x => x.Id).ToList();
            discounts.ForEach(discounts => discounts.Product = products.FirstOrDefault(x => x.Id == discounts.ProductId)?.Name);
            return discounts; 

        }
    }
}
