﻿
using _0_Framework.Application;
using System.Collections.Generic;

namespace ShopManagement.Application.Contracts.ProductCategory
{
    public interface IProductCategoryApplication
    {
        OperationResult Create(CreateProductCategory command);
        OperationResult Edit(EditProductCategory command);
        EditProductCategory GetDetails(long id);
        List<ProductCatagoryViewModel> GetProductCategories();
        List<ProductCatagoryViewModel> Search(ProductCategorySearchModel searchModel);
    }
}
