using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class TblComparacion
{
    public int FldIdComparacion { get; set; }

    public string? FldObservacion { get; set; }

    public int? FldEstado { get; set; }

    public DateTime? FldFecha { get; set; }
}
