using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class Ciudade
{
    public int IdCiudad { get; set; }

    public string NombreCiudades { get; set; } = null!;

    public int EstadoCiudades { get; set; }

    public int IdProvincias { get; set; }

    public virtual Provincia IdProvinciasNavigation { get; set; } = null!;

    public virtual ICollection<Parroquia> Parroquia { get; set; } = new List<Parroquia>();
}
