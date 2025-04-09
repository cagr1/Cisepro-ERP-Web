using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class InformacionTributarium
{
    public int IdInformacion { get; set; }

    public string? EstablecimientoFacturaIt { get; set; }

    public string? PuntoEmisionFacturaIt { get; set; }

    public string? SecuencialFacturaIt { get; set; }

    public string? EstableciminetoNotaCreditoIt { get; set; }

    public string? PuntoEmisionNotaCreditoIt { get; set; }

    public string? SecuencialNotaCreditoIt { get; set; }

    public string? EstableciminetoComprobanteRetencionIt { get; set; }

    public string? PuntoEmisionComprobanteRetencionIt { get; set; }

    public string? SecuencialComprobanteRetencionIt { get; set; }

    public string? NroAutorizacionFacturaIt { get; set; }

    public string? NroAutorizacionNotaCreditoIt { get; set; }

    public string? NroAutorizacionCompRetencionIt { get; set; }

    public int? PorcentajeIvaIt { get; set; }

    public int PorcentajeIceIt { get; set; }

    public int EstadoIt { get; set; }

    public int? IdEmpresa { get; set; }

    public string? CtaIvaCompra { get; set; }

    public string? CtaIvaCompra2019 { get; set; }

    public int CtaIvaCn { get; set; }

    public string? EstablecimientoLiquidacionCompraIt { get; set; }

    public string? PuntoEmisionLiquidacionCompraIt { get; set; }

    public string? SecuencialLiquidacionCompraIt { get; set; }

    public string? NroAutorizacionLiquidacionCompraIt { get; set; }

    public string? NroResolucionAgenteRetencion { get; set; }

    public string? SecuencialFacturaIt3 { get; set; }

    public string? SecuencialFacturaIt4 { get; set; }

    public string? SecuencialComprobanteRetencionIt3 { get; set; }

    public string? SecuencialComprobanteRetencionIt4 { get; set; }

    public string? SecuencialLiquidacionCompraIt3 { get; set; }

    public string? SecuencialLiquidacionCompraIt4 { get; set; }

    public virtual EmpresaGeneral? IdEmpresaNavigation { get; set; }
}
