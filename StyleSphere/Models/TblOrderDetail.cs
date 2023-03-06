using System;
using System.Collections.Generic;

namespace StyleSphere.Models;

public partial class TblOrderDetail
{
    public int OrderDetailsId { get; set; }

    public int OrderId { get; set; }

    public int ProductMappingId { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public decimal Total { get; set; }

    public bool ActiveStatus { get; set; }

    public virtual TblOrderDatum Order { get; set; } = null!;

    public virtual TblProductMapping ProductMapping { get; set; } = null!;
}
