using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cisepro.Data.DTOs.TalentoHumano
{
    public class PersonalCreateDTO
    {
        public string Cedula { get; set; } = null!;
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Provincia { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public DateTime? FechaNacimiento { get; set; }
        public string Sexo { get; set; } = null!;
        public string Ciudad { get; set; } = null!;
        public decimal Sueldo { get; set; }
        public string LibretaMilitar { get; set; } = null!;
        public string TipoSangre { get; set; } = null!;
        public string Pasaporte { get; set; } = null!;
        public int Peso { get; set; }
        public int Edad { get; set; }
        public string PruebaAntidroga { get; set; } = null!;
        public DateTime? FechaEntrada { get; set; }
        public DateTime? FechaSalida { get; set; }
        public int EstadoPersonal { get; set; }
        public int IdArea { get; set; }
        public int IdCargoOcupacional { get; set; }
        public string Ubicacion { get; set; } = null!;
        public string Instruccion { get; set; } = null!;
        public string EstadoCivil { get; set; } = null!;
        public string? Movil { get; set; }
        public string? Telefono { get; set; }
        public int? CantidadHijos { get; set; }
        public string? HistoriaClinica { get; set; }
        public string? Parroquia { get; set; }
        public decimal? Estatura { get; set; }
        public string? Discapacidad { get; set; }
        public string? ExamenPsicologico { get; set; }
        public string? LugarExamenPsicologico { get; set; }
        public string? CarnetConadis { get; set; }
        public string? DatosHijos { get; set; }
        public string? DatosEsposa { get; set; }
        public string Casa { get; set; } = null!;
        public string Arriendo { get; set; } = null!;
        public string DeudorGarante { get; set; } = null!;
        public decimal CantidadDeuda { get; set; }
        public string AQuienAdeuda { get; set; } = null!;
        public string TrabajoAteriormente { get; set; } = null!;
        public string AnteriorTrabajo { get; set; } = null!;
        public string CargoAnteriorTrabajo { get; set; } = null!;
        public string MotivoSalidaTrabajo { get; set; } = null!;
        public DateTime EntradaAnterior { get; set; }
        public DateTime SalidaAnterior { get; set; }
        public string NombresPatronoAnterior { get; set; } = null!;
        public string TelefonoPatronoAnterior { get; set; } = null!;
        public string Recomendaciones { get; set; } = null!;
        public string DatosFamiliares { get; set; } = null!;
        public string DatosEmergencia { get; set; } = null!;
        public byte[]? Foto { get; set; }
        public byte[]? Perfil { get; set; }
        public string? Email { get; set; }
        public string? CursoVigilante { get; set; }
        public string? EmisorCursoVigilante { get; set; }
        public int? Credencial { get; set; }
    }
}
