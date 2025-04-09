using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class PagosFacturaVentum
{
    public long IdPagoFacturaVenta { get; set; }

    public DateTime? FechaPagoFacturaCompra { get; set; }

    public long? NumeroPagoFacturaVenta { get; set; }

    public string? FormaPagoFacturaVenta { get; set; }

    public decimal? MontoPagoFacturaVenta { get; set; }

    public decimal? SaldoPagoFacturaVenta { get; set; }

    public int? EstadoPagoFacturaVenta { get; set; }

    public long IdFacturaVenta { get; set; }

    public long? IdClienteGeneral { get; set; }

    public long? IdComprobanteIngresoBancos { get; set; }
}
