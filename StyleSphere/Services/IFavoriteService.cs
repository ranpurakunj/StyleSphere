using Microsoft.AspNetCore.Mvc;
using StyleSphere.Models;

namespace StyleSphere.Services
{
    public interface IFavoriteService
    {
        public Task<IActionResult> GetFavoritesByCustomerId(int id);
        public Task<IActionResult> SaveFavorites(int CustomerId, int ProductId, TblFavorite tblFavorite);
    }
}
