using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class EquipoPuestoSitioTrabajo
{
    public long IdEquipoPuntoTrabajo { get; set; }

    public string? Equipo { get; set; }

    public string? Marca { get; set; }

    public string? Calibre { get; set; }

    public string? Serie { get; set; }

    public string? Permiso { get; set; }

    public DateTime? Caduca { get; set; }

    public string? Origen { get; set; }

    public string? Tipo { get; set; }

    public int? Cantidad { get; set; }

    public string? EstadoEquipo { get; set; }

    public DateTime FechaAsignacion { get; set; }

    public DateTime FechaLevantamiento { get; set; }

    public string? Custodio { get; set; }

    public long? IdPunto { get; set; }

    public int? Estado { get; set; }

    public string? IdComprobante { get; set; }
}
