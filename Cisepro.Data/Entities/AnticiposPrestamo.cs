using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class AnticiposPrestamo
{
    public int IdAntipres { get; set; }

    public DateTime Fecha { get; set; }

    public string Tipo { get; set; } = null!;

    public string Forma { get; set; } = null!;

    public decimal Valor { get; set; }

    public int IdPersonal { get; set; }

    public int Estado { get; set; }

    public string? Detalle { get; set; }

    public int Diferido { get; set; }

    public int Interes { get; set; }

    public decimal ValCuota { get; set; }

    public int SaldoCuotas { get; set; }

    public decimal SaldoTotal { get; set; }

    public int IdfrIdeg { get; set; }
}
