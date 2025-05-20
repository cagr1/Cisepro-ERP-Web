using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cisepro.Data.Enums;
using Cisepro.Data.DTOs.Auth;
using Cisepro.Services.DivisionGeografica;


namespace Cisepro.Web.Controllers.DivisionGeografica
{
    [Route("api/[controller]")]
    [ApiController]
    
    
    public class CiudadController : ControllerBase
    {
        private readonly CiudadService _ciudadServices;

        public CiudadController(CiudadService ciudadServices)
        {
            _ciudadServices = ciudadServices;
        }

        [HttpGet("get-ciudad-por-provincia")]
        public async Task<IActionResult> GetCiudades([FromQuery] TipoConexion TipoConexion, [FromQuery] int idProvincia)
        {
            try
            {
                var ciudades = await _ciudadServices.BuscarNombreCiuydadesXIdProvinciasAsync(idProvincia, TipoConexion);
                return Ok(
                    new
                    {
                        success = true,
                        data = ciudades
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
