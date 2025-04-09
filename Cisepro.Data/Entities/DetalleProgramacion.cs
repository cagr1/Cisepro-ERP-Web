using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class DetalleProgramacion
{
    public int IdProgramacion { get; set; }

    public int IdPersonal { get; set; }

    public int IdPuesto { get; set; }

    public int IdHorario { get; set; }

    public int Estado { get; set; }

    public DateTime FechaDesde { get; set; }

    public DateTime FechaHasta { get; set; }

    public string? Detalle { get; set; }

    public int? Tipo { get; set; }

    public virtual Personal IdPersonalNavigation { get; set; } = null!;

    public virtual ProgramacionOperativo IdProgramacionNavigation { get; set; } = null!;

    public virtual SitiosTrabajo IdPuestoNavigation { get; set; } = null!;
}
