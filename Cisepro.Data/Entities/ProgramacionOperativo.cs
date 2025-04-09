using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class ProgramacionOperativo
{
    public int IdProgramacion { get; set; }

    public int MesProgramacion { get; set; }

    public int AnioProgramacion { get; set; }

    public DateTime FechaDesde { get; set; }

    public DateTime FechaHasta { get; set; }

    public int Estado { get; set; }

    public virtual ICollection<AsignacionPersonal> AsignacionPersonals { get; set; } = new List<AsignacionPersonal>();
}
