using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class DetalleVacacione
{
    public int IdDetalle { get; set; }

    public int Num { get; set; }

    public int IdPersonal { get; set; }

    public DateTime FechaRegistro { get; set; }

    public DateTime FechaSalida { get; set; }

    public DateTime FechaEntrada { get; set; }

    public int Ndiasv { get; set; }

    public int Ndiasp { get; set; }

    public string Periodo { get; set; } = null!;

    public DateTime FechaFirma { get; set; }

    public int IdPermiso { get; set; }

    public string? Obs { get; set; }

    public int? Estado { get; set; }

    public decimal ValorCobro { get; set; }
}
