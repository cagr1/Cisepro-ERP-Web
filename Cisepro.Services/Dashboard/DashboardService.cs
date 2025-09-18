using Cisepro.Data.Context;
using Cisepro.Data.Enums;
using System.Text;
using Cisepro.Data.DTOs.Dashboard;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;


namespace Cisepro.Services.Dashboard
{
    public class DashboardService
    {
        private readonly Func<TipoConexion, AppDbContext> _contextFactory;

        public DashboardService(Func<TipoConexion, AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<SalesData> GetSalesDataRangeAsync(TipoConexion tipoCon, DateTime startDate, DateTime endDate)
        {
            using var _context = _contextFactory(tipoCon);

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@FECHA_INICIAL", startDate),
                new SqlParameter("@FECHA_FINAL", endDate)
            };

            var result = new SalesData();

            using var command = _context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "sp_SalesDataByDateRange";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(parameters);

            await _context.Database.OpenConnectionAsync();

            using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                result.TotalSales = reader.IsDBNull("TOTAL_VENTAS") ? 0 : reader.GetDecimal("TOTAL_VENTAS");
            }

            return result;            



        }

        public async Task<SalesData> GetAccumulatedSalesDataAsync(TipoConexion tipoCon, DateTime endDate)
        {
            using var _context = _contextFactory(tipoCon);

            var parameters = new SqlParameter[]
            {

                new SqlParameter("@FECHA_FINAL", endDate)
            };

            var result = new SalesData();

            using var command = _context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "sp_SalesAccumulatedByRange";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(parameters);
            await _context.Database.OpenConnectionAsync();

            using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                result.TotalSales = reader.IsDBNull("TOTAL_VENTAS") ? 0 : reader.GetDecimal("TOTAL_VENTAS");
            }

            return result;
            
            

        }

        public async Task<AnnualVariationRevenues> GetVariationIncomeAsync(TipoConexion tipoCon, DateTime startDate, DateTime endDate)
        {

            using var _context = _contextFactory(tipoCon);

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@FECHA_INICIAL", startDate),
                new SqlParameter("@FECHA_FINAL", endDate)
            };

            using var command = _context.Database.GetDbConnection().CreateCommand();
            command.CommandText = "sp_AnnualVariationRevenues";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(parameters);

            await _context.Database.OpenConnectionAsync();

            using var reader = await command.ExecuteReaderAsync();

            var result = new AnnualVariationRevenues();
            if (await reader.ReadAsync())
                result.VariationPercentage = reader.IsDBNull("VariacionPorcentual") ? 0 : reader.GetDecimal("VariacionPorcentual");

            return result;





        }

        public async Task<AnnualEarnings> GetAnnualEarningsAsync(TipoConexion tipoCon, DateTime startDate, DateTime endDate)
        {
            using var _context = _contextFactory(tipoCon);

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@FECHA_INICIAL", startDate),
                new SqlParameter("@FECHA_FINAL", endDate)
            };

            using var command = _context.Database.GetDbConnection().CreateCommand();
            command.CommandText = "sp_AnnualEarnings";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(parameters);

            await _context.Database.OpenConnectionAsync();

            using var reader = await command.ExecuteReaderAsync();

            var result = new AnnualEarnings();
            if (await reader.ReadAsync())
                result.TotalEarnings = reader.IsDBNull("Utilidad") ? 0 : reader.GetDecimal("Utilidad");

            return result;



        }

        public async Task<EarningAccumulated> GetEarningAccumulatedAsync(TipoConexion tipoCon, DateTime endDate)
        {
            using var _context = _contextFactory(tipoCon);
            
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@FECHA_FINAL", endDate)
            };


            using var command = _context.Database.GetDbConnection().CreateCommand();
            command.CommandText = "sp_EarningsAccumulated";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(parameters);

            await _context.Database.OpenConnectionAsync();
            using var reader = await command.ExecuteReaderAsync();

            var result = new EarningAccumulated();
            if (await reader.ReadAsync())
                result.TotalEarnings = reader.IsDBNull("Utilidad") ? 0 : reader.GetDecimal("Utilidad");

            return result;

        }

        public async Task<AnnualVariationRevenues> GetVariationProfitAsync(TipoConexion tipoCon, DateTime startDate, DateTime endDate)
        {
            using var _context = _contextFactory(tipoCon);
            
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@FECHA_INICIAL", startDate),
                new SqlParameter("@FECHA_FINAL", endDate)
            };
            using var command = _context.Database.GetDbConnection().CreateCommand();
            command.CommandText = "sp_AnnualVariationIncomes";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(parameters);

            await _context.Database.OpenConnectionAsync();
            using var reader = await command.ExecuteReaderAsync();

            var result = new AnnualVariationRevenues();
            if (await reader.ReadAsync())
                result.VariationPercentage = reader.IsDBNull("Variacion") ? 0 : reader.GetDecimal("Variacion");

            return result;



        }

        public async Task<List<AccumulatedProfitLossEarnings>> GetAccumulatedProfitLossEarningsAsync(TipoConexion tipoCon, int year)
        {
            using var _context = _contextFactory(tipoCon);

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@anio", SqlDbType.Int)
                {
                    Value = year
                }
            };

            using var command = _context.Database.GetDbConnection().CreateCommand();
            command.CommandText = "sp_ReportProfitLossEarnings";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(parameters);

            await _context.Database.OpenConnectionAsync();
            using var reader = await command.ExecuteReaderAsync();

            var result = new List<AccumulatedProfitLossEarnings>();
            while (await reader.ReadAsync())
            {
                result.Add(new AccumulatedProfitLossEarnings
                {
                    NumberMonth = reader.GetInt64("NumeroMes"),
                    NameMonth = reader.GetString("NombreMes"),
                    TotalIncome = reader.GetDecimal("Ingresos"),
                    TotalExpenses = reader.GetDecimal("Egresos"),
                    TotalEarnings = reader.GetDecimal("Utilidad")
                });
            }

            return result;

        }

        public async Task<AnnualVariationRevenues> GetAnnualVariationRevenuesAsync(TipoConexion tipoCon, DateTime startDate, DateTime endDate)
        {
            using var _context = _contextFactory(tipoCon);
            
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@FECHA_INICIAL", startDate ),
                new SqlParameter("@FECHA_FINAL", endDate )
            };

            using var command = _context.Database.GetDbConnection().CreateCommand();
            command.CommandText = "sp_AnnualVariationRevenues";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(parameters);

            await _context.Database.OpenConnectionAsync();
            using var reader = await command.ExecuteReaderAsync();

            var result = new AnnualVariationRevenues();
            if (await reader.ReadAsync())
                result.VariationPercentage = reader.IsDBNull("VariacionPorcentual") ? 0 : reader.GetDecimal("VariacionPorcentual");

            return result;
        }



        public async Task<List<SalesbyCategory>> GetSalesbyCategoriesAsync(TipoConexion tipoCon, DateTime startDate, DateTime endDate)
        {
            using var _context = _contextFactory(tipoCon);
            
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@FECHA_INICIAL", startDate ),
                new SqlParameter("@FECHA_FINAL", endDate )
            };

            using var command = _context.Database.GetDbConnection().CreateCommand();
            command.CommandText = "sp_salesByCategory";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(parameters);

            await _context.Database.OpenConnectionAsync();
            using var reader = await command.ExecuteReaderAsync();

            var result = new List<SalesbyCategory>();
            while (await reader.ReadAsync())
            {
                result.Add(new SalesbyCategory
                {
                    Code = reader.GetString("Codigo"),
                    Description = reader.GetString("Cuenta"),
                    Saldo = reader.GetDecimal("Saldo")
                });
            }

            return result;

        }


        public async Task<MarginEarnings> GetMarginEarningsAsync(TipoConexion tipoCon, DateTime startDate, DateTime endDate)
        {
            using var _context = _contextFactory(tipoCon);
            
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@FECHA_INICIAL", startDate ),
                new SqlParameter("@FECHA_FINAL", endDate )
            };

            using var command = _context.Database.GetDbConnection().CreateCommand();
            command.CommandText = "sp_MarginEarnings";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(parameters);

            await _context.Database.OpenConnectionAsync();
            using var reader = await command.ExecuteReaderAsync();

            var result = new MarginEarnings();
            if (await reader.ReadAsync())
                result.TotalEarnings = reader.IsDBNull("MargenUtilidadNeta") ? 0 : reader.GetDecimal("MargenUtilidadNeta");

            return result;
        }

        public async Task<LiquidityRatio> GetLiquidityRatioAsync(TipoConexion tipoCon, DateTime startDate, DateTime endDate)
        {
            using var _context = _contextFactory(tipoCon);
            
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@FECHA_INICIAL", startDate ),
                new SqlParameter("@FECHA_FINAL", endDate )
            };

            using var command = _context.Database.GetDbConnection().CreateCommand();
            command.CommandText = "sp_liquidityLevel";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(parameters);

            await _context.Database.OpenConnectionAsync();
            using var reader = await command.ExecuteReaderAsync();

            var result = new LiquidityRatio();
            if (await reader.ReadAsync())
                result.LiquidityLevel = reader.IsDBNull("Liquidez") ? 0 : reader.GetDecimal("Liquidez");

            return result;
        }

        //Metodo para obtener guardias por canton

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
