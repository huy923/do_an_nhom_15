using System;
using System.Collections.Generic;

namespace do_an_nhom_15.Models;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public int ProductId { get; set; }

    public string? CustomerName { get; set; }

    public string? CustomerEmail { get; set; }

    public int? Rating { get; set; }

    public string Content { get; set; } = null!;

    public DateTime? FeedbackDate { get; set; }

    public bool? IsAnswered { get; set; }

    public virtual ICollection<FeedbackReply> FeedbackReplies { get; set; } = new List<FeedbackReply>();

    public virtual Product Product { get; set; } = null!;
}
