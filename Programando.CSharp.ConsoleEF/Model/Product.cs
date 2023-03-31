using System;
using System.Collections.Generic;

namespace Programando.CSharp.ConsoleEF.Model;

public partial class Product
{
    public int ProductID { get; set; }

    public string ProductName { get; set; }

    public int? SupplierID { get; set; }

    public int? CategoryID { get; set; }

    public string QuantityPerUnit { get; set; }

    public decimal? UnitPrice { get; set; }

    public short? UnitsInStock { get; set; }

    public short? UnitsOnOrder { get; set; }

    public short? ReorderLevel { get; set; }

    public bool Discontinued { get; set; }

    public virtual Category Category { get; set; }

    public virtual ICollection<Order_Detail> Order_Details { get; } = new List<Order_Detail>();

    public virtual Supplier Supplier { get; set; }
}
