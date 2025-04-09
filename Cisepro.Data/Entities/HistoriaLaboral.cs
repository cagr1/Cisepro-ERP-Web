using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class HistoriaLaboral
{
    public long IdHistoriaLaboral { get; set; }

    public DateTime FechaHistoriaLaboral { get; set; }

    public string DetalleHistoriaLaboral { get; set; } = null!;

    public int EstadoHistoriaLaboral { get; set; }

    public int IdPersonalHistoriaLaboral { get; set; }

    public string? IdSitioPuesto { get; set; }

    public int? IdAux { get; set; }

    public virtual Personal IdPersonalHistoriaLaboralNavigation { get; set; } = null!;
}
