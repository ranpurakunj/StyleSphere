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
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<TblOrderDatum>>> GetTblOrderData()
        //{
        //    return await _context.TblOrderData.ToListAsync();
        //}

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
        [HttpPost]
        public async Task<ActionResult<string>> Checkout(CheckoutMaster order)
        {
            //var tblOrderDatum = _context.TblOrderData.Where(a => a.CustomerId == customerID).ToList();
            //List<OrderDatumViewModel> orders = new List<OrderDatumViewModel>();
            //foreach (var order in tblOrderDatum)
            //{
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    TblOrderDatum model = new TblOrderDatum();
                    model.OrderId = order.OrderId;
                    model.CustomerId = order.CustomerId;
                    model.OrderDate = order.OrderDate;
                    model.ShippingAddress = order.ShippingAddress;
                    model.BillingAddress = order.BillingAddress;
                    model.TrackingId = order.TrackingId;
                    model.NetAmount = order.NetAmount;
                    _context.TblOrderData.Add(model);
                    await _context.SaveChangesAsync();
                    foreach (var detail in order.OrderDetails)
                    {
                        TblOrderDetail detailItem = new TblOrderDetail();
                        detailItem.Quantity = detail.Quantity;
                        detailItem.Price = detail.Price;
                        detailItem.ProductMappingId = detail.ProductMappingId;
                        detailItem.OrderId = model.OrderId;
                        detailItem.Total = detail.Total;
                        detailItem.ActiveStatus = true;
                        _context.TblOrderDetails.Add(detailItem);
                        await _context.SaveChangesAsync();
                    }
                    transaction.Commit();
                    return Ok(model.OrderId.ToString());
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return Ok(ex.Message);
                }
            }
        }

        //// PUT: api/TblOrderDatums/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTblOrderDatum(int id, TblOrderDatum tblOrderDatum)
        //{
        //    if (id != tblOrderDatum.OrderId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(tblOrderDatum).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TblOrderDatumExists(id))
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

        //// POST: api/TblOrderDatums
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<TblOrderDatum>> PostTblOrderDatum(TblOrderDatum tblOrderDatum)
        //{
        //    //tblOrderDatum.NetAmount = tblOrderDatum.TblOrderDetails.Sum(a => a.Total);
        //    _context.TblOrderData.Add(tblOrderDatum);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetTblOrderDatum", new { id = tblOrderDatum.OrderId }, tblOrderDatum);
        //}

        //// DELETE: api/TblOrderDatums/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteTblOrderDatum(int id)
        //{
        //    var tblOrderDatum = await _context.TblOrderData.FindAsync(id);
        //    if (tblOrderDatum == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.TblOrderData.Remove(tblOrderDatum);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool TblOrderDatumExists(int id)
        //{
        //    return _context.TblOrderData.Any(e => e.OrderId == id);
        //}
    }
}
