using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class RetencionIva
{
    public int IdRetencionIva { get; set; }

    public string DescripcionRetencionIva { get; set; } = null!;

    public string TipoRetencionIva { get; set; } = null!;

    public string ContabilidadRetencionIva { get; set; } = null!;

    public int EstadoRetencionIva { get; set; }
}
