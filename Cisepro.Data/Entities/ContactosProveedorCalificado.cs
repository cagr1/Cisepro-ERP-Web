using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class ContactosProveedorCalificado
{
    public int IdContactoProveedorCalificado { get; set; }

    public string NombresContactoProveedorCalificado { get; set; } = null!;

    public string ApellidosContactoProveedorCalificado { get; set; } = null!;

    public string CargoContactoProveedorCalificado { get; set; } = null!;

    public string TelefonoContactoProveedorCalificado { get; set; } = null!;

    public string CelularContactoProveedorCalificado { get; set; } = null!;

    public string EmailContactoProveedorCalificado { get; set; } = null!;

    public int EstadoContactoProveedorCalificado { get; set; }

    public int IdProveedorGeneral { get; set; }
}
