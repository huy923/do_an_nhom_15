using System;
using System.Collections.Generic;

namespace do_an_nhom_15.Models;

public partial class Blog
{
    public int BlogId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Detail { get; set; }

    public DateTime? Time { get; set; }

    public int? Adminid { get; set; }

    public string? Image { get; set; }

    public virtual AdminUser? Admin { get; set; }

    public virtual ICollection<CommentBlog> CommentBlogs { get; set; } = new List<CommentBlog>();
}
