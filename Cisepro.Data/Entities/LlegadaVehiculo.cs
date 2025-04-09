using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class LlegadaVehiculo
{
    public long IdLlegadaV { get; set; }

    public DateTime FechaLlegadaV { get; set; }

    public string HoraLlegadaV { get; set; } = null!;

    public int KmLlegadaV { get; set; }

    public int EstadoLlegadaV { get; set; }

    public virtual ICollection<ControlCombustible> ControlCombustibles { get; set; } = new List<ControlCombustible>();
}
