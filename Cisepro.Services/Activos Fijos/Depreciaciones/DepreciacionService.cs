
using Cisepro.Data;
using Cisepro.Data.Context;
using Cisepro.Data.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Cisepro.Data.Enums;
using Cisepro.Data.DTOs;

namespace Cisepro.Services.Activos_Fijos.Depreciaciones
{
    public class DepreciacionService
    {
        private readonly Func<TipoConexion, AppDbContext> _contextFactory;
        public DepreciacionService(Func<TipoConexion, AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<int> NuevaDepreciacionGeneralAsync(TipoConexion tipoCon, DepreciacionesGeneral dto)
        {
            using var _context = _contextFactory(tipoCon);                

            var parameters = new[] {
                new SqlParameter("@ID_DEPRECIACION", dto.IdDepreciacion),
                new SqlParameter ("@ID_ACTIVO_FIJO", dto.IdActivoFijo),
                new SqlParameter("@PORCENTAJE", dto.Porcentaje),
                new SqlParameter("@CUENTA_CONTABLE", dto.CuentaContable),
                new SqlParameter("@TOPE_DEPRECIACIONES", dto.TopeDepreciaciones),
                new SqlParameter("@ESTADO", dto.Estado)
            
            };
            
           var result = await _context.Database
                .ExecuteSqlRawAsync("EXEC nuevaDepreciacionGeneral @ID_DEPRECIACION, @ID_ACTIVO_FIJO, @PORCENTAJE, @CUENTA_CONTABLE, @TOPE_DEPRECIACIONES, @ESTADO", parameters);
           
            return result;
        }

        public async Task<int> BuscarMayorIddepre(TipoConexion tipoCon)

        {
            using var _context = _contextFactory(tipoCon);
            return await _context.DepreciacionesGenerals
                .MaxAsync(d => (int?)d.IdDepreciacion) ?? 0;
        }

        public async Task<List<DepreciacionesGeneral>> BuscarActivoFijoPorIdActivoEnDepreciacionGeneralAsync(TipoConexion tipoCon, string filtro, DateTime desde, DateTime hasta )
        {
            var _context = _contextFactory(tipoCon);
            var parameters = new[]
            {
                new SqlParameter("@FILTRO", filtro),
                new SqlParameter("@DESDE", desde),
                new SqlParameter("@HASTA", hasta)
            };
            return await _context.DepreciacionesGenerals
                .FromSqlRaw("EXEC sp_SeleccionDepreciacionGeneralxFiltro @filtro, @desde, @hasta", parameters)
                .ToListAsync();
        }

        public async Task<DepreciacionCompletaDto> BuscardepreciacionporIdActivo(TipoConexion tipoCon, int idActivo)
        {
            using var _context = _contextFactory(tipoCon);

            return new DepreciacionCompletaDto
            {
                Depreciaciones = await _context.DepreciacionesGenerals
                .Where(d => d.Estado == 1 && d.IdActivoFijo == idActivo)
                .ToListAsync(),

                Detalles = await _context.DetalleDepreciacions
                .Where(d => d.Estado == 1)
                .ToListAsync(),

                ActivosFijos = await _context.ActivoFijoGenerals
                .Where(a => a.Estado == 1)
                .ToListAsync()

            };           
            
        }

        public async Task<List<RegistroDepreciaciones>> SeleccionarTodosLosRegistrosDepreciaciones(TipoConexion tipoCon )
        {
            using var context = _contextFactory(tipoCon);
            
            return await context.RegistroDepreciaciones
                .FromSqlRaw("EXEC seleccionarTodasLosRegistrosDepreciaciones")
                .AsNoTracking()
                .ToListAsync();
        }





    }

}

