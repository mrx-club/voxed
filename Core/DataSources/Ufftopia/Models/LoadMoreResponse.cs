using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataSources.Ufftopia.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class Media
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("vistaPrevia")]
        public string VistaPrevia { get; set; }

        [JsonProperty("vistaPreviaOtroMedios")]
        public string VistaPreviaOtroMedios { get; set; }

        [JsonProperty("vistaPreviaCuadrado")]
        public string VistaPreviaCuadrado { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("tipo")]
        public int Tipo { get; set; }

        [JsonProperty("esGif")]
        public bool EsGif { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("creacion")]
        public DateTime Creacion { get; set; }
    }

    public class LoadMoreResponse
    {
        [JsonProperty("cantidadComentarios")]
        public int CantidadComentarios { get; set; }

        [JsonProperty("nuevo")]
        public bool Nuevo { get; set; }

        [JsonProperty("titulo")]
        public string Titulo { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("sticky")]
        public int Sticky { get; set; }

        [JsonProperty("bump")]
        public DateTime Bump { get; set; }

        [JsonProperty("categoriaId")]
        public int CategoriaId { get; set; }

        [JsonProperty("contenido")]
        public string Contenido { get; set; }

        [JsonProperty("creacion")]
        public DateTime Creacion { get; set; }

        [JsonProperty("media")]
        public Media Media { get; set; }

        [JsonProperty("thumbnail")]
        public object Thumbnail { get; set; }

        [JsonProperty("estado")]
        public int Estado { get; set; }

        [JsonProperty("rango")]
        public int Rango { get; set; }

        [JsonProperty("nombre")]
        public object Nombre { get; set; }

        [JsonProperty("dados")]
        public bool Dados { get; set; }

        [JsonProperty("encuesta")]
        public bool Encuesta { get; set; }

        [JsonProperty("encuestaData")]
        public object EncuestaData { get; set; }

        [JsonProperty("idUnico")]
        public bool IdUnico { get; set; }

        [JsonProperty("vistas")]
        public int Vistas { get; set; }

        [JsonProperty("bandera")]
        public bool Bandera { get; set; }

        [JsonProperty("face")]
        public bool Face { get; set; }

        [JsonProperty("colors")]
        public bool Colors { get; set; }

        [JsonProperty("reset200")]
        public bool Reset200 { get; set; }

        [JsonProperty("nuevoUsuario")]
        public bool NuevoUsuario { get; set; }

        [JsonProperty("usuarioId")]
        public object UsuarioId { get; set; }

        [JsonProperty("historial")]
        public bool Historial { get; set; }
    }


}
