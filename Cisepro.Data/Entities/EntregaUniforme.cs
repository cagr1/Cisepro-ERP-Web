using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class EntregaUniforme
{
    public long IdUniformes { get; set; }

    public string CodigoUniformes { get; set; } = null!;

    public string VersionUniformes { get; set; } = null!;

    public DateTime FechaUniformes { get; set; }

    public string NombreUniformes { get; set; } = null!;

    public string CedulaUniformes { get; set; } = null!;

    public string ClienteUniformes { get; set; } = null!;

    public DateTime FechaIngresoUniformes { get; set; }

    public string RealizadoUniformes { get; set; } = null!;

    public string RevisadoUniformes { get; set; } = null!;

    public string AprobadoUniformes { get; set; } = null!;

    public string RegistradoUniformes { get; set; } = null!;

    public int EstadoUniformes { get; set; }

    public string ObservacionUniformes { get; set; } = null!;

    public virtual ICollection<DetalleUniforme> DetalleUniformes { get; set; } = new List<DetalleUniforme>();
}
