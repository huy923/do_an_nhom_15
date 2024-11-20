using System;
using System.Collections.Generic;

namespace do_an_nhom_15.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int OrderId { get; set; }

    public DateTime? PaymentDate { get; set; }

    public virtual Order Order { get; set; } = null!;
}
