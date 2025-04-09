using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class LiquidacionCompra
{
    public long IdLiquidacionCompras { get; set; }

    public long NumeroLiquidacionCompras { get; set; }

    public string NumAutoSriLiquidacionCompra { get; set; } = null!;

    public DateTime FechaAutoSriLiquidacionCompra { get; set; }

    public DateTime FechaEmisionLiquidacionCompra { get; set; }

    public int IdProveedorGeneral { get; set; }

    public decimal Subtotal12LiquidacionCompra { get; set; }

    public decimal Subtotal0LiquidacionCompra { get; set; }

    public decimal SubtotalLiquidacionCompra { get; set; }

    public decimal IvaLiquidacionCompra { get; set; }

    public decimal TotalLiquidacionCompra { get; set; }

    public int EstadoLiquidacionCompra { get; set; }

    public string? ObservacionComprobanteCompra { get; set; }

    public long? IdComprobanteCompra { get; set; }

    public virtual ICollection<DetalleLiquidacionCompra> DetalleLiquidacionCompras { get; set; } = new List<DetalleLiquidacionCompra>();
}
