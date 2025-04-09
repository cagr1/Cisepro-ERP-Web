using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class SucursalGeneral
{
    public int IdSucursal { get; set; }

    public string CodigoSucursal { get; set; } = null!;

    public string NombreSucursal { get; set; } = null!;

    public int EstadoSucursal { get; set; }

    public int IdEmpresa { get; set; }

    public virtual EmpresaGeneral IdEmpresaNavigation { get; set; } = null!;
}
