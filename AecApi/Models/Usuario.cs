using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AecApi.Models
{
    public class Usuarios
    {
        [JsonIgnore]
        public int? Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Nome { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Usuario { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Senha { get; set;}
    }
}
