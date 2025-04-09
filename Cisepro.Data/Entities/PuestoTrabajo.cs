using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class PuestoTrabajo
{
    public long IdPuesto { get; set; }

    public string Codigo { get; set; } = null!;

    public string Version { get; set; } = null!;

    public DateTime FechaEmision { get; set; }

    public string NombrePuesto { get; set; } = null!;

    public string Ubicacion { get; set; } = null!;

    public string Provincia { get; set; } = null!;

    public string Ciudad { get; set; } = null!;

    public string Parroquia { get; set; } = null!;

    public string CentroCosto { get; set; } = null!;

    public long IdClienteGeneral { get; set; }

    public string Cliente { get; set; } = null!;

    public string Observacion { get; set; } = null!;

    public string Realizado { get; set; } = null!;

    public string Revisado { get; set; } = null!;

    public string Aprobado { get; set; } = null!;

    public string Registrado { get; set; } = null!;

    public int Estado { get; set; }

    public string? IdPersonalSupervisor { get; set; }

    public virtual ClienteGeneral IdClienteGeneralNavigation { get; set; } = null!;
}
