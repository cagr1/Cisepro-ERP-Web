using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class GrupoSuministro
{
    public int IdGrupoSuministros { get; set; }

    public string NombreGrupoSuministros { get; set; } = null!;

    public int EstadoGrupoSuministros { get; set; }

    public int IdCategoriaSuministros { get; set; }

    public int? CategoriaGr { get; set; }

    public int? GrupoGr { get; set; }

    public virtual CategoriaSuministro IdCategoriaSuministrosNavigation { get; set; } = null!;

    public virtual ICollection<SubgrupoSuministro> SubgrupoSuministros { get; set; } = new List<SubgrupoSuministro>();
}
