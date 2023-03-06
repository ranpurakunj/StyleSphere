using System;
using System.Collections.Generic;

namespace StyleSphere.Models;

public partial class TblColorMaster
{
    public int ColorId { get; set; }

    public string Color { get; set; } = null!;

    public bool ActiveStatus { get; set; }

    public virtual ICollection<TblProductMapping> TblProductMappings { get; } = new List<TblProductMapping>();
}
