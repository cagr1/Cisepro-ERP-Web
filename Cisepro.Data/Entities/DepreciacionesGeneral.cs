using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class DepreciacionesGeneral
{
    public int IdDepreciacion { get; set; }

    public int IdActivoFijo { get; set; }

    public decimal Porcentaje { get; set; }

    public string CuentaContable { get; set; } = null!;

    public int TopeDepreciaciones { get; set; }

    public int Estado { get; set; }

    public virtual ActivoFijoGeneral IdActivoFijoNavigation { get; set; } = null!;
}
