using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class EvaluacionProveedorMateriale
{
    public int IdEvaluacionProveedorMateriales { get; set; }

    public DateTime FechaEvaluacionProveedorMateriales { get; set; }

    public int CapacidadProvisionProveedorMateriales { get; set; }

    public int PuntosEntregaEvaluacionProveedorMateriales { get; set; }

    public int TiemposEntregaEvaluacionProveedorMateriales { get; set; }

    public int PrecioEvaluacionProveedorMateriales { get; set; }

    public int CondicionesPagoEvaluacionProveedorMateriales { get; set; }

    public int GarantiasEvaluacionProveedorMateriales { get; set; }

    public int SoporteTecnicoEvaluacionProveedorMateriales { get; set; }

    public int ServiciosAsociadosEvaluacionProveedorMateriales { get; set; }

    public int CalidadMaterialEvaluacionProveedorMateriales { get; set; }

    public int TotalEvaluacionProveedorMateriales { get; set; }

    public int EstadoEvaluacionProveedorMateriales { get; set; }

    public int IdProveedorGeneral { get; set; }

    public int IdPersonal { get; set; }

    public virtual ProveedorGeneral IdProveedorGeneralNavigation { get; set; } = null!;
}
