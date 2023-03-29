using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StyleSphere.Models;
using StyleSphere.Services;

namespace StyleSphere.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblCategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;

        public TblCategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        // GET: api/TblCategories
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            return await _categoriesService.GetCategoriesAsync();
        }

        [HttpGet]
        [Route("ShowOnTop")]
        public async Task<IActionResult> GetShowonTopCategories()
        {
            return await _categoriesService.GetShowOnTopCategories();
        }

        //// GET: api/TblCategories/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<TblCategory>> GetTblCategory(int id)
        //{
        //    var tblCategory = await _context.TblCategories.FindAsync(id);

        //    if (tblCategory == null)
        //    {
        //        return NotFound();
        //    }

        //    return tblCategory;
        //}

        //// PUT: api/TblCategories/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTblCategory(int id, TblCategory tblCategory)
        //{
        //    if (id != tblCategory.CategoryId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(tblCategory).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TblCategoryExists(id))
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

        //// POST: api/TblCategories
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<TblCategory>> PostTblCategory(TblCategory tblCategory)
        //{
        //    _context.TblCategories.Add(tblCategory);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetTblCategory", new { id = tblCategory.CategoryId }, tblCategory);
        //}

        //// DELETE: api/TblCategories/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteTblCategory(int id)
        //{
        //    var tblCategory = await _context.TblCategories.FindAsync(id);
        //    if (tblCategory == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.TblCategories.Remove(tblCategory);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool TblCategoryExists(int id)
        //{
        //    return _context.TblCategories.Any(e => e.CategoryId == id);
        //}
    }
}
