using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace do_an_nhom_15.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    [Required(ErrorMessage = "First name is required")]
    public string? FirstName { get; set; }
    [Required(ErrorMessage = "Last name is required")]
    public string? LastName { get; set; }
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string? Email { get; set; }
    [Phone(ErrorMessage = "Invalid phone number")]
    [Required(ErrorMessage = "Position is required")]
    public string? PhoneNumber { get; set; }
    [Required(ErrorMessage = "Position is required")]
    public string? Position { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive value")]
    [Required(ErrorMessage = "Salary is required")]
    public decimal? Salary { get; set; }

    public DateTime? HireDate { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual ICollection<Salary> Salaries { get; set; } = new List<Salary>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual ICollection<Shift> Shifts { get; set; } = new List<Shift>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
