using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class CategoriaItem
{
    public long IdCategoriaItem { get; set; }

    public string NombreCategoriaItem { get; set; } = null!;

    public DateTime FechaCategoriaItem { get; set; }

    public int EstadoCategoriaItem { get; set; }

    public virtual ICollection<GrupoItem> GrupoItems { get; set; } = new List<GrupoItem>();
}
