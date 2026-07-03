using System;
using System.Collections.Generic;

namespace GiveAID.Models;

public partial class Ngo
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? MissionStatement { get; set; }

    public string? ContactInfo { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<WelfareProgramme> WelfareProgrammes { get; set; } = new List<WelfareProgramme>();
}
