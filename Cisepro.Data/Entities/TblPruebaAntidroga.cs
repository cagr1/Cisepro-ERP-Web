using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class TblPruebaAntidroga
{
    public int IdControl { get; set; }

    public DateTime FechaPrueba { get; set; }

    public string? Observaciones { get; set; }

    public int IdPersonal { get; set; }

    public int IdResponsable { get; set; }

    public string? Nombres { get; set; }

    public string? Area { get; set; }

    public string? Cargo { get; set; }
}
