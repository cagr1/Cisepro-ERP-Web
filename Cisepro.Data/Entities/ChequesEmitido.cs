using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class ChequesEmitido
{
    public long IdChequeEmitido { get; set; }

    public DateTime FechaEmisionChequeEmitido { get; set; }

    public string BancoChequeEmitido { get; set; } = null!;

    public string CtaCteChequeEmitido { get; set; } = null!;

    public string NumeroChequeEmitido { get; set; } = null!;

    public string BeneficiarioChequeEmitido { get; set; } = null!;

    public decimal ValorChequeEmitido { get; set; }

    public int EstadoChequeEmitido { get; set; }

    public DateTime? FechaCobroChequeEmitido { get; set; }

    public long IdComprobanteEgresoBancos { get; set; }
}
