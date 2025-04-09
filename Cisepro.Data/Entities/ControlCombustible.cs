using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class ControlCombustible
{
    public long IdControlC { get; set; }

    public DateTime FechaControlC { get; set; }

    public decimal ValorControlC { get; set; }

    public string DestinoControlC { get; set; } = null!;

    public int TotalKmControlC { get; set; }

    public int EstadoControlC { get; set; }

    public string MotivoControlC { get; set; } = null!;

    public long? IdSolicitudFr { get; set; }

    public long? IdSolicitudCch { get; set; }

    public int IdAcivoFijo { get; set; }

    public int? IdGastosFr { get; set; }

    public int? IdGastosCch { get; set; }

    public int? IdResponsableAutoFr { get; set; }

    public int? IdResponsableAutoCch { get; set; }

    public int IdPersonal { get; set; }

    public int IdRubro { get; set; }

    public long IdSalidaV { get; set; }

    public long IdLlegadaV { get; set; }

    public virtual LlegadaVehiculo IdLlegadaVNavigation { get; set; } = null!;

    public virtual SalidaVehiculo IdSalidaVNavigation { get; set; } = null!;
}
