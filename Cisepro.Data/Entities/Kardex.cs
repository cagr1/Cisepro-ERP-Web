using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class Kardex
{
    public long IdKardex { get; set; }

    public long IdSecuencialItem { get; set; }

    public DateTime Fecha { get; set; }

    public int Cantidad { get; set; }

    public int Estado { get; set; }

    public virtual ICollection<DetalleKardex> DetalleKardices { get; set; } = new List<DetalleKardex>();
}
