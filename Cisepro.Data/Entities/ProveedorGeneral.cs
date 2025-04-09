using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class ProveedorGeneral
{
    public int IdProveedorGeneral { get; set; }

    public DateTime FechaProveedorGeneral { get; set; }

    public string RucCiProveedorGeneral { get; set; } = null!;

    public string RazonSocialProveedorGeneral { get; set; } = null!;

    public string NombreComercialProveedorGeneral { get; set; } = null!;

    public string TipoProveedorGeneral { get; set; } = null!;

    public string ContabilidadProveedorGeneral { get; set; } = null!;

    public string ContribuyenteEspecialProveedorGeneral { get; set; } = null!;

    public string DireccionProveedorGeneral { get; set; } = null!;

    public int IdCiudad { get; set; }

    public string Telefono1ProveedorGeneral { get; set; } = null!;

    public string Telefono2ProveedorGeneral { get; set; } = null!;

    public string EmailProveedorGeneral { get; set; } = null!;

    public int EstadoProveedorGeneral { get; set; }

    public int? DocumentoContriEspeProveedorGeneral { get; set; }

    public virtual ICollection<EvaluacionProveedorMateriale> EvaluacionProveedorMateriales { get; set; } = new List<EvaluacionProveedorMateriale>();

    public virtual ICollection<EvaluacionProveedorServicio> EvaluacionProveedorServicios { get; set; } = new List<EvaluacionProveedorServicio>();

    public virtual ICollection<OrdenCompra> OrdenCompras { get; set; } = new List<OrdenCompra>();

    public virtual ICollection<ProveedorCalificado> ProveedorCalificados { get; set; } = new List<ProveedorCalificado>();
}
