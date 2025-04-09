using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class ControlUniforme
{
    public long IdControl { get; set; }

    public int IdPersonal { get; set; }

    public string IdComprobante { get; set; } = null!;

    public int CantidadArticulos { get; set; }

    public DateTime Fecha { get; set; }

    public int IdActividad { get; set; }

    public int Estado { get; set; }

    public long? IdDetalleKardex { get; set; }
}
