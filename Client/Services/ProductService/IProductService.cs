using Ecommerce.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Client.Services.ProductService
{
    interface IProductService
    {
        event Action Onchange;
        List<Product> Products { get; set;}
        Task LoadProdcuts(string categoryUrl = null);
        Task<Product> GetProduct(int id);
    }
}
