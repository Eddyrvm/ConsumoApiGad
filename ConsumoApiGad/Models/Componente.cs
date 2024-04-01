using Newtonsoft.Json;

namespace ConsumoApiGAD.Models
{
    public class Componente
    {
        [JsonProperty("key")]
        public string Key { get; set; } = null!;

        [JsonProperty("nombreMiembro")]
        public string NombreMiembro { get; set; } = null!;

        [JsonProperty("valor")]
        public decimal Valor { get; set; }
        public ICollection<Titulo> Titulos { get; set; } = null!;
    }

}
