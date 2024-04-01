using Newtonsoft.Json;

namespace ConsumoApiGAD.Models
{
    public class Titulo
    {
        [JsonProperty("clavePredial")]
        public string ClavePredia { get; set; } = null!;

        [JsonProperty("fechaEmision")]
        public string FechaEmision { get; set; } = null!;

        [JsonProperty("year")]
        public string Year { get; set; } = null!;

        [JsonProperty("valorNeto")]
        public string ValorNeto { get; set; } = null!;

        [JsonProperty("valorTitulo")]
        public string ValorTitulo { get; set; } = null!;

        [JsonProperty("valorEmision")]
        public string ValorEmision { get; set; } = null!;

        public ICollection<Rubro> Rubros { get; set; } = null!;
    }
}
