using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class RolPago
{
    public int IdRol { get; set; }

    public DateTime FechaElab { get; set; }

    public int MesRol { get; set; }

    public int AnioRol { get; set; }

    public int Quincena { get; set; }

    public DateTime Desde { get; set; }

    public DateTime Hasta { get; set; }

    public int Estado { get; set; }

    public string? Observacion { get; set; }

    public DateTime? FechaVal { get; set; }

    public int? Tipo { get; set; }

    public int Auxfil { get; set; }

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

    public string? Retenidos { get; set; }

    public string Grupo { get; set; } = null!;

    public decimal PorcentajeDesMed { get; set; }

    public decimal PorcentajeExtSal { get; set; }

    public virtual ICollection<DetallesRol> DetallesRols { get; set; } = new List<DetallesRol>();
}
