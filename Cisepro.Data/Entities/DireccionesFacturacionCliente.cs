using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class DireccionesFacturacionCliente
{
    public long IdDireccion { get; set; }

    public long IdClienteGeneral { get; set; }

    public string DireccionFacturacion { get; set; } = null!;
}
