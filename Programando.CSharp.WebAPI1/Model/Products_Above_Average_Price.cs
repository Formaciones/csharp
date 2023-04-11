using System;
using System.Collections.Generic;

namespace Programando.CSharp.WebAPI1.Model;

public partial class Products_Above_Average_Price
{
    public string ProductName { get; set; } = null!;

    public decimal? UnitPrice { get; set; }
}
