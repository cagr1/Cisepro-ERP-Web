using System;
using Cisepro.Data.Context;
using Cisepro.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Cisepro.Data.Enums;

namespace Cisepro.Services.EstructuraEmpresa
{
    public class AreaService
    {
        private readonly Func<TipoConexion, AppDbContext> _contextFactory;

        public AreaService(Func<TipoConexion, AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<int> BuscarMayorIdAreaAsync(TipoConexion tipoCon)
        {
            using var context = _contextFactory(tipoCon);
            return await context.AreaGenerals
                .MaxAsync(a => (int?)a.IdAreaGeneral) ?? 0;
        }

        public async Task<List<AreaGeneral>> SeleccionarTodosRegistrosAreaAsync(TipoConexion tipoCon)
        {
            using var context = _contextFactory(tipoCon);
            
            return await context.AreaGenerals
                .FromSqlRaw("SeleccionarTodosLosRegistrosArea")
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
