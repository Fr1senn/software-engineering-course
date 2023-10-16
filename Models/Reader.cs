using System;
using System.Collections.Generic;

namespace SoftwareEngineering.Models;

public partial class Reader
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public string? Education { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
