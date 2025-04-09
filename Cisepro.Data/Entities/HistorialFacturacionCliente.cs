using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class HistorialFacturacionCliente
{
    public long IdHistorialFacturacion { get; set; }

    public long IdClienteGeneral { get; set; }

    public long IdFacturaVenta { get; set; }

    public DateTime FechaHistorialFacturacion { get; set; }

    public string CodigoHistorialFacturacion { get; set; } = null!;

    public string CuentaHistorialFacturacion { get; set; } = null!;

    public int EstadoHistorialFacturacion { get; set; }
}
