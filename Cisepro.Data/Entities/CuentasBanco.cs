using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class CuentasBanco
{
    public int IdCuentaBancos { get; set; }

    public string NumeroCuentaBancos { get; set; } = null!;

    public decimal MontoCuentaBancos { get; set; }

    public string TipoCuentaBancos { get; set; } = null!;

    public int EstadoCuentaBancos { get; set; }

    public int IdBanco { get; set; }

    public string? CodigoPlanCuentas { get; set; }

    public virtual Banco IdBancoNavigation { get; set; } = null!;
}
