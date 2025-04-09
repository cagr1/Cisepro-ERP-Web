using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class BancosCobro
{
    public int IdBancoCobros { get; set; }

    public string NombreBancoCobros { get; set; } = null!;

    public string CiudadBancoCobros { get; set; } = null!;

    public string PaisBancoCobros { get; set; } = null!;

    public int EstadoBancoCobros { get; set; }
}
