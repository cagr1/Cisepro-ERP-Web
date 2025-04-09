using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class Categorium
{
    public int IdCategoria { get; set; }

    public int Codigo { get; set; }

    public string NombreCategoria { get; set; } = null!;

    public int EstadoCategoria { get; set; }

    public virtual ICollection<GrupoGeneral> GrupoGenerals { get; set; } = new List<GrupoGeneral>();
}
