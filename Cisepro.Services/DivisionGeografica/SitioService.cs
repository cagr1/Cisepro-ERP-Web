using System;
using Cisepro.Data.Context;
using Cisepro.Data.Entities;
using Cisepro.Data.DTOs.EstrcuturaEmpresa;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Cisepro.Data.Enums;

namespace Cisepro.Services.DivisionGeografica
{
    public class SitioService
    {
        private readonly Func<TipoConexion, AppDbContext> _contextFactory;

        public SitioService(Func<TipoConexion, AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<int> BuscarMayorIdSitioAsync(TipoConexion tipoCon)
        {
            using var context = _contextFactory(tipoCon);
            return await context.SitiosTrabajos
                .MaxAsync(s => (int?)s.IdSitioTrabajo) ?? 0;
        }

        public async Task<List<SitiosTrabajo>> SeleccionarTodosRegistrosSitioAsync(TipoConexion tipoCon)
        {
            using var context = _contextFactory(tipoCon);
            return await context.SitiosTrabajos
                .FromSqlRaw("EXEC SeleccionarSitios")
                .AsNoTracking()
                .AsSplitQuery()
                .ToListAsync();
        }
        
        
        public async Task<List<SitioDTO>> BuscarNombreSitioMinAsync(TipoConexion tipoCon)
        {
            using var context = _contextFactory(tipoCon);

             return await context.Database
                .SqlQueryRaw<SitioDTO>("EXEC SP_BuscarSitioMin")
                .AsNoTracking()
                .ToListAsync();       


            
        }
    }
}
