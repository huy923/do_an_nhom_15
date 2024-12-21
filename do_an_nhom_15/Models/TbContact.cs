using System;
using System.Collections.Generic;

namespace do_an_nhom_15.Models;

public partial class TbContact
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Message { get; set; } = null!;

    public DateOnly CreatedDate { get; set; }
}
