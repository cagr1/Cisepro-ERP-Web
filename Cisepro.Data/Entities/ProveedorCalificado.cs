using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class ProveedorCalificado
{
    public int IdProveedorCalificado { get; set; }

    public DateTime FechaInicioProveedorCalificado { get; set; }

    public DateTime FechaCeseProveedorCalificado { get; set; }

    public DateTime FechaActualizacionProveedorCalificado { get; set; }

    public int NumeroCarpetaProveedorCalificado { get; set; }

    public string ActividadProveedorCalificado { get; set; } = null!;

    public string EsImportadorProveedorCalificado { get; set; } = null!;

    public string PaginaWebProveedorCalificado { get; set; } = null!;

    public string ServiciosPrestadosProveedorCalificado { get; set; } = null!;

    public string FormaPagoProveedorCalificado { get; set; } = null!;

    public string CertificacionesProveedorCalificado { get; set; } = null!;

    public string ObservacionesProveedorCalificado { get; set; } = null!;

    public int EstadoProveedorCalificado { get; set; }

    public int IdProveedorGeneral { get; set; }

    public virtual ProveedorGeneral IdProveedorGeneralNavigation { get; set; } = null!;
}
