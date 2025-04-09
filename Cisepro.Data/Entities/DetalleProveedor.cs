using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class DetalleProveedor
{
    public int? IdProveedorGeneral { get; set; }

    public string? TipoIdentificacion { get; set; }

    public string? TipoProveedorGeneral { get; set; }
}
