using Microsoft.AspNetCore.Mvc;
using StyleSphere.Models;
using StyleSphere.Services;

namespace StyleSphere.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblFavoritesController : ControllerBase
    {
        private readonly IFavoriteService _favoriteService;

        public TblFavoritesController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        // GET: api/TblFavorites
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<TblFavorite>>> GetTblFavorites()
        //{
        //    return await _context.TblFavorites.ToListAsync();
        //}
        
        [HttpGet("{cId}")]
        public async Task<IActionResult> GetFavoritesForCustomer(int cId)
        {
            return await _favoriteService.GetFavoritesByCustomerId(cId);
        }

        //// GET: api/TblFavorites/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<TblFavorite>> GetTblFavorite(int id)
        //{
        //    var tblFavorite = await _context.TblFavorites.FindAsync(id);

        //    if (tblFavorite == null)
        //    {
        //        return NotFound();
        //    }

        //    return tblFavorite;
        //}

        // PUT: api/TblFavorites/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTblFavorite(int id, TblFavorite tblFavorite)
        //{
        //    if (id != tblFavorite.FavoriteId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(tblFavorite).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TblFavoriteExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/TblFavorites
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> SaveFavorite(int customerId, int productId, TblFavorite tblFavorite)
        {
            return await _favoriteService.SaveFavorites(customerId,productId, tblFavorite);
        }

        //// DELETE: api/TblFavorites/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteTblFavorite(int id)
        //{
        //    var tblFavorite = await _context.TblFavorites.FindAsync(id);
        //    if (tblFavorite == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.TblFavorites.Remove(tblFavorite);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool TblFavoriteExists(int id)
        //{
        //    return _context.TblFavorites.Any(e => e.FavoriteId == id);
        //}
    }
}
