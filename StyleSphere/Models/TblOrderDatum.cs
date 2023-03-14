using System;
using System.Collections.Generic;

namespace StyleSphere.Models;

public partial class TblOrderDatum
{
    public TblOrderDatum()
    {
        TblOrderDetails = new List<TblOrderDetail>();
        //Customer = new TblCustomer();
    }
    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public DateTime OrderDate { get; set; }

    public string ShippingAddress { get; set; } = null!;

    public string BillingAddress { get; set; } = null!;

    public string TrackingId { get; set; } = null!;

    public decimal NetAmount { get; set; }

    public bool ActiveStatus { get; set; }

    public virtual TblCustomer Customer { get; set; } = null;

    public virtual ICollection<TblOrderDetail> TblOrderDetails { get; set; }
}
