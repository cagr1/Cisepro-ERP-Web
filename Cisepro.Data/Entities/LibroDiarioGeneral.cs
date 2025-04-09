using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class LibroDiarioGeneral
{
    public long IdLibroDiario { get; set; }

    public DateTime FechaLibroDiario { get; set; }

    public decimal? TotalDebeLibroDiario { get; set; }

    public decimal? TotalHaberLibroDiario { get; set; }

    public string EstadoLibroDiario { get; set; } = null!;

    public virtual ICollection<AsientosLibroDiario> AsientosLibroDiarios { get; set; } = new List<AsientosLibroDiario>();
}
