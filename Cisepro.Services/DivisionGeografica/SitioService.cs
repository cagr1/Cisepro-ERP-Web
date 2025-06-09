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
                .FromSqlRaw("SeleccionarSitios")
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<SitioDTO>> BuscarNombreSitioXIdAsync(TipoConexion tipoCon, int id)
        {
            using var context = _contextFactory(tipoCon);

            var param = new SqlParameter("@ID_SITIO_TRABAJO", id);

            var nombres = await context.Database
                .SqlQueryRaw<string>("EXEC BuscarNombreSitioXIdSitio @ID_SITIO_TRABAJO", param)
                .ToListAsync();


            return nombres.Select(n => new SitioDTO 
            { 
                Id_Sitio_trabajo = id,
                Nombre_Sitio_trabajo = n
            }).ToList();


            
        }
    }
}
