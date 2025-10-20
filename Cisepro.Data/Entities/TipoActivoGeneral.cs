using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class TipoActivoGeneral
{
    public int IdTipoActivo { get; set; }

    public string Descripcion { get; set; } = null!;

    public int Estado { get; set; }
}
