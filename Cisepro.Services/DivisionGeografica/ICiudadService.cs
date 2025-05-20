using Cisepro.Data.Entities;
using Cisepro.Data.Enums;

namespace Cisepro.Services.DivisionGeografica
{
    public interface ICiudadService
    {
        Task<int> ActualizarCiudadAsync(Ciudade ciudad, TipoConexion tipoCon);
        Task<int> BuscarMayorIdAsync(TipoConexion tipoCon);
        Task<List<Ciudade>> BuscarNombreCiuydadesXIdProvinciasAsync(int idProvincia, TipoConexion tipoCon);
        Task<int> NuevoCiudadAsync(Ciudade ciudad, TipoConexion tipoCon);
    }
}