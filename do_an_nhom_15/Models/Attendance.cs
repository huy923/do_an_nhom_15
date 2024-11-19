using System;
using System.Collections.Generic;

namespace do_an_nhom_15.Models;

public partial class Attendance
{
    public int AttendanceId { get; set; }

    public int? EmployeeId { get; set; }

    public DateOnly? Date { get; set; }

    public TimeOnly? CheckIn { get; set; }

    public TimeOnly? CheckOut { get; set; }

    public string? Status { get; set; }

    public virtual Employee? Employee { get; set; }
}
