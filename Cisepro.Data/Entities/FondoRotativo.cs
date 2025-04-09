using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class FondoRotativo
{
    public int IdFondoRotativo { get; set; }

    public string DetalleFondoRotativo { get; set; } = null!;

    public decimal MontoFondoRotativo { get; set; }

    public string CtaContable { get; set; } = null!;

    public int TipoCta { get; set; }

    public int NivelCta { get; set; }

    public int EstadoFondoRotativo { get; set; }

    public int IdProvincias { get; set; }

    public int IdCiudad { get; set; }

    public int? IdParroquias { get; set; }

    public int? IdCentroCosto { get; set; }

    public int? IdPersonal { get; set; }

    public virtual CentroCosto? IdCentroCostoNavigation { get; set; }

    public virtual ICollection<SolicitudFondoRotativo> SolicitudFondoRotativos { get; set; } = new List<SolicitudFondoRotativo>();
}
