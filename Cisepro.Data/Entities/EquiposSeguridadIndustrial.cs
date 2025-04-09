using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class EquiposSeguridadIndustrial
{
    public int IdActivoFijo { get; set; }

    public string Marca { get; set; } = null!;

    public string Modelo { get; set; } = null!;

    public string EstadoActivo { get; set; } = null!;

    public string Color { get; set; } = null!;

    public string Serie { get; set; } = null!;

    public string Material { get; set; } = null!;

    public int Ano { get; set; }

    public string Adicional { get; set; } = null!;

    public int Estado { get; set; }

    public virtual ActivoFijoGeneral IdActivoFijoNavigation { get; set; } = null!;
}
