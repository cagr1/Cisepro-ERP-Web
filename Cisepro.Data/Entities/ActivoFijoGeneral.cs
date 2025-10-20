using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class ActivoFijoGeneral
{
    public int IdActivoFijo { get; set; }

    public int IdPersonal { get; set; }

    public int IdEmpresa { get; set; }

    public int IdSucursal { get; set; }

    public int IdGerencias { get; set; }

    public int IdArea { get; set; }

    public string Carpeta { get; set; } = null!;

    public string Contrato { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public string NombreActivo { get; set; } = null!;

    public string NombreProvedor { get; set; } = null!;

    public string NombreCustodio { get; set; } = null!;

    public string Responsable { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public string CodigoArancel { get; set; } = null!;

    public string NumOrdenCompra { get; set; } = null!;

    public string NumFactura { get; set; } = null!;

    public decimal ValorFactura { get; set; }

    public decimal ValorAdicional { get; set; }

    public decimal ValorResidual { get; set; }

    public DateTime FechaAdquisicion { get; set; }

    public int AñosVidaUtil { get; set; }

    public string CtaActivo { get; set; } = null!;

    public string CtaGastos { get; set; } = null!;

    public string CtaDepreciacion { get; set; } = null!;

    public int Estado { get; set; }

    public string EstadoActivo { get; set; } = null!;

    public string TipoActivo { get; set; } = null!;

    public string Mantenimiento { get; set; } = null!;

    public DateTime FechaMantenimiento { get; set; }

    public int? IdSitio { get; set; }

    public int? IdProoveedorGeneral { get; set; }

    public int? IdSubactivo { get; set; }

    public virtual ICollection<ActivoFijoBaja> ActivoFijoBajas { get; set; } = new List<ActivoFijoBaja>();

    public virtual ICollection<DepreciacionesGeneral> DepreciacionesGenerals { get; set; } = new List<DepreciacionesGeneral>();

    public virtual Personal IdPersonalNavigation { get; set; } = null!;

    public virtual SitiosTrabajo? IdSitioNavigation { get; set; }

    public virtual ICollection<RotacionVehiculo> RotacionVehiculos { get; set; } = new List<RotacionVehiculo>();
}
