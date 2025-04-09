using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class Arma
{
    public int IdActivoFijo { get; set; }

    public string NumPermisoGobierno { get; set; } = null!;

    public string NumPermisoComando { get; set; } = null!;

    public string NumTenenciaArmas { get; set; } = null!;

    public DateTime FecAceptacionTenencia { get; set; }

    public DateTime FecCaducidadTenencia { get; set; }

    public string NumMatriculaArma { get; set; } = null!;

    public DateTime FecAceptacionMatricula { get; set; }

    public DateTime FecCaducidadMatricula { get; set; }

    public string Serie { get; set; } = null!;

    public int Estado { get; set; }

    public string? Origen { get; set; }

    public virtual ActivoFijoGeneral IdActivoFijoNavigation { get; set; } = null!;
}
