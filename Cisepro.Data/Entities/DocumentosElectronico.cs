using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class DocumentosElectronico
{
    public int IdArc { get; set; }

    public int? IdDoc { get; set; }

    public string? Tipo { get; set; }

    public string? Documento { get; set; }

    public DateTime? FechaGenerado { get; set; }

    public string? Numdoc { get; set; }
}
