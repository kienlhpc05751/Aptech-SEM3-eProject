using System;
using System.Collections.Generic;

namespace GiveAID.Models;

public partial class WelfareProgramme
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int NgoId { get; set; }

    public int CauseId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public decimal MaxDonationAmount { get; set; }

    public string? Location { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Cause Cause { get; set; } = null!;

    public virtual Ngo Ngo { get; set; } = null!;
}
