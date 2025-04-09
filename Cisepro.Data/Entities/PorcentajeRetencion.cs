using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class PorcentajeRetencion
{
    public int IdPorcentajeRetencion { get; set; }

    public decimal? CantidadPorcentajeRetencion { get; set; }

    public int? IdImpuestoRetenido { get; set; }

    public int? IdConceptoPago { get; set; }

    public int? IdContribuyenteRetenido { get; set; }

    public string? CuentaCompra { get; set; }

    public string? CuentaVenta { get; set; }

    public int? TipoBS { get; set; }
}
