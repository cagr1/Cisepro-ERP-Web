using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class CodigoAutorizarFactura
{
    public int IdCodigoAutorizarFactura { get; set; }

    public string NumeroCodigoAutorizarFactura { get; set; } = null!;

    public DateTime? FechaCodigoAutorizarFactura { get; set; }

    public string? ObservacionCodigoAutorizarFactura { get; set; }

    public int? EstadoCodigoAutorizarFactura { get; set; }

    public string? NumeroFacturaVenta { get; set; }
}
