using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class SolicitudFondoRotativo
{
    public long IdSolicitudFr { get; set; }

    public long NumeroSolicitudFr { get; set; }

    public DateTime FechaSolicitudFr { get; set; }

    public decimal ValorSolicitudFr { get; set; }

    public string DetalleSolicitudFr { get; set; } = null!;

    public string CodDebe { get; set; } = null!;

    public string CodHaber { get; set; } = null!;

    public int EstadoSolicitudFr { get; set; }

    public int IdFondoRotativo { get; set; }

    public int IdResponsableAutoFr { get; set; }

    public int IdCentroCosto { get; set; }

    public int IdGastosFr { get; set; }

    public int IdPersonal { get; set; }

    public int IdProvincias { get; set; }

    public int IdCiudad { get; set; }

    public int IdParroquias { get; set; }

    public int IdParametroDocumentos { get; set; }

    public int? IdLiquidacionFr { get; set; }

    public string? TipoDocumento { get; set; }

    public string? IdDocumento { get; set; }

    public string? NumeroDocumento { get; set; }

    public string? NombreRazonSocialClienteGeneral { get; set; }

    public virtual FondoRotativo IdFondoRotativoNavigation { get; set; } = null!;

    public virtual ResponsableAutorizacionFondoRotativo IdResponsableAutoFrNavigation { get; set; } = null!;
}
