using Microsoft.AspNetCore.Mvc;
using StyleSphere.Models;

namespace StyleSphere.Services
{
    public interface IOrderDatumService
    {
        public Task<IActionResult> GetOrderDataByCustomerId(int customerId);
        public Task<IActionResult> Checkout(CheckoutMaster order);
    }
}
