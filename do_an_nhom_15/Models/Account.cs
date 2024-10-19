using System;
using System.Collections.Generic;

namespace do_an_nhom_15.Models;

public partial class Account
{
    public int UserId { get; set; }

    public int? CustomerId { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? Role { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Customer? Customer { get; set; }
}
