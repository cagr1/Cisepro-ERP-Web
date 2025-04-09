using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class RegistroSancionesPersonal
{
    public int IdRegistro { get; set; }

    public int IdPersonal { get; set; }

    public int IdSancion { get; set; }

    public DateTime Fecha { get; set; }

    public decimal Valor { get; set; }

    public int Estado { get; set; }

    public string? Observacion { get; set; }

    public int? IdSitio { get; set; }

    public int? IdProg { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public int IdDescuento { get; set; }

    public string? Multador { get; set; }

    public virtual Personal IdPersonalNavigation { get; set; } = null!;

    public virtual SancionesPersonal IdSancionNavigation { get; set; } = null!;
}
