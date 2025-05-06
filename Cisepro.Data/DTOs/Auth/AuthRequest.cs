using Cisepro.Data.Enums;
using System.Text.Json.Serialization;


namespace Cisepro.Data.DTOs.Auth
{
    public class AuthRequest
    {
        [JsonPropertyName("tipoConexion")]
        public TipoConexion TipoConexion { get; set; }
        [JsonPropertyName("login")]
        public string Login { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
