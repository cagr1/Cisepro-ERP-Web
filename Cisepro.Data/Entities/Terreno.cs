using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class Terreno
{
    public int IdActivoFijo { get; set; }

    public int Medida { get; set; }

    public string Ubicacion { get; set; } = null!;

    public string EstadoTerreno { get; set; } = null!;

    public int Estado { get; set; }

    public virtual ActivoFijoGeneral IdActivoFijoNavigation { get; set; } = null!;
}
