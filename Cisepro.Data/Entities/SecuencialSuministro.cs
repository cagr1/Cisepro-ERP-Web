using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class SecuencialSuministro
{
    public int IdSecuencialSuministros { get; set; }

    public string NombreSecuencialSuministros { get; set; } = null!;

    public string MarcaSecuencialSuministros { get; set; } = null!;

    public string ModeloSecuencialSuministros { get; set; } = null!;

    public string DetalleSecuencialSuministros { get; set; } = null!;

    public decimal PreciouSecuencialSuministros { get; set; }

    public int StockSecuencialSuministros { get; set; }

    public int EstadoSecuencialSuministros { get; set; }

    public int IdSubgrupoSuministros { get; set; }

    public int IdUnidadMedida { get; set; }

    public int CategoriaSec { get; set; }

    public int GrupoSec { get; set; }

    public int SubgrupoSec { get; set; }

    public int SecuencialSec { get; set; }

    public virtual SubgrupoSuministro IdSubgrupoSuministrosNavigation { get; set; } = null!;

    public virtual UnidadMedidum IdUnidadMedidaNavigation { get; set; } = null!;
}
