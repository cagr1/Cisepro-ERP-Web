using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class SolicitudCajaChica
{
    public long IdSolictudCch { get; set; }

    public long NumeroSolicitudCch { get; set; }

    public DateTime FechaSolicitudCch { get; set; }

    public decimal ValorSolicitudCch { get; set; }

    public string DetalleSolicitudCch { get; set; } = null!;

    public string CodDebeCch { get; set; } = null!;

    public string CodHaberCch { get; set; } = null!;

    public int EstadoSolicitudCch { get; set; }

    public int IdCajaChica { get; set; }

    public int IdResponsableAutoCch { get; set; }

    public int IdCentroCosto { get; set; }

    public int IdGastoCajaCh { get; set; }

    public int IdProvincia { get; set; }

    public int IdCiudad { get; set; }

    public int IdParroquias { get; set; }

    public string NombresRecibe { get; set; } = null!;

    public string CedulaRecibe { get; set; } = null!;

    public string NombresEntrega { get; set; } = null!;

    public string CedulaEntrega { get; set; } = null!;

    public int IdParametroDocumentos { get; set; }

    public string NroParametroDocumentos { get; set; } = null!;

    public int IdPersonal { get; set; }

    public int IdLiquidacion { get; set; }

    public long? IdComprobante { get; set; }

    public string? NombreRazonSocialClienteGeneral { get; set; }

    public virtual CajaChica IdCajaChicaNavigation { get; set; } = null!;

    public virtual ResponsableAutorizacionFondoCaja IdResponsableAutoCchNavigation { get; set; } = null!;
}
