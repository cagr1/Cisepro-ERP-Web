using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class Banco
{
    public int IdBanco { get; set; }

    public string? CodigoBanco { get; set; }

    public string NombreBanco { get; set; } = null!;

    public string DireccionBanco { get; set; } = null!;

    public string OficialCreditoBanco { get; set; } = null!;

    public string TelefonoBanco { get; set; } = null!;

    public string FaxBanco { get; set; } = null!;

    public string EmailBanco { get; set; } = null!;

    public int EstadoBanco { get; set; }

    public virtual ICollection<CuentasBanco> CuentasBancos { get; set; } = new List<CuentasBanco>();
}
