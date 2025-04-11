using System.ComponentModel.DataAnnotations;

namespace FocinhosFelizes1.Models
{
    public class Doador
    {
        public Guid DoadorId { get; set; }
        public string NomeDoador { get; set; }
        public string CPF { get; set; }
        public string Celular { get; set; }
    }
}
