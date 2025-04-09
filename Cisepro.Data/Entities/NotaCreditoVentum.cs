using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class NotaCreditoVentum
{
    public long IdNotaCredito { get; set; }

    public long IdClienteGeneral { get; set; }

    public string NumeroNotaCredito { get; set; } = null!;

    public string NumAutoSriNotaCredito { get; set; } = null!;

    public DateTime FechaAutoSriNotaCredito { get; set; }

    public DateTime FechaEmisionNotaCredito { get; set; }

    public string NumDocModificacionNotaCredito { get; set; } = null!;

    public string RazonModificacionNotaCredito { get; set; } = null!;

    public decimal Subtotal12NotaCredito { get; set; }

    public decimal? Subtotal0TotaCredito { get; set; }

    public decimal? SubtotalNotaCredito { get; set; }

    public int? PorcentajeIvaNotaCredito { get; set; }

    public decimal IvaNotaCredito { get; set; }

    public decimal TotalNotaCredito { get; set; }

    public int EstadoNotaCredito { get; set; }

    public long? IdFacturaVenta { get; set; }
}
