using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class HistorialVehiculo
{
    public int IdActivoFijo { get; set; }

    public int NroHistorial { get; set; }

    public DateTime Fecha { get; set; }

    public DateTime Soat { get; set; }

    public string Aseguradora { get; set; } = null!;

    public string Seguro { get; set; } = null!;

    public string Broker { get; set; } = null!;

    public string NroPoliza { get; set; } = null!;

    public decimal CostoPrima { get; set; }

    public string DispositivoSeguridad { get; set; } = null!;

    public DateTime FechaInicioContrato { get; set; }

    public DateTime FechaFinalContrato { get; set; }

    public DateTime FechaRenovacionContrato { get; set; }

    public DateTime FechaInicioDisSeg { get; set; }

    public DateTime FechaFinalDisSeg { get; set; }

    public DateTime FechaRenovacionDisSeg { get; set; }

    public int Estado { get; set; }

    public virtual ActivoFijoGeneral IdActivoFijoNavigation { get; set; } = null!;
}
