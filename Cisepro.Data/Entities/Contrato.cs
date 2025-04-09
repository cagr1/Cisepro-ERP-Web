using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class Contrato
{
    public long IdContrato { get; set; }

    public long NroContrato { get; set; }

    public DateTime FechaInicialContrato { get; set; }

    public DateTime FechaVencimientoContrato { get; set; }

    public string PeriodoContrato { get; set; } = null!;

    public int TipoContrato { get; set; }

    public string EstadoContrato { get; set; } = null!;

    public int IdPersonal { get; set; }

    public int Estado { get; set; }

    public int Iess { get; set; }

    public DateTime FechaAfiliacion { get; set; }

    public int ReservaRol { get; set; }

    public int XiiiRol { get; set; }

    public int XivRol { get; set; }

    public string? Observacion { get; set; }

    public decimal? RecExt { get; set; }

    public int AcumFonRes { get; set; }

    public int DescSeg { get; set; }

    public int? CobraQuince { get; set; }

    public int? Extsal { get; set; }

    public int IdProyecto { get; set; }

    public virtual Personal IdPersonalNavigation { get; set; } = null!;
}
