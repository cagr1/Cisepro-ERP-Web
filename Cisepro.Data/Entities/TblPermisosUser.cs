using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class TblPermisosUser
{
    public int FldIdPermisosUser { get; set; }

    public int FldIdRolUser { get; set; }

    public int FldIdMenu { get; set; }

    public int FldIdMenuDos { get; set; }

    public int? FldIdMenuTres { get; set; }

    public bool? FldEstado { get; set; }

    public DateTime? FldCreateAt { get; set; }
}
