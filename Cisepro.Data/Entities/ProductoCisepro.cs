using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class ProductoCisepro
{
    public int IdProducto { get; set; }

    public string NombreProducto { get; set; } = null!;

    public int EstadoProducto { get; set; }
}
