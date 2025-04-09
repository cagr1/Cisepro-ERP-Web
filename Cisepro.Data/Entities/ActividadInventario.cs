using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class ActividadInventario
{
    public int IdActividad { get; set; }

    public string DetalleActividad { get; set; } = null!;

    public int NumerosConceptos { get; set; }

    public int Estado { get; set; }

    public virtual ICollection<ConceptosInventario> ConceptosInventarios { get; set; } = new List<ConceptosInventario>();
}
