using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class ComprobanteIngresoBanco
{
    public long IdComprobanteIngresoBancos { get; set; }

    public DateTime FechaComprobanteIngresoBancos { get; set; }

    public string NumeroFacturaVenta { get; set; } = null!;

    public long IdClienteGeneral { get; set; }

    public string ActividadComprobanteIngresoBancos { get; set; } = null!;

    public string ConceptoComprobanteIngresoBancos { get; set; } = null!;

    public string FormaPagoComprobanteIngresoBancos { get; set; } = null!;

    public string ObservacionesComprobanteIngresoBancos { get; set; } = null!;

    public decimal ValorComprobanteIngresoBancos { get; set; }

    public string? NumeroDepositoComprobanteIngresoBancos { get; set; }

    public int EstadoComprobanteIngresoBancos { get; set; }

    public int IdProvincia { get; set; }

    public int IdCiudad { get; set; }

    public int IdParroquias { get; set; }

    public int IdCentroCosto { get; set; }

    public int IdBanco { get; set; }

    public int IdCuentaBancos { get; set; }
}
