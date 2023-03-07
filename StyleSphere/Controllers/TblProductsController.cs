using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StyleSphere.Models;

namespace StyleSphere.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblProductsController : ControllerBase
    {
        private readonly DbStyleSphereContext _context;

        public TblProductsController(DbStyleSphereContext context)
        {
            _context = context;
        }

        // GET: api/TblProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblProduct>>> GetTblProducts()
        {
            return await _context.TblProducts.ToListAsync();
        }



        // GET: api/TblProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductViewModel>> GetTblProduct(int id)
        {
            
            var tblProduct = await _context.TblProducts.FindAsync(id);
            if (tblProduct == null)
            {
                return NotFound();
            }

            //return tblProduct;

            // For View Model
            ProductViewModel model = new ProductViewModel();
            model.ProductId=tblProduct.ProductId;  
            model.ProductName=tblProduct.ProductName;
            model.Image1 = tblProduct.Image1;
            model.Image2 = tblProduct.Image2;
            model.Image3 = tblProduct.Image3;
            model.ThumbnailImage= tblProduct.ThumbnailImage;
            model.Price=tblProduct.Price;
            model.Description = tblProduct.Description;
            model.ColorCount = tblProduct.TblProductMappings.Select(a => a.ColorId).Distinct().Count();
            model.NoOfRatings = tblProduct.TblRatings.Count();
            model.ratings = (tblProduct.TblRatings.Select(a => a.Rating).Sum() / tblProduct.TblRatings.Count());

            List<TblSizeMaster> sizeList = new List<TblSizeMaster>();
            List<TblColorMaster> ColorList = new List<TblColorMaster>();
            foreach (var item in tblProduct.TblProductMappings)
            {
                var colorData = _context.TblColorMasters.Where(a => a.ColorId == item.ColorId).FirstOrDefault();
                var sizeData = _context.TblSizeMasters.Where(a => a.SizeId == item.SizeId).FirstOrDefault();
                
                TblSizeMaster objSize = new TblSizeMaster();
                objSize.SizeId = item.SizeId;
                objSize.Eusize = sizeData.Eusize;
                objSize.Ussize = sizeData.Ussize;
                sizeList.Add(objSize);

                TblColorMaster objColor = new TblColorMaster();
                objColor.ColorId = item.ColorId;
                objColor.Color = colorData.Color;
                ColorList.Add(objColor);
            }
            model.ColorList = ColorList;
            model.sizeList = sizeList;
            return model;
        }

        // PUT: api/TblProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblProduct(int id, TblProduct tblProduct)
        {
            if (id != tblProduct.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(tblProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TblProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblProduct>> PostTblProduct(TblProduct tblProduct)
        {
            _context.TblProducts.Add(tblProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblProduct", new { id = tblProduct.ProductId }, tblProduct);
        }

        // DELETE: api/TblProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblProduct(int id)
        {
            var tblProduct = await _context.TblProducts.FindAsync(id);
            if (tblProduct == null)
            {
                return NotFound();
            }

            _context.TblProducts.Remove(tblProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblProductExists(int id)
        {
            return _context.TblProducts.Any(e => e.ProductId == id);
        }
    }
}
