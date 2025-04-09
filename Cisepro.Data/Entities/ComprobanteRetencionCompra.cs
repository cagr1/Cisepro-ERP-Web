using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class ComprobanteRetencionCompra
{
    public long IdComprobanteRetencionCompra { get; set; }

    public string? NumeroComprobanteRetencionCompra { get; set; }

    public string? NumAutoSriComprobanteRetencionCompra { get; set; }

    public DateTime? FechaAutoSriComprobanteRetencionCompa { get; set; }

    public DateTime FechaEmisionComprobanteRetencionCompra { get; set; }

    public int? IdProveedorGeneral { get; set; }

    public string? TipoCompVentaComprobanteRetencionCompra { get; set; }

    public string? NumCompVentaComprobanteRetencionCompra { get; set; }

    public decimal? TotalComprobanteRetencionCompra { get; set; }

    public int? EstadoComprobanteRetencionCompra { get; set; }

    public long IdComprobanteCompra { get; set; }

    public virtual ICollection<DetalleComprobanteRetencionCompra> DetalleComprobanteRetencionCompras { get; set; } = new List<DetalleComprobanteRetencionCompra>();
}
