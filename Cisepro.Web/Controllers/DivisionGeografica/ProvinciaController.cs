using Cisepro.Data.Context;
using Cisepro.Data.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cisepro.Services.DivisionGeografica;

namespace Cisepro.Web.Controllers.DivisionGeografica
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciaController : ControllerBase
    {
        private readonly ProvinciaService _provinciaServices;

        public ProvinciaController(ProvinciaService provinciaServices)
        {
            _provinciaServices = provinciaServices;
        }

        [HttpGet("get-provincias")]
        public async Task<IActionResult> GetProvincias([FromQuery] TipoConexion TipoConexion)
        {
            try
            {
                var provincias = await _provinciaServices.SeleccionarTodosLosRegistrosProvinciasAsync(TipoConexion);
                return Ok(
                    new
                    {
                        success = true,
                        data = provincias
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
