﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Cisepro.Data.DTOs.Auth
{
    public class AuthResponse
    {
        public string Token { get; set; }
        public UsuarioDTO Usuario { get; set; }
    }
}
