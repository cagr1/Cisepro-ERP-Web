using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class CortesContable
{
    public long IdCorte { get; set; }

    public DateTime Fecha { get; set; }

    public DateTime FechaInicioCorte { get; set; }

    public DateTime FechaFinCorte { get; set; }

    public int Estado { get; set; }

    public int IdEmpresa { get; set; }
}
