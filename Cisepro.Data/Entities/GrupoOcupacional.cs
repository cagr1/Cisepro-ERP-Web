using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class GrupoOcupacional
{
    public int IdGrupoOcupacional { get; set; }

    public string Descripcion { get; set; } = null!;

    public int Estado { get; set; }

    public virtual ICollection<SerieOcupacional> SerieOcupacionals { get; set; } = new List<SerieOcupacional>();
}
