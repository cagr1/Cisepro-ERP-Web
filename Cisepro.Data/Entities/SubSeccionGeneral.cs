using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class SubSeccionGeneral
{
    public int IdSubSeccion { get; set; }

    public string Codigo { get; set; } = null!;

    public string NombreSubSeccion { get; set; } = null!;

    public int EstadoSubSeccion { get; set; }

    public int IdSeccion { get; set; }

    public virtual SeccionGeneral IdSeccionNavigation { get; set; } = null!;
}
