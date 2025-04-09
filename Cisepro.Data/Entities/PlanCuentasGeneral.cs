using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class PlanCuentasGeneral
{
    public int IdPlan { get; set; }

    public string Codigo { get; set; } = null!;

    public string Detalle { get; set; } = null!;

    public int Nivel { get; set; }

    public string PadreCuenta { get; set; } = null!;

    public string Movimiento { get; set; } = null!;

    public string Presupuesto { get; set; } = null!;

    public int TipoCuenta { get; set; }

    public int IdEmpresa { get; set; }

    public int Estado { get; set; }

    public int? EstadoContable { get; set; }

    public virtual EmpresaGeneral IdEmpresaNavigation { get; set; } = null!;
}
