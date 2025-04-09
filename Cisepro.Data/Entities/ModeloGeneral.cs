using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class ModeloGeneral
{
    public int IdModelo { get; set; }

    public string Detalle { get; set; } = null!;

    public int Estado { get; set; }
}
