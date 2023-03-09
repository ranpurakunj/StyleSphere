using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Abstractions;
using StyleSphere.Models;

namespace StyleSphere.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblOrderDatumsController : ControllerBase
    {
        private readonly DbStyleSphereContext _context;

        public TblOrderDatumsController(DbStyleSphereContext context)
        {
            _context = context;
        }

        // GET: api/TblOrderDatums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblOrderDatum>>> GetTblOrderData()
        {
            return await _context.TblOrderData.ToListAsync();
        }

        // GET: api/TblOrderDatums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDataDto>> GetTblOrderDatumByCustomerID(int id)
        {
            var tblOrderDatum = _context.TblOrderData
                .Where(e => e.CustomerId == id)
                .Select(c=>new OrderDataDto
                {
                    OrderId = c.OrderId,
                    CustomerId = c.CustomerId,
                    OrderDate = c.OrderDate,
                    ShippingAddress = c.ShippingAddress,
                    BillingAddress = c.BillingAddress,
                    TrackingId = c.TrackingId,
                    NetAmount = c.NetAmount
                }).ToList();
            if (tblOrderDatum == null)
            {
                return NotFound();
            }
            return Ok(tblOrderDatum);
        }

        [Route("checkout")]
        [HttpGet]
        public async Task<ActionResult<OrderDatumViewModel>> Checkout(int customerID)
        {
            var tblOrderDatum = _context.TblOrderData.Where(a => a.CustomerId == customerID).ToList();
            List<OrderDatumViewModel> orders = new List<OrderDatumViewModel>();
            foreach (var order in tblOrderDatum)
            {
                OrderDatumViewModel model = new OrderDatumViewModel();
                model.OrderId = order.OrderId;
                model.CustomerId = order.CustomerId;
                model.OrderDate = order.OrderDate;
                model.ShippingAddress = order.ShippingAddress;
                model.BillingAddress = order.BillingAddress;
                model.TrackingId = order.TrackingId;
                model.NetAmount = order.NetAmount;
                foreach (var detail in order.TblOrderDetails)
                {
                    model.ProductName = detail.ProductMapping.Product.ProductName;
                    model.thumbnailImage = detail.ProductMapping.Product.ThumbnailImage;
                    model.Quantity = detail.Quantity;
                    model.color = detail.ProductMapping.Color.Color;
                    model.EUSize = detail.ProductMapping.Size.Eusize;
                    model.USSize = detail.ProductMapping.Size.Ussize;
                    model.price = detail.Price;
                }
                orders.Add(model);
            }
            return Ok(orders);
        }

        // PUT: api/TblOrderDatums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblOrderDatum(int id, TblOrderDatum tblOrderDatum)
        {
            if (id != tblOrderDatum.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(tblOrderDatum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblOrderDatumExists(id))
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

        // POST: api/TblOrderDatums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblOrderDatum>> PostTblOrderDatum(TblOrderDatum tblOrderDatum)
        {
            //tblOrderDatum.NetAmount = tblOrderDatum.TblOrderDetails.Sum(a => a.Total);
            _context.TblOrderData.Add(tblOrderDatum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblOrderDatum", new { id = tblOrderDatum.OrderId }, tblOrderDatum);
        }

        // DELETE: api/TblOrderDatums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblOrderDatum(int id)
        {
            var tblOrderDatum = await _context.TblOrderData.FindAsync(id);
            if (tblOrderDatum == null)
            {
                return NotFound();
            }

            _context.TblOrderData.Remove(tblOrderDatum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblOrderDatumExists(int id)
        {
            return _context.TblOrderData.Any(e => e.OrderId == id);
        }
    }
}
