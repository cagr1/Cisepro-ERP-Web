using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cisepro.Data.Context;
using Cisepro.Data.Enums;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Cisepro.Data.Entities;


namespace Cisepro.Services.Talento_Humano
{
    public class HistorialService
    {
        private readonly Func<TipoConexion, AppDbContext> _contextFactory;

        public HistorialService(Func<TipoConexion, AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<int> BuscarMayorIdHistorial(TipoConexion tipoCon)
        {
            using var context = _contextFactory(tipoCon);
            return await context.HistoriaLaborals.MaxAsync(x => (int?)x.IdHistoriaLaboral) ?? 0;
        }

        public async Task<List<HistoriaLaboral>> ObtenerHistorialPorIdPersonalAsync(TipoConexion tipoCon, int idPersonal)
        {
            using var context = _contextFactory(tipoCon);

            return await context.HistoriaLaborals
                .Where(h => h.IdPersonalHistoriaLaboral == idPersonal)
                .Select(h => new HistoriaLaboral
                {
                    IdHistoriaLaboral = h.IdHistoriaLaboral,
                    FechaHistoriaLaboral = h.FechaHistoriaLaboral,
                    DetalleHistoriaLaboral = h.DetalleHistoriaLaboral,
                    EstadoHistoriaLaboral = h.EstadoHistoriaLaboral,
                    IdPersonalHistoriaLaboral = h.IdPersonalHistoriaLaboral,
                    IdSitioPuesto = h.IdSitioPuesto,
                    IdAux = h.IdAux
                })
                .ToListAsync();
        }
    }
}
