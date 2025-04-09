using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class ComprobantesCompra
{
    public long IdComprobanteCompra { get; set; }

    public int? IdProveedorGeneral { get; set; }

    public string? TipoComprobanteCompra { get; set; }

    public string? NumeroComprobanteCompra { get; set; }

    public string? NumAutoSriComprobanteCompra { get; set; }

    public DateTime? FechaAutoSriComprobanteCompra { get; set; }

    public DateTime? FechaEmisionComprobanteCompra { get; set; }

    public string? GuiaRemisionComprobanteCompra { get; set; }

    public string? DocModComprobanteCompra { get; set; }

    public string? RazModComprobanteCompra { get; set; }

    public string? ObservacionComprobanteCompra { get; set; }

    public decimal? Subtotal12ComprobanteCompra { get; set; }

    public decimal? Subtotal0ComprobanteCompra { get; set; }

    public decimal? DescuentoComprobanteCompra { get; set; }

    public decimal? SubtotalComprobanteCompra { get; set; }

    public int? PorcentajeIvaComprobanteCompra { get; set; }

    public decimal? IvaComprobanteCompra { get; set; }

    public decimal? TotalComprobanteCompra { get; set; }

    public int? EstadoComprobanteCompra { get; set; }

    public decimal? Subtotal5ComprobanteCompra { get; set; }

    public decimal? Iva5ComprobanteCompra { get; set; }
}
