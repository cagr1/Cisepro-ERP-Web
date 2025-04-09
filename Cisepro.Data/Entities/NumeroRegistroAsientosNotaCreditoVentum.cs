using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class NumeroRegistroAsientosNotaCreditoVentum
{
    public long IdNotaCredito { get; set; }

    public long? IdLibroDiario { get; set; }

    public long? IdAsiento { get; set; }

    public long NumeroRegistro { get; set; }
}
