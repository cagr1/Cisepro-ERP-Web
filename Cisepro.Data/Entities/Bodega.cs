using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class Bodega
{
    public long IdBodega { get; set; }

    public string NombreBodega { get; set; } = null!;

    public string TelefonoBodega { get; set; } = null!;

    public string ObservacionBodega { get; set; } = null!;

    public DateTime FechaCreacionBodega { get; set; }

    public int IdPersonalBodega { get; set; }

    public int IdSitioTrabajoBodega { get; set; }

    public int EstadoBodega { get; set; }

    public virtual ICollection<CategoriaUbicacion> CategoriaUbicacions { get; set; } = new List<CategoriaUbicacion>();

    public virtual Personal IdPersonalBodegaNavigation { get; set; } = null!;

    public virtual SitiosTrabajo IdSitioTrabajoBodegaNavigation { get; set; } = null!;

    public virtual ICollection<InventarioItem> InventarioItems { get; set; } = new List<InventarioItem>();
}
