using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class RotacionVehiculo
{
    public int IdRotacion { get; set; }

    public int IdActivo { get; set; }

    public DateTime Fecha { get; set; }

    public int IdCustodioAnterior { get; set; }

    public int IdCustodioNuevo { get; set; }

    public string NombreCustodioAnterior { get; set; } = null!;

    public string NombreCustodioNuevo { get; set; } = null!;

    public string Observacion { get; set; } = null!;

    public int Estado { get; set; }

    public virtual ActivoFijoGeneral IdActivoNavigation { get; set; } = null!;
}
