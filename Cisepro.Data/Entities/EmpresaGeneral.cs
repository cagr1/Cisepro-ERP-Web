using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class EmpresaGeneral
{
    public int IdEmpresa { get; set; }

    public int CodigoEmpresa { get; set; }

    public string? RucEmpresa { get; set; }

    public string RazonSocialEmpresa { get; set; } = null!;

    public string NombreComercialEmpresa { get; set; } = null!;

    public string RucEmpre { get; set; } = null!;

    public string DireccionMatrizEmpresa { get; set; } = null!;

    public string? NroResContEspecialEmpresa { get; set; }

    public string ObligadoLlevarContEmpresa { get; set; } = null!;

    public int EstadoEmpresa { get; set; }

    public string Telefono { get; set; } = null!;

    public virtual ICollection<GerenciaGeneral> GerenciaGenerals { get; set; } = new List<GerenciaGeneral>();

    public virtual ICollection<PlanCuentasGeneral> PlanCuentasGenerals { get; set; } = new List<PlanCuentasGeneral>();

    public virtual ICollection<SucursalGeneral> SucursalGenerals { get; set; } = new List<SucursalGeneral>();
}
