using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class Migration
{
    public string Migration1 { get; set; } = null!;

    public int Batch { get; set; }
}
