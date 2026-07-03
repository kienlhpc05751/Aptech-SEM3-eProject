using System;
using System.Collections.Generic;

namespace GiveAID.Models;

public partial class AboutUsSubpage
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public string? MediaUrl { get; set; }

    public DateTime UpdatedAt { get; set; }
}
