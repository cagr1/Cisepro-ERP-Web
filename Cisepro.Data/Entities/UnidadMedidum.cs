using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class UnidadMedidum
{
    public int IdUnidadMedida { get; set; }

    public string DetalleUnidadMedida { get; set; } = null!;

    public string CodigoUnidadMedida { get; set; } = null!;

    public int EstadoUnidadMedida { get; set; }

    public virtual ICollection<SecuencialSuministro> SecuencialSuministros { get; set; } = new List<SecuencialSuministro>();
}
