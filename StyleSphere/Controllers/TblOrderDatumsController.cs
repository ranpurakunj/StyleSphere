using Microsoft.AspNetCore.Mvc;
using StyleSphere.Models;
using StyleSphere.Services;

namespace StyleSphere.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblOrderDatumsController : ControllerBase
    {
        private readonly IOrderDatumService _orderDatumService;

        public TblOrderDatumsController(IOrderDatumService orderDatumService)
        {
            _orderDatumService= orderDatumService;
        }

        // GET: api/TblOrderDatums
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<TblOrderDatum>>> GetTblOrderData()
        //{
        //    return await _context.TblOrderData.ToListAsync();
        //}

        // GET: api/TblOrderDatums/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTblOrderDatumByCustomerID(int id)
        {
            return await _orderDatumService.GetOrderDataByCustomerId(id);
        }

        [Route("checkout")]
        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutMaster order)
        {
            return await _orderDatumService.Checkout(order);
            
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
