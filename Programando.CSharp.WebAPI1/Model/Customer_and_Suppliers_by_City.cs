using System;
using System.Collections.Generic;

namespace Programando.CSharp.WebAPI1.Model;

public partial class Customer_and_Suppliers_by_City
{
    public string? City { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? ContactName { get; set; }

    public string Relationship { get; set; } = null!;
}
