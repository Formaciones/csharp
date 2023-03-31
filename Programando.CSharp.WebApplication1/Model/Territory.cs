using System;
using System.Collections.Generic;

namespace Programando.CSharp.WebApplication1.Model;

public partial class Territory
{
    public string TerritoryID { get; set; } = null!;

    public string TerritoryDescription { get; set; } = null!;

    public int RegionID { get; set; }

    public virtual Region Region { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
