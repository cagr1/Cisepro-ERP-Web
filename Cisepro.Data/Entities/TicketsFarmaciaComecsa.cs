using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class TicketsFarmaciaComecsa
{
    public long IdTicket { get; set; }

    public long NumTicket { get; set; }

    public DateTime FechaRegistro { get; set; }

    public string Cedularuc { get; set; } = null!;

    public string ApellidosNombres { get; set; } = null!;

    public string DetalleObservacion { get; set; } = null!;

    public int TipoTicket { get; set; }

    public int Estado { get; set; }
}
