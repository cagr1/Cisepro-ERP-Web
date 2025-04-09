using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class OrdenTecnicaSupervision
{
    public long IdOrden { get; set; }

    public DateTime FechaRegistro { get; set; }

    public DateTime FechaOrden { get; set; }

    public string Cedularuc { get; set; } = null!;

    public string ApellidosNombres { get; set; } = null!;

    public long IdClienteGeneral { get; set; }

    public int Estado { get; set; }

    public string DetalleNotificacion { get; set; } = null!;

    public int Tipo { get; set; }

    public DateTime? FechaRevision { get; set; }

    public DateTime? FechaPendiente { get; set; }

    public DateTime? FechaRealizado { get; set; }

    public int? IdSeg { get; set; }
}
