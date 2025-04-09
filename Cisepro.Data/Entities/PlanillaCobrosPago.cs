using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class PlanillaCobrosPago
{
    public int IdPlanilla { get; set; }

    public string NumComprobante { get; set; } = null!;

    public string Beneficiario { get; set; } = null!;

    public string TipoServicio { get; set; } = null!;

    public DateTime FechaProceso { get; set; }

    public DateTime FechaVence { get; set; }

    public string TipoCuenta { get; set; } = null!;

    public string NumCuenta { get; set; } = null!;

    public string Referencia { get; set; } = null!;

    public string TipoNegociacion { get; set; } = null!;

    public int CantCuentas { get; set; }

    public decimal TotalCuentas { get; set; }

    public int Estado { get; set; }

    public string? Observacion { get; set; }

    public virtual ICollection<DetallePlanillaCobrosPago> DetallePlanillaCobrosPagos { get; set; } = new List<DetallePlanillaCobrosPago>();
}
