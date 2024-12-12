using System;
using System.Collections.Generic;

namespace do_an_nhom_15.Models;

public partial class CommentBlog
{
    public int CommentBlogId { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? Time { get; set; }

    public int? BlogId { get; set; }

    public string? Comment { get; set; }

    public virtual Blog? Blog { get; set; }

    public virtual Customer? Customer { get; set; }
}
