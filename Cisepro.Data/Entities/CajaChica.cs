using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class CajaChica
{
    public int IdCajaChica { get; set; }

    public string DetalleCajaChica { get; set; } = null!;

    public decimal MontoCajaChica { get; set; }

    public decimal ValorGasto { get; set; }

    public string CtaContable { get; set; } = null!;

    public int TipoCta { get; set; }

    public int NivelCta { get; set; }

    public int EstadoCajaChica { get; set; }

    public int IdCentroCosto { get; set; }

    public int IdProvincias { get; set; }

    public int IdCiudad { get; set; }

    public int IdParroquias { get; set; }

    public int IdPersonal { get; set; }

    public virtual CentroCosto IdCentroCostoNavigation { get; set; } = null!;

    public virtual ICollection<SolicitudCajaChica> SolicitudCajaChicas { get; set; } = new List<SolicitudCajaChica>();
}
