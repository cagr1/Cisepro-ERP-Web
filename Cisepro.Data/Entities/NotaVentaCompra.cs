using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class NotaVentaCompra
{
    public long IdNotaVentaCompra { get; set; }

    public int IdProveedorGeneral { get; set; }

    public string NumeroNotaVentaCompra { get; set; } = null!;

    public string NumAutoSriNotaVentaCompra { get; set; } = null!;

    public DateTime FechaAutoSriNotaVentaCompra { get; set; }

    public DateTime FechaEmisionNotaVentaCompra { get; set; }

    public decimal TotalNotaVentaCompra { get; set; }

    public int EstadoNotaVentaCompra { get; set; }
}
