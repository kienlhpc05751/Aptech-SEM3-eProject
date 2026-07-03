using System;
using System.Collections.Generic;

namespace GiveAID.Models;

public partial class Partner
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string LogoUrl { get; set; } = null!;

    public string? Description { get; set; }

    public string? WebsiteLink { get; set; }

    public DateTime CreatedAt { get; set; }
}
