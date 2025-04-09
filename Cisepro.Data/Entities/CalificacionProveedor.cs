using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class CalificacionProveedor
{
    public int IdCalificacionProveedor { get; set; }

    public DateTime FechaCalificacionProveedor { get; set; }

    public int RucActualizadoCalificacionProveedor { get; set; }

    public int EspecificacionProductoCalificacionProveedor { get; set; }

    public int PresentacionProductoCalificacionProveedor { get; set; }

    public int FormaPagoCalificacionProveedor { get; set; }

    public int TiempoEntregaCalificacionProveedor { get; set; }

    public int CertificacionesCalificacionProveedor { get; set; }

    public int TotalCalificacionProveedor { get; set; }

    public string AprobadoCalificacionProveedor { get; set; } = null!;

    public string ObservacionesCalificacionProveedor { get; set; } = null!;

    public int EstadoCalificacionProveedor { get; set; }

    public int IdProveedorGeneral { get; set; }

    public int IdPersonal { get; set; }
}
