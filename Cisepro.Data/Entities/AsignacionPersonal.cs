using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class AsignacionPersonal
{
    public int IdAsignacion { get; set; }

    public int IdPersonal { get; set; }

    public int IdPuesto { get; set; }

    public int IdHorario { get; set; }

    public int Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public int? IdProgramacion { get; set; }

    public DateTime Fecha { get; set; }

    public string? C50 { get; set; }

    public string? C51 { get; set; }

    public string? C40 { get; set; }

    public string? C41 { get; set; }

    public string? Entrada { get; set; }

    public string? Salida { get; set; }

    public string? Tipo { get; set; }

    public int? Cantrep { get; set; }

    public string? Observacion { get; set; }

    public string? Report { get; set; }

    public int IdUser { get; set; }

    public string? Horario { get; set; }

    public int? FldContarMultas { get; set; }

    public virtual HorariosOperacion IdHorarioNavigation { get; set; } = null!;

    public virtual Personal IdPersonalNavigation { get; set; } = null!;

    public virtual ProgramacionOperativo? IdProgramacionNavigation { get; set; }

    public virtual SitiosTrabajo IdPuestoNavigation { get; set; } = null!;
}
