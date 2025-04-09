using Cisepro.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cisepro.Data.DTOs
{
    public class DepreciacionCompletaDto
    {
        public List<DepreciacionesGeneral> Depreciaciones { get; set; }
        public List<DetalleDepreciacion> Detalles { get; set; }
        public List<ActivoFijoGeneral> ActivosFijos { get; set; }
    }

    public class RegistroDepreciaciones
    {
        public int IdDepreciacion { get; set; }
        public int IdActivoFijo { get; set; }
        public decimal Porcentaje { get; set; }
        public string CuentaContable { get; set; }
        public int TopeDepreciaciones { get; set; }
        public string CodigoActivo { get; set; }
        public string NombreActivo { get; set; }
    }
}
