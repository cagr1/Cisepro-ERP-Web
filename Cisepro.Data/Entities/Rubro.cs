using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class Rubro
{
    public int IdRubro { get; set; }

    public string NombreRubro { get; set; } = null!;

    public decimal ValorRubro { get; set; }

    public int EstadoRubro { get; set; }
}
