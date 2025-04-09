using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class DetalleUniforme
{
    public long IdDetalleUniformes { get; set; }

    public long IdKardexDetalleUniformes { get; set; }

    public long IdDetalleKardexDetalleUniformes { get; set; }

    public string ObservacionDetalleUniformes { get; set; } = null!;

    public int CantidadDetalleUniformes { get; set; }

    public int EstadoDetalleUniformes { get; set; }

    public DateTime FechaRenovacionDetalleUniformes { get; set; }

    public long IdUniformes { get; set; }

    public string? Observacion { get; set; }

    public virtual EntregaUniforme IdUniformesNavigation { get; set; } = null!;
}
