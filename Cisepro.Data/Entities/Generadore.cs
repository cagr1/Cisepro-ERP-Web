﻿using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class Generadore
{
    public int IdActivoFijo { get; set; }

    public string Marca { get; set; } = null!;

    public string Modelo { get; set; } = null!;

    public string EstadoActivo { get; set; } = null!;

    public string Color { get; set; } = null!;

    public string Serie { get; set; } = null!;

    public string Material { get; set; } = null!;

    public int Amperaje { get; set; }

    public int Voltaje { get; set; }

    public string Tipo { get; set; } = null!;

    public int Ano { get; set; }

    public string Adicionales { get; set; } = null!;

    public int Estado { get; set; }

    public virtual ActivoFijoGeneral IdActivoFijoNavigation { get; set; } = null!;
}
