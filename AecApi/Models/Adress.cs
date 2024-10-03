using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AecApi.Models
{
    [Table("Enderecos")]
    public class Adress
    {
        [JsonIgnore]
        public int Id { get; set; }

        public string? Cep { get; set; }

        public string? Logradouro { get; set;}

        public string? Complemento { get; set; }

        public string? Bairro { get; set; }

        public string? Cidade { get; set; }

        public string? UF { get; set; }

        public string? Numero { get; set; }  

        public int UsuarioID { get; set; }
    }
}
