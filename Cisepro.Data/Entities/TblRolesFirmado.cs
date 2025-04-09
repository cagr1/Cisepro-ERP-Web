using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class TblRolesFirmado
{
    public int IdTblRoles { get; set; }

    public int IdPersonal { get; set; }

    public int? Mes { get; set; }

    public int? Anio { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public int? Estado { get; set; }
}
