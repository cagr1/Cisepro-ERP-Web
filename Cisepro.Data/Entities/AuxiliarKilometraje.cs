using System;
using System.Collections.Generic;

namespace Cisepro.Data.Entities;

public partial class AuxiliarKilometraje
{
    public long IdAuxiliarKm { get; set; }

    public int KilometrajeAuxiliarKm { get; set; }

    public int IdActivoFijo { get; set; }

    public long IdControlC { get; set; }
}
