using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class SubGrupoItem
{
    public long IdSubGrupoItem { get; set; }

    public string CodigoSubGrupoItem { get; set; } = null!;

    public string NombreSubGrupoItem { get; set; } = null!;

    public DateTime FechaSubGrupoItem { get; set; }

    public int EstadoSubGrupoItem { get; set; }

    public long IdGrupoItem { get; set; }

    public virtual GrupoItem IdGrupoItemNavigation { get; set; } = null!;

    public virtual ICollection<SecuencialItem> SecuencialItems { get; set; } = new List<SecuencialItem>();
}
