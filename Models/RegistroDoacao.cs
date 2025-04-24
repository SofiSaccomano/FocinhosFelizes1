namespace FocinhosFelizes1.Models
{
    public class RegistroDoacao
    {
        public Guid RegistroDoacaoId { get; set; }

        public Guid ProdutosId { get; set; }
        public Produtos? Produtos { get; set; }

        public Guid DoadorId { get; set; }
        public Doador? Doador { get; set; }

        public DateTime? ValidadeProduto { get; set; }
        public DateTime? DataDoacao { get; set; }
    }
}
