using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class ConceptosComprobantesCompra
{
    public int IdConceptoComprobanteCompra { get; set; }

    public string NombreConceptoComprobanteCompra { get; set; } = null!;

    public string CuentaConceptoComprobanteCompra { get; set; } = null!;

    public int EstadoConceptoComprobanteCompra { get; set; }

    public int IdPlan { get; set; }
}
