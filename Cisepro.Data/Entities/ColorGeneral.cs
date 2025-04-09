using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class ColorGeneral
{
    public int IdColor { get; set; }

    public string Detalle { get; set; } = null!;

    public int Estado { get; set; }
}
