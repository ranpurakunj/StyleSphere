using System;
using System.Collections.Generic;

namespace StyleSphere.Models;

public partial class TblCustomer
{
    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string ContactNo { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string ZipCode { get; set; } = null!;

    public bool ActiveStatus { get; set; }

    public virtual ICollection<TblOrderDatum> TblOrderData { get; } = new List<TblOrderDatum>();

    public virtual ICollection<TblRating> TblRatings { get; } = new List<TblRating>();

    public virtual ICollection<TblFavorite> TblFavorites { get; } = new List<TblFavorite>();
}
