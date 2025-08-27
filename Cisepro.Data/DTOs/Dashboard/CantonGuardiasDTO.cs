using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;  

namespace Cisepro.Data.DTOs.Dashboard
{
    public class CantonGuardiasDTO
    {
        [JsonPropertyName("DPA_DESCAN")]
        public string? DPA_DESCAN { get; set; }
        
        [JsonPropertyName("DPA_PRO")]
        public string? DPA_PRO { get; set; }
        
        public int TotalGuardias { get; set; }
        



    }
}
