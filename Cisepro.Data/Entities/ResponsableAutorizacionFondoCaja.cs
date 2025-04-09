using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class ResponsableAutorizacionFondoCaja
{
    public int IdResponsableAutoCch { get; set; }

    public int IdPersonal { get; set; }

    public string NombresAutoCch { get; set; } = null!;

    public string CedulaAutoCch { get; set; } = null!;

    public int IdProvincia { get; set; }

    public int IdCiudad { get; set; }

    public int IdParroquias { get; set; }

    public int EstadoResponsableAutoCch { get; set; }

    public virtual ICollection<SolicitudCajaChica> SolicitudCajaChicas { get; set; } = new List<SolicitudCajaChica>();
}
