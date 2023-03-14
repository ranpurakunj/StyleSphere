using System;
using System.Collections.Generic;

namespace StyleSphere.Models;

public partial class TblSizeMaster
{
    public int SizeId { get; set; }

    public string Eusize { get; set; }

    public string Ussize { get; set; }

    public bool ActiveStatus { get; set; }

    public virtual ICollection<TblProductMapping> TblProductMappings { get; } = new List<TblProductMapping>();
}
