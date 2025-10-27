using Cisepro.Services.Talento_Humano;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cisepro.Services.Dashboard;
using Cisepro.Data.Enums;

namespace Cisepro.Web.Controllers.Dashboard
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly DashboardService _dashboardService;

        public DashboardController(DashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        //Endpoint para tabla finaciera
        [HttpGet("financial-table")]
        public async Task<IActionResult> GetFinancialTable([FromQuery] TipoConexion tipoConexion, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var result = await _dashboardService.GetTablaFinancieraAsync(tipoConexion, startDate, endDate);
                return Ok(result);
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


        //Endpoint para obtener guardias por canton
        [HttpGet("guardians-by-canton")]
        public async Task<IActionResult> GetGuardiansByCanton([FromQuery] TipoConexion tipoConexion)
        {
            try
            {
                var result = await _dashboardService.GetGuardiasPorCantonAsync(tipoConexion);
                return Ok(result);
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
