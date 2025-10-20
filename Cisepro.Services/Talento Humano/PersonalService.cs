using System;
using Cisepro.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Cisepro.Data.Enums;
using Cisepro.Data.DTOs.TalentoHumano;
using System.Data;

namespace Cisepro.Services.Talento_Humano
{
    public class PersonalService
    {
        private readonly Func<TipoConexion, AppDbContext> _contextFactory;

        public PersonalService(Func<TipoConexion, AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<int> BuscarMayorIdPersonalAsync(TipoConexion tipoCon)
        {
            using var context = _contextFactory(tipoCon);
            return await context.Personals
                .MaxAsync(p => (int?)p.IdPersonal) ?? 0;
        }

        public async Task<(List<PersonalResultDto> Data, int TotalRecords)> SelecccionarTodosLosRegistrosPersonalAsync(TipoConexion tipoCon, string filtro, int page =1, int itemsPerPage = 20)
        { 
          using var _context = _contextFactory(tipoCon);
           
          var parameters = new[]
            {
                new SqlParameter("@FILTRO", filtro),
                new SqlParameter("@PAGE", page),
                new SqlParameter("@ITEMSPERPAGE", itemsPerPage),
                
            };

            var results = new List<PersonalResultDto>();
            int totalRecords = 0;

            using var command = _context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "SeleccionarTodosRegistrosPersonalFiltroTodos";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(parameters);

            await _context.Database.OpenConnectionAsync();

            using var reader = await command.ExecuteReaderAsync();

            if ( await reader.ReadAsync() )
            {
                totalRecords = reader.GetInt32(0);
            }
            
            if (await reader.NextResultAsync())
            {
                while (await reader.ReadAsync())
                {
                    var personal = new PersonalResultDto
                    {
                        Id_Personal = reader.GetInt32("ID_PERSONAL"),
                        Cedula = reader.IsDBNull("CEDULA") ? null : reader.GetString("CEDULA"),
                        Apellidos = reader.IsDBNull("APELLIDOS") ? null : reader.GetString("APELLIDOS"),
                        Nombres = reader.IsDBNull("NOMBRES") ? null : reader.GetString("NOMBRES"),
                        Provincia = reader.IsDBNull("PROVINCIA") ? null : reader.GetString("PROVINCIA"),
                        Direccion = reader.IsDBNull("DIRECCION") ? null : reader.GetString("DIRECCION"),
                        Fecha_Nacimiento = reader.IsDBNull("FECHA_NACIMIENTO") ? null : reader.GetDateTime("FECHA_NACIMIENTO"),
                        Sexo = reader.IsDBNull("SEXO") ? null : reader.GetString("SEXO"),
                        Ciudad = reader.IsDBNull("CIUDAD") ? null : reader.GetString("CIUDAD"),
                        Sueldo = reader.IsDBNull("SUELDO") ? 0 : reader.GetDecimal("SUELDO"),
                        Libreta_Militar = reader.IsDBNull("LIBRETA_MILITAR") ? null : reader.GetString("LIBRETA_MILITAR"),
                        Tipo_Sangre = reader.IsDBNull("TIPO_SANGRE") ? null : reader.GetString("TIPO_SANGRE"),
                        Pasaporte = reader.IsDBNull("PASAPORTE") ? null : reader.GetString("PASAPORTE"),
                        Peso = reader.IsDBNull("PESO") ? 0 : reader.GetInt32("PESO"),
                        Edad = reader.GetInt32("EDAD"),
                        Prueba_Antidroga = reader.IsDBNull("PRUEBA_ANTIDROGA") ? null : reader.GetString("PRUEBA_ANTIDROGA"),
                        Fecha_Entrada = reader.IsDBNull("FECHA_ENTRADA") ? null : reader.GetDateTime("FECHA_ENTRADA"),
                        Fecha_Salida = reader.IsDBNull("FECHA_SALIDA") ? null : reader.GetDateTime("FECHA_SALIDA"),
                        Estado_Personal = reader.IsDBNull("ESTADO_PERSONAL") ? 0 : reader.GetInt32("ESTADO_PERSONAL"),
                        Id_Area = reader.IsDBNull("ID_AREA") ? 0 : reader.GetInt32("ID_AREA"),
                        Id_Cargo_Ocupacional = reader.IsDBNull("ID_CARGO_OCUPACIONAL") ? 0 : reader.GetInt32("ID_CARGO_OCUPACIONAL"),
                        Ubicacion = reader.IsDBNull("UBICACION") ? null : reader.GetString("UBICACION"),
                        Instruccion = reader.IsDBNull("INSTRUCCION") ? null : reader.GetString("INSTRUCCION"),
                        Estado_Civil = reader.IsDBNull("ESTADO_CIVIL") ? null : reader.GetString("ESTADO_CIVIL"),
                        Movil = reader.IsDBNull("MOVIL") ? null : reader.GetString("MOVIL"),
                        Telefono = reader.IsDBNull("TELEFONO") ? null : reader.GetString("TELEFONO"),
                        Cantidad_Hijos = reader.IsDBNull("CANTIDAD_HIJOS") ? null : reader.GetInt32("CANTIDAD_HIJOS"),
                        Historia_Clinica = reader.IsDBNull("HISTORIA_CLINICA") ? null : reader.GetString("HISTORIA_CLINICA"),
                        Parroquia = reader.IsDBNull("PARROQUIA") ? null : reader.GetString("PARROQUIA"),
                        Estatura = reader.IsDBNull("ESTATURA") ? null : reader.GetDecimal("ESTATURA"),
                        Discapacidad = reader.IsDBNull("DISCAPACIDAD") ? null : reader.GetString("DISCAPACIDAD"),
                        Examen_Psicologico = reader.IsDBNull("EXAMEN_PSICOLOGICO") ? null : reader.GetString("EXAMEN_PSICOLOGICO"),
                        Lugar_Examen_Psicologico = reader.IsDBNull("LUGAR_EXAMEN_PSICOLOGICO") ? null : reader.GetString("LUGAR_EXAMEN_PSICOLOGICO"),
                        Carnet_Conadis = reader.IsDBNull("CARNET_CONADIS") ? null : reader.GetString("CARNET_CONADIS"),
                        Datos_Hijos = reader.IsDBNull("DATOS_HIJOS") ? null : reader.GetString("DATOS_HIJOS"),
                        Datos_Esposa = reader.IsDBNull("DATOS_ESPOSA") ? null : reader.GetString("DATOS_ESPOSA"),
                        Casa = reader.IsDBNull("CASA") ? null : reader.GetString("CASA"),
                        Arriendo = reader.IsDBNull("ARRIENDO") ? null : reader.GetString("ARRIENDO"),
                        Deudor_Garante = reader.IsDBNull("DEUDOR_GARANTE") ? null : reader.GetString("DEUDOR_GARANTE"),
                        Cantidad_Deuda = reader.IsDBNull("CANTIDAD_DEUDA") ? 0 : reader.GetDecimal("CANTIDAD_DEUDA"),
                        A_Quien_Adeuda = reader.IsDBNull("A_QUIEN_ADEUDA") ? null : reader.GetString("A_QUIEN_ADEUDA"),
                        Trabajo_Ateriormente = reader.IsDBNull("TRABAJO_ATERIORMENTE") ? null : reader.GetString("TRABAJO_ATERIORMENTE"),
                        Anterior_Trabajo = reader.IsDBNull("ANTERIOR_TRABAJO") ? null : reader.GetString("ANTERIOR_TRABAJO"),
                        Cargo_Anterior_Trabajo = reader.IsDBNull("CARGO_ANTERIOR_TRABAJO") ? null : reader.GetString("CARGO_ANTERIOR_TRABAJO"),
                        Motivo_Salida_Trabajo = reader.IsDBNull("MOTIVO_SALIDA_TRABAJO") ? null : reader.GetString("MOTIVO_SALIDA_TRABAJO"),
                        Entrada_Anterior = reader.GetDateTime("ENTRADA_ANTERIOR"),
                        Salida_Anterior = reader.GetDateTime("SALIDA_ANTERIOR"),
                        Nombres_Patrono_Anterior = reader.IsDBNull("NOMBRES_PATRONO_ANTERIOR") ? null : reader.GetString("NOMBRES_PATRONO_ANTERIOR"),
                        Telefono_Patrono_Anterior = reader.IsDBNull("TELEFONO_PATRONO_ANTERIOR") ? null : reader.GetString("TELEFONO_PATRONO_ANTERIOR"),
                        Recomendaciones = reader.IsDBNull("RECOMENDACIONES") ? null : reader.GetString("RECOMENDACIONES"),
                        Datos_Familiares = reader.IsDBNull("DATOS_FAMILIARES") ? null : reader.GetString("DATOS_FAMILIARES"),
                        Datos_Emergencia = reader.IsDBNull("DATOS_EMERGENCIA") ? null : reader.GetString("DATOS_EMERGENCIA"),
                        Foto = reader.IsDBNull("FOTO") ? null : (byte[])reader["FOTO"],
                        Perfil = reader.IsDBNull("PERFIL") ? null : (byte[])reader["PERFIL"],
                        Email = reader.IsDBNull("EMAIL") ? null : reader.GetString("EMAIL"),
                        Curso_Vigilante = reader.IsDBNull("CURSO_VIGILANTE") ? null : reader.GetString("CURSO_VIGILANTE"),
                        Emisor_Curso_Vigilante = reader.IsDBNull("EMISOR_CURSO_VIGILANTE") ? null : reader.GetString("EMISOR_CURSO_VIGILANTE"),
                        Credencial = reader.IsDBNull("CREDENCIAL") ? null : reader.GetInt32("CREDENCIAL"),
                        Nombre_Area = reader.IsDBNull("nombre_area") ? null : reader.GetString("nombre_area"),
                        TotalRegistros = totalRecords
                    };

                    results.Add(personal);
                }
            }
            return (results, totalRecords);
        }




        //public async Task<int> CreatePersonalAsync(TipoConexion tipoCon, PersonalCreateDTO dto)
        //{
        //    using var context = _contextFactory(tipoCon);

        //    var parameters = new[]
        //    {
        //    new SqlParameter("@CEDULA", dto.Cedula ?? (object)DBNull.Value),
        //    new SqlParameter("@APELLIDOS", dto.Apellidos ?? (object)DBNull.Value),
        //    new SqlParameter("@NOMBRES", dto.Nombres ?? (object)DBNull.Value),
        //    new SqlParameter("@PROVINCIA", dto.Provincia ?? (object)DBNull.Value),
        //    new SqlParameter("@DIRECCION", dto.Direccion ?? (object)DBNull.Value),
        //    new SqlParameter("@FECHA_NACIMIENTO", dto.FechaNacimiento ?? (object)DBNull.Value),
        //    new SqlParameter("@SEXO", dto.Sexo ?? (object)DBNull.Value),
        //    new SqlParameter("@CIUDAD", dto.Ciudad ?? (object)DBNull.Value),
        //    new SqlParameter("@EMAIL", dto.Email ?? (object)DBNull.Value),
        //    new SqlParameter("@TELEFONO", dto.Telefono ?? (object)DBNull.Value),
        //    new SqlParameter("@ESTADO_PERSONAL", dto.EstadoPersonal)
        //};

        //}



    }


 }

