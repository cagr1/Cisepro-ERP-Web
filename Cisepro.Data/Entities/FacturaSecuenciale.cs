using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class FacturaSecuenciale
{
    public long IdFacturaSecuencial { get; set; }

    public DateTime FechaEmisionFacturaSecuenciales { get; set; }

    public int CantidadFacturaSecuenciales { get; set; }

    public int NumeroInicialFacturaSecuenciales { get; set; }

    public int NumeroFinalFacturaSecuenciales { get; set; }

    public int? ActualFacturaSecuenciales { get; set; }

    public string? ObservacionesFacturaSecuenciales { get; set; }

    public int EstadoFacturaSecuenciales { get; set; }
}
