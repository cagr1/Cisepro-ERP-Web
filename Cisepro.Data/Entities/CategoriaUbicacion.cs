using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class CategoriaUbicacion
{
    public long IdCategoriaUbicacion { get; set; }

    public string NombreCategoriaUbicacion { get; set; } = null!;

    public DateTime FechaCategoriaUbicacion { get; set; }

    public int EstadoCategoriaUbicacion { get; set; }

    public int FilasTotalCategoriaUbicacion { get; set; }

    public int FilasVaciasCategoriaUbicacion { get; set; }

    public int FilasUsadasCategoriaUbicacion { get; set; }

    public long IdBodega { get; set; }

    public virtual ICollection<GrupoUbicacion> GrupoUbicacions { get; set; } = new List<GrupoUbicacion>();

    public virtual Bodega IdBodegaNavigation { get; set; } = null!;
}
