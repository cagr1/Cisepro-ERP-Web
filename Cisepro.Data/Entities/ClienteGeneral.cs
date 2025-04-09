using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class ClienteGeneral
{
    public long IdClienteGeneral { get; set; }

    public string? CodigoClienteGeneral { get; set; }

    public string? TipoIdentificacionClienteGeneral { get; set; }

    public string? RucCiClienteGeneral { get; set; }

    public string? NompreRazonSocialClienteGeneral { get; set; }

    public string? ApellidoNombreComercialClienteGenral { get; set; }

    public string? NroResContEspecialClienteGeneral { get; set; }

    public string? ObligLlevarContClienteGeneral { get; set; }

    public string? DireccionUbicacionClienteGeneral { get; set; }

    public string? DireccionFacturacionClienteGeneral { get; set; }

    public string? ConsorcioClienteGeneral { get; set; }

    public int? IdCiudad { get; set; }

    public string? Telefono1ClienteGeneral { get; set; }

    public string? Telefono2ClienteGeneral { get; set; }

    public string? EmailClienteGeneral { get; set; }

    public string? ContactoClienteGeneral { get; set; }

    public DateTime? FechaIngresoClienteGeneral { get; set; }

    public string? TipoClienteGeneral { get; set; }

    public string? ObservacionesClienteGeneral { get; set; }

    public string? EstadoClienteGeneral { get; set; }

    public string? TipoEmpresaCliente { get; set; }

    public virtual ICollection<ContratoCliente> ContratoClientes { get; set; } = new List<ContratoCliente>();

    public virtual ICollection<PuestoTrabajo> PuestoTrabajos { get; set; } = new List<PuestoTrabajo>();
}
