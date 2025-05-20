using Cisepro.Services.EstructuraEmpresa;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cisepro.Data.Enums;

namespace Cisepro.Web.Controllers.EstructuraEmpresa
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly AreaService _areaService;

        public AreaController(AreaService areaService)
        {
            _areaService = areaService;
        }

        [HttpGet("get-Area")]
        public async Task<IActionResult> GetArea([FromQuery] TipoConexion tipoConexion )
        {
            try
            {
                var result = await _areaService.SeleccionarTodosRegistrosAreaAsync(tipoConexion);
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
