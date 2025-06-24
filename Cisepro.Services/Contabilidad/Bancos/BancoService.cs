using System;
using Cisepro.Data.Context;
using Cisepro.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Cisepro.Data.Enums;

namespace Cisepro.Services.Contabilidad.Bancos
{
    public class BancoService
    {
        private readonly Func<TipoConexion, AppDbContext> _contextFactory;

        public BancoService(Func<TipoConexion, AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<int> BuscarMayorIdBancos(TipoConexion tipoCon)
        {
            var context = _contextFactory(tipoCon);
            return await context.Bancos.MaxAsync(b => b.IdBanco);
        }

        public async Task<List<Banco>> SeleccionarBancosAsync(TipoConexion tipoCon) 
        {
            using var context = _contextFactory(tipoCon);
            return await context.Bancos
                .FromSqlRaw("EXEC SeleccionarRegistrosBancos")
                .AsNoTracking()
                .ToListAsync();
        }
        
            

    }
}
