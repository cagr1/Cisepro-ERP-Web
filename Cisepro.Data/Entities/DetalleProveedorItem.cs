using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class DetalleProveedorItem
{
    public long IdSecuencialItem { get; set; }

    public int IdProveedorGeneral { get; set; }

    public DateTime Fecha { get; set; }

    public int Estado { get; set; }

    public virtual ProveedorGeneral IdProveedorGeneralNavigation { get; set; } = null!;

    public virtual SecuencialItem IdSecuencialItemNavigation { get; set; } = null!;
}
