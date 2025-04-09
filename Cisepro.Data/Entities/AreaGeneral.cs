using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class AreaGeneral
{
    public int IdAreaGeneral { get; set; }

    public string Codigo { get; set; } = null!;

    public string NombreArea { get; set; } = null!;

    public int EstadoArea { get; set; }

    public int IdGerenciasGeneral { get; set; }

    public virtual GerenciasGeneral IdGerenciasGeneralNavigation { get; set; } = null!;

    public virtual ICollection<Personal> Personals { get; set; } = new List<Personal>();

    public virtual ICollection<SeccionGeneral> SeccionGenerals { get; set; } = new List<SeccionGeneral>();
}
