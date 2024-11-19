using System;
using System.Collections.Generic;

namespace do_an_nhom_15.Models;

public partial class Cart
{
    public int CartId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public virtual Product Product { get; set; } = null!;
}
