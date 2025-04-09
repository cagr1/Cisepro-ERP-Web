using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class ComprobanteIngresoBodega
{
    public string IdComprobante { get; set; } = null!;

    public DateTime FechaComprobante { get; set; }

    public string NroParametro { get; set; } = null!;

    public long IdBodega { get; set; }

    public int IdActividad { get; set; }

    public int IdConcepto { get; set; }

    public int IdProvincias { get; set; }

    public int IdCiudad { get; set; }

    public int IdParroquias { get; set; }

    public int IdCentroCosto { get; set; }

    public int IdParametroDocumento { get; set; }

    public int Estado { get; set; }

    public string Razon { get; set; } = null!;

    public int IdPersonal { get; set; }

    public int IdEmpresa { get; set; }

    public string Cliente { get; set; } = null!;

    public string? IdSitioTrabajo { get; set; }

    public virtual ICollection<DetalleComprobanteIngresoBodega> DetalleComprobanteIngresoBodegas { get; set; } = new List<DetalleComprobanteIngresoBodega>();
}
