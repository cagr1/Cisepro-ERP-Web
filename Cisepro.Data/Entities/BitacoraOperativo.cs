using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class BitacoraOperativo
{
    public int IdBitacora { get; set; }

    public DateTime FechaBitacora { get; set; }

    public int TipoBitacora { get; set; }

    public int IdPuesto { get; set; }

    public string Puesto { get; set; } = null!;

    public string River { get; set; } = null!;

    public string Provincia { get; set; } = null!;

    public string Ciudad { get; set; } = null!;

    public int IdVigilante { get; set; }

    public string Vigilante { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public string? DetalleBitacora { get; set; }
}
