using Newtonsoft.Json;

namespace ConsumoApiGAD.Models
{
    public class Rubro
    {
        [JsonProperty("nombreRubro")]
        public string NombreRubro { get; set; } = null!;
      
        [JsonProperty("valor")]
        public decimal Valor { get; set; }

        [JsonProperty("total")]
        public decimal Total { get; set; }

        [JsonProperty("total")]
        public decimal ValorTotalInteres { get; set; }

        [JsonProperty("total")]
        public decimal GastosAdministrativos { get; set; }
        
    }
}
