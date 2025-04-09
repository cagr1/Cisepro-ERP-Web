using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class CargoOcupacional
{
    public int IdCargoOcupacional { get; set; }

    public string Codigo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public int Estado { get; set; }

    public int IdSerieOcupacional { get; set; }

    public decimal? SueldoBasico { get; set; }

    public virtual SerieOcupacional IdSerieOcupacionalNavigation { get; set; } = null!;

    public virtual ICollection<Personal> Personals { get; set; } = new List<Personal>();
}
