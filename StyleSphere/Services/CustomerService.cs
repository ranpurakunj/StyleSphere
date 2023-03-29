using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StyleSphere.Models;
using System.Threading.Tasks;

namespace StyleSphere.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly DbStyleSphereContext _context;
        public CustomerService(DbStyleSphereContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> GetCustomer(int id)
        {
            return new OkObjectResult(await _context.TblCustomers.FindAsync(id));
        }

        public async Task<IActionResult> LoginCustomer(string email, string password)
        {
            var customer = await _context.TblCustomers.SingleOrDefaultAsync(c => c.Email == email);
            if (customer == null || customer.Password != password)
            {
                return new BadRequestObjectResult("Invalid Email or Password");
            }
            return new OkObjectResult(customer);
        }

        public async Task<IActionResult> RegisterCustomer(TblCustomer tblCustomer)
        {
            if (TblCustomerExists(tblCustomer.Email))
            {
                return new BadRequestObjectResult("User already Exists");
            }
            else
            {
                _context.TblCustomers.Add(tblCustomer);
                await _context.SaveChangesAsync();

                return new CreatedAtActionResult("Register", "TblCustomers", new { id = tblCustomer.CustomerId }, tblCustomer);
            }
        }

        private bool TblCustomerExists(string email)
        {
            return _context.TblCustomers.Any(e => e.Email == email);
        }
    }
}
