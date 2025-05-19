using System;
using Cisepro.Data.Context;
using Cisepro.Data.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Cisepro.Data.Enums;
using Cisepro.Data.DTOs;

namespace Cisepro.Services.DivisionGeografica
{
    public class ProvinciaServices
    {
        private readonly Func<TipoConexion, AppDbContext> _contextFactory;

        public ProvinciaServices(Func<TipoConexion, AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<int> BuscarMayorIdProvinciaAsync(TipoConexion tipoCon)
        {
            using var context = _contextFactory(tipoCon);
            return await context.Provincias
                .MaxAsync(p => (int?)p.IdProvincias) ?? 0;
        }

        public async Task<List<Provincia>> SeleccionarTodosLosRegistrosProvinciasAsync(TipoConexion tipoCon)
        {
            using var context = _contextFactory(tipoCon);
            return await context.Provincias
                .FromSqlRaw("EXEC SeleccionarTodosLosRegistrosProvincias")
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<int> NuevaProvinciaAsync(Provincia provincia, TipoConexion tipoCon)
        {
            using var context = _contextFactory(tipoCon);

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@ID_PROVINCIA", provincia.IdProvincias),
                new SqlParameter("@NOMBRE_PROVINCIAS", provincia.NombreProvincias),
                
            };

            return await context.Database
                .ExecuteSqlRawAsync("EXEC NuevaProvincia @ID_PROVINCIA, @NOMBRE_PROVINCIAS", parameters);
        }

        public async Task<int> ActualizarProvinciaAsync(Provincia provincia, TipoConexion tipoCon)
        {
            using var context = _contextFactory(tipoCon);

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@ID_PROVINCIA", provincia.IdProvincias),
                new SqlParameter("@NOMBRE_PROVINCIAS", provincia.NombreProvincias),
         
            };

            return await context.Database
                .ExecuteSqlRawAsync("EXEC ActualizarProvincia @ID_PROVINCIA, @NOMBRE_PROVINCIA, @ESTADO_PROVINCIA", parameters);
        }





    }
}
