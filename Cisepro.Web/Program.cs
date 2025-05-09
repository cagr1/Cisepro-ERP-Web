using Cisepro.Data.Enums;
using Cisepro.Data.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerGen;
using Cisepro.Services.Configuration;
using Cisepro.Services.Usuario_General;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
var builder = WebApplication.CreateBuilder(args);

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secret = jwtSettings["SecretKey"];

builder.Services.Configure<JwtSettings>(jwtSettings);
builder.Services.AddScoped<AuthService>();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });




// Configuración de autenticación
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(secret))
        };
    });
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddScoped<Func<TipoConexion, AppDbContext>>(provider => tipoCon =>
{
    var connectionString = tipoCon == TipoConexion.Cisepro ?
    builder.Configuration.GetConnectionString("Cisepro") :
    builder.Configuration.GetConnectionString("Seportpac");

    return new AppDbContext(connectionString);
});



builder.Services.AddCors(options =>
{
    options.AddPolicy("VueDev", policy =>
    {
        policy.WithOrigins("http://localhost:5173", "https://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( c =>
    {
        c.SwaggerDoc("v1", new() { Title = "Cisepro Web API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cisepro Web API V1");
    
});
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("VueDev");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

