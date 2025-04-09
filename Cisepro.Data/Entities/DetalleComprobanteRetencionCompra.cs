using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class DetalleComprobanteRetencionCompra
{
    public long IdDetalleComprobanteRetencionCompra { get; set; }

    public int? EjFiscalDetalleComprobanteRetencionCompra { get; set; }

    public string? CodigoDetalleComprobanteRetencionCompra { get; set; }

    public decimal? BaseImponibleDetalleComprobanteRetencionCompra { get; set; }

    public string? ImpuestoDetalleComprobanteRetencionCompra { get; set; }

    public decimal? PorcentajeDetalleComprobanteRetencionCompra { get; set; }

    public decimal? ValorDetalleComprobanteRetencionCompra { get; set; }

    public int? EstadoDetalleComprobanteRetencionCompra { get; set; }

    public long IdComprobanteRetencionCompra { get; set; }

    public long? IdComprobanteCompra { get; set; }

    public virtual ComprobanteRetencionCompra IdComprobanteRetencionCompraNavigation { get; set; } = null!;
}
