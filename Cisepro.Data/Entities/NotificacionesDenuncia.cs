using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class NotificacionesDenuncia
{
    public long IdNotificacion { get; set; }

    public long NumNotificacion { get; set; }

    public DateTime FechaRegistro { get; set; }

    public DateTime FechaNotificacion { get; set; }

    public string Cedularuc { get; set; } = null!;

    public string ApellidosNombres { get; set; } = null!;

    public string DetalleNotificacion { get; set; } = null!;

    public int Estado { get; set; }
}
