using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class NotaDebitoCompra
{
    public long IdNotaDebitoCompra { get; set; }

    public string NumeroNotaDebitoCompra { get; set; } = null!;

    public string NumAutoSriNotaDebitoCompra { get; set; } = null!;

    public DateTime FechaAutoSriNotaDebitoCompra { get; set; }

    public DateTime FechaEmisionNotaDebitoCompra { get; set; }

    public string RazonModificacionNotaDebitoCompra { get; set; } = null!;

    public decimal IvaNotaDebitoCompra { get; set; }

    public decimal TotalNotaDebitoCompra { get; set; }

    public int EstadoNotaDebitoCompra { get; set; }
}
