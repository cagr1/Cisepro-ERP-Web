using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class GastosCajaChica
{
    public int IdGastosCajaCh { get; set; }

    public string NombreGastoCajaCh { get; set; } = null!;

    public string CtaContableGastoCajaCh { get; set; } = null!;

    public int IdPlan { get; set; }

    public int Estado { get; set; }
}
