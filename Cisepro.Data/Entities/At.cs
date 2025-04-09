using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class At
{
    public int IdAts { get; set; }

    public DateTime? PeriodoAts { get; set; }

    public string? ComprasFacturasAts { get; set; }

    public string? ComprasNotasVentaAts { get; set; }

    public string? ComprasNotasCredito { get; set; }

    public string? ComprasLiquidacionesAts { get; set; }

    public string? VentasNotasCreditoAts { get; set; }

    public string? VentasFacturasAts { get; set; }

    public string? RetencionesComprasAts { get; set; }

    public DateTime? FechaCreacionAts { get; set; }

    public int? EstadoAts { get; set; }
}
