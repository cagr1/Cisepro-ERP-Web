using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class GerenciaGeneral
{
    public int IdGerencia { get; set; }

    public string Codigo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public int EstadoGerencia { get; set; }

    public int IdEmpresa { get; set; }

    public int IdSucursal { get; set; }

    public virtual ICollection<GerenciasGeneral> GerenciasGenerals { get; set; } = new List<GerenciasGeneral>();

    public virtual EmpresaGeneral IdEmpresaNavigation { get; set; } = null!;
}
