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
    public class TblCustomersController : ControllerBase
    {
        private readonly DbStyleSphereContext _context;

        public TblCustomersController(DbStyleSphereContext context)
        {
            _context = context;
        }

        // GET: api/TblCustomers
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<TblCustomer>>> GetTblCustomers()
        //{
        //    return await _context.TblCustomers.ToListAsync();
        //}

        //// GET: api/TblCustomers/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<TblCustomer>> GetTblCustomer(int id)
        //{
        //    var tblCustomer = await _context.TblCustomers.FindAsync(id);

        //    if (tblCustomer == null)
        //    {
        //        return NotFound();
        //    }

        //    return tblCustomer;
        //}

        [Route("login")]
        [HttpGet]
        public async Task<ActionResult<TblCustomer>> LoginCustomer(string email, string password)
        {
            var customer = _context.TblCustomers.SingleOrDefault(c => c.Email == email);
            if (customer == null || customer.Password != password)
            {
                return BadRequest("Invalid Email or Password");
            }
            return Ok(customer);
        }

        // POST: api/TblCustomers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblCustomer>> PostTblCustomer(TblCustomer tblCustomer)
        {
            if (TblCustomerExists(tblCustomer.Email))
            {
                return BadRequest();
            }
            else
            {
                _context.TblCustomers.Add(tblCustomer);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetTblCustomer", new { id = tblCustomer.CustomerId }, tblCustomer);
            }

        }

        // PUT: api/TblCustomers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTblCustomer(int id, TblCustomer tblCustomer)
        //{
        //    if (id != tblCustomer.CustomerId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(tblCustomer).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        //if (!TblCustomerExists(id))
        //        //{
        //        //    return NotFound();
        //        //}
        //        //else
        //        //{
        //        //    throw;
        //        //}
        //    }

        //    return NoContent();
        //}

        //// DELETE: api/TblCustomers/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteTblCustomer(int id)
        //{
        //    var tblCustomer = await _context.TblCustomers.FindAsync(id);
        //    if (tblCustomer == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.TblCustomers.Remove(tblCustomer);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool TblCustomerExists(string email)
        {
            return _context.TblCustomers.Any(e => e.Email == email);
        }
    }
}
