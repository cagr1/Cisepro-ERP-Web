using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class GrupoUbicacion
{
    public long IdGrupoUbicacion { get; set; }

    public string NombreGrupoUbicacion { get; set; } = null!;

    public DateTime FechaGrupoUbicacion { get; set; }

    public int EstadoGrupoUbicacion { get; set; }

    public long IdCategoriaUbicacion { get; set; }

    public int CasillerosTotalCategoriaUbicacion { get; set; }

    public int CasillerosVaciasCategoriaUbicacion { get; set; }

    public int CasillerosUsadasCategoriaUbicacion { get; set; }

    public long IdBodega { get; set; }

    public virtual CategoriaUbicacion IdCategoriaUbicacionNavigation { get; set; } = null!;

    public virtual ICollection<SubGrupoUbicacion> SubGrupoUbicacions { get; set; } = new List<SubGrupoUbicacion>();
}
