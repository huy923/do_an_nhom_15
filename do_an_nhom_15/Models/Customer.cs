using System;
using System.Collections.Generic;

namespace do_an_nhom_15.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<CommentBlog> CommentBlogs { get; set; } = new List<CommentBlog>();
}
