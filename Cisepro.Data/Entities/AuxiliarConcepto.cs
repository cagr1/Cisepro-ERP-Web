using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class AuxiliarConcepto
{
    public int IdConcepto { get; set; }

    public string NombreConcepto { get; set; } = null!;

    public string CtaContableConcepto { get; set; } = null!;

    public int EstadoConcepto { get; set; }
}
