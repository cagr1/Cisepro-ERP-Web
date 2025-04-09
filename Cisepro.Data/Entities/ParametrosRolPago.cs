using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class ParametrosRolPago
{
    public decimal SueldoVigilantes { get; set; }

    public decimal CostoHoras { get; set; }

    public decimal CostoHoras50 { get; set; }

    public decimal CostoHoras100 { get; set; }

    public decimal PorcenAportePatronal { get; set; }

    public decimal ProcenAportePersonal { get; set; }

    public decimal ProcentajeFondoReserva { get; set; }

    public decimal SueldoBasicoUnificado { get; set; }

    public decimal OtrosDescVigi { get; set; }

    public decimal OtrosDescAdmi { get; set; }

    public decimal AnticipoUtilidadMes { get; set; }

    public decimal ValorAnticipoGuardias { get; set; }

    public int QuinceAdSbEx { get; set; }

    public decimal PorcentajeDesMed { get; set; }

    public decimal PorcentajeExtSal { get; set; }
}
