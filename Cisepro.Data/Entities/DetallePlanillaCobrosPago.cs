using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class DetallePlanillaCobrosPago
{
    public int IdPlanilla { get; set; }

    public string TipoDoc { get; set; } = null!;

    public string CiRuc { get; set; } = null!;

    public string Ordenante { get; set; } = null!;

    public string Contrato { get; set; } = null!;

    public string FormaPago { get; set; } = null!;

    public string Banco { get; set; } = null!;

    public string TipoCuenta { get; set; } = null!;

    public string NumCuenta { get; set; } = null!;

    public decimal Valor { get; set; }

    public string Submotivo { get; set; } = null!;

    public decimal BaseImponible { get; set; }

    public decimal IvaCausado { get; set; }

    public int PRetenIva { get; set; }

    public decimal ValorReten { get; set; }

    public int? Procesado { get; set; }

    public string Proces { get; set; } = null!;

    public int IdDetalle { get; set; }

    public DateTime? FechaProceso { get; set; }

    public string IdFactura { get; set; } = null!;

    public string NumFactura { get; set; } = null!;

    public string IdCliente { get; set; } = null!;

    public string Cliente { get; set; } = null!;

    public virtual PlanillaCobrosPago IdPlanillaNavigation { get; set; } = null!;
}
