using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class ActivoFijoMantenimiento
{
    public long IdMantenimiento { get; set; }

    public DateTime Fecha { get; set; }

    public decimal Costo { get; set; }

    public string NombreTallerTecnico { get; set; } = null!;

    public string DetalleTrabajo { get; set; } = null!;

    public string Autorizo { get; set; } = null!;

    public DateTime FechaNuevoMantenimiento { get; set; }

    public int Estado { get; set; }

    public int IdPersonal { get; set; }

    public long? Asiento { get; set; }
}
