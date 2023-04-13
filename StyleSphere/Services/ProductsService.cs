using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StyleSphere.Models;
using System.Runtime.InteropServices;

namespace StyleSphere.Services
{
    public class ProductsService:IProductsService
    {
        private readonly DbStyleSphereContext _context;

        public ProductsService(DbStyleSphereContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> GetAllProducts()
        {
            var tblproduct = await _context.TblProducts.ToListAsync();
            return new OkObjectResult( _GetProductViewModels(tblproduct));
        }

        public async Task<IActionResult> GetProductsByCategory(int CategoryId)
        {
            List<ProductViewModel> products = new List<ProductViewModel>();
            var tblProduct = await _context.TblProducts.Where(e => e.CategoryId == CategoryId).ToListAsync();
            return new OkObjectResult(_GetProductViewModels(tblProduct));
        }

        public async Task<IActionResult> GetProductsById(int id)
        {
            List<ProductViewModel> products = new List<ProductViewModel>();
            var tblProduct = await _context.TblProducts.Where(e => e.ProductId == id).ToListAsync();
            return new OkObjectResult(_GetProductViewModels(tblProduct));
        }

        public async Task<IActionResult> GetProductsBySubCategory(int SubCategoryId)
        {
            List<ProductViewModel> products = new List<ProductViewModel>();
            var tblProduct = await _context.TblProducts.Where(e => e.SubCategoryId == SubCategoryId).ToListAsync();
            return new OkObjectResult(_GetProductViewModels(tblProduct));
        }

        public async Task<IActionResult> GetProductUnderPrice(decimal price)
        {
            List<ProductViewModel> products = new List<ProductViewModel>();
            var tblProduct = await _context.TblProducts.Where(e => e.Price <= price).ToListAsync();
            return new OkObjectResult(_GetProductViewModels(tblProduct));
        }

        public async Task<IActionResult> GetSearchedProducts(string SearchText)
        {
            List<ProductViewModel> products = new List<ProductViewModel>();
            var tblproduct = await _context.TblProducts.Where(e => e.ProductName.Contains(SearchText) || e.Description.Contains(SearchText)).ToListAsync();
            return new OkObjectResult(_GetProductViewModels(tblproduct));
        }

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

                List<TblSizeMaster> sizeList = new List<TblSizeMaster>();
                List<TblColorMaster> ColorList = new List<TblColorMaster>();
                List<ProductMappingViewModel> mappings = new List<ProductMappingViewModel>();
                var mapppingsData = _context.TblProductMappings.Where(a => a.ProductId == items.ProductId).ToList();
                model.ColorCount = mapppingsData.Select(a => a.ColorId).Distinct().Count();
                foreach (var item in mapppingsData)
                {
                    ProductMappingViewModel productMapping = new ProductMappingViewModel();
                    productMapping.ProductMappingId = item.ProductMappingId;
                    productMapping.ProductId = item.ProductId;
                    var colorData = _context.TblColorMasters.Where(a => a.ColorId == item.ColorId).FirstOrDefault();
                    var sizeData = _context.TblSizeMasters.Where(a => a.SizeId == item.SizeId).FirstOrDefault();

                    if (sizeData != null)
                    {
                        TblSizeMaster objSize = new TblSizeMaster();
                        objSize.SizeId = item.SizeId;
                        objSize.Eusize = sizeData.Eusize;
                        productMapping.EUSize = sizeData.Eusize;
                        objSize.Ussize = sizeData.Ussize;
                        productMapping.UsSize = sizeData.Ussize;
                        sizeList.Add(objSize);
                    }

                    if (colorData != null)
                    {
                        TblColorMaster objColor = new TblColorMaster();
                        objColor.ColorId = item.ColorId;
                        objColor.Color = colorData.Color;
                        productMapping.Color = colorData.Color;
                        ColorList.Add(objColor);
                    }
                    mappings.Add(productMapping);
                }
                model.mappingList= mappings;
                model.ColorList = ColorList;
                model.sizeList = sizeList;
                products.Add(model);
            }
            return products;
        }
    }
}
