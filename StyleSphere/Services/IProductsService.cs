using Microsoft.AspNetCore.Mvc;
using StyleSphere.Models;

namespace StyleSphere.Services
{
    public interface IProductsService
    {
        public Task<IActionResult> GetAllProducts();
        public Task<IActionResult> GetProductsById(int id);
        public Task<IActionResult> GetProductsByCategory(int CategoryId);
        public Task<IActionResult> GetProductsBySubCategory(int SubCategoryId);
        public Task<IActionResult> GetProductUnderPrice(decimal ProductId);
        public Task<IActionResult> GetSearchedProducts(string SearchText);
    }
}
