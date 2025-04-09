using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class InventarioItem
{
    public long IdInventarioItem { get; set; }

    public string NombreInventarioItem { get; set; } = null!;

    public DateTime FechaInventarioItem { get; set; }

    public int EstadoInventarioItem { get; set; }

    public long IdBodega { get; set; }

    public virtual Bodega IdBodegaNavigation { get; set; } = null!;
}
