using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class SerieOcupacional
{
    public int IdSerieOcupacional { get; set; }

    public string Descripcion { get; set; } = null!;

    public int Estado { get; set; }

    public int IdGrupoOcupacional { get; set; }

    public virtual ICollection<CargoOcupacional> CargoOcupacionals { get; set; } = new List<CargoOcupacional>();

    public virtual GrupoOcupacional IdGrupoOcupacionalNavigation { get; set; } = null!;
}
