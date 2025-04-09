using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class DetalleUbicacion
{
    public long IdKardex { get; set; }

    public long IdSubGrupoUbicacion { get; set; }

    public DateTime Fecha { get; set; }

    public int Estado { get; set; }

    public virtual Kardex IdKardexNavigation { get; set; } = null!;

    public virtual SubGrupoUbicacion IdSubGrupoUbicacionNavigation { get; set; } = null!;
}
