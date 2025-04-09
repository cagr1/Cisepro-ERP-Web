using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class LibroColeccione
{
    public int IdActivoFijo { get; set; }

    public string Editorial { get; set; } = null!;

    public string Autor { get; set; } = null!;

    public int Tomos { get; set; }

    public int AnosEdicion { get; set; }

    public int Estado { get; set; }

    public virtual ActivoFijoGeneral IdActivoFijoNavigation { get; set; } = null!;
}
