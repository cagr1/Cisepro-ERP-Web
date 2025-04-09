using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class HorariosOperacion
{
    public int IdHorario { get; set; }

    public string Detalle { get; set; } = null!;

    public string? Lunes { get; set; }

    public string? Martes { get; set; }

    public string? Miercoles { get; set; }

    public string? Jueves { get; set; }

    public string? Viernes { get; set; }

    public string? Sabado { get; set; }

    public string? Domingo { get; set; }

    public decimal? HoraRegular { get; set; }

    public decimal? RecargoNocturno { get; set; }

    public decimal? HoraCincuenta { get; set; }

    public decimal? HoraCien { get; set; }

    public string? Observacion { get; set; }

    public string? Dias { get; set; }

    public int? Estado { get; set; }

    public string? Categoria { get; set; }

    public int? Tipo { get; set; }

    public decimal? TotalHoras { get; set; }

    public int? LuDi { get; set; }

    public int? MaDi { get; set; }

    public int? MiDi { get; set; }

    public int? JuDi { get; set; }

    public int? ViDi { get; set; }

    public int? SaDi { get; set; }

    public int? DoDi { get; set; }

    public virtual ICollection<AsignacionPersonal> AsignacionPersonals { get; set; } = new List<AsignacionPersonal>();
}
