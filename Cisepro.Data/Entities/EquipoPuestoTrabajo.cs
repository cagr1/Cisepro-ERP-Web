using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class EquipoPuestoTrabajo
{
    public long IdEquipoPuestoTrabajo { get; set; }

    public string Equipo { get; set; } = null!;

    public string Marca { get; set; } = null!;

    public string Calibre { get; set; } = null!;

    public string Serie { get; set; } = null!;

    public string Permiso { get; set; } = null!;

    public DateTime Caduca { get; set; }

    public string Origen { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public int Cantidad { get; set; }

    public int Estado { get; set; }

    public string EstadoEquipo { get; set; } = null!;

    public string Supervisor { get; set; } = null!;

    public DateTime FechaLevantamiento { get; set; }

    public string Custodio { get; set; } = null!;

    public long IdPuesto { get; set; }
}
