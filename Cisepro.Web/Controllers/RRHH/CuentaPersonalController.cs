using Cisepro.Services.Talento_Humano;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cisepro.Data.Enums;



namespace Cisepro.Web.Controllers.RRHH
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaPersonalController : ControllerBase
    {
        private readonly CuentaPersonalService _cuentaPersonalService;

        public CuentaPersonalController(CuentaPersonalService cuentaPersonalService)
        {
            _cuentaPersonalService = cuentaPersonalService;
        }

        [HttpGet("get-cuenta-personal")]
        public async Task<IActionResult> ObtenerCuentaPersonal([FromQuery] TipoConexion tipoCon, [FromQuery] int idPersonal)
        {
            try
            {
                var result = await _cuentaPersonalService.SeleccionarCuenta(tipoCon, idPersonal);
                return Ok(
                    new
                    {
                        success = true,
                        data = result
                    });
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new
                    {
                        success = false,
                        message = ex.Message
                    });
            }
        }
    }
}
