using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class ComprobanteEgresoBanco
{
    public long IdComprobanteEgresoBancos { get; set; }

    public long NumeroComprobanteEgresobancos { get; set; }

    public DateTime FechaComprobanteEgresoBancos { get; set; }

    public string NumeroFacturaReceptor { get; set; } = null!;

    public string RucCiReceptor { get; set; } = null!;

    public string NombreReceptor { get; set; } = null!;

    public string Actividad { get; set; } = null!;

    public string Concepto { get; set; } = null!;

    public string TipoPagoComprobanteEgresoBancos { get; set; } = null!;

    public string RazonComprobanteEgresoBancos { get; set; } = null!;

    public decimal ValorComprobanteEgresoBancos { get; set; }

    public string NumeroCheque { get; set; } = null!;

    public int EstadoComprobanteEgresoBanco { get; set; }

    public int IdProvincias { get; set; }

    public int IdCiudad { get; set; }

    public int IdParroquias { get; set; }

    public int IdCentroCosto { get; set; }

    public int IdBanco { get; set; }

    public int IdCuentaBancos { get; set; }
}
