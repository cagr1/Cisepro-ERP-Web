using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class NumeroRegistroAsientosComprobanteEgreso
{
    public long IdComprobanteEgresoBancos { get; set; }

    public long IdLibroDiario { get; set; }

    public long IdAsiento { get; set; }

    public long NumeroRegistro { get; set; }

    public int TempId { get; set; }
}
