using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class NumeroRegistroAsientosComprobanteIngreso
{
    public long IdComprobanteIngresoBancos { get; set; }

    public long IdLibroDiario { get; set; }

    public long IdAsiento { get; set; }

    public long NumeroRegistro { get; set; }

    public int TempId { get; set; }
}
