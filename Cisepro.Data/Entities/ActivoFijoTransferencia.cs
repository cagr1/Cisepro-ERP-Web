using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class ActivoFijoTransferencia
{
    public long IdTransferencia { get; set; }

    public DateTime Fecha { get; set; }

    public int IdPersonalAnterior { get; set; }

    public int IdPersonalNuevo { get; set; }

    public string NombreAutoriza { get; set; } = null!;

    public string Razon { get; set; } = null!;

    public string UbicacionAnterior { get; set; } = null!;

    public string CustodioAnterior { get; set; } = null!;

    public string UbicacionNueva { get; set; } = null!;

    public string CustodioNuevo { get; set; } = null!;

    public int Estado { get; set; }
}
