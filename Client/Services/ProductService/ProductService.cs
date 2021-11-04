using Ecommerce.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Ecommerce.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        public event Action Onchange;

        public List<Product> Products { get; set; } = new List<Product>();
        public ProductService(HttpClient http)
        {
            _http = http;
        }
        public async Task LoadProdcuts(string categoryUrl=null)
        {
            if (categoryUrl == null)
            {
                Products = await _http.GetFromJsonAsync<List<Product>>("api/Product/");
            }
            else
            {
                Products = await _http.GetFromJsonAsync<List<Product>>($"api/Product/category/{categoryUrl}");
            }          
            Onchange.Invoke();
        }

        public async Task<Product> GetProduct(int id)
        {
           return await _http.GetFromJsonAsync<Product>($"api/Product/{id}");
            
        }
    }
}
