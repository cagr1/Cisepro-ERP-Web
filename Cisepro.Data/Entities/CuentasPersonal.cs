using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class CuentasPersonal
{
    public int? IdPersonal { get; set; }

    public int? IdBanco { get; set; }

    public string? NumCuenta { get; set; }

    public string? Tipo { get; set; }
}
