using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class Provincia
{
    public int IdProvincias { get; set; }

    public string NombreProvincias { get; set; } = null!;

    public int EstadoProvincias { get; set; }

    public int IdPaises { get; set; }

    public virtual ICollection<Ciudade> Ciudades { get; set; } = new List<Ciudade>();

    public virtual Paise IdPaisesNavigation { get; set; } = null!;

    public virtual ICollection<SitiosTrabajo> SitiosTrabajos { get; set; } = new List<SitiosTrabajo>();
}
