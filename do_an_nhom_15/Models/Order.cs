using System;
using System.Collections.Generic;

namespace do_an_nhom_15.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public string? CustomerName { get; set; }

    public string? CustomerPhone { get; set; }

    public string? CustomerAddress { get; set; }

    public DateOnly? OrderDate { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
