using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class DetalleTransferencia
{
    public long IdTransferencia { get; set; }

    public string CodigoActivo { get; set; } = null!;

    public string NombreActivo { get; set; } = null!;

    public int IdEmpresa { get; set; }

    public int IdSucursal { get; set; }

    public int IdGerencias { get; set; }

    public int IdArea { get; set; }

    public int Estado { get; set; }

    public string EstadoTransferencia { get; set; } = null!;

    public virtual ActivoFijoTransferencia IdTransferenciaNavigation { get; set; } = null!;
}
