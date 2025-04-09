using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class BancoRole
{
    public int IdBanco { get; set; }

    public string Banco { get; set; } = null!;

    public string? Cod { get; set; }
}
