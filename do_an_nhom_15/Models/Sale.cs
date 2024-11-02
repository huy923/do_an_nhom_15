using System;
using System.Collections.Generic;

namespace do_an_nhom_15.Models;

public partial class Sale
{
    public int SaleId { get; set; }

    public int? EmployeeId { get; set; }

    public DateOnly? SaleDate { get; set; }

    public decimal? Amount { get; set; }

    public virtual Employee? Employee { get; set; }
}
