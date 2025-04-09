using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class SubGrupoUbicacion
{
    public long IdSubGrupoUbicacion { get; set; }

    public string NombreSubGrupoUbicacion { get; set; } = null!;

    public DateTime FechaSubGrupoUbicacion { get; set; }

    public int EstadoSubGrupoUbicacion { get; set; }

    public long IdGrupoUbicacion { get; set; }

    public virtual GrupoUbicacion IdGrupoUbicacionNavigation { get; set; } = null!;
}
