using Microsoft.AspNetCore.Mvc;
using StyleSphere.Models;
using System.Threading.Tasks;

namespace StyleSphere.Services
{
    public interface ICustomerService
    {
        public Task<IActionResult> GetCustomer(int id);
        public Task<IActionResult> LoginCustomer(string email, string password);
        public Task<IActionResult> RegisterCustomer(TblCustomer tblCustomer);
    }
}
