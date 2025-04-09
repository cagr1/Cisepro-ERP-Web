using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class Secuencial
{
    public int IdSecuencial { get; set; }

    public int Codigo { get; set; }

    public string NombreSecuencial { get; set; } = null!;

    public string EstadoDepreciable { get; set; } = null!;

    public int IdSubGrupoSecuencial { get; set; }

    public int EstadoSecuencial { get; set; }

    public virtual SubGrupoGeneral IdSubGrupoSecuencialNavigation { get; set; } = null!;
}
