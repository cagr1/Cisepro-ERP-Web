using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cisepro.Data.Enums;
using Cisepro.Services.Talento_Humano;

namespace Cisepro.Web.Controllers.RRHH
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialController : ControllerBase
    {
        
        private readonly HistorialService _historialService;

        public HistorialController(HistorialService historialService)
        {
            _historialService = historialService;
        }

        [HttpGet("get-mayorHistorial")]
        public async Task<IActionResult> BuscarMayorIdHistorial([FromQuery] TipoConexion tipoCon)
        {
            try
            {
                var result = await _historialService.BuscarMayorIdHistorial(tipoCon);
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

        [HttpGet("get-historialPersonal")]
        public async Task<IActionResult> ObtenerHistorialPorIdPersonalAsync([FromQuery] TipoConexion tipoCon, [FromQuery] int idPersonal)
        {
            try
            {
            var result = await _historialService.ObtenerHistorialPorIdPersonalAsync(tipoCon, idPersonal);
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
