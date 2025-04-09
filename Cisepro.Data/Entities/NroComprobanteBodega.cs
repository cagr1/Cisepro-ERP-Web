using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class NroComprobanteBodega
{
    public long Ingreso { get; set; }

    public long Egreso { get; set; }

    public long Reingreso { get; set; }

    public long Ajuste { get; set; }

    public long Donacion { get; set; }
}
