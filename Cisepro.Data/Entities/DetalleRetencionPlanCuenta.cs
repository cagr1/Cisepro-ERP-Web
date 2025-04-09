using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class DetalleRetencionPlanCuenta
{
    public int IdDetalle { get; set; }

    public int? IdFacturaVenta { get; set; }

    public int? IdComprobanteCompra { get; set; }

    public int? IdDetalleComprobanteRetencionVenta { get; set; }

    public int? IdDetalleComprobanteRetencionCompra { get; set; }

    public string? Codigo { get; set; }

    public string? Cuenta { get; set; }
}
