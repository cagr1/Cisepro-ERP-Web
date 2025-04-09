using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class PagosComprobantesCompra
{
    public long IdPagosComprobanteCompra { get; set; }

    public DateTime? FechaPagosComprobanteCompra { get; set; }

    public int NumeroPagosComprobanteCompra { get; set; }

    public decimal MontoPagosComprobanteCompra { get; set; }

    public decimal SaldoPagosComprobanteCompra { get; set; }

    public int EstadoPagosComprobanteCompra { get; set; }

    public long IdComprobanteCompra { get; set; }

    public int? IdProveedorGeneral { get; set; }

    public long? IdComprobanteEgresoBancos { get; set; }
}
