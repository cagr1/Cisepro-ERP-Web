using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class EgresoSuministro
{
    public long IdEgresoSuministros { get; set; }

    public DateTime FechaEgresoSuministros { get; set; }

    public int EstadoEgresoSuministros { get; set; }

    public int IdProvincia { get; set; }

    public int IdCuidad { get; set; }

    public int IdParroquia { get; set; }

    public int IdCentroCosto { get; set; }

    public int IdPersonal { get; set; }

    public virtual ICollection<DetalleEgresoSuministro> DetalleEgresoSuministros { get; set; } = new List<DetalleEgresoSuministro>();
}
