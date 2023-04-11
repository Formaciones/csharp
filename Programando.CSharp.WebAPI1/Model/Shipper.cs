using System;
using System.Collections.Generic;

namespace Programando.CSharp.WebAPI1.Model;

public partial class Shipper
{
    public int ShipperID { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? Phone { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
