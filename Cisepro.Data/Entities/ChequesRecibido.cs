using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class ChequesRecibido
{
    public long IdChequeRecibido { get; set; }

    public DateTime? FechaEmisionChequeRecibido { get; set; }

    public string TitularChequeRecibido { get; set; } = null!;

    public string? BancoChequeRecibido { get; set; }

    public string CtaCteChequeRecibido { get; set; } = null!;

    public int NumeroChequeRecibido { get; set; }

    public decimal ValorChequeRecibido { get; set; }

    public int EstadoChequeRecibido { get; set; }

    public long? IdComprobanteIngresoBancos { get; set; }

    public int? IdClienteGeneral { get; set; }
}
