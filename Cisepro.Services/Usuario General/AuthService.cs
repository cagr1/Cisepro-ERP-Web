using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using Cisepro.Services.Configuration;
using Microsoft.Data.SqlClient;
using Cisepro.Data.Entities;
using Cisepro.Data.Enums;
using Cisepro.Data.Context;
using Microsoft.EntityFrameworkCore;
using Azure.Core;
using Cisepro.Data.DTOs.Auth;





namespace Cisepro.Services.Usuario_General
{
    public class AuthService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly Func<TipoConexion, AppDbContext> _contextFactory;
        public AuthService(IOptions<JwtSettings> jwtSettings, Func<TipoConexion, AppDbContext> contextFactory)
        {
            _jwtSettings = jwtSettings.Value;
            _contextFactory = contextFactory;
        }

        public AuthResponse Authenticate(TipoConexion tipoCon, AuthRequest request)
        {
            using var context = _contextFactory(tipoCon);
            
            if (string.IsNullOrEmpty(request.Login) || string.IsNullOrEmpty(request.Password))
                return null;

            var usuario = context.UsuarioGenerals
                .FromSqlRaw("EXEC SeleccionarUsuarioxLoginYPassword @LOGIN, @PASSWORD",
                                   new SqlParameter("@LOGIN", request.Login),
                                   new SqlParameter("@PASSWORD", request.Password))
                .AsEnumerable()
                .FirstOrDefault();
            if (usuario == null || usuario.Estado != 1)
                return null;

            var token = GenerateJwtToken(usuario);
            return new AuthResponse { 
                Token = token,
                Usuario = new UsuarioDTO
                {
                    Id = usuario.IdUsuario,
                    Nombre = usuario.Login,
                    Email = usuario.Datos,
                    Rol = usuario.IdRol ?? 0
                }
            
            };

        }

        private string GenerateJwtToken(UsuarioGeneral user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.IdUsuario.ToString()),
                new Claim(ClaimTypes.Name, user.Datos),
                new Claim(ClaimTypes.Email, user.Login),
                new Claim(ClaimTypes.Role, user.IdRol.ToString())                
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryInMinutes),
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
