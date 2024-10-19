using System;
using System.Collections.Generic;

namespace do_an_nhom_15.Models;

public partial class Category
{
    public int CategoriesId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public bool? Active { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
