using System;
using Cisepro.Data.Context;
using Cisepro.Data.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Cisepro.Data.Enums;

namespace Cisepro.Services.DivisionGeografica
{
    public class ParroquiaService
    {
        private readonly Func<TipoConexion, AppDbContext> _contextFactory;

        public ParroquiaService(Func<TipoConexion, AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<int> BuscarMayorIdParroquiaAsync(TipoConexion tipoCon)
        {
            using var context = _contextFactory(tipoCon);
            return await context.Parroquias
                .MaxAsync(p => (int?)p.IdParroquias) ?? 0;
        }

        public async Task<List<Parroquia>> BuscarParroquiaXIdCiudadAsync(int idCiudad, TipoConexion tipoCon)
        {
            var param = new SqlParameter("@ID_CIUDAD", idCiudad);
            using var context = _contextFactory(tipoCon);
            return await context.Parroquias
                .FromSqlRaw("EXEC BuscarNombreParroquiaXIdCiudades @ID_CIUDAD")
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<int> NuevaParroquiaAsync(Parroquia parroquia, TipoConexion tipoCon)
        {
            using var context = _contextFactory(tipoCon);

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@ID_PARROQUIAS", parroquia.IdParroquias),
                new SqlParameter("@NOMBRE_PARROQUIAS", parroquia.NombreParroquias),
                new SqlParameter("@ESTADO_PARROQUIAS", parroquia.EstadoParroquias),
                new SqlParameter("@ID_CIUDAD", parroquia.IdCiudad)
                
            };

            return await context.Database
                .ExecuteSqlRawAsync("EXEC NuevaParroquia @ID_PARROQUIA, @NOMBRE_PARROQUIA, @ESTADO_PARROQUIA, @ID_CIUDAD ", parameters);
        }

        public async Task<int> ActualizarParroquiaAsync(Parroquia parroquia, TipoConexion tipoCon)
        {
            using var context = _contextFactory(tipoCon);

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@ID_PARROQUIAS", parroquia.IdParroquias),
                new SqlParameter("@NOMBRE_PARROQUIAS", parroquia.NombreParroquias)                

            };

            return await context.Database
                .ExecuteSqlRawAsync("EXEC ActualizarParroquia @ID_PARROQUIA, @NOMBRE_PARROQUIAS ", parameters);
        }


    }
}
