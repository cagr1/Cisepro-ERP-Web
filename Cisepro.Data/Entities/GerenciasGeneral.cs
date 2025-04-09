using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class GerenciasGeneral
{
    public int IdGerenciasGeneral { get; set; }

    public string Codigo { get; set; } = null!;

    public string NombreGerencias { get; set; } = null!;

    public int EstadoGerencias { get; set; }

    public int IdGerencia { get; set; }

    public virtual ICollection<AreaGeneral> AreaGenerals { get; set; } = new List<AreaGeneral>();

    public virtual GerenciaGeneral IdGerenciaNavigation { get; set; } = null!;
}
