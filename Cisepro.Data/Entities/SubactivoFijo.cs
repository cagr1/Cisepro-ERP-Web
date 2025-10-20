using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class SubactivoFijo
{
    public int IdSubactivo { get; set; }

    public int IdTipoActivo { get; set; }

    public string Descripcion { get; set; } = null!;

    public int Estado { get; set; }
}
