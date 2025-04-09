using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class DocumentoNodeducible
{
    public long IdDocumentoNodeducible { get; set; }

    public string NumeroDocumentoNodeducible { get; set; } = null!;

    public DateTime FechaDocumentoNodeducible { get; set; }

    public string DescripcionDocumentoNodeducible { get; set; } = null!;

    public decimal ValorDocumentoNodeducible { get; set; }

    public int EstadoDocumentoNodeducible { get; set; }

    public int IdParametroDocumentos { get; set; }

    public long? IdSolicitudFr { get; set; }

    public long? IdSolicitudCch { get; set; }

    public virtual PrametrosDocumento IdParametroDocumentosNavigation { get; set; } = null!;
}
