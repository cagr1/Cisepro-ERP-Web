using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class PrametrosDocumento
{
    public int IdParametroDocumentos { get; set; }

    public string NombreParametroDocumentos { get; set; } = null!;

    public string TipoParametroDocumentos { get; set; } = null!;

    public int EstadoParametroDocumentos { get; set; }

    public virtual ICollection<DocumentoNodeducible> DocumentoNodeducibles { get; set; } = new List<DocumentoNodeducible>();
}
