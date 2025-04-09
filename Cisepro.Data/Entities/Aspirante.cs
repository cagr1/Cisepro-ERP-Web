using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class Aspirante
{
    public int IdAspirante { get; set; }

    public string Cedula { get; set; } = null!;

    public string Sexo { get; set; } = null!;

    public DateTime? FechaNacimiento { get; set; }

    public int Edad { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string EstadoCivil { get; set; } = null!;

    public string Instruccion { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Movil { get; set; }

    public string? Email { get; set; }

    public string Provincia { get; set; } = null!;

    public string Ciudad { get; set; } = null!;

    public string? Parroquia { get; set; }

    public string Direccion { get; set; } = null!;

    public string? Observacion { get; set; }

    public string AptoPara { get; set; } = null!;

    public int TieneCedula { get; set; }

    public int TieneCertificadoVotacion { get; set; }

    public int TieneLibretaMilitar { get; set; }

    public int TieneDiscapacidad { get; set; }

    public string TipoDiscapacidad { get; set; } = null!;

    public string PruebaAntidroga { get; set; } = null!;

    public int TieneCurso { get; set; }

    public string EntidadCurso { get; set; } = null!;

    public int TieneCredencial { get; set; }

    public string EntidadCredencial { get; set; } = null!;

    public int TieneAntecedentes { get; set; }

    public string DetalleAntecedentes { get; set; } = null!;

    public int TieneNoViolencia { get; set; }

    public string DetalleNoViolencia { get; set; } = null!;

    public int TienePsicologico { get; set; }

    public string DetallePsicologico { get; set; } = null!;

    public int TieneCertTrabajo { get; set; }

    public string DetalleCertTrabajo { get; set; } = null!;

    public int TieneRecomendacion { get; set; }

    public string DetalleRecomendacion { get; set; } = null!;

    public int TieneBachiller { get; set; }

    public string DetalleBachiller { get; set; } = null!;

    public int TienePoligrafica { get; set; }

    public string DetallePoligrafica { get; set; } = null!;

    public int TieneAfis { get; set; }

    public string DetalleAfis { get; set; } = null!;

    public int TieneVehiculo { get; set; }

    public string DetalleVehiculo { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public byte[]? Documentos { get; set; }
}
