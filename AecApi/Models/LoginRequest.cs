using System.ComponentModel.DataAnnotations;

namespace AecApi.Models
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string? Usuario { get; set; }

        [Required]
        public string? Senha { get; set; }
    }
}
