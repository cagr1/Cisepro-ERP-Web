using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class FacturasImpagasGeneral
{
    public long IdClienteGeneral { get; set; }

    public string? RucCiClienteGeneral { get; set; }

    public string? NompreRazonSocialClienteGeneral { get; set; }

    public string? ApellidoNombreComercialClienteGenral { get; set; }

    public long IdFacturaVenta { get; set; }

    public DateTime FechaEmisionFacturaVenta { get; set; }

    public decimal Total { get; set; }

    public decimal? Saldo { get; set; }

    public int? Mes { get; set; }

    public int? Anio { get; set; }

    public string TipoCuenta { get; set; } = null!;

    public string BancoConvenio { get; set; } = null!;

    public string NumCuentaTarj { get; set; } = null!;

    public string TipoDoc { get; set; } = null!;

    public string NumCiRuc { get; set; } = null!;

    public string TitularCuenta { get; set; } = null!;

    public string NumeroFacturaVenta { get; set; } = null!;

    public decimal Convenio { get; set; }
}
