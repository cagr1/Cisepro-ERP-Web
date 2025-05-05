using Cisepro.Services.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cisepro.Data.Enums;
using Cisepro.Data.DTOs.Auth;

namespace Cisepro.Web.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] AuthRequest request)
        {
            var tipoConexion = request.TipoConexion;

            var response = _authService.Authenticate(tipoConexion, request);
            
            if (response == null)
                return Unauthorized(new
                {
                    success = false,
                    message = "Credenciales incorrectas"
                });

            return Ok(new
                {
                success = true,
                message = "Autenticación exitosa"
                });
            }
        }
    }

