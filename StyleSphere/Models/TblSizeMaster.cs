using System;
using System.Collections.Generic;

namespace StyleSphere.Models;

public partial class TblSizeMaster
{
    public int SizeId { get; set; }

    public int Eusize { get; set; }

    public int Ussize { get; set; }

    public bool ActiveStatus { get; set; }

    public virtual ICollection<TblProductMapping> TblProductMappings { get; } = new List<TblProductMapping>();
}
