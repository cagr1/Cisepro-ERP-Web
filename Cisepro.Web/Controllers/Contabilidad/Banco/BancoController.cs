using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cisepro.Data.Enums;
using Cisepro.Services.Contabilidad.Bancos;

namespace Cisepro.Web.Controllers.Contabilidad.Banco
{
    [Route("api/[controller]")]
    [ApiController]
    public class BancoController : ControllerBase
    {
        private readonly BancoService _bancoService;

        public BancoController(BancoService bancoService)
        {
            _bancoService = bancoService;
        }

        [HttpGet("get-bancos")]
        public async Task<IActionResult> GetBancos([FromQuery] TipoConexion tipoConexion)
        {
            try
            {
                var bancos = await _bancoService.SeleccionarBancosAsync(tipoConexion);
                return Ok(
                    new
                    {
                        success = true,
                        data = bancos
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
