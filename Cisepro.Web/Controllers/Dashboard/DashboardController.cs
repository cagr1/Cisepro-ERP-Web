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

        //Endpoint to get sales per year
        [HttpGet("sales/by-date")]
        public async Task<IActionResult> GetSalesData([FromQuery] TipoConexion tipoConexion, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var result = await _dashboardService.GetSalesDataRangeAsync(tipoConexion, startDate, endDate);
                var response = new
                {
                    success = true,
                    data = result

                };
                
                return Ok(response);
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

        // Endpoint para ventas acumuladas
        [HttpGet("sales/accumulated")]
        public async Task<IActionResult> GetSalesAccumulated([FromQuery] TipoConexion tipoConexion, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var result = await _dashboardService.GetAccumulatedSalesDataAsync(tipoConexion, endDate);
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

        //Endpoint para obtener variación de ingresos
        [HttpGet("variation/income")]
        public async Task<IActionResult> GetIncomeVariation([FromQuery] TipoConexion tipoConexion, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var result = await _dashboardService.GetVariationIncomeAsync(tipoConexion, startDate, endDate);
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

        //Endpoint para obtener ingresos anuales
        [HttpGet("annual-earnings")]

        public async Task<IActionResult> GetAnnualEarnings([FromQuery] TipoConexion tipoConexion, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var result = await _dashboardService.GetAnnualEarningsAsync(tipoConexion, startDate, endDate);
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

        //Endpoint para obtener ingresos acumulados
        [HttpGet("accumulated-earnings")]

        public async Task<IActionResult> GetAccumulatedEarnings([FromQuery] TipoConexion tipoConexion, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var result = await _dashboardService.GetEarningAccumulatedAsync(tipoConexion, endDate);
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

        //Endpoint para variacion de Utlidades
        [HttpGet("variation/profit")]

        public async Task<IActionResult> GetProfitVariation([FromQuery] TipoConexion tipoConexion, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var result = await _dashboardService.GetVariationProfitAsync(tipoConexion, startDate, endDate);
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

        //Endpoint para obtener reporte de Ingresos, Egresos y Utilidades
        [HttpGet("profit-loss-byMonth")]

        public async Task<IActionResult> GetProfitLossByMonth([FromQuery] TipoConexion tipoConexion, [FromQuery] int year)
        {
            try
            {
                var result = await _dashboardService.GetAccumulatedProfitLossEarningsAsync(tipoConexion,year);
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

        //Endpoint para obtener varaicion anual de ingresos
        [HttpGet("variation/annual-revenues")]

        public async Task<IActionResult> GetVariationAnnualRevenues([FromQuery] TipoConexion tipoConexion, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var result = await _dashboardService.GetAnnualVariationRevenuesAsync(tipoConexion, startDate, endDate);
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

        //Endpoint para obtener ventas por categoria
        [HttpGet("sales-by-category")]

        public async Task<IActionResult> GetSalesByCategory([FromQuery] TipoConexion tipoConexion, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var result = await _dashboardService.GetSalesbyCategoriesAsync(tipoConexion, startDate, endDate);
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

        //Endpoint para obtener margen de utilidad
        [HttpGet("margin-earnings")]
        public async Task<IActionResult> GetMarginEarnings([FromQuery] TipoConexion tipoConexion, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var result = await _dashboardService.GetMarginEarningsAsync(tipoConexion, startDate, endDate);
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

        //Endpoint para obtener liquidez
        [HttpGet("liquidity-ratio")]

        public async Task<IActionResult> GetLiquidityRatio([FromQuery] TipoConexion tipoConexion, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var result = await _dashboardService.GetLiquidityRatioAsync(tipoConexion, startDate, endDate);
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
