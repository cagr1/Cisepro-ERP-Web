using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class SubGrupoGeneral
{
    public int IdSubGrupo { get; set; }

    public int Codigo { get; set; }

    public string NombreSubGrupo { get; set; } = null!;

    public int IdGrupoSubGrupo { get; set; }

    public int EstadoSubGrupo { get; set; }

    public virtual GrupoGeneral IdGrupoSubGrupoNavigation { get; set; } = null!;

    public virtual ICollection<Secuencial> Secuencials { get; set; } = new List<Secuencial>();
}
