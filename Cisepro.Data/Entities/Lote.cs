using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class Lote
{
    public long IdLote { get; set; }

    public string NombreLote { get; set; } = null!;

    public DateTime FechaLote { get; set; }

    public DateTime CaducidadLote { get; set; }

    public int Estado { get; set; }

    public virtual ICollection<SecuencialItem> SecuencialItems { get; set; } = new List<SecuencialItem>();
}
