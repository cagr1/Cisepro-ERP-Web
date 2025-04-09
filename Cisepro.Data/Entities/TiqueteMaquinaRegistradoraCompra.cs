using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class TiqueteMaquinaRegistradoraCompra
{
    public long IdTiqueteMaquina { get; set; }

    public int IdProveedorGeneral { get; set; }

    public string NumeroTiqueteMaquina { get; set; } = null!;

    public string NumAutoSriTiqueteMaquina { get; set; } = null!;

    public DateTime FechaEmisionTiqueteMaquina { get; set; }

    public decimal SubtotalTiqueteMaquina { get; set; }

    public decimal IvaTiqueteMaquina { get; set; }

    public decimal TotalTiqueteMaquina { get; set; }

    public int EstadoTiqueteMaquina { get; set; }
}
