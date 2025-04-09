using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class SubgrupoSuministro
{
    public int IdSubgrupoSuministros { get; set; }

    public string NombreSubgrupoSuministros { get; set; } = null!;

    public string EstadoSubgrupoSuministros { get; set; } = null!;

    public int IdGrupoSuministros { get; set; }

    public int? CategoriaSgr { get; set; }

    public int? GrupoSgr { get; set; }

    public int? SubgrupoSgr { get; set; }

    public virtual GrupoSuministro IdGrupoSuministrosNavigation { get; set; } = null!;

    public virtual ICollection<SecuencialSuministro> SecuencialSuministros { get; set; } = new List<SecuencialSuministro>();
}
