using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cisepro.Services.EstructuraEmpresa;
using Cisepro.Data.Enums;

namespace Cisepro.Web.Controllers.EstructuraEmpresa
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private readonly CargoService _cargoService;

        public CargoController(CargoService cargoService)
        {
            _cargoService = cargoService;
        }

        [HttpGet("get-Cargo")]
        public async Task<IActionResult> GetCargo([FromQuery] TipoConexion tipoConexion)
        {
            try
            {
                var result = await _cargoService.SeleccionarTodosRegistrosCargoAsync(tipoConexion);
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
