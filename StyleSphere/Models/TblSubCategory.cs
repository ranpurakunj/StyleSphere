using System;
using System.Collections.Generic;

namespace StyleSphere.Models;

public partial class TblSubCategory
{
    public int SubCategoryId { get; set; }

    public int CategoryId { get; set; }

    public string SubCategoryName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool ActiveStatus { get; set; }

    public virtual TblCategory Category { get; set; } = null!;

    public virtual ICollection<TblProduct> TblProducts { get; } = new List<TblProduct>();
}
