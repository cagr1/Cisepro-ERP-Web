using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class PuntoSitioTrabajo
{
    public int IdPuntoSitio { get; set; }

    public int? IdSitio { get; set; }

    public string? Nombre { get; set; }

    public string? Ubicacion { get; set; }

    public int? Estado { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public string? Tipo { get; set; }
}
