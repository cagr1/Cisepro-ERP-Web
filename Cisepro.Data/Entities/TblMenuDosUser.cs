using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class TblMenuDosUser
{
    public int FldIdMenuDosUser { get; set; }

    public int FldIdMenuUser { get; set; }

    public string? FldNombre { get; set; }

    public bool? FldEstado { get; set; }

    public DateTime? FldCreateAt { get; set; }
}
