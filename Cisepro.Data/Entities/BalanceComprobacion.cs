using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class BalanceComprobacion
{
    public long IdBalance { get; set; }

    public string Descripcion { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public DateTime FechaInicioCorte { get; set; }

    public DateTime FechaFinCorte { get; set; }

    public decimal TotalDebe { get; set; }

    public decimal TotalHaber { get; set; }

    public decimal TotalDeudor { get; set; }

    public decimal TotalAcreedor { get; set; }

    public int Estado { get; set; }

    public long IdCorte { get; set; }

    public int IdEmpresa { get; set; }

    public virtual ICollection<DetalleBalanceComprobación> DetalleBalanceComprobacións { get; set; } = new List<DetalleBalanceComprobación>();
}
