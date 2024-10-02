using System.ComponentModel.DataAnnotations.Schema;

namespace AecApi.Models
{
    [Table("Enderecos")]
    public class Adress
    {
        public string Id { get; set; }

        public string CEP { get; set; }

        public string lougradouro { get; set;}

        public string complemento { get; set; }

        public string bairro { get; set; }

        public string cidade { get; set; }

        public string uf { get; set; }

        public string numero { get; set; }  

        public Usuario usuario { get; set; }
    }
}
