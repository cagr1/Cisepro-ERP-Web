using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class EquiposComputo
{
    public int IdActivoFijo { get; set; }

    public string Marca { get; set; } = null!;

    public string Modelo { get; set; } = null!;

    public string Componente { get; set; } = null!;

    public string EstadoComponente { get; set; } = null!;

    public string ColorComponente { get; set; } = null!;

    public string CodigoComponente { get; set; } = null!;

    public int Estado { get; set; }

    public int? Garantia { get; set; }

    public byte[]? Documento { get; set; }

    public DateTime? Caducidad { get; set; }

    public string? Ruta { get; set; }

    public virtual ActivoFijoGeneral IdActivoFijoNavigation { get; set; } = null!;
}
