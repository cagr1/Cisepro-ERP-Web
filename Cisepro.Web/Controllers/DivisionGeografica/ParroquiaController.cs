using Cisepro.Services.DivisionGeografica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cisepro.Data.Enums;



namespace Cisepro.Web.Controllers.DivisionGeografica
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParroquiaController : ControllerBase
    {
        private readonly ParroquiaService _parroquiaService;

        public ParroquiaController(ParroquiaService parroquiaServices)
        {
            _parroquiaService = parroquiaServices;
        }

        [HttpGet("get-parroquias")]

        public async Task<IActionResult> GetParroquias([FromQuery] TipoConexion TipoConexion, [FromQuery] int idCiudad)
        {
            try
            {
                var parroquias = await _parroquiaService.BuscarParroquiaXIdCiudadAsync(TipoConexion, idCiudad);
                return Ok(
                    new
                    {
                        success = true,
                        data = parroquias
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
