using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class SalidaVehiculo
{
    public long IdSalidaV { get; set; }

    public DateTime FechaSalidaV { get; set; }

    public string HoraSalidaV { get; set; } = null!;

    public int KmSalidaV { get; set; }

    public int EstadoSalidaV { get; set; }

    public virtual ICollection<ControlCombustible> ControlCombustibles { get; set; } = new List<ControlCombustible>();
}
