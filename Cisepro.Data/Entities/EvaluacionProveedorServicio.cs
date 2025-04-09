using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class EvaluacionProveedorServicio
{
    public int IdEvaluacionProveedorServicios { get; set; }

    public DateTime FechaEvaluacionProveedorServicios { get; set; }

    public int InstalacionesEvaluacionProveedorServicios { get; set; }

    public int PersonalPropioEvaluacionProveedorServicios { get; set; }

    public int TransporteEvaluacionProveedorServicios { get; set; }

    public int TiempoRespuestaEvaluacionProveedorServicios { get; set; }

    public int CumplimientoTiemposEntregaEvaluacionProveedorServicios { get; set; }

    public int PrecioEvaluacionProveedorServicios { get; set; }

    public int CondicionesPagoEvaluacionProveedorServicios { get; set; }

    public int GarantiasEvaluacionProveedorServicios { get; set; }

    public int SoporteTecnicoEvaluacionProveedorServicios { get; set; }

    public int DocumentosActualizadosEvaluacionProveedorServicios { get; set; }

    public int TotalEvaluacionProveedorServicios { get; set; }

    public int EstadoEvaluacionProveedorServicios { get; set; }

    public int IdProveedorGeneral { get; set; }

    public int IdPersonal { get; set; }

    public virtual ProveedorGeneral IdProveedorGeneralNavigation { get; set; } = null!;
}
