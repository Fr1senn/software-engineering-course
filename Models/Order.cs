using System;
using System.Collections.Generic;

namespace SoftwareEngineering.Models;

public partial class Order
{
    public int Id { get; set; }

    public DateOnly OrderDate { get; set; }

    public DateOnly? RefundDate { get; set; }

    public int? ReaderId { get; set; }

    public int? BookId { get; set; }

    public virtual Book? Book { get; set; }

    public virtual Reader? Reader { get; set; }
}
