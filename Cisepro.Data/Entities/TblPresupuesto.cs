using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class TblPresupuesto
{
    public int IdPresupuesto { get; set; }

    public string Codigo { get; set; } = null!;

    public string Cuenta { get; set; } = null!;

    public byte Month { get; set; }

    public int Year { get; set; }

    public decimal Presupuesto { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public bool? Estado { get; set; }
}
