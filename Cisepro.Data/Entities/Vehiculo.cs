using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class Vehiculo
{
    public int IdActivoFijo { get; set; }

    public string Marca { get; set; } = null!;

    public string Modelo { get; set; } = null!;

    public string Serie { get; set; } = null!;

    public string Chasis { get; set; } = null!;

    public string EstadoActivo { get; set; } = null!;

    public string Placas { get; set; } = null!;

    public string Motor { get; set; } = null!;

    public string Cilindraje { get; set; } = null!;

    public string Capacidad { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public string Color { get; set; } = null!;

    public int AnoFabricacion { get; set; }

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

    public DateTime Soat { get; set; }

    public virtual ActivoFijoGeneral IdActivoFijoNavigation { get; set; } = null!;
}
