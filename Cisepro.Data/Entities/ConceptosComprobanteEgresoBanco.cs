using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class ConceptosComprobanteEgresoBanco
{
    public int IdConceptoComprobanteEgresoBancos { get; set; }

    public string NombreConceptoComprobanteEgresoBancos { get; set; } = null!;

    public string CuentaConceptoComprobanteEgresoBancos { get; set; } = null!;

    public int EstadoConceptoComprobanteEgresoBancos { get; set; }

    public int IdPlan { get; set; }
}
