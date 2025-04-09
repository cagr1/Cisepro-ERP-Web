using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class DetalleSolicitudSuministro
{
    public long IdDetalleSolicitudSuministros { get; set; }

    public int IdSecuencialSuministros { get; set; }

    public int CantidadDetalleSolicitudSuministros { get; set; }

    public int EstadoDetalleSolicitudSuministros { get; set; }

    public long IdSolicitudSuministros { get; set; }

    public virtual SolicitudMensualSuministro IdSolicitudSuministrosNavigation { get; set; } = null!;
}
