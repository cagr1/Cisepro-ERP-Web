using System;
using Cisepro.Data.Context;
using Cisepro.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Cisepro.Data.Enums;

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

        public async Task<List<Personal>> SelecccionarTodosLosRegistrosPersonalAsync(TipoConexion tipoCon, string filtro, int page =1, int itemsPerPage = 20)
        { 
          using var _context = _contextFactory(tipoCon);
           
          var parameters = new[]
            {
                new SqlParameter("@FILTRO", filtro),
                new SqlParameter("@PAGE", page),
                new SqlParameter("@ITEMSPERPAGE", itemsPerPage)
            };

            

            return await _context.Personals
                .FromSqlRaw("SeleccionarTodosRegistrosPersonalFiltroTodos @FILTRO, @PAGE, @ITEMSPERPAGE", parameters)
                .AsNoTracking()
                .ToListAsync();
        }


    }
}
