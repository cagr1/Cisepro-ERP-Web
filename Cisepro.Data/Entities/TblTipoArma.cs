using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class TblTipoArma
{
    public int IdTipoArma { get; set; }

    public string? Marca { get; set; }

    public string? Calibre { get; set; }

    public int? IdPaisFabrica { get; set; }

    public string? TipoUso { get; set; }

    public string? Categoria { get; set; }

    public int? Color { get; set; }

    public string Estado { get; set; } = null!;

    public bool Activo { get; set; }

    public int? IdSubactivo { get; set; }
}
