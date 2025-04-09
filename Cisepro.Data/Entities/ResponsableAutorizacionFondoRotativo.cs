using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class ResponsableAutorizacionFondoRotativo
{
    public int IdResponsableAutoFr { get; set; }

    public string CiResponsableAutoFr { get; set; } = null!;

    public string NombreResponsableAutoFr { get; set; } = null!;

    public string ApellidoResponsableAutoFr { get; set; } = null!;

    public string CargoResponsableAutoFr { get; set; } = null!;

    public int EstadoResponsableAutoFr { get; set; }

    public int IdProvincias { get; set; }

    public int IdCiudad { get; set; }

    public int IdParroquias { get; set; }

    public virtual ICollection<SolicitudFondoRotativo> SolicitudFondoRotativos { get; set; } = new List<SolicitudFondoRotativo>();
}
