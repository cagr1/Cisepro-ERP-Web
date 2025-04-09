using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class NumeroRegistroAsientosComprobanteCompra
{
    public long IdComprobanteCompra { get; set; }

    public long? IdLibroDiario { get; set; }

    public long? IdAsiento { get; set; }

    public long NumeroRegistro { get; set; }
}
