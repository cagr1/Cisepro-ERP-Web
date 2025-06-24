using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cisepro.Data.Context;
using Cisepro.Data.Entities;
using Cisepro.Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace Cisepro.Services.Talento_Humano
{
    public class CuentaPersonalService
    {
        private readonly Func<TipoConexion, AppDbContext> _contextFactory;

        public CuentaPersonalService(Func<TipoConexion, AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<CuentasPersonal>> SeleccionarCuenta(TipoConexion tipoCon, int idPersonal)
        {
            using var context = _contextFactory(tipoCon);

            return await context.CuentasPersonals
                .Where(x => x.IdPersonal == idPersonal)
                .Select(x => new CuentasPersonal
                {
                    IdPersonal = x.IdPersonal,
                    IdBanco = x.IdBanco,
                    NumCuenta = x.NumCuenta,
                    Tipo = x.Tipo
                })
                .ToListAsync();
        }
    }
}
