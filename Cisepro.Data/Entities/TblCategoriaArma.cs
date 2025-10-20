using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class TblCategoriaArma
{
    public int IdCategoriaArma { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool Activo { get; set; }
}
