using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class ConceptoPago
{
    public int IdConceptoPago { get; set; }

    public string? CodigoConceptoPago { get; set; }

    public string? DescripcionConceptoPago { get; set; }

    public int? EjercicioFiscalConceptoPago { get; set; }

    public int? EstadoConceptoPago { get; set; }

    public virtual ICollection<PorcentajeRet> PorcentajeRets { get; set; } = new List<PorcentajeRet>();
}
