using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class ConceptosComprobanteIngresoBanco
{
    public int IdConceptoComprobanteIngresoBancos { get; set; }

    public string? NombreConceptoComprobanteIngresoBancos { get; set; }

    public string? CuentaConceptoComprobanteIngresoBancos { get; set; }

    public int? EstadoConceptoComprobanteIngresoBancos { get; set; }

    public int? IdPlan { get; set; }
}
