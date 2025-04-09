using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class ImpuestoRetenido
{
    public int IdImpuestoRetenido { get; set; }

    public string? DescripcionImpuestoRetenido { get; set; }

    public string? EstadoImpuestoRetenido { get; set; }

    public virtual ICollection<PorcentajeRet> PorcentajeRets { get; set; } = new List<PorcentajeRet>();
}
