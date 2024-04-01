using ConsumoApiGAD.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsumoApiGad.Pages
{
    public partial class DeudasIndex
    {
        public string? FechaHora { get; set; }
        Personas Personas = new();
        Componente Componente = new();
        List<Componente> listComp = new();
        Titulo Titulo = new();
        Rubro Rubro = new();
        List<Rubro> listRubro = new();
        private string? ValorB { get; set; }
        private string? SelectedOption { get; set; }
        private bool IsLoading { get; set; }
        bool MostrarTabla = true;

        private void ClearForm()
        {
            // Limpiar los campos y ocultar el resultado
            FechaHora = string.Empty;
            Personas.NombresApellidos = string.Empty;
            Personas.Identificador = string.Empty;
            Personas.Direccion = string.Empty;
            Personas.Email = string.Empty;
            Personas.Nuevo = false;
            Personas.Rural = false;
            Personas.Telefono = string.Empty;
            Titulo.ClavePredia = string.Empty;
            Titulo.FechaEmision = string.Empty;
            Titulo.Year = string.Empty;
            Titulo.ValorTitulo = string.Empty;
            Titulo.ValorEmision = string.Empty;
            ValorB = string.Empty;
            SelectedOption = string.Empty;
            Componente.NombreMiembro = string.Empty;
            listRubro.Clear();
            listComp.Clear();
            MostrarTabla = false;
        }

        private async Task SubmitFormAsync()
        {
            IsLoading = true;
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var json = await httpClient.GetStringAsync($"https://api.gadbolivar.gob.ec/api/public/deudas?criterio=CE&valor={ValorB}");

                    object? task = JsonConvert.DeserializeObject(json.ToString());
                    JObject obj = JObject.Parse(task!.ToString()!);
                    JValue _fechaHora = (JValue)obj["fechaHora"]!;
                    JArray _persona = (JArray)obj["personas"]!;
                    JArray _componentes = (JArray)obj["componentes"]!;
                    FechaHora = (string)obj["fechaHora"]!;
                    foreach (var item in _persona)
                    {
                        Personas = new Personas
                        {
                            NombresApellidos = (string)item.SelectToken("apellidosNombres")!,
                            Identificador = (string)item.SelectToken("identificador")!,
                            Direccion = (string)item.SelectToken("direccion")!,
                            Email = (string)item.SelectToken("email")!,
                            Id = (int)item.SelectToken("id")!,
                            Nuevo = (bool)item.SelectToken("nuevo")!,
                            Rural = (bool)item.SelectToken("rural")!,
                            Telefono = (string)item.SelectToken("telefono")!,
                        };
                    }

                    foreach (var itemComp in _componentes)
                    {
                        Componente = new Componente
                        {
                            NombreMiembro = (string)itemComp.SelectToken("nombreMiembro")!,
                            Valor = (decimal)itemComp.SelectToken("valor")!,
                        };
                        listComp.Add(Componente);
                    }

                    if (_componentes!.Count > 0)
                    {
                        foreach (var y in _componentes)
                        {
                            JArray _titulos = (JArray)y["titulos"]!;

                            foreach (var i in _titulos)
                            {
                                Titulo = new Titulo
                                {
                                    ClavePredia = (string)i.SelectToken("clavePredial")!,
                                    FechaEmision = (string)i.SelectToken("fechaEmision")!,
                                    Year = (string)i.SelectToken("year")!,
                                    ValorNeto = (string)i.SelectToken("valorNeto")!,
                                    ValorTitulo = (string)i.SelectToken("valorTitulo")!,
                                    ValorEmision = (string)i.SelectToken("valorEmision")!,
                                };

                                JArray _rubros = (JArray)i["rubros"]!;
                                JObject _intereses = (JObject)i["interes"]!;
                                JValue nombreIntereses = (JValue)_intereses["nombreRubro"]!;
                                JValue valorIntereses = (JValue)_intereses["valor"]!;
                                JObject _emision = (JObject)i["emision"]!;
                                JValue nombreEmision = (JValue)_emision["nombreRubro"]!;
                                JValue valorEmision = (JValue)_emision["total"]!;
                                foreach (var item in _rubros)
                                {
                                    Rubro = new Rubro
                                    {
                                        NombreRubro = (string)item.SelectToken("nombreRubro")! + " Periodo: " + (string)i.SelectToken("periodo")!,
                                        Valor = (decimal)item.SelectToken("valor")!,
                                        ValorTotalInteres = (decimal)_intereses.SelectToken("total")!,
                                        GastosAdministrativos = (decimal)_emision.SelectToken("total")!,
                                        Total = (decimal)item.SelectToken("total")!,

                                    };
                                    listRubro.Add(Rubro);
                                }
                            }
                        }
                    }


                    else
                    {
                        // Manejar la situación en la que no se recibe ninguna respuesta
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            IsLoading = false;
        }
    }
}
