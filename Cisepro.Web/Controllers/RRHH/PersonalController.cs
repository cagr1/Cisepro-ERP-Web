﻿using Cisepro.Services.Talento_Humano;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cisepro.Data.Enums;
using Cisepro.Data.Entities;

namespace Cisepro.Web.Controllers.RRHH
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalController : ControllerBase
    {
        private readonly PersonalService _personalService;

        public PersonalController(PersonalService personalService)
        {
            _personalService = personalService;
        }

        [HttpGet("Get-Personal")]
        public async Task<IActionResult> GetPersonal([FromQuery] TipoConexion tipoConexion, [FromQuery] string filtro, [FromQuery] int page =1, [FromQuery] int itemsPerPage = 20)
        {
            try
            {  

                var result = await _personalService.SelecccionarTodosLosRegistrosPersonalAsync(tipoConexion, filtro, page, itemsPerPage);

                var totalPages = result.TotalRecords > 0
                                ? (int)Math.Ceiling((double)result.TotalRecords / itemsPerPage)
                                : 0;

                var response = new
                {
                    success = true,
                    data = result.Data,
                    pagination = new
                    {
                        page,
                        itemsPerPage,
                        totalRecords = result.TotalRecords,
                        totalPages
                    },
                    filter = filtro
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


    }
}
