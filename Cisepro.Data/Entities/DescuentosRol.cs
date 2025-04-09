using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class DescuentosRol
{
    public int IdRegistro { get; set; }

    public int IdPersonal { get; set; }

    public DateTime Fecha { get; set; }

    public int Estado { get; set; }

    public int Procesado { get; set; }

    public int MesRol { get; set; }

    public int AnioRol { get; set; }

    public int? IdRol { get; set; }

    public int Tipo { get; set; }

    public string? Observacion { get; set; }

    public DateTime FechaRegistro { get; set; }

    public decimal Valor { get; set; }

    public string? Tipox { get; set; }

    public int IdProg { get; set; }

    public string? Anual { get; set; }
}
