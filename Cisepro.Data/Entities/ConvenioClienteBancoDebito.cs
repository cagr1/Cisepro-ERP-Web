using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class ConvenioClienteBancoDebito
{
    public int IdConvenio { get; set; }

    public int IdClienteGeneral { get; set; }

    public string BancoConvenio { get; set; } = null!;

    public string TipoCuenta { get; set; } = null!;

    public string TipoDoc { get; set; } = null!;

    public string NumCuentaTarj { get; set; } = null!;

    public string NumCiRuc { get; set; } = null!;

    public string TitularCuenta { get; set; } = null!;

    public decimal Valor { get; set; }

    public int Estado { get; set; }

    public string? Observacion { get; set; }
}
