using System;
using Cisepro.Data.Context;
using Cisepro.Data.Entities;
using Cisepro.Data.DTOs.TalentoHumano;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Cisepro.Data.Enums;
using Dapper;

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

        public async Task<ContratoDTO> ObtenerContratoXIdpersonalAsync(TipoConexion tipoCon, int idPersonal)
        {
            //Uso de Dapper para funciones que retornan tablas unicas

            using var context = _contextFactory(tipoCon);

            var conn = (SqlConnection)context.Database.GetDbConnection();

            if (conn.State == System.Data.ConnectionState.Closed)
                await conn.OpenAsync();

            var sql = "sp_seleccionarContratoXIdPersonal";

            var result = await conn.QueryFirstOrDefaultAsync<ContratoDTO>(
                sql,
                new { @id_personal = idPersonal },
                commandType: System.Data.CommandType.StoredProcedure
                );

            return result;

        }
    }
}
