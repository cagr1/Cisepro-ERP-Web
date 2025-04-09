using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class DetalleOrdenTecnicaSupervision
{
    public long IdOrden { get; set; }

    public long IdDetalle { get; set; }

    public string? Detalle { get; set; }

    public int? Ok { get; set; }

    public string? Observacion { get; set; }
}
