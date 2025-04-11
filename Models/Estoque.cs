namespace FocinhosFelizes1.Models
{
    public class Estoque
    {
        public Guid EstoqueId { get; set; }

        public Guid ProdutosId { get; set; }
        public Produtos? Produtos { get; set; }

        public string QtdEstoque { get; set; }

    }
}
