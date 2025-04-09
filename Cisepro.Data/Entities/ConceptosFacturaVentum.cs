using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class ConceptosFacturaVentum
{
    public int IdConceptoFacturaVenta { get; set; }

    public string NombreConceptoFacturaVenta { get; set; } = null!;

    public string CuentaConceptoFacturaVenta { get; set; } = null!;

    public int EstadoConceptoFacturaVenta { get; set; }

    public int IdPlan { get; set; }
}
