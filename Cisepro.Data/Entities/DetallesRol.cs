using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class DetallesRol
{
    public string? Grupo { get; set; }

    public int? IdPersonal { get; set; }

    public int? Num { get; set; }

    public string? Cliente { get; set; }

    public string? Ubicacion { get; set; }

    public string? Nomina { get; set; }

    public string? Cedula { get; set; }

    public DateTime? Ingreso { get; set; }

    public string? Cargo { get; set; }

    public string? Area { get; set; }

    public decimal? Sueldob { get; set; }

    public int? Diast { get; set; }

    public decimal? Sueldodt { get; set; }

    public int? Diasdm { get; set; }

    public decimal? Sueldodm { get; set; }

    public decimal? Sueldodtdm { get; set; }

    public decimal? Hnor { get; set; }

    public decimal? CosHnor { get; set; }

    public decimal? TotHnor { get; set; }

    public decimal? Hsup { get; set; }

    public decimal? CosHsup { get; set; }

    public decimal? TotHsup { get; set; }

    public decimal? Hext { get; set; }

    public decimal? CosHext { get; set; }

    public decimal? TotHext { get; set; }

    public decimal? Hextf { get; set; }

    public decimal? CosHextf { get; set; }

    public decimal? TotHextf { get; set; }

    public decimal? RecNoturno { get; set; }

    public decimal? Adicional { get; set; }

    public decimal? OtIng { get; set; }

    public decimal? TotExt { get; set; }

    public decimal? IngExt { get; set; }

    public decimal? Xiii { get; set; }

    public decimal? XiiiPension { get; set; }

    public decimal? Xiv { get; set; }

    public decimal? XivPension { get; set; }

    public decimal? FonRes { get; set; }

    public decimal? FonResAnt { get; set; }

    public decimal? TotBen { get; set; }

    public decimal? TotIng { get; set; }

    public string? Espacio { get; set; }

    public decimal? DescIess { get; set; }

    public decimal? QuinAnte { get; set; }

    public decimal? DescQuir { get; set; }

    public decimal? DescHip { get; set; }

    public decimal? DescExsc { get; set; }

    public decimal? AntEme { get; set; }

    public decimal? DescCapa { get; set; }

    public decimal? AntVari { get; set; }

    public decimal? DescPrem { get; set; }

    public decimal? DescComc { get; set; }

    public decimal? DescComi { get; set; }

    public decimal? DescEquip { get; set; }

    public decimal? DescPension { get; set; }

    public decimal? DescVivi { get; set; }

    public decimal? DescMultas { get; set; }

    public decimal? OtDesc { get; set; }

    public decimal? TotDesc { get; set; }

    public decimal? NetoRol { get; set; }

    public decimal? Extra { get; set; }

    public int Fonres { get; set; }

    public int Xiiirol { get; set; }

    public int Xivrol { get; set; }

    public int Acufor { get; set; }

    public int Deseg { get; set; }

    public int Xiisex { get; set; }

    public int Forsex { get; set; }

    public int? IdBanco { get; set; }

    public string? Banco { get; set; }

    public string? Cuenta { get; set; }

    public string? TipoBanco { get; set; }

    public int? Est { get; set; }

    public int IdRol { get; set; }

    public int IdDetaRol { get; set; }

    public int? Tipo { get; set; }

    public DateTime? FNacim { get; set; }

    public string? Ciudad { get; set; }

    public decimal ValAcumFonRes { get; set; }

    public decimal DescAlmuerzo { get; set; }

    public int Extsal { get; set; }

    public decimal? DescDiasnolab { get; set; }

    public decimal? DifDecFon { get; set; }

    public int? Extedit { get; set; }

    public virtual RolPago IdRolNavigation { get; set; } = null!;
}
