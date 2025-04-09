using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class DetalleKardex
{
    public long IdDetalle { get; set; }

    public int IdActividad { get; set; }

    public int IdConcepto { get; set; }

    public int CantidadIngreso { get; set; }

    public decimal ValorUnitarioIngreso { get; set; }

    public decimal ValorTotalIngreso { get; set; }

    public int CantidadEgreso { get; set; }

    public decimal ValorUnitarioEgreso { get; set; }

    public decimal ValorTotalEgreso { get; set; }

    public int CantidadSaldo { get; set; }

    public decimal ValorUnitarioSaldo { get; set; }

    public decimal ValorTotalSaldo { get; set; }

    public DateTime Fecha { get; set; }

    public long IdKardex { get; set; }

    public int Estado { get; set; }

    public string IdComprobante { get; set; } = null!;

    public virtual Kardex IdKardexNavigation { get; set; } = null!;
}
