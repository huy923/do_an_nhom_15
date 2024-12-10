using System;
using System.Collections.Generic;

namespace do_an_nhom_15.Models;

public partial class Order
{
    public int OrderId { get; set; }

<<<<<<< HEAD
    public string? CustomerName { get; set; }

    public string? CustomerPhone { get; set; }

    public string? CustomerAddress { get; set; }

    public DateOnly? OrderDate { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
=======
    public string CustomerName { get; set; } = null!;
    public string CustomerPhone { get; set; } = null!;
    public string CustomerAddress { get; set; } = null!;
    public DateTime OrderDate { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

>>>>>>> b1f2a760b93b161268ccccbfcf0af6a007fe3e29
}
