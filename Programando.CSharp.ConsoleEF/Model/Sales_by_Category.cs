using System;
using System.Collections.Generic;

namespace Programando.CSharp.ConsoleEF.Model;

public partial class Sales_by_Category
{
    public int CategoryID { get; set; }

    public string CategoryName { get; set; }

    public string ProductName { get; set; }

    public decimal? ProductSales { get; set; }
}
