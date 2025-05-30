using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cisepro.Services.Talento_Humano;
using Cisepro.Data.Enums;

namespace Cisepro.Web.Controllers.RRHH
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoController : ControllerBase
    {
        private readonly ContratoService _contratoService;

        public ContratoController(ContratoService contratoService)
        {
            _contratoService = contratoService;
        }

        [HttpGet("Get-Personal-Contrato")]
        public async Task<IActionResult> GetContratos([FromQuery] TipoConexion tipoConexion, [FromQuery] bool estado)
        {
            try
            {
                var result = await _contratoService.SeleccionarTodosLosRegistrosProyectosAsync(tipoConexion, estado);
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

        [HttpGet("Get-Contrato-PorPersonal")]
        public async Task<IActionResult> ObtenerContratoPorPersonal([FromQuery] TipoConexion tipoConexion, [FromQuery] int id)
        {
            try
            {
                var result = await _contratoService.ObtenerContratoXIdpersonalAsync(tipoConexion, id);
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
