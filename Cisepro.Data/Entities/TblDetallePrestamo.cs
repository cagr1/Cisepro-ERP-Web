using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class TblDetallePrestamo
{
    public int IdDetallePrestamo { get; set; }

    public int Periodo { get; set; }

    public DateTime Fecha { get; set; }

    public decimal Cuota { get; set; }

    public decimal CapitalPagado { get; set; }

    public decimal CapitalRestante { get; set; }

    public int IdPersonal { get; set; }

    public int IdPrestamo { get; set; }
}
