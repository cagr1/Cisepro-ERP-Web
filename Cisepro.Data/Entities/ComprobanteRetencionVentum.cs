using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class ComprobanteRetencionVentum
{
    public long IdComprobanteRetencionVenta { get; set; }

    public long IdClienteGeneral { get; set; }

    public string NumeroComprobanteRetencionVenta { get; set; } = null!;

    public string NumAutoSriComprobanteRetencionVenta { get; set; } = null!;

    public DateTime FechaEmisionComprobanteRetencionVenta { get; set; }

    public string TipoCompVentaComprobanteRetencionVenta { get; set; } = null!;

    public string NumCompVentaComprobanteRetencionVenta { get; set; } = null!;

    public decimal TotalComprobanteRetencionVenta { get; set; }

    public int EstadoComprobanteRetencionVenta { get; set; }

    public long IdFacturaVenta { get; set; }

    public virtual ICollection<DetalleComprobanteRetencionVentum> DetalleComprobanteRetencionVenta { get; set; } = new List<DetalleComprobanteRetencionVentum>();
}
