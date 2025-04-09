using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class Logsql
{
    public int IdLog { get; set; }

    public string? Nombre { get; set; }

    public string? Sqls { get; set; }

    public DateTime Fecha { get; set; }
}
