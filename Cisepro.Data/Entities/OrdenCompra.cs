using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class OrdenCompra
{
    public long IdOrdenCompra { get; set; }

    public DateTime FechaOrdenCompra { get; set; }

    public int IdProveedorGeneral { get; set; }

    public string FormaPagoOrdenCompra { get; set; } = null!;

    public string TipoPagoOrdenCompra { get; set; } = null!;

    public string ObservacionesOrdenCompra { get; set; } = null!;

    public decimal Subtotal12OrdenCompra { get; set; }

    public decimal Subtotal0OrdenCompra { get; set; }

    public decimal DescuentoOrdenCompra { get; set; }

    public decimal IvaOrdenCompra { get; set; }

    public decimal TotalOrdenCompra { get; set; }

    public int EstadoOrdenCompra { get; set; }

    public string? IdRequisicion { get; set; }

    public virtual ICollection<DetalleOrdenCompra> DetalleOrdenCompras { get; set; } = new List<DetalleOrdenCompra>();

    public virtual ProveedorGeneral IdProveedorGeneralNavigation { get; set; } = null!;
}
