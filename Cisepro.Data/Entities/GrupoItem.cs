using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class GrupoItem
{
    public long IdGrupoItem { get; set; }

    public string CodigoGrupoItem { get; set; } = null!;

    public string NombreGrupoItem { get; set; } = null!;

    public DateTime FechaGrupoItem { get; set; }

    public int EstadoGrupoItem { get; set; }

    public long IdCategoriaItem { get; set; }

    public virtual CategoriaItem IdCategoriaItemNavigation { get; set; } = null!;

    public virtual ICollection<SubGrupoItem> SubGrupoItems { get; set; } = new List<SubGrupoItem>();
}
