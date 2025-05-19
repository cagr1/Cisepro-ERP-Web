using System;
using Cisepro.Data.Context;
using Cisepro.Data.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Cisepro.Data.Enums;

namespace Cisepro.Services.Talento_Humano
{
    public class ContratoService
    {
        private readonly Func<TipoConexion, AppDbContext> _contextFactory;

        public ContratoService(Func<TipoConexion, AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<int> BuscarMayorIdContrato(TipoConexion tipoCon)
        {
            using var context = _contextFactory(tipoCon);

            return await context.Contratos.MaxAsync(x => (int?)x.IdContrato) ?? 0;
        }

        public async Task<List<ContratoProyecto>> SeleccionarTodosLosRegistrosProyectosAsync(TipoConexion tipoCon, bool todos)
        {
            using var context = _contextFactory(tipoCon);

            var query = context.ContratoProyectos
                .AsNoTracking();

            if (!todos)
                query = query.Where(p => p.Estado == 1);

            return await query
                .Select(p => new ContratoProyecto
                {
                    IdProyecto = p.IdProyecto,
                    NombreProyecto = p.NombreProyecto,
                    FechaInicio = p.FechaInicio,
                    FechaFin = p.FechaFin,
                    IdCliente = p.IdCliente,
                    Estado = p.Estado,
                    Codigo = p.Codigo
                })
                .ToListAsync();
        }




    }
}
