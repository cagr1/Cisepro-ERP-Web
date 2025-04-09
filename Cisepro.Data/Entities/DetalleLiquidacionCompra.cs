using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class DetalleLiquidacionCompra
{
    public long IdDetalleLiquidacionCompras { get; set; }

    public int CantidadDetalleLiquidacionCompras { get; set; }

    public int IdSecuencialItem { get; set; }

    public decimal ValoruDetalleLiquidacionCompras { get; set; }

    public decimal ValortDetalleLiquidacionCompras { get; set; }

    public int EstadoDetalleLiquidacionCompras { get; set; }

    public long IdLiquidacionCompras { get; set; }

    public virtual LiquidacionCompra IdLiquidacionComprasNavigation { get; set; } = null!;
}
