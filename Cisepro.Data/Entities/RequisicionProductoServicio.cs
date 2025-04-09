using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class RequisicionProductoServicio
{
    public long IdRequisicionPs { get; set; }

    public DateTime FechaRequisicionPs { get; set; }

    public int IdPersonal { get; set; }

    public string? PrioridadEntregaRequisicionPs { get; set; }

    public string TiempoEntregaRequisicionPs { get; set; } = null!;

    public int EstadoRequisicionPs { get; set; }

    public virtual ICollection<DetalleRequisicionProductoServicio> DetalleRequisicionProductoServicios { get; set; } = new List<DetalleRequisicionProductoServicio>();
}
