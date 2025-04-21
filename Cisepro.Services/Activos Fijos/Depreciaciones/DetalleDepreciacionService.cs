using Cisepro.Data.Context;
using Cisepro.Data.Entities;
using Cisepro.Data.Enums;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace Cisepro.Services.Activos_Fijos.Depreciaciones
{
    public class DetalleDepreciacionService
    {
        private readonly Func<TipoConexion, AppDbContext> _contextFactory;
        public DetalleDepreciacionService(Func<TipoConexion, AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<int> BuscarMayorIdDepreciacion(TipoConexion tipoCon)
        {
            using var _context = _contextFactory(tipoCon);
            return await _context.DetalleDepreciacions.MaxAsync(d => (int?)d.IdDepreciacion) ?? 0;
        }

        public async Task<int> BuscarIdDetalleDepreciacioRepetido(TipoConexion tipoCon, int idDepreciacion)
        {
            var _context = _contextFactory(tipoCon);
            var parameters = new[]
            {
                new SqlParameter("@iddepre", idDepreciacion)
            };
            return await _context.Database.ExecuteSqlRawAsync("EXEC sp_BuscarIdDetalleDepreciacionRepetido @iddepre", parameters);

        }

        public async Task<int> NuevaDetalleDepreciacionAsync(TipoConexion tipoCon, DetalleDepreciacion detalle)
        {
            using var _context = _contextFactory(tipoCon);
            var parameters = new[]
            {
                new SqlParameter("@ID_DEPRECIACION", detalle.IdDepreciacionGeneral),
                new SqlParameter("FECHA",detalle.Fecha),
                new SqlParameter("@NUM_DEPRECIACION", detalle.NumDepreciacion),
                new SqlParameter("@VALOR_DEPRECIACION", detalle.ValorDepreciacion),
                new SqlParameter("@VALOR_RESIDUAL_DEPRECIACION", detalle.ValorResidualDepreciacion),
                new SqlParameter("@ESTADO", detalle.Estado),
                new SqlParameter("@ID_DEPRECIACION_GENERAL", detalle.IdDepreciacionGeneral)
            };

            return await _context.Database.ExecuteSqlRawAsync("EXEC nuevaDetalleDepreciacion @ID_DEPRECIACION, @FECHA, @NUM_DEPRECIACION, @VALOR_DEPRECIACION, @VALOR_RESIDUAL_DEPRECIACION, @ESTADO, @ID_DEPRECIACION_GENERAL", parameters);
        }

        public async Task<List<DetalleDepreciacion>> SeleccionarDetallesDepreciacionPorIdDepreciacion(TipoConexion tipoCon, List<int> ids)
        {
            using var _context = _contextFactory(tipoCon);

            //Convertir List<int> a List<int?>
            var idsInt = ids.Select(id => (int?)id).ToList();

            return await _context.DetalleDepreciacions
                .Where(d => d.Estado ==1 && idsInt.Contains(d.IdDepreciacionGeneral))
                .OrderBy(d => d.IdDepreciacionGeneral)
                .ToListAsync();
        }
    }
}
