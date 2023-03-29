using Microsoft.AspNetCore.Mvc;

namespace StyleSphere.Services
{
    public interface ICategoriesService
    {
        public Task<IActionResult> GetCategoriesAsync();

        public Task<IActionResult> GetShowOnTopCategories();


    }
}
