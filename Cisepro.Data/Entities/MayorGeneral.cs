using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class MayorGeneral
{
    public long IdMayor { get; set; }

    public string Codigo { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public string Observacion { get; set; } = null!;

    public decimal TotalDebe { get; set; }

    public decimal TotalHaber { get; set; }

    public decimal TotalDeudor { get; set; }

    public decimal TotalAcreedor { get; set; }

    public int DeudorAcreedor { get; set; }

    public int Estado { get; set; }

    public int IdEmpresa { get; set; }

    public string CodigoPadre { get; set; } = null!;

    public virtual ICollection<DetalleMayore> DetalleMayores { get; set; } = new List<DetalleMayore>();
}
