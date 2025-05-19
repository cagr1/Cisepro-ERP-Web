using System;
using Cisepro.Data.Context;
using Cisepro.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Cisepro.Data.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace Cisepro.Services.EstructuraEmpresa
{
    public class CargoService
    {
        private readonly Func<TipoConexion, AppDbContext> _contextFactory;
        public CargoService(Func<TipoConexion, AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<int> BuscarMayorIdCargoAsync(TipoConexion tipoCon)
        {
            using var context = _contextFactory(tipoCon);
            return await context.CargoOcupacionals
                .MaxAsync(c => (int?)c.IdCargoOcupacional) ?? 0;
        }

        public async Task<List<CargoOcupacional>> SeleccionarTodosRegistrosCargoAsync(TipoConexion tipoCon)
        {
            using var context = _contextFactory(tipoCon);
            return await context.CargoOcupacionals
                .FromSqlRaw("SeleccionarTodosLosRegistrosCargos")
                .AsNoTracking()
                .ToListAsync();
        }



    }
}
