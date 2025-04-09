using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class EntregaEpp
{
    public long IdEpp { get; set; }

    public string CodigoEpp { get; set; } = null!;

    public string VersionEpp { get; set; } = null!;

    public DateTime FechaEpp { get; set; }

    public string NombreEpp { get; set; } = null!;

    public string CedulaEpp { get; set; } = null!;

    public string ClienteEpp { get; set; } = null!;

    public DateTime FechaIngresoEpp { get; set; }

    public string RealizadoEpp { get; set; } = null!;

    public string RevisadoEpp { get; set; } = null!;

    public string AprobadoEpp { get; set; } = null!;

    public string RegistradoEpp { get; set; } = null!;

    public int EstadoEpp { get; set; }

    public string ObservacionEpp { get; set; } = null!;

    public virtual ICollection<DetalleEpp> DetalleEpps { get; set; } = new List<DetalleEpp>();
}
