using System;
using System.Collections.Generic;

namespace do_an_nhom_15.Models;

public partial class Salary
{
    public int SalaryId { get; set; }

    public int? EmployeeId { get; set; }

    public decimal? BaseSalary { get; set; }

    public decimal? Bonus { get; set; }

    public decimal? Deductions { get; set; }

    public decimal? TotalSalary { get; set; }

    public DateOnly? PaymentDate { get; set; }

    public virtual Employee? Employee { get; set; }
}
