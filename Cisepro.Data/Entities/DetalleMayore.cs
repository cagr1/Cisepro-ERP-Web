using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class DetalleMayore
{
    public long IdDetalle { get; set; }

    public DateTime Fecha { get; set; }

    public string Descripcion { get; set; } = null!;

    public long Referencia { get; set; }

    public decimal Debe { get; set; }

    public decimal Haber { get; set; }

    public long IdMayor { get; set; }

    public int Estado { get; set; }

    public long IdAsiento { get; set; }

    public long? IdCorte { get; set; }

    public virtual MayorGeneral IdMayorNavigation { get; set; } = null!;
}
