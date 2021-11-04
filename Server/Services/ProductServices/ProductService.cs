using Ecommerce.Server.Data;
using Ecommerce.Server.Services.CategoryService;
using Ecommerce.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Server.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly ICategoryService _categoryService;
        private readonly DataContext _dataContext;

        public ProductService(ICategoryService categoryService, DataContext dataContext)
        {
            _categoryService = categoryService;
            _dataContext = dataContext;
        }
      

        public async Task<List<Product>> GetAllProducts()
        {
            return await _dataContext.Products.ToListAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            Product product = await _dataContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            return product;
        }


        public async Task<List<Product>> GetProductsByCategory(string categoryUrl)
        {
            Category category = await _categoryService.GetCategoryByUrl(categoryUrl);
            return await  _dataContext.Products.Where(p => p.CategoryId == category.Id).ToListAsync();
        }
    }
}
