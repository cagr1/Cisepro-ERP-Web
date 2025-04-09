using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class DetalleEgresoSuministro
{
    public long IdDetalleEgresoSuministros { get; set; }

    public int IdSecuencialSuministros { get; set; }

    public int IdUnidadMedida { get; set; }

    public int CantidadDetalleEgresoSuministros { get; set; }

    public int EstadoDetalleEgresoSuministros { get; set; }

    public long IdEgresoSuministros { get; set; }

    public virtual EgresoSuministro IdEgresoSuministrosNavigation { get; set; } = null!;
}
