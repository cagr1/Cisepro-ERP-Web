using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class RegistroPermisosPersonal
{
    public int IdRegistro { get; set; }

    public int IdPersonal { get; set; }

    public int IdSancion { get; set; }

    public DateTime Desde { get; set; }

    public DateTime Hasta { get; set; }

    public int Estado { get; set; }

    public string? Observacion { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public int? IdSitio { get; set; }

    public int? Ndoc { get; set; }

    public byte[]? Certificado { get; set; }

    public virtual Personal IdPersonalNavigation { get; set; } = null!;

    public virtual SancionesPersonal IdSancionNavigation { get; set; } = null!;

    public virtual SitiosTrabajo? IdSitioNavigation { get; set; }
}
