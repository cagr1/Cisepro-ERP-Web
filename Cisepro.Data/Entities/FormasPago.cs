using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class FormasPago
{
    public int IdFormaPago { get; set; }

    public string DetalleFormaPago { get; set; } = null!;

    public string? CodigoFormaPago { get; set; }

    public int EstadoFormaPago { get; set; }
}
