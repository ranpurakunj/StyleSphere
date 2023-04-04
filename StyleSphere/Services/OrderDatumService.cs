using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StyleSphere.Models;

namespace StyleSphere.Services
{
    public class OrderDatumService:IOrderDatumService
    {
        private readonly DbStyleSphereContext _context;

        public OrderDatumService(DbStyleSphereContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Checkout(CheckoutMaster order)
        {
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
                    model.ActiveStatus = order.ActiveStatus;
                    _context.TblOrderData.Add(model);
                    await _context.SaveChangesAsync();
                    foreach (var detail in order.OrderDetails)
                    {
                        TblOrderDetail detailItem = new TblOrderDetail();
                        detailItem.Quantity = detail.Quantity;
                        detailItem.Price = detail.Price;
                        detailItem.ProductMappingId = detail.ProductMappingId;
                        detailItem.OrderId = model.OrderId;
                        detailItem.ActiveStatus = true;
                        _context.TblOrderDetails.Add(detailItem);
                        await _context.SaveChangesAsync();
                    }
                    transaction.Commit();
                    return new OkObjectResult(model.OrderId.ToString());
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return new OkObjectResult(ex.Message);
                }
            }
        }

        public async Task<IActionResult> GetOrderDataByCustomerId(int customerId)
        {
            var tblOrderDatum = await _context.TblOrderData
                .Where(e => e.CustomerId == customerId)
                .Select(c => new OrderDataDto
                {
                    OrderId = c.OrderId,
                    CustomerId = c.CustomerId,
                    OrderDate = c.OrderDate,
                    ShippingAddress = c.ShippingAddress,
                    BillingAddress = c.BillingAddress,
                    TrackingId = c.TrackingId,
                    NetAmount = c.NetAmount
                }).ToListAsync();
            if (tblOrderDatum == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(tblOrderDatum);
        }
    }
}
