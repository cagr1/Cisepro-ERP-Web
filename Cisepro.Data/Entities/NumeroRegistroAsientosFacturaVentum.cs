using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class NumeroRegistroAsientosFacturaVentum
{
    public long IdFacturaVenta { get; set; }

    public long? IdLibroDiario { get; set; }

    public long? IdAsiento { get; set; }

    public long NumeroRegistro { get; set; }
}
