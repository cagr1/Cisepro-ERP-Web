using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class UserProfile
{
    public int Id { get; set; }

    public string Bio { get; set; } = null!;

    public string? Twitter { get; set; }

    public string? Website { get; set; }

    public DateTime? Birthdate { get; set; }

    public int UserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
