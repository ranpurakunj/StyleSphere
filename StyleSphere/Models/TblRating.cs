﻿using System;
using System.Collections.Generic;

namespace StyleSphere.Models;

public partial class TblRating
{
    public int RatingId { get; set; }

    public int ProductId { get; set; }

    public int CustomerId { get; set; }

    public int Rating { get; set; }

    public bool ActiveStatus { get; set; }

    public virtual TblCustomer Customer { get; set; } = null!;

    public virtual TblProduct Product { get; set; } = null!;
}
