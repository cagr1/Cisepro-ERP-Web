using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class CompEgresoPagosCompCompra
{
    public long IdComprobanteEgresoBancos { get; set; }

    public long IdComprobanteCompra { get; set; }

    public long IdPagosComprobanteCompra { get; set; }

    public decimal MontoPagosComprobanteCompra { get; set; }

    public long NumeroRegistroAsiento { get; set; }
}
