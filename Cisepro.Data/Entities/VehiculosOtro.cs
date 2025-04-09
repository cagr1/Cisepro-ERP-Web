using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class VehiculosOtro
{
    public int IdVehiculos { get; set; }

    public string NombreVehiculo { get; set; } = null!;

    public string Responsable { get; set; } = null!;

    public string TipoVehiculo { get; set; } = null!;

    public string Placas { get; set; } = null!;

    public string Chasis { get; set; } = null!;

    public string Marca { get; set; } = null!;

    public string Modelo { get; set; } = null!;

    public string Serie { get; set; } = null!;

    public string Motor { get; set; } = null!;

    public string Cilindraje { get; set; } = null!;

    public DateTime Soat { get; set; }

    public string Color { get; set; } = null!;

    public string Capacidad { get; set; } = null!;

    public string Ubicacion { get; set; } = null!;

    public int Estado { get; set; }
}
