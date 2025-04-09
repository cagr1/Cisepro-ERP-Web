using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class ContribuyenteRetenido
{
    public int IdContribuyenteRetenido { get; set; }

    public string? TipoContribuyenteRetenido { get; set; }

    public int? EstadoContribuyenteRetenido { get; set; }

    public virtual ICollection<PorcentajeRet> PorcentajeRets { get; set; } = new List<PorcentajeRet>();
}
