using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class DetalleComprobanteEgresoBodega
{
    public long IdDetalleComprobante { get; set; }

    public long IdKardex { get; set; }

    public long IdDetalleKardex { get; set; }

    public string ObservacionDetalle { get; set; } = null!;

    public string IdComprobante { get; set; } = null!;

    public int EstadoDetalle { get; set; }

    public string? Observacion { get; set; }

    public virtual ComprobanteEgresoBodega IdComprobanteNavigation { get; set; } = null!;
}
