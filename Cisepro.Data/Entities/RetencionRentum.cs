using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class RetencionRentum
{
    public int IdRetencionRenta { get; set; }

    public string CodigoAnualRetencionRenta { get; set; } = null!;

    public string ConceptoAnualRetencionRenta { get; set; } = null!;

    public int PorcentajeRetencionRenta { get; set; }

    public int AñoRetencionRenta { get; set; }

    public int EstadoRetencionRenta { get; set; }
}
