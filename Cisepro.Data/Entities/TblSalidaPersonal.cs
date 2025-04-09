using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class TblSalidaPersonal
{
    public int IdSalida { get; set; }

    public int IdPersonal { get; set; }

    public int? CertificadoMedico { get; set; }

    public int? Uniformes { get; set; }

    public int? Roles { get; set; }

    public int? Credencial { get; set; }

    public string? Observarciones { get; set; }

    public DateTime FechaSalida { get; set; }

    public int? Estado { get; set; }
}
