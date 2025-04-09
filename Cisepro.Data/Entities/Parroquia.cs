using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class Parroquia
{
    public int IdParroquias { get; set; }

    public string NombreParroquias { get; set; } = null!;

    public int EstadoParroquias { get; set; }

    public int IdCiudad { get; set; }

    public virtual Ciudade IdCiudadNavigation { get; set; } = null!;

    public virtual ICollection<SitiosTrabajo> SitiosTrabajos { get; set; } = new List<SitiosTrabajo>();
}
