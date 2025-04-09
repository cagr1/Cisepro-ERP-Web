using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class FacturaVentum
{
    public long IdFacturaVenta { get; set; }

    public int IdEmpresaGeneral { get; set; }

    public string NumeroFacturaVenta { get; set; } = null!;

    public DateTime FechaEmisionFacturaVenta { get; set; }

    public string GuiaRemisionFacturaVenta { get; set; } = null!;

    public long IdClienteGeneral { get; set; }

    public string TipoPagoFacturaVenta { get; set; } = null!;

    public string? ConceptoFacturaVenta { get; set; }

    public string ObservacionesFacturaVenta { get; set; } = null!;

    public decimal Subtotal12FacturaVenta { get; set; }

    public decimal Subtotal0FacturaVenta { get; set; }

    public decimal DescuentoFacturaVenta { get; set; }

    public decimal SubtotalFacturaVenta { get; set; }

    public int? PorcentajeIvaFacturaVenta { get; set; }

    public decimal IvaFacturaVenta { get; set; }

    public decimal TotalFacturaVenta { get; set; }

    public int EstadoFacturaVenta { get; set; }

    public DateTime? PlazoFacturaVenta { get; set; }

    public virtual ICollection<DetalleFacturaVentum> DetalleFacturaVenta { get; set; } = new List<DetalleFacturaVentum>();
}
