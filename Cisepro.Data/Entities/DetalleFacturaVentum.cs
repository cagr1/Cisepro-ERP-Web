using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class DetalleFacturaVentum
{
    public long IdDetalleFacturaVenta { get; set; }

    public long IdSecuencialItem { get; set; }

    public int CantidadDetalleFacturaVenta { get; set; }

    public decimal ValoruDetalleFacturaVenta { get; set; }

    public decimal? ValordDetalleFacturaVenta { get; set; }

    public decimal ValortDetalleFacturaVenta { get; set; }

    public int EstadoDetalleFacturaVenta { get; set; }

    public long IdFacturaVenta { get; set; }

    public virtual FacturaVentum IdFacturaVentaNavigation { get; set; } = null!;
}
