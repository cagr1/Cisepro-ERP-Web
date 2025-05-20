using System;
using System.Text;
using System.Threading.Tasks;
using Cisepro.Data.Context;
using Cisepro.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Cisepro.Data.Enums;
using Cisepro.Data.DTOs;

namespace Cisepro.Services.DivisionGeografica
{
    public class CiudadService : ICiudadService
    {
        private readonly Func<TipoConexion, AppDbContext> _contextFactory;

        public CiudadService(Func<TipoConexion, AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<int> BuscarMayorIdAsync(TipoConexion tipoCon)
        {
            using var context = _contextFactory(tipoCon);
            return await context.Ciudades
                .MaxAsync(c => (int?)c.IdCiudad) ?? 0;
        }

        public async Task<List<Ciudade>> BuscarNombreCiuydadesXIdProvinciasAsync(int idProvincia, TipoConexion tipoCon)
        {
            using var context = _contextFactory(tipoCon);

            var param = new SqlParameter("@ID_PROVINCIAS", idProvincia);

            var ciudades = await context.Ciudades
                .FromSqlRaw("EXEC BuscarNombreCiudadesXIdProvincia @ID_PROVINCIAS", param)
                .AsNoTracking()
                .ToListAsync();

            return ciudades;
        }

        public async Task<int> NuevoCiudadAsync(Ciudade ciudad, TipoConexion tipoCon)
        {
            using var context = _contextFactory(tipoCon);

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@ID_CIUDAD", ciudad.IdCiudad),
                new SqlParameter("@NOMBRE_CIUDADES", ciudad.NombreCiudades),
                new SqlParameter("@ID_PROVINCIAS", ciudad.IdProvincias),
                new SqlParameter("@ESTADO_CIUDADES", ciudad.EstadoCiudades)
            };

            return await context.Database
                .ExecuteSqlRawAsync("EXEC NuevaCiudad @ID_CIUDAD, @NOMBRE_CIUDADES, @ID_PROVINCIAS, @ESTADO_CIUDADES", parameters);
        }

        public async Task<int> ActualizarCiudadAsync(Ciudade ciudad, TipoConexion tipoCon)
        {
            using var context = _contextFactory(tipoCon);

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@ID_CIUDAD", ciudad.IdCiudad),
                new SqlParameter("@NOMBRE_CIUDADES", ciudad.NombreCiudades),

            };

            return await context.Database
                .ExecuteSqlRawAsync("EXEC ActualizarCiudad @ID_CIUDAD, @NOMBRE_CIUDADES", parameters);

        }


    }
}
