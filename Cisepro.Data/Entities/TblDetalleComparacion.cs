using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class TblDetalleComparacion
{
    public int FldIdDetalleComparacion { get; set; }

    public int FldIdSecuencialItem { get; set; }

    public int FldIdProveedor { get; set; }

    public int FldIdComparacion { get; set; }

    public decimal? FldPrecio { get; set; }

    public int? FldCredito { get; set; }

    public int? FldDias { get; set; }

    public int? FldEstado { get; set; }
}
