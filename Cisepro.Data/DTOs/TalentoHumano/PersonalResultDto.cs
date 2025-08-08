using System;
using Cisepro.Data.Entities;


namespace Cisepro.Data.DTOs.TalentoHumano
{
    public class PersonalResultDto
    {
        public int TotalRegistros { get; set; }
        public int Id_Personal { get; set; }
        public string Cedula { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Nombres { get; set; } = null!;
        public string Provincia { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public DateTime? Fecha_Nacimiento { get; set; }

        public string Sexo { get; set; } = null!;

        public string Ciudad { get; set; } = null!;

        public decimal Sueldo { get; set; }

        public string Libreta_Militar { get; set; } = null!;

        public string Tipo_Sangre { get; set; } = null!;

        public string Pasaporte { get; set; } = null!;

        public int Peso { get; set; }

        public int Edad { get; set; }

        public string Prueba_Antidroga { get; set; } = null!;

        public DateTime? Fecha_Entrada { get; set; }

        public DateTime? Fecha_Salida { get; set; }

        public int Estado_Personal { get; set; }

        public int Id_Area { get; set; }

        public int Id_Cargo_Ocupacional { get; set; }

        public string Ubicacion { get; set; } = null!;

        public string Instruccion { get; set; } = null!;

        public string Estado_Civil { get; set; } = null!;

        public string? Movil { get; set; }

        public string? Telefono { get; set; }

        public int? Cantidad_Hijos { get; set; }

        public string? Historia_Clinica { get; set; }

        public string? Parroquia { get; set; }

        public decimal? Estatura { get; set; }

        public string? Discapacidad { get; set; }

        public string? Examen_Psicologico { get; set; }

        public string? Lugar_Examen_Psicologico { get; set; }

        public string? Carnet_Conadis { get; set; }

        public string? Datos_Hijos { get; set; }

        public string? Datos_Esposa { get; set; }

        public string Casa { get; set; } = null!;

        public string Arriendo { get; set; } = null!;

        public string Deudor_Garante { get; set; } = null!;

        public decimal Cantidad_Deuda { get; set; }

        public string A_Quien_Adeuda { get; set; } = null!;

        public string Trabajo_Ateriormente { get; set; } = null!;

        public string Anterior_Trabajo { get; set; } = null!;

        public string Cargo_Anterior_Trabajo { get; set; } = null!;

        public string Motivo_Salida_Trabajo { get; set; } = null!;

        public DateTime Entrada_Anterior { get; set; }

        public DateTime Salida_Anterior { get; set; }

        public string Nombres_Patrono_Anterior { get; set; } = null!;

        public string Telefono_Patrono_Anterior { get; set; } = null!;

        public string Recomendaciones { get; set; } = null!;

        public string Datos_Familiares { get; set; } = null!;

        public string Datos_Emergencia { get; set; } = null!;

        public byte[]? Foto { get; set; }

        public byte[]? Perfil { get; set; }

        public string? Email { get; set; }

        public string? Curso_Vigilante { get; set; }

        public string? Emisor_Curso_Vigilante { get; set; }

        
        public int? Credencial { get; set; }

        public string? Nombre_Area { get; set; } //nombre_area
        
    }
}
