using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class AuxiliarFondoRotativo
{
    public int IdFondoRotativo { get; set; }

    public decimal? MontoFondoRotativo { get; set; }

    public decimal? MontoAnterior { get; set; }
}
