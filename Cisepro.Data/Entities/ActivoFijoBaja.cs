using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class ActivoFijoBaja
{
    public int IdBaja { get; set; }

    public DateTime Fecha { get; set; }

    public int IdCustodio { get; set; }

    public int IdActivo { get; set; }

    public string Autorizo { get; set; } = null!;

    public string Motivo { get; set; } = null!;

    public string Destinatario { get; set; } = null!;

    public string InformeTecnico { get; set; } = null!;

    public long NroMemorandum { get; set; }

    public int Estado { get; set; }

    public string TipoActivo { get; set; } = null!;

    public string EstadoActivo { get; set; } = null!;

    public virtual ActivoFijoGeneral IdActivoNavigation { get; set; } = null!;
}
