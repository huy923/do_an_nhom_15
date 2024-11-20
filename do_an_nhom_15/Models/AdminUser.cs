using System;
using System.Collections.Generic;

namespace do_an_nhom_15.Models;

public partial class AdminUser
{
    public int AdminId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? FullName { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }
}
