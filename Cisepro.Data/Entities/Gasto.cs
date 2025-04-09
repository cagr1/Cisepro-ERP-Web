using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class Gasto
{
    public long IdGastos { get; set; }

    public string DetalleCtaGastos { get; set; } = null!;

    public string CtaContableGastos { get; set; } = null!;

    public string CtaPadreGastos { get; set; } = null!;

    public int TipoCta { get; set; }

    public int EstadoGastos { get; set; }
}
