using Newtonsoft.Json;

namespace ConsumoApiGAD.Models
{
    public class Personas
    {
        [JsonProperty("apellidos")]
        public string Apellidos { get; set; } = null!;

        [JsonProperty("nombres")]
        public string Nombres { get; set; } = null!;

        [JsonProperty("apellidosNombres")]
        public string ApellidosNombres { get; set; } = null!;

        [JsonProperty("nombresApellidos")]
        public string NombresApellidos { get; set; } = null!;

        [JsonProperty("identificador")]
        public string Identificador { get; set; } = null!;

        [JsonProperty("direccion")]
        public string Direccion { get; set; } = null!;

        [JsonProperty("email")]
        public string Email { get; set; } = null!;

        [JsonProperty("telefono")]
        public string Telefono { get; set; } = null!;

        [JsonProperty("locales")]
        public List<object> ?Locales { get; set; }

        [JsonProperty("deuda")]
        public object Deuda { get; set; } = null!;

        [JsonProperty("abonos")]
        public List<object> Abonos { get; set; } = null!;

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nombre")]
        public object Nombre { get; set; } = null!;

        [JsonProperty("valor")]
        public decimal Valor { get; set; }

        [JsonProperty("nuevo")]
        public bool Nuevo { get; set; }

        [JsonProperty("rural")]
        public bool Rural { get; set; }

        [JsonProperty("mostrarCodigo")]
        public bool MostrarCodigo { get; set; }

        [JsonProperty("componentes")]
        public ICollection<Componente> Componentes { get; set; } = null!;
    }
}
