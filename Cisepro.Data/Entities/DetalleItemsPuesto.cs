using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class DetalleItemsPuesto
{
    public int? IdSitio { get; set; }

    public int? IdDetalleComprobante { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Tipo { get; set; }

    public int? Estado { get; set; }

    public int IdDetalle { get; set; }

    public string? Serie { get; set; }
}
