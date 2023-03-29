using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StyleSphere.Models;

namespace StyleSphere.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly DbStyleSphereContext _context;

        public CategoriesService(DbStyleSphereContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> GetCategoriesAsync()
        {
            var categories = await _context.TblCategories
                .Select(c => new CategoryDto
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                    Description = c.Description
                })
                .ToListAsync();
            return new OkObjectResult(categories);
        }

        public async Task<IActionResult> GetShowOnTopCategories()
        {
            var categories = await _context.TblCategories
                .Where(c => c.ShowOnTop)
                .Select(c => new CategoryDto
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                    Description = c.Description
                })
                .ToListAsync();
            return new OkObjectResult(categories);
        }
    }
}
