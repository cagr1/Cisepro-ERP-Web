using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class DetalleComprobanteRetencionVentum
{
    public long IdDetalleComprobanteRetencionVenta { get; set; }

    public int EjFiscalDetalleComprobanteRetencionVenta { get; set; }

    public string CodigoDetalleComprobanteRetencionVenta { get; set; } = null!;

    public decimal BaseImponibleDetalleComprobanteRetencionVenta { get; set; }

    public string ImpuestoDetalleComprobanteRetencionVenta { get; set; } = null!;

    public decimal PorcentajeDetalleComprobanteRetencionVenta { get; set; }

    public decimal ValorDetalleComprobanteRetencionVenta { get; set; }

    public int EstadoDetalleComprobanteRetencionVenta { get; set; }

    public long IdComprobanteRetencionVenta { get; set; }

    public long? IdFacturaVenta { get; set; }

    public virtual ComprobanteRetencionVentum IdComprobanteRetencionVentaNavigation { get; set; } = null!;
}
