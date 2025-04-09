using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class TblPago
{
    public int IdPago { get; set; }

    public DateTime Fecha { get; set; }

    public int Periodo { get; set; }

    public decimal MontoPagado { get; set; }

    public int IdPrestamo { get; set; }
}
