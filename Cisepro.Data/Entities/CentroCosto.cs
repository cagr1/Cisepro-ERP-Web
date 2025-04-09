using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class CentroCosto
{
    public int IdCentroCosto { get; set; }

    public string DetalleCentroCosto { get; set; } = null!;

    public string CodigoCentroCosto { get; set; } = null!;

    public int EstadoCentroCosto { get; set; }

    public virtual ICollection<CajaChica> CajaChicas { get; set; } = new List<CajaChica>();

    public virtual ICollection<FondoRotativo> FondoRotativos { get; set; } = new List<FondoRotativo>();
}
