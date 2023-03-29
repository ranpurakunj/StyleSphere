using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using StyleSphere.Models;

namespace StyleSphere.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly DbStyleSphereContext _context;

        public FavoriteService(DbStyleSphereContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> GetFavoritesByCustomerId(int id)
        {
            var data = await _context.TblFavorites.Where(a => a.CustomerId == id).ToListAsync();
            return new OkObjectResult(data);
        }

        public async Task<IActionResult> SaveFavorites(int CustomerId, int ProductId, TblFavorite tblFavorite)
        {
            // Get the customer and product from the database
            var customer = await _context.TblCustomers.FindAsync(CustomerId);
            var product = await _context.TblProducts.FindAsync(ProductId);

            // If either the customer or product is not found, return a 404 error
            if (customer == null || product == null)
            {
                return new NotFoundResult();
            }

            // Create a new favorite object and set its properties
            var favorite = new TblFavorite
            {
                CustomerId = CustomerId,
                ProductId = ProductId,
                ActiveStatus = true
                //Customer = customer,
                //Product = product
            };

            // Add the new favorite to the database and save changes
            _context.TblFavorites.Add(favorite);
            await _context.SaveChangesAsync();
            return new CreatedAtActionResult("SaveFavorites", "TblFavorites", new { id = tblFavorite.FavoriteId }, favorite);
        }
    }
}
