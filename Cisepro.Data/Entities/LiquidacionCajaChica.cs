using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class LiquidacionCajaChica
{
    public int IdLiquidacionCch { get; set; }

    public DateTime FechaLiquidacionCch { get; set; }

    public decimal TotalLiquidacionCch { get; set; }

    public decimal FondoLiquidacionCch { get; set; }

    public decimal GastosLiquidacionCch { get; set; }

    public decimal SaldoLiquidacionCch { get; set; }

    public decimal ReposicionLiquidacionCch { get; set; }

    public int EstadoLiquidacionCch { get; set; }

    public int IdProvincias { get; set; }

    public int IdCiudad { get; set; }

    public int IdParroquias { get; set; }

    public int IdCajaCch { get; set; }

    public int IdCentroCostoCch { get; set; }

    public long NroAsiento { get; set; }
}
