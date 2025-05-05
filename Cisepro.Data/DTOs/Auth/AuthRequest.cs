using Cisepro.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cisepro.Data.DTOs.Auth
{
    public class AuthRequest
    {
        public TipoConexion TipoConexion { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
