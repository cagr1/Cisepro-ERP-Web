using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class DetalleOrdenComprobanteCompra
{
    public int? IdOrdenCompra { get; set; }

    public int? IdComprobanteCompra { get; set; }

    public int? IdComprobanteIngreso { get; set; }
}
