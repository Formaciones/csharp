using System;
using System.Collections.Generic;

namespace Programando.CSharp.WebAPI1.Model;

public partial class Order_Subtotal
{
    public int OrderID { get; set; }

    public decimal? Subtotal { get; set; }
}
