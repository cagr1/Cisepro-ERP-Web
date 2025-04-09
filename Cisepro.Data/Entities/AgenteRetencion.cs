using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class AgenteRetencion
{
    public int IdAgente { get; set; }

    public string DescripcionAgente { get; set; } = null!;

    public int EstadoAgenteRetencion { get; set; }
}
