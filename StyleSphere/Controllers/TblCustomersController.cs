using Microsoft.AspNetCore.Mvc;
using StyleSphere.Models;
using StyleSphere.Services;

namespace StyleSphere.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblCustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        // We don't need this if we are using dependency injections for all API calls. _context can be declared and defined in the service class and its contructors.
        //private readonly DbStyleSphereContext _context; 
        
        //We don't need to pass instance of the DBContext as a parameter if Dependency is used for the same reasons as mentioned above.
        public TblCustomersController( ICustomerService customerService)
        {
            _customerService = customerService;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerbyId(int id)
        {
            return await _customerService.GetCustomer(id);
        }

        [Route("login")]
        [HttpGet]
        public async Task<IActionResult> LoginCustomer(string email, string password)
        {
            return await _customerService.LoginCustomer(email, password);
        }

        // POST: api/TblCustomers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> Register(TblCustomer tblCustomer)
        {
            return await _customerService.RegisterCustomer(tblCustomer);

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

    }
}
