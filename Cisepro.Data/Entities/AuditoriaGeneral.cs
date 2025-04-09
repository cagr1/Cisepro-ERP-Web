using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class AuditoriaGeneral
{
    public long IdAuditoriaGeneral { get; set; }

    public int IdUsuario { get; set; }

    public string Formulario { get; set; } = null!;

    public string Accion { get; set; } = null!;

    public DateTime FechaAuditoriaGeneral { get; set; }

    public int EstadoAuditoriaGeneral { get; set; }

    public virtual UsuarioGeneral IdUsuarioNavigation { get; set; } = null!;
}
