using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class CodigoCargoOcupacional
{
    public int IdCodigo { get; set; }

    public string CodigoOcupacional { get; set; } = null!;

    public int? IdCargoOcupacional { get; set; }
}
