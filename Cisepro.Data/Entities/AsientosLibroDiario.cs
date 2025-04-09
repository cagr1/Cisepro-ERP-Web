using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class AsientosLibroDiario
{
    public long IdAsiento { get; set; }

    public DateTime FechaAsiento { get; set; }

    public string CodigoCuentaAsiento { get; set; } = null!;

    public string NombreCuentaAsiento { get; set; } = null!;

    public string ConceptoAsiento { get; set; } = null!;

    public string DetalleTransaccionAsiento { get; set; } = null!;

    public string ProvinciaAsiento { get; set; } = null!;

    public string CiudadAsiento { get; set; } = null!;

    public string ParroquiaAsiento { get; set; } = null!;

    public string CentroCostoAsiento { get; set; } = null!;

    public decimal? ValorDebeAsiento { get; set; }

    public decimal? ValorHaberAsiento { get; set; }

    public long NumeroRegistroAsiento { get; set; }

    public int DebeHaber { get; set; }

    public int? ConciliarAsiento { get; set; }

    public int EstadoAsiento { get; set; }

    public long IdLibroDiario { get; set; }

    public int? EstadoMayor { get; set; }

    public virtual LibroDiarioGeneral IdLibroDiarioNavigation { get; set; } = null!;
}
