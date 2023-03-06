using System;
using System.Collections.Generic;

namespace StyleSphere.Models;

public partial class TblProductMapping
{
    public int ProductMappingId { get; set; }

    public int ProductId { get; set; }

    public int SizeId { get; set; }

    public int ColorId { get; set; }

    public bool ActiveStatus { get; set; }

    public virtual TblColorMaster Color { get; set; } = null!;

    public virtual TblProduct Product { get; set; } = null!;

    public virtual TblSizeMaster Size { get; set; } = null!;

    public virtual ICollection<TblOrderDetail> TblOrderDetails { get; } = new List<TblOrderDetail>();
}
