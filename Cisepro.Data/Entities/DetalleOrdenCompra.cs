using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class DetalleOrdenCompra
{
    public long IdDetalleOrdenCompra { get; set; }

    public long IdSecuencialItem { get; set; }

    public string UmedidaDetalleOrdenCompra { get; set; } = null!;

    public int CantidadDetalleOrdenCompra { get; set; }

    public decimal ValoruDetalleOrdenCompra { get; set; }

    public decimal ValortDetalleOrdenCompra { get; set; }

    public string EstadoDetalleOrdenCompra { get; set; } = null!;

    public long IdOrdenCompra { get; set; }

    public virtual OrdenCompra IdOrdenCompraNavigation { get; set; } = null!;

    public virtual SecuencialItem IdSecuencialItemNavigation { get; set; } = null!;
}
