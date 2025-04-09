using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class DetalleMantenimiento
{
    public long IdMantenimiento { get; set; }

    public string CodigoActivo { get; set; } = null!;

    public string NombreActivo { get; set; } = null!;

    public string NroFactura { get; set; } = null!;

    public decimal Valor { get; set; }

    public string DetalleMantenimiento1 { get; set; } = null!;

    public string Observacion { get; set; } = null!;

    public int IdEmpresa { get; set; }

    public int IdSucursal { get; set; }

    public int IdGerencias { get; set; }

    public int IdArea { get; set; }

    public int IdActivoFijo { get; set; }

    public int Estado { get; set; }

    public string Cumplio { get; set; } = null!;

    public virtual ActivoFijoMantenimiento IdMantenimientoNavigation { get; set; } = null!;
}
