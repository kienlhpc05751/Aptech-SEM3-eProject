using System;
using System.Collections.Generic;

namespace GiveAID.Models;

public partial class Cause
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsHidden { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<WelfareProgramme> WelfareProgrammes { get; set; } = new List<WelfareProgramme>();
}
