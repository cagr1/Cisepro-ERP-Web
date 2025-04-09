using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class UsuarioGeneral
{
    public int IdUsuario { get; set; }

    public int IdEmpresa { get; set; }

    public int IdSucursal { get; set; }

    public int IdArea { get; set; }

    public string Datos { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string TipoUsuario { get; set; } = null!;

    public int Estado { get; set; }

    public string? IdPersonal { get; set; }

    public int? IdRol { get; set; }

    public virtual ICollection<AuditoriaGeneral> AuditoriaGenerals { get; set; } = new List<AuditoriaGeneral>();
}
