using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class Note
{
    public int Id { get; set; }

    public string Note1 { get; set; } = null!;

    public int Estado { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
