using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class TblRolUser
{
    public int FldIdRol { get; set; }

    public string FldTipoRol { get; set; } = null!;

    public string? FldDescripcion { get; set; }

    public bool? FldEstado { get; set; }

    public DateTime? FldCreateAt { get; set; }
}
