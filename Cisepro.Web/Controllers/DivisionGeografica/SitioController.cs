using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cisepro.Data.Enums;
using Microsoft.AspNetCore.Http;
using Cisepro.Services.DivisionGeografica;

namespace Cisepro.Web.Controllers.DivisionGeografica
{
    [Route("api/[controller]")]
    [ApiController]
    public class SitioController : ControllerBase
    {
        private readonly SitioService _sitioServices;

        public SitioController(SitioService sitioServices)
        {
            _sitioServices = sitioServices;
        }

        [HttpGet("get-sitios")]
        public async Task<IActionResult> GetSitios([FromQuery] TipoConexion TipoConexion)
        {
            try
            {
                var sitios = await _sitioServices.SeleccionarTodosRegistrosSitioAsync(TipoConexion);
                return Ok(
                    new
                    {
                        success = true,
                        data = sitios
                    });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }

        [HttpGet("get-sitio-por-nombre")]
        public async Task<IActionResult> GetSitiosXNombre([FromQuery] TipoConexion TipoConexion, [FromQuery] int id)
        {
            try
            {
                var sitios = await _sitioServices.BuscarNombreSitioXIdAsync(TipoConexion, id);
                return Ok(
                    new
                    {
                        success = true,
                        data = sitios
                    });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }
    }
}
