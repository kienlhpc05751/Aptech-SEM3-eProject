using System;
using System.Collections.Generic;

namespace GiveAID.Models;

public partial class Query
{
    public int Id { get; set; }

    public int MemberId { get; set; }

    public string Subject { get; set; } = null!;

    public string Message { get; set; } = null!;

    public string? ReplyText { get; set; }

    public bool IsResolved { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual User Member { get; set; } = null!;
}
