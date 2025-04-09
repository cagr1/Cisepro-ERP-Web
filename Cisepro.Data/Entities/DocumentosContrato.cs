using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class DocumentosContrato
{
    public int? IdContrato { get; set; }

    public string? TipoDocumento { get; set; }

    public DateTime? FechaCarga { get; set; }

    public byte[] Documento { get; set; } = null!;

    public int IdDocumento { get; set; }

    public string? Nombre { get; set; }
}
