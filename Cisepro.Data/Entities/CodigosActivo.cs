using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class CodigosActivo
{
    public int IdCategoria { get; set; }

    public int CodigoCategoria { get; set; }

    public string Categoria { get; set; } = null!;

    public int EstadoCategoria { get; set; }

    public int IdGrupo { get; set; }

    public int CodigoGrupo { get; set; }

    public string Grupo { get; set; } = null!;

    public int EstadoGrupo { get; set; }

    public int CodigoSubgrupo { get; set; }

    public string Subgrupo { get; set; } = null!;

    public int EstadoSubGrupo { get; set; }

    public int CodigoSecuencial { get; set; }

    public string Secuencial { get; set; } = null!;

    public int EstadoSecuencial { get; set; }

    public string Depreciable { get; set; } = null!;
}
