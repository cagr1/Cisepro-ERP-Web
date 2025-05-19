using System;
using Microsoft.Extensions.DependencyInjection;
using Cisepro.Services.DivisionGeografica;
using Cisepro.Services.Usuario_General;
using Cisepro.Services.Talento_Humano;
using Cisepro.Data.Enums;
using Cisepro.Data.Context;
using Microsoft.Extensions.Configuration;



namespace Cisepro.Services.Configuration
{
    public class ServiceRegistration
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            // Configuración de servicios
            services.AddScoped<Func<TipoConexion, AppDbContext>>(provider => tipoCon =>
            {
                var connectionString = tipoCon == TipoConexion.Cisepro ?
                configuration.GetConnectionString("Cisepro") :
                configuration.GetConnectionString("Seportpac");

                return new AppDbContext(connectionString);
            });

            // Otros servicios
            services.AddScoped<AuthService>();
            services.AddScoped<CiudadServices>();
        }
    }
}
