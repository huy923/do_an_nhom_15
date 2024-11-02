﻿using System;
using System.Collections.Generic;

namespace do_an_nhom_15.Models;

public partial class Payment
{
    public int PaymentsId { get; set; }

    public int OrderId { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public string? PaymentStatus { get; set; }

    public DateTime? PaymentDate { get; set; }

    public virtual Order Order { get; set; } = null!;
}
