using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class Software
{
    public int IdActivoFijo { get; set; }

    public string Detalle { get; set; } = null!;

    public string Version { get; set; } = null!;

    public string Provedor { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public int Estado { get; set; }

    public virtual ActivoFijoGeneral IdActivoFijoNavigation { get; set; } = null!;
}
