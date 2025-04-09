using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class CategoriaSuministro
{
    public int IdCategoriaSuministros { get; set; }

    public string NombreCategoriaSuministros { get; set; } = null!;

    public int EstadoCategoriaSuministros { get; set; }

    public int? CategoriaCat { get; set; }

    public virtual ICollection<GrupoSuministro> GrupoSuministros { get; set; } = new List<GrupoSuministro>();
}
