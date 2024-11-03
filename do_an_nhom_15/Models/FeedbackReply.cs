using System;
using System.Collections.Generic;

namespace do_an_nhom_15.Models;

public partial class FeedbackReply
{
    public int ReplyId { get; set; }

    public int FeedbackId { get; set; }

    public string ReplyContent { get; set; } = null!;

    public DateTime? ReplyDate { get; set; }

    public string? RepliedBy { get; set; }

    public virtual Feedback Feedback { get; set; } = null!;
}
