﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VATUShop.MVC.Models;
using VATUShop.MVC.ViewModels;

namespace VATUShop.MVC.Repository
{
    public interface IProductRepository
    {
        int Create(Product product);
        IEnumerable<ProductViewModel> Gets();
        ProductViewModel Get(int productId);
        Product ConvertToProduct(ProductViewModel model);
        EditProductViewModel ConvertToEditProductViewModel(ProductViewModel model);
        Product Edit(EditProductViewModel model);
        bool Delete(int id);
        int ChangeStatus(int id, bool status);
    }
}
