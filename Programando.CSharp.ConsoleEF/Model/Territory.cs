using System;
using System.Collections.Generic;

namespace Programando.CSharp.ConsoleEF.Model;

public partial class Territory
{
    public string TerritoryID { get; set; }

    public string TerritoryDescription { get; set; }

    public int RegionID { get; set; }

    public virtual Region Region { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
