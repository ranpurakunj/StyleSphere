using Microsoft.AspNetCore.Mvc;
using StyleSphere.Services;

namespace StyleSphere.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblProductsController : ControllerBase
    {
        
        private readonly IProductsService _productsService;
        public TblProductsController(IProductsService productsService)
        {
            _productsService= productsService;
        }

        // GET: api/TblProducts
        //[Route("ListAllProducts")]
        [HttpGet]
        public async Task<IActionResult> GetTblProducts()
        {
            return await _productsService.GetAllProducts();
        }

        // GET: api/TblProducts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTblProduct(int id)
        {
            return await _productsService.GetProductsById(id);
        }

        [Route("ProductByCategory")]
        [HttpGet]
        public async Task<IActionResult> GetTblProductByCategory(int id)
        {
            return await _productsService.GetProductsByCategory(id);
        }

        [Route("ProductBySubCategory")]
        [HttpGet]
        public async Task<IActionResult> GetTblProductBySubCategory(int id)
        {
            return await _productsService.GetProductsBySubCategory(id);
        }

        [Route("ProductUnderPrice")]
        [HttpGet]
        public async Task<IActionResult> GetTblProductUnderPrice(decimal price)
        {
            return await _productsService.GetProductUnderPrice(price);
        }

        [Route("search")]
        [HttpPost]
        public async Task<IActionResult> SearchProduct(string SearchText)
        {   
            return await _productsService.GetSearchedProducts(SearchText);
        }

        // PUT: api/TblProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTblProduct(int id, TblProduct tblProduct)
        //{
        //    if (id != tblProduct.ProductId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(tblProduct).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TblProductExists(id))
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

        //// POST: api/TblProducts
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<TblProduct>> PostTblProduct(TblProduct tblProduct)
        //{
        //    _context.TblProducts.Add(tblProduct);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetTblProduct", new { id = tblProduct.ProductId }, tblProduct);
        //}

        

        //// DELETE: api/TblProducts/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteTblProduct(int id)
        //{
        //    var tblProduct = await _context.TblProducts.FindAsync(id);
        //    if (tblProduct == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.TblProducts.Remove(tblProduct);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool TblProductExists(int id)
        //{
        //    return _context.TblProducts.Any(e => e.ProductId == id);
        //    //_context.TblProducts.Where(e => e.ProductName.Contains(searchText) || e.Description.Contains(searchText)).ToList();
        //}

        
    }
}
