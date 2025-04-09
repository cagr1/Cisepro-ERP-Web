using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class LiquidacionFondoRotativo
{
    public int IdLiquidacionFr { get; set; }

    public DateTime FechaLiquidacionFr { get; set; }

    public decimal TotalLiquidacion { get; set; }

    public decimal FondoLiquidacionFr { get; set; }

    public decimal GastosLiquidacionFr { get; set; }

    public decimal SaldoLiquidacionFr { get; set; }

    public decimal ReposicionLiquidacionFr { get; set; }

    public int EstadoLiquidacionFr { get; set; }

    public int IdProvicias { get; set; }

    public int IdCiudad { get; set; }

    public int IdParroquias { get; set; }

    public int? IdCentroCosto { get; set; }

    public long? NroAsiento { get; set; }
}
