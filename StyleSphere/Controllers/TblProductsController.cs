using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;
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
            //List<ProductViewModel> products = new List<ProductViewModel>();
            var tblproduct = _context.TblProducts.ToList();
            return _GetProductViewModels(tblproduct);
            //return Ok(products);

        }

        // GET: api/TblProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductViewModel>> GetTblProduct(int id)
        {
            List<ProductViewModel> products = new List<ProductViewModel>();
            var tblProduct = _context.TblProducts.Where(e => e.ProductId == id).ToList();
            products = _GetProductViewModels(tblProduct);
            return Ok(products);
        }

        [Route("ProductByCategory")]
        [HttpGet]
        public async Task<ActionResult<ProductViewModel>> GetTblProductByCategory(int id)
        {
            List<ProductViewModel> products = new List<ProductViewModel>();
            var tblProduct = _context.TblProducts.Where(e => e.CategoryId == id).ToList();
            products = _GetProductViewModels(tblProduct);
            return Ok(Ok(products));
        }

        [Route("ProductBySubCategory")]
        [HttpGet]
        public async Task<ActionResult<ProductViewModel>> GetTblProductBySubCategory(int id)
        {
            List<ProductViewModel> products = new List<ProductViewModel>();
            var tblProduct = _context.TblProducts.Where(e => e.SubCategoryId == id).ToList();
            products = _GetProductViewModels(tblProduct);
            return Ok(products);
        }

        [Route("ProductUnderPrice")]
        [HttpGet]
        public async Task<ActionResult<ProductViewModel>> GetTblProductUnderPrice(decimal price)
        {
            List<ProductViewModel> products = new List<ProductViewModel>();
            var tblProduct = _context.TblProducts.Where(e => e.Price <= price).ToList();
            products = _GetProductViewModels(tblProduct);
            return Ok(products);
        }

        [Route("search")]
        [HttpPost]
        public async Task<ActionResult<ProductViewModel>> SearchProduct(string SearchText)
        {
            List<ProductViewModel> products = new List<ProductViewModel>();
            var tblproduct3 = _context.TblProducts.Where(e => e.ProductName.Contains(SearchText) || e.Description.Contains(SearchText)).ToList();
            products = _GetProductViewModels(tblproduct3);
            return Ok(products);
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

        private List<ProductViewModel> _GetProductViewModels(List<TblProduct> tblproduct) 
        {
            List<ProductViewModel> products = new List<ProductViewModel>();
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
                //model.ColorCount = items.TblProductMappings.Select(a => a.ColorId).Distinct().Count();
                // Ratings Count
                var ratingsData = _context.TblRatings.Where(a => a.ProductId == items.ProductId).ToList();
                model.NoOfRatings = ratingsData.Count();
                if (ratingsData.Count() > 0)
                    model.ratings = (ratingsData.Sum(a => a.Rating) / ratingsData.Count());
                else
                    model.ratings = 0;

                List <TblSizeMaster> sizeList = new List<TblSizeMaster>();
                List<TblColorMaster> ColorList = new List<TblColorMaster>();
                var mapppingsData = _context.TblProductMappings.Where(a => a.ProductId == items.ProductId).ToList();
                model.ColorCount = mapppingsData.Select(a => a.ColorId).Distinct().Count();
                foreach (var item in mapppingsData)
                {
                    var colorData = _context.TblColorMasters.Where(a => a.ColorId == item.ColorId).FirstOrDefault();
                    var sizeData = _context.TblSizeMasters.Where(a => a.SizeId == item.SizeId).FirstOrDefault();

                    if (sizeData != null)
                    {
                        TblSizeMaster objSize = new TblSizeMaster();
                        objSize.SizeId = item.SizeId;
                        objSize.Eusize = sizeData.Eusize;
                        objSize.Ussize = sizeData.Ussize;
                        sizeList.Add(objSize);
                    }

                    if (colorData != null)
                    {
                        TblColorMaster objColor = new TblColorMaster();
                        objColor.ColorId = item.ColorId;
                        objColor.Color = colorData.Color;
                        ColorList.Add(objColor);
                    }
                }
                model.ColorList = ColorList;
                model.sizeList = sizeList;
                products.Add(model);
            }
            return products;
        }
    }
}
