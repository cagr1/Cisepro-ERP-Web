using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class SitiosTrabajo
{
    public int IdSitioTrabajo { get; set; }

    public int IdProvincia { get; set; }

    public int IdCiudad { get; set; }

    public int IdParroquia { get; set; }

    public string DireccionSitioTrabajo { get; set; } = null!;

    public string ReferenciaSitioTrabajo { get; set; } = null!;

    public string NombreSitioTrabajo { get; set; } = null!;

    public string TipoSitioTrabajo { get; set; } = null!;

    public int? IdClienteGeneral { get; set; }

    public int? IdPersonalSupervisor { get; set; }

    public int? Estado { get; set; }

    public string? Latitud { get; set; }

    public string? Longitud { get; set; }

    public string? River { get; set; }

    public string? Grupo { get; set; }

    public int? Rive { get; set; }

    public int? PuestoHoras { get; set; }

    public decimal? CantHoras { get; set; }

    public decimal? CantHoras50 { get; set; }

    public decimal? CantHoras100 { get; set; }

    public decimal? CantHorasExt { get; set; }

    public decimal? CantRecNoc { get; set; }

    public decimal? CantAdici { get; set; }

    public int? DecimoExtra { get; set; }

    public virtual ICollection<ActivoFijoGeneral> ActivoFijoGenerals { get; set; } = new List<ActivoFijoGeneral>();

    public virtual ICollection<AsignacionPersonal> AsignacionPersonals { get; set; } = new List<AsignacionPersonal>();

    public virtual ICollection<Bodega> Bodegas { get; set; } = new List<Bodega>();

    public virtual Parroquia IdParroquiaNavigation { get; set; } = null!;

    public virtual Provincia IdProvinciaNavigation { get; set; } = null!;

    public virtual ICollection<RegistroPermisosPersonal> RegistroPermisosPersonals { get; set; } = new List<RegistroPermisosPersonal>();
}
