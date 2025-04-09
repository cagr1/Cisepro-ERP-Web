using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class DetalleEpp
{
    public long IdDetalleEpp { get; set; }

    public long IdKardexDetalleEpp { get; set; }

    public long IdDetalleKardexDetalleEpp { get; set; }

    public string ObservacionDetalleEpp { get; set; } = null!;

    public int CantidadDetalleEpp { get; set; }

    public int EstadoDetalleEpp { get; set; }

    public DateTime FechaRenovacionDetalleEpp { get; set; }

    public long IdEpp { get; set; }

    public string? Observacion { get; set; }

    public virtual EntregaEpp IdEppNavigation { get; set; } = null!;
}
