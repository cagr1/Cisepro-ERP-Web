using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class ConceptosInventario
{
    public int IdConcepto { get; set; }

    public int IdActividad { get; set; }

    public int IdDetalle { get; set; }

    public string CodigoConcepto { get; set; } = null!;

    public int EstadoConcepto { get; set; }

    public virtual ActividadInventario IdActividadNavigation { get; set; } = null!;

    public virtual DetalleConceptoInventario IdDetalleNavigation { get; set; } = null!;
}
