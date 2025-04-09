using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class Foto
{
    public int IdFoto { get; set; }

    public byte[]? Foto1 { get; set; }

    public string Aux { get; set; } = null!;
}
