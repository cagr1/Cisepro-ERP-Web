using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class TblPrestamo
{
    public int IdPrestamo { get; set; }

    public DateTime Fecha { get; set; }

    public int Plazo { get; set; }

    public decimal Cuota { get; set; }

    public decimal MontoPrestamo { get; set; }

    public int IdPersonal { get; set; }
}
