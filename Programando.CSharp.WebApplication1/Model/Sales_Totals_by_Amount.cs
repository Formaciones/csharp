using System;
using System.Collections.Generic;

namespace Programando.CSharp.WebApplication1.Model;

public partial class Sales_Totals_by_Amount
{
    public decimal? SaleAmount { get; set; }

    public int OrderID { get; set; }

    public string CompanyName { get; set; } = null!;

    public DateTime? ShippedDate { get; set; }
}
