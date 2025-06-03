using System;
using Microsoft.Extensions.DependencyInjection;
using Cisepro.Data.Enums;
using Cisepro.Data.Context;
using Microsoft.Extensions.Configuration;
using Cisepro.Services.DivisionGeografica;
using Cisepro.Services.Usuario_General;
using Cisepro.Services.Activos_Fijos.Depreciaciones;
using Cisepro.Services.Contabilidad.Bancos;
using Cisepro.Services.Talento_Humano;
using Cisepro.Services.EstructuraEmpresa;



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
                        
            //Activos Fijos
            services.AddScoped<DepreciacionService>();
            services.AddScoped<DetalleDepreciacionService>();
            //Bancos
            services.AddScoped<BancoService>();
            //Division Geografica            
            services.AddScoped<CiudadService>();
            services.AddScoped<ProvinciaService>();
            services.AddScoped<ParroquiaService>();
            services.AddScoped<SitioService>();
            //Estructura Organizacional
            services.AddScoped<CargoService>();
            services.AddScoped<AreaService>();
            //Usuarios
            services.AddScoped<AuthService>();
            services.AddScoped<UsuarioService>();
            //Talento Humano
            services.AddScoped<ContratoService>();
            services.AddScoped<PersonalService>();
            

        }
    }
}
