using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class DetalleConceptoInventario
{
    public int IdDetalle { get; set; }

    public string Detalle { get; set; } = null!;

    public int Estado { get; set; }

    public virtual ICollection<ConceptosInventario> ConceptosInventarios { get; set; } = new List<ConceptosInventario>();
}
