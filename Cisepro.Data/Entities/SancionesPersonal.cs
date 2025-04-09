using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class SancionesPersonal
{
    public int IdSancion { get; set; }

    public string? TipoSancion { get; set; }

    public string? Detalle { get; set; }

    public decimal? ValorDescuento { get; set; }

    public int? Estado { get; set; }

    public int? SanPer { get; set; }

    public virtual ICollection<RegistroPermisosPersonal> RegistroPermisosPersonals { get; set; } = new List<RegistroPermisosPersonal>();

    public virtual ICollection<RegistroSancionesPersonal> RegistroSancionesPersonals { get; set; } = new List<RegistroSancionesPersonal>();
}
