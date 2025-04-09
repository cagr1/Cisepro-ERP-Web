using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class DetalleRequisicionProductoServicio
{
    public long IdDetalleRequisicionPs { get; set; }

    public long IdSecuencialItem { get; set; }

    public string UmedidaDetalleRequisicionPs { get; set; } = null!;

    public int CantidadDetalleRequisicionPs { get; set; }

    public string EspecificacionDetalleRequisicionPs { get; set; } = null!;

    public string ObservacionesDetalleRequisicionPs { get; set; } = null!;

    public int EstadoDetalleRequisicionPs { get; set; }

    public long IdRequisicionPs { get; set; }

    public virtual RequisicionProductoServicio IdRequisicionPsNavigation { get; set; } = null!;
}
