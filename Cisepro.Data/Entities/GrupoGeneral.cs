using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class GrupoGeneral
{
    public int IdGrupo { get; set; }

    public int Codigo { get; set; }

    public string NombreGrupo { get; set; } = null!;

    public int IdCategoriaGrupo { get; set; }

    public int EstadoGrupo { get; set; }

    public virtual Categorium IdCategoriaGrupoNavigation { get; set; } = null!;

    public virtual ICollection<SubGrupoGeneral> SubGrupoGenerals { get; set; } = new List<SubGrupoGeneral>();
}
