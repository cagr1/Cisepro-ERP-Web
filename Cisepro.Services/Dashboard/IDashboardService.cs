using Cisepro.Data.DTOs.Dashboard;
using Cisepro.Data.Enums;

namespace Cisepro.Services.Dashboard
{
    public interface IDashboardService
    {
        Task<List<CantonGuardiasDTO>> GetGuardiasPorCantonAsync(TipoConexion tipoCon);
        Task<DashboardDataResponse> GetTablaFinancieraAsync(TipoConexion tipoConexion, DateTime startDate, DateTime endDate);
    }
}