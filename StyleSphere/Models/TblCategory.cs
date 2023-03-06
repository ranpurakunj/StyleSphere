using System;
using System.Collections.Generic;

namespace StyleSphere.Models;

public partial class TblCategory
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool ActiveStatus { get; set; }

    public bool ShowOnTop { get; set; }

    public virtual ICollection<TblProduct> TblProducts { get; } = new List<TblProduct>();

    public virtual ICollection<TblSubCategory> TblSubCategories { get; } = new List<TblSubCategory>();
}
