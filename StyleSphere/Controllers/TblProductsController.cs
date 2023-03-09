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
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetTblProducts()
        {
            List<ProductViewModel> products = new List<ProductViewModel>();
            var tblproduct2 = _context.TblProducts.ToList();
            products = _GetProductViewModels(products, tblproduct2);
            return Ok(products);

        }

        // GET: api/TblProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductViewModel>> GetTblProduct(int id)
        {
            List<ProductViewModel> products = new List<ProductViewModel>();
            var tblProduct1 = _context.TblProducts.Where(e => e.ProductId == id).ToList();
            products = _GetProductViewModels(products, tblProduct1);
            return Ok(products); 
        }

        [Route("ProductByCategory")]
        [HttpGet]
        public async Task<ActionResult<ProductViewModel>> GetTblProductByCategory(int id)
        {
            List<ProductViewModel> products = new List<ProductViewModel>();
            var tblProduct5 = _context.TblProducts.Where(e => e.CategoryId == id).ToList();
            products = _GetProductViewModels(products, tblProduct5);
            return Ok(Ok(products));
        }

        [Route("ProductBySubCategory")]
        [HttpGet]
        public async Task<ActionResult<ProductViewModel>> GetTblProductBySubCategory(int id)
        {
            List<ProductViewModel> products = new List<ProductViewModel>();
            var tblProduct6 = _context.TblProducts.Where(e => e.SubCategoryId == id).ToList();
            products = _GetProductViewModels(products, tblProduct6);
            return Ok(products);
        }

        [Route("ProductUnderPrice")]
        [HttpGet]
        public async Task<ActionResult<ProductViewModel>> GetTblProductUnderPrice(decimal price)
        {
            List<ProductViewModel> products = new List<ProductViewModel>();
            var tblProduct4 = _context.TblProducts.Where(e => e.Price <= price).ToList();
            products = _GetProductViewModels(products, tblProduct4);
            return Ok(products);
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

        [Route("search")]
        [HttpPost]
        public async Task<ActionResult<ProductViewModel>> SearchProduct(string SearchText)
        {
            List<ProductViewModel> products = new List<ProductViewModel>();
            var tblproduct3 = _context.TblProducts.Where(e => e.ProductName.Contains(SearchText) || e.Description.Contains(SearchText)).ToList();
            products = _GetProductViewModels(products, tblproduct3);
            return Ok(products);
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
            //_context.TblProducts.Where(e => e.ProductName.Contains(searchText) || e.Description.Contains(searchText)).ToList();
        }

        private List<ProductViewModel> _GetProductViewModels(List<ProductViewModel> products, List<TblProduct> tblproduct) 
        {
            foreach (var items in tblproduct)
            {
                ProductViewModel model = new ProductViewModel();
                model.ProductId = items.ProductId;
                model.ProductName = items.ProductName;
                model.Image1 = items.Image1;
                model.Image2 = items.Image2;
                model.Image3 = items.Image3;
                model.ThumbnailImage = items.ThumbnailImage;
                model.Price = items.Price;
                model.Description = items.Description;
                model.ColorCount = items.TblProductMappings.Select(a => a.ColorId).Distinct().Count();
                model.NoOfRatings = items.TblRatings.Count();
                model.ratings = (items.TblRatings.Select(a => a.Rating).Sum() / items.TblRatings.Count());

                List<TblSizeMaster> sizeList = new List<TblSizeMaster>();
                List<TblColorMaster> ColorList = new List<TblColorMaster>();
                foreach (var item in items.TblProductMappings)
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
                products.Add(model);
            }
            return products;
        }
    }
}
