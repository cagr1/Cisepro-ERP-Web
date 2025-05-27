using System;
using Cisepro.Data.Context;
using Cisepro.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Cisepro.Data.Enums;
using Cisepro.Data.DTOs.TalentoHumano;
using System.Data;

namespace Cisepro.Services.Talento_Humano
{
    public class PersonalService
    {
        private readonly Func<TipoConexion, AppDbContext> _contextFactory;

        public PersonalService(Func<TipoConexion, AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<int> BuscarMayorIdPersonalAsync(TipoConexion tipoCon)
        {
            using var context = _contextFactory(tipoCon);
            return await context.Personals
                .MaxAsync(p => (int?)p.IdPersonal) ?? 0;
        }

        public async Task<PersonalResultDto> SelecccionarTodosLosRegistrosPersonalAsync(TipoConexion tipoCon, string filtro, int page =1, int itemsPerPage = 20)
        { 
          using var _context = _contextFactory(tipoCon);
           
          var parameters = new[]
            {
                new SqlParameter("@FILTRO", filtro),
                new SqlParameter("@PAGE", page),
                new SqlParameter("@ITEMSPERPAGE", itemsPerPage),
                
            };

            

            var results =  await _context.Personals
                .FromSqlRaw("SeleccionarTodosRegistrosPersonalFiltroTodos @FILTRO, @PAGE, @ITEMSPERPAGE", parameters)
                .AsNoTracking()
                .ToListAsync();

            int totalRecords = results.Count > 0 ? Convert.ToInt32(results[0].GetType().GetProperty("TotalRegistros").GetValue(results[0])) : 0;

            return new PersonalResultDto{
                Data = results,
                TotalRecords = totalRecords };
        }


    }
}
