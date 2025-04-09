using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class ContratoCliente
{
    public long IdContrato { get; set; }

    public long IdClienteGeneral { get; set; }

    public decimal Valor { get; set; }

    public int Anio { get; set; }

    public DateTime Fecha { get; set; }

    public int Estado { get; set; }

    public virtual ClienteGeneral IdClienteGeneralNavigation { get; set; } = null!;
}
