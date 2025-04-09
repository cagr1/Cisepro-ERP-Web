using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class SeccionGeneral
{
    public int IdSeccion { get; set; }

    public string Codigo { get; set; } = null!;

    public string NombreSeccion { get; set; } = null!;

    public int EstadoSeccion { get; set; }

    public int IdAreaGeneral { get; set; }

    public virtual AreaGeneral IdAreaGeneralNavigation { get; set; } = null!;

    public virtual ICollection<SubSeccionGeneral> SubSeccionGenerals { get; set; } = new List<SubSeccionGeneral>();
}
