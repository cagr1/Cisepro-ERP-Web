using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class Paise
{
    public int IdPaises { get; set; }

    public string NombrePaises { get; set; } = null!;

    public int EstadoPaises { get; set; }

    public virtual ICollection<Provincia> Provincia { get; set; } = new List<Provincia>();
}
