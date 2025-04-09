using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class ContratoProyecto
{
    public int IdProyecto { get; set; }

    public string NombreProyecto { get; set; } = null!;

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFin { get; set; }

    public int? IdCliente { get; set; }

    public int Estado { get; set; }

    public string? Codigo { get; set; }
}
