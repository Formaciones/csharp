using System;
using System.Collections.Generic;

namespace Programando.CSharp.ConsoleEF.Model;

public partial class Summary_of_Sales_by_Quarter
{
    public DateTime? ShippedDate { get; set; }

    public int OrderID { get; set; }

    public decimal? Subtotal { get; set; }
}
