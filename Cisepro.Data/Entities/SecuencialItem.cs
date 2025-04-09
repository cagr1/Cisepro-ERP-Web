using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class SecuencialItem
{
    public long IdSecuencialItem { get; set; }

    public string CodigoSecuencialItem { get; set; } = null!;

    public string NombreSecuencialItem { get; set; } = null!;

    public DateTime FechaSecuencialItem { get; set; }

    public int IdMarca { get; set; }

    public int IdModelo { get; set; }

    public int IdMaterial { get; set; }

    public int IdColor { get; set; }

    public int IdUnidadMedida { get; set; }

    public string Descripcion { get; set; } = null!;

    public int EstadoSecuencialItem { get; set; }

    public long? IdLote { get; set; }

    public long IdSubGrupoItem { get; set; }

    public decimal Costo { get; set; }

    public decimal? Pvp { get; set; }

    public string? Serie { get; set; }

    public int? Descuento { get; set; }

    public virtual ICollection<DetalleOrdenCompra> DetalleOrdenCompras { get; set; } = new List<DetalleOrdenCompra>();

    public virtual Lote? IdLoteNavigation { get; set; }

    public virtual SubGrupoItem IdSubGrupoItemNavigation { get; set; } = null!;
}
