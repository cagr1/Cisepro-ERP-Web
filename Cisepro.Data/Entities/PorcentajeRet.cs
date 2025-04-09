using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class PorcentajeRet
{
    public int IdPorcentajeRetencion { get; set; }

    public decimal? CantidadPorcentajeRetencion { get; set; }

    public int? IdImpuestoRetenido { get; set; }

    public int? IdConceptoPago { get; set; }

    public int? IdContribuyenteRetenido { get; set; }

    public virtual ConceptoPago? IdConceptoPagoNavigation { get; set; }

    public virtual ContribuyenteRetenido? IdContribuyenteRetenidoNavigation { get; set; }

    public virtual ImpuestoRetenido? IdImpuestoRetenidoNavigation { get; set; }
}
