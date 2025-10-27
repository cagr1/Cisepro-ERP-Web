using Cisepro.Data.Context;
using Cisepro.Data.Enums;
using System.Text;
using Cisepro.Data.DTOs.Dashboard;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Cisepro.Data.Entities;
using System.Reflection.PortableExecutable;


namespace Cisepro.Services.Dashboard
{
    public class DashboardService : IDashboardService
    {
        private readonly Func<TipoConexion, AppDbContext> _contextFactory;
        private readonly ILogger<DashboardService> _logger;

        public DashboardService(Func<TipoConexion, AppDbContext> contextFactory, ILogger<DashboardService> logger)
        {
            _contextFactory = contextFactory;
            _logger = logger;
        }

        public async Task<DashboardDataResponse> GetTablaFinancieraAsync(TipoConexion tipoConexion, DateTime startDate, DateTime endDate)
        {
            using var _context = _contextFactory(tipoConexion);

            try
            {
                _logger?.LogInformation("Retrieving financial table data. {TipoConexion}", tipoConexion);
                var parameters = new[]
                {
                    new SqlParameter("@FECHA_INICIAL",  startDate ),
                    new SqlParameter("@FECHA_FINAL",  endDate )
                };

                var tablaPrimaria = new List<TablaFinancieraDTO>();

                using var command = _context.Database.GetDbConnection().CreateCommand();
                command.CommandText = "sp_TablaFinanciera";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(parameters);

                await _context.Database.OpenConnectionAsync();

                using var reader = await command.ExecuteReaderAsync();
                int recorCount = 0;
                while (await reader.ReadAsync())
                {
                    recorCount++;
                    var fila = new TablaFinancieraDTO
                    {
                        Partidas = reader["Partidas"]?.ToString() ?? string.Empty,
                        Enero = reader.IsDBNull("Enero") ? 0 : reader.GetDecimal("Enero"),
                        Febrero = reader.IsDBNull("Febrero") ? 0 : reader.GetDecimal("Febrero"),
                        Marzo = reader.IsDBNull("Marzo") ? 0 : reader.GetDecimal("Marzo"),
                        Abril = reader.IsDBNull("Abril") ? 0 : reader.GetDecimal("Abril"),
                        Mayo = reader.IsDBNull("Mayo") ? 0 : reader.GetDecimal("Mayo"),
                        Junio = reader.IsDBNull("Junio") ? 0 : reader.GetDecimal("Junio"),
                        Julio = reader.IsDBNull("Julio") ? 0 : reader.GetDecimal("Julio"),
                        Agosto = reader.IsDBNull("Agosto") ? 0 : reader.GetDecimal("Agosto"),
                        Septiembre = reader.IsDBNull("Septiembre") ? 0 : reader.GetDecimal("Septiembre"),
                        Octubre = reader.IsDBNull("Octubre") ? 0 : reader.GetDecimal("Octubre"),
                        Noviembre = reader.IsDBNull("Noviembre") ? 0 : reader.GetDecimal("Noviembre"),
                        Diciembre = reader.IsDBNull("Diciembre") ? 0 : reader.GetDecimal("Diciembre")
                    };
                    tablaPrimaria.Add(fila);
                }

                _logger?.LogInformation("Retrieved {RecorCount} records from the database.", recorCount);

                return new DashboardDataResponse
                {
                    TablaPrimaria = tablaPrimaria,
                    FechaInicial = startDate,
                    FechaFinal = endDate,
                };



            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error retrieving financial table data.");
                throw;


            }

        }

        public async Task<List<CantonGuardiasDTO>> GetGuardiasPorCantonAsync(TipoConexion tipoCon)
        {
            using var _context = _contextFactory(tipoCon);
            var result = new List<CantonGuardiasDTO>();

            using var command = _context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "sp_ObtenerGuardiasPorCanton";
            command.CommandType = CommandType.StoredProcedure;

            await _context.Database.OpenConnectionAsync();
            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                result.Add(new CantonGuardiasDTO
                {
                    DPA_DESCAN = reader["DPA_DESCAN"].ToString(),
                    DPA_PRO = reader["DPA_PRO"].ToString().Trim(),
                    TotalGuardias = Convert.ToInt32(reader["TotalGuardias"].ToString())

                });
            }

            return result;
        }


    }
}
