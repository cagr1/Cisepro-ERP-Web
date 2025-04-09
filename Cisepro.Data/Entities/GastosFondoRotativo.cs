using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class GastosFondoRotativo
{
    public int IdGastosFr { get; set; }

    public string NombreGastosFr { get; set; } = null!;

    public string CtaContableGastosFr { get; set; } = null!;

    public int EstadoGastosFr { get; set; }

    public int IdFondoRotativo { get; set; }

    public int IdPlan { get; set; }
}
