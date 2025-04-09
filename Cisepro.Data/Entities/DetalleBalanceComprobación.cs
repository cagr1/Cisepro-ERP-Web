using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class DetalleBalanceComprobación
{
    public long IdDetalle { get; set; }

    public DateTime Fecha { get; set; }

    public string Codigo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public long Referencia { get; set; }

    public decimal Debe { get; set; }

    public decimal Haber { get; set; }

    public decimal Deudor { get; set; }

    public decimal Acreedor { get; set; }

    public int DeudorAcreedor { get; set; }

    public long IdBalance { get; set; }

    public int Estado { get; set; }

    public virtual BalanceComprobacion IdBalanceNavigation { get; set; } = null!;
}
