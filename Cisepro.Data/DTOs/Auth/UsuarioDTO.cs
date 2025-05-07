using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cisepro.Data.DTOs.Auth
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Datos { get; set; }
        public int Rol { get; set; }
    }
}
