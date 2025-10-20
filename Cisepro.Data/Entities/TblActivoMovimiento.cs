using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class TblActivoMovimiento
{
    public int IdActivoMovimiento { get; set; }

    public int IdActivoFijo { get; set; }

    public long IdDetalleKardex { get; set; }

    public DateTime FechaMovimiento { get; set; }

    public string TipoMovimiento { get; set; } = null!;

    public string? Observacion { get; set; }
}
