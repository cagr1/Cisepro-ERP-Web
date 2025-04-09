using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class DetalleDepreciacion
{
    public int IdDepreciacion { get; set; }

    public DateTime Fecha { get; set; }

    public int NumDepreciacion { get; set; }

    public decimal ValorDepreciacion { get; set; }

    public decimal ValorResidualDepreciacion { get; set; }

    public int Estado { get; set; }

    public int? IdDepreciacionGeneral { get; set; }
}
