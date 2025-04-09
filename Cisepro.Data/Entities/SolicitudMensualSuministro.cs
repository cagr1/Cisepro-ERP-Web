using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class SolicitudMensualSuministro
{
    public long IdSolicitudSuministros { get; set; }

    public long NumeroSolicitudSuministros { get; set; }

    public string MesSolicitudSuministros { get; set; } = null!;

    public DateTime FechaSolicitudSuministros { get; set; }

    public int IdProvincia { get; set; }

    public int IdCiudad { get; set; }

    public int IdParroquia { get; set; }

    public int IdCentroCosto { get; set; }

    public virtual ICollection<DetalleSolicitudSuministro> DetalleSolicitudSuministros { get; set; } = new List<DetalleSolicitudSuministro>();
}
