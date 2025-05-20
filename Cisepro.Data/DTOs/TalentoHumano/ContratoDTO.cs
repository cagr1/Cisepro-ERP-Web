using System;
using Cisepro.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Cisepro.Data.DTOs.TalentoHumano
{
    public class ContratoDTO
    {
        public int IdContrato { get; set; }
        public long NroContrato { get; set; }
        public string? Nomina { get; set; }
        public string? Descripcion { get; set; }
        
        public string? Area { get; set; }
        
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string? Periodo { get; set; }
        public int TipoContrato { get; set; }
        public string? Estado { get; set; }
        public  int Iess { get; set; }

        public DateTime FechaAfiliacion { get; set; }
        
        public int ReservaRol { get; set; }

        public int XIII { get; set; }

        public int XIV { get; set; }

        public string? Observaciones { get; set; }

        public decimal Rec_Extra { get; set; }

        public int Acu_fondo { get; set; }

        public int Desc_Seg { get; set; } 

        public int IdProyecto { get; set; }

        
    }
}
